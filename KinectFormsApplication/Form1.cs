using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.Interaction;
using System.Runtime.InteropServices;
using Microsoft.Kinect.Toolkit.Controls; // ハンドカーソル利用のため
using System.IO;

namespace KinectFormsApplication
{
    public partial class Form1 : Form
    {
        //右手座標の保存にあたり，color image 上および skeleton 上の座標の両方を保存したい
        class HandPoint
        {
            public ColorImagePoint colorImagePoint;
            public SkeletonPoint skeletonPoint;

            public HandPoint(ColorImagePoint c, SkeletonPoint s)
            {
                colorImagePoint = c;
                skeletonPoint = s;
            } 
        }

        readonly int Bgr32BytesPerPixel = 4; //ピクセルあたりのバイト数
        InteractionStream interactionStream;
        InteractionHandEventType handEventType = InteractionHandEventType.GripRelease; //初期状態＝パー

        Joint jointHandRight;

        //描画先とするImageオブジェクトを作成する
        Bitmap canvas;

        int EventInterval = 10; //10[ms] 毎にタイマーを動かす
        int countColorFrame = 0;

        Boolean isRecording = false;    //入力を記録中か否かを表すフラグ

        string saveFileName = "";   //座標列を保存するファイル名

        //右手座標を保存するためのリスト
        List<HandPoint> rightHandCoordinates = new List<HandPoint>();

        public Form1()
        {
            InitializeComponent();

            //手書き用
            canvas = new Bitmap(pictureBoxHand.Width, pictureBoxHand.Height);

            //タイマー
            eventTimer.Interval = EventInterval; // interval
            eventTimer.Tick += new System.EventHandler(eventTimer_Tick);
            eventTimer.Enabled = true;

            try
            {
                //Kinect の接続を確認
                if (KinectSensor.KinectSensors.Count == 0)
                {
                    throw new Exception("Kinect を接続して下さい");
                }

                //Kinect の動作開始
                StartKinect(KinectSensor.KinectSensors[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //2014.10.20 追加
         public class NewInteractionClient : IInteractionClient
        {
            public InteractionInfo GetInteractionInfoAtLocation(int skeletonTrackId, InteractionHandType handType, double x, double y)
            {
                var summarize = new InteractionInfo();
                summarize.IsGripTarget = true;
                summarize.IsPressTarget = true;
                summarize.PressAttractionPointX = 0.5;
                summarize.PressAttractionPointY = 0.5;
                summarize.PressTargetControlId = 1;
                return summarize;
            }
        }

        /// <summary>
        /// Kinect の動作を開始する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartKinect(KinectSensor kinect)
        {
            //kinect.ColorStream.CameraSettings.FrameInterval = 1000;
            //kinect.ColorStream.CameraSettings.AutoExposure = false;

            kinect.ColorStream.Enable();
            kinect.DepthStream.Enable();
            kinect.SkeletonStream.Enable();
            //kinect.AllFramesReady += new EventHandler<AllFramesReadyEventArgs>(kinect_AllFramesReady);

            kinect.Start();

            //インタラクションライブラリの初期化 (2014.10.20 追加)
            interactionStream = new InteractionStream(kinect, new NewInteractionClient());
            interactionStream.InteractionFrameReady += new EventHandler<InteractionFrameReadyEventArgs>(interactionstream_InteractionFrameReady);
            //interactionStream.InteractionFrameReady += interactionstream_InteractionFrameReady;

            //depth モード / near モードの切り替え
            comboBoxRange.Items.Clear();
            foreach (var range in Enum.GetValues(typeof(DepthRange)))
            {
                comboBoxRange.Items.Add(range.ToString());
            }

            comboBoxRange.SelectedIndex = 0;

            //KinectRegion の利用（ハンドカーソル）(2014.10.22)
            //KinectRegion.AddHandPointerPressHandler((System.Windows.UIElement)this.button1, OnHandPointerPress);
        }

        private void StopKinect(KinectSensor kinect)
        {
            if (kinect != null)
            {
                if (kinect.IsRunning)
                {
                    kinect.AllFramesReady -= kinect_AllFramesReady;

                    kinect.Stop();
                    kinect.Dispose();

                    pictureBoxRgb.Image = null;
                    //pictureBoxDepth.Image = null;
                    pictureBoxHand.BackColor = Color.Green;
                }
            }
        }

        //取り込みフレームレート調整のため Timer を使うようにしたから，
        //以下の kinect_AllFramesReady() を使わないことにした。(2014.11.21)

        /// <summary>
        /// RGBカメラ，距離カメラ，骨格のフレーム更新イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void kinect_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {

            try
            {
                KinectSensor kinect = sender as KinectSensor;
                if (kinect == null)
                {
                    return;
                }
                String kinectInfo = "kinect.status : " + kinect.Status + System.Environment.NewLine
                    +"ColorStream.Format : " + kinect.ColorStream.Format + System.Environment.NewLine
                    + "CameraSettings.FrameInterval : " + kinect.ColorStream.CameraSettings.FrameInterval + System.Environment.NewLine
                    + "CameraSettings.MinFrameInterval : " + kinect.ColorStream.CameraSettings.MinFrameInterval + System.Environment.NewLine
                    +"CameraSettings.MaxFrameInterval : " + kinect.ColorStream.CameraSettings.MaxFrameInterval;
                kinectInformationTextBox.Text = kinectInfo;

                //現在の日付を利用して bitmap を書き込むファイル名を決定
                DateTime dt = System.DateTime.Now;
                string fileName = String.Format("{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}{6:000}.jpg",
                    dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

                //RGBカメラのフレームデータを取得
                using (ColorImageFrame colorFrame = e.OpenColorImageFrame())
                {
                    if (colorFrame != null)
                    {
                        frameCounterTextBox.Text = countColorFrame.ToString();
                        countColorFrame += 1;

                        //RGBカメラのピクセルデータの取得
                        byte[] colorPixel = new byte[colorFrame.PixelDataLength];
                        colorFrame.CopyPixelDataTo(colorPixel);

                        //ピクセルデータをビットマップに変換
                        Bitmap bitmap = new Bitmap(kinect.ColorStream.FrameWidth, kinect.ColorStream.FrameHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                        Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                        Marshal.Copy(colorPixel, 0, data.Scan0, colorPixel.Length);
                        bitmap.UnlockBits(data);

                        pictureBoxRgb.Image = bitmap;

                        //ファイルへの書き出し (2014.10.20 コメントアウト）
                        //bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

                //距離カメラのフレームデータの取得
                using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
                {
                    if (depthFrame != null)
                    {
                        // 2014.10.20 追加
                        interactionStream.ProcessDepth(depthFrame.GetRawPixelData(), depthFrame.Timestamp);

                        //距離データの画像化
                        /*
                        Bitmap bitmap = new Bitmap(kinect.DepthStream.FrameWidth, kinect.DepthStream.FrameHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                        Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                        System.Drawing.Imaging.BitmapData data = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                        byte[] gray = ConvertDepthColor(kinect, depthFrame);
                        Marshal.Copy(gray, 0, data.Scan0, gray.Length);
                        bitmap.UnlockBits(data);

                        pictureBoxDepth.Image = bitmap;
                         */
                    }
                }

                //スケルトンフレームの取得
                using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
                {
                    if (skeletonFrame != null)
                    {
                        const int R = 5;
                        Graphics g = Graphics.FromImage(pictureBoxRgb.Image);
                        Graphics gHand = Graphics.FromImage(canvas);

                        //スケルトンのデータの取得
                        Skeleton[] skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                        skeletonFrame.CopySkeletonDataTo(skeletons);

                        // 2014.10.20 追加
                        interactionStream.ProcessSkeleton(skeletons, kinect.AccelerometerGetCurrentReading(), skeletonFrame.Timestamp);

                        //トラッキングされているスケルトンのジョイントを描画する
                        foreach (var skeleton in skeletons)
                        {
                            if (skeleton.TrackingState != SkeletonTrackingState.Tracked) continue;

                            //右手ジョイントの位置を保存
                            jointHandRight = skeleton.Joints[JointType.HandRight];

                            //ジョイントの描画
                            foreach (Joint joint in skeleton.Joints)
                            {
                                if (joint.TrackingState != JointTrackingState.Tracked) continue;


                                //スケルトンの座標を「RGBカメラの座標」に変換して円を描く
                                ColorImagePoint point = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(joint.Position, kinect.ColorStream.Format);
                                g.DrawEllipse(new Pen(Brushes.Red), new Rectangle(point.X - R, point.Y - R, R * 2, R * 2));
                            }
                        }

                        if(handEventType == InteractionHandEventType.Grip){
                            ColorImagePoint point = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(jointHandRight.Position, kinect.ColorStream.Format);
                            gHand.DrawEllipse(new Pen(Brushes.Red), new Rectangle(point.X, point.Y, 10, 10)); 
                                        
                            //リソースを解放する
                            gHand.Dispose();
                            //PictureBox1に表示する
                            pictureBoxHand.Image = canvas;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void interactionstream_InteractionFrameReady(object sender, InteractionFrameReadyEventArgs e)
        {
            //sender から値を取ると null になる
            /*
            KinectSensor kinect = sender as KinectSensor;
            if (kinect == null){
                Console.WriteLine("kinect is NULL");
                return;
            }
            */
            KinectSensor kinect = KinectSensor.KinectSensors[0];

            using (var interactionFrame = e.OpenInteractionFrame())
            {
                if(interactionFrame != null)
                {
                    var userInfos = new UserInfo[InteractionFrame.UserInfoArrayLength];
                    interactionFrame.CopyInteractionDataTo(userInfos);

                    foreach (var user in userInfos)
                    {
                        if (user.SkeletonTrackingId != 0)
                        {
                            foreach (var hand in user.HandPointers)
                            {
                                //右手座標の表示
                                /*
                                if (hand.HandEventType != 0 && hand.HandType == InteractionHandType.Right)
                                {
                                    rawXtextBox.Text = String.Format("{0:0.000}", hand.RawX);
                                    rawYtextBox.Text = String.Format("{0:0.000}", hand.RawY);
                                }
                                */
                                

                                //Console.WriteLine(hand.HandType); // output : Left or Right
                                //Console.WriteLine(hand.HandEventType); //output : None , Grid or GripRelease
                                if (hand.HandEventType != 0 && hand.HandType == InteractionHandType.Right)
                                {
                                    handConditionTextBox.Text = hand.HandType.ToString() + " : " + hand.HandEventType.ToString();


                                    handEventType = hand.HandEventType;

                                }
                               
                            }
                        }
                    }
                }
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>距離データを画像データに変換する
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private byte[] ConvertDepthColor(KinectSensor kinect, DepthImageFrame depthFrame)
        {
            ColorImageStream colorStream = kinect.ColorStream;
            DepthImageStream depthStream = kinect.DepthStream;

            //距離カメラのピクセル毎のデータを取得
            short[] depthPixel = new short[depthFrame.PixelDataLength];
            DepthImagePixel[] depthImagePixel = new DepthImagePixel[depthFrame.PixelDataLength];
            depthFrame.CopyPixelDataTo(depthPixel);

            //距離カメラの座標に対応するRGBカメラの座標を取得
            ColorImagePoint[] colorPoint = new ColorImagePoint[depthFrame.PixelDataLength];
            kinect.CoordinateMapper.MapDepthFrameToColorFrame(depthStream.Format, depthImagePixel, colorStream.Format, colorPoint);
            //kinect.MapDepthFrameToColorFrame(depthStream.Format, depthPixel, colorStream.Format, colorPoint);

            byte[] depthColor = new byte[depthFrame.PixelDataLength * Bgr32BytesPerPixel];
            for(int index = 0; index < depthPixel.Length; index++){
                //距離カメラのデータからプレイヤーIDと距離を取得する
                int player = depthPixel[index] & DepthImageFrame.PlayerIndexBitmask;
                int distance = depthPixel[index] >> DepthImageFrame.PlayerIndexBitmaskWidth;

                //変換した結果がフレームサイズを超える場合があるため，小さい方を使う
                int x = Math.Min(colorPoint[index].X, colorStream.FrameWidth - 1);
                int y = Math.Min(colorPoint[index].Y, colorStream.FrameHeight - 1);
                int colorIndex = ((y * depthFrame.Width) + x) * Bgr32BytesPerPixel;

                //プレイヤーがいるピクセルの場合
                if(player != 0){
                    depthColor[colorIndex] = 255;
                    depthColor[colorIndex + 1] = 255;
                    depthColor[colorIndex + 2] = 255;
                }
                else
                {
                    //サポート外 (0-40cm)
                    if (distance == depthStream.UnknownDepth)
                    {
                        depthColor[colorIndex] = 0;
                        depthColor[colorIndex + 1] = 0;
                        depthColor[colorIndex + 2] = 255;
                    }
                    //近すぎ (40-80cm)
                    else if (distance == depthStream.TooNearDepth)
                    {
                        depthColor[colorIndex] = 0;
                        depthColor[colorIndex + 1] = 255;
                        depthColor[colorIndex + 2] = 0;
                    }
                    //遠すぎ (3m for Near, 4m for Default - 8m)
                    else if (distance == depthStream.TooFarDepth)
                    {
                        depthColor[colorIndex] = 255;
                        depthColor[colorIndex + 1] = 0;
                        depthColor[colorIndex + 2] = 0;
                    }
                    //有効な距離データ
                    else
                    {
                        depthColor[colorIndex] = 0;
                        depthColor[colorIndex + 1] = 255;
                        depthColor[colorIndex + 2] = 255;
                    }
                }
            }

            return depthColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setSaveFileName();
            labelSaveFileName.Text = saveFileName;

            linkLabelMoreInfo.Text = "Click here to get more info.";
            linkLabelMoreInfo.Links.Add(6, 4, "www.amazon.com");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopKinect(KinectSensor.KinectSensors[0]);
        }

        private void comboBoxRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KinectSensor.KinectSensors[0].DepthStream.Range = (DepthRange)comboBoxRange.SelectedIndex;
            }
            catch (Exception)
            {
                comboBoxRange.SelectedIndex = 0;
            }
        }

        private void erasePictureBoxHand()
        {
            Graphics g = Graphics.FromImage(canvas);
            g.Clear(Color.White);
            pictureBoxHand.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erasePictureBoxHand();
        }

        //KinectRegion の利用（ハンドカーソル）(2014.10.22)
        private void OnHandPointerPress(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }

        private void eventTimer_Tick(object sender, EventArgs e)
        {
            KinectSensor kinect = KinectSensor.KinectSensors[0];

            String kinectInfo = "kinect.status : " + kinect.Status + System.Environment.NewLine
                + "ColorStream.Format : " + kinect.ColorStream.Format + System.Environment.NewLine
                + "CameraSettings.FrameInterval : " + kinect.ColorStream.CameraSettings.FrameInterval + System.Environment.NewLine
                + "CameraSettings.MinFrameInterval : " + kinect.ColorStream.CameraSettings.MinFrameInterval + System.Environment.NewLine
                + "CameraSettings.MaxFrameInterval : " + kinect.ColorStream.CameraSettings.MaxFrameInterval;
            kinectInformationTextBox.Text = kinectInfo;

            using (ColorImageFrame colorFrame = kinect.ColorStream.OpenNextFrame(1))
            {
                if (colorFrame != null)
                {
                    frameCounterTextBox.Text = countColorFrame.ToString();
                    countColorFrame += 1;

                    //RGBカメラのピクセルデータの取得
                    byte[] colorPixel = new byte[colorFrame.PixelDataLength];
                    colorFrame.CopyPixelDataTo(colorPixel);

                    //ピクセルデータをビットマップに変換
                    Bitmap bitmap = new Bitmap(kinect.ColorStream.FrameWidth, kinect.ColorStream.FrameHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

                    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                    System.Drawing.Imaging.BitmapData data = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                    Marshal.Copy(colorPixel, 0, data.Scan0, colorPixel.Length);
                    bitmap.UnlockBits(data);

                    pictureBoxRgb.Image = bitmap;

                    colorFrame.Dispose();
                }
            }

            //距離カメラのフレームデータの取得
            using (DepthImageFrame depthFrame = kinect.DepthStream.OpenNextFrame(1))
            {
                if (depthFrame != null)
                {
                    // InteractionStream に深度情報を流しこむ (2014.10.20 追加)
                    interactionStream.ProcessDepth(depthFrame.GetRawPixelData(), depthFrame.Timestamp);

                    depthFrame.Dispose();
                }
            }

            //スケルトンフレームの取得
            using (SkeletonFrame skeletonFrame = kinect.SkeletonStream.OpenNextFrame(1))
            {
                if (skeletonFrame != null)
                {
                    const int R = 5;
                    Graphics g = Graphics.FromImage(pictureBoxRgb.Image);
                    Graphics gHand = Graphics.FromImage(canvas);

                    //スケルトンのデータの取得
                    Skeleton[] skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);

                    // InteractionStream にスケルトン情報を流しこむ (2014.10.20 追加)
                    interactionStream.ProcessSkeleton(skeletons, kinect.AccelerometerGetCurrentReading(), skeletonFrame.Timestamp);

                    //トラッキングされているスケルトンのジョイントを描画する
                    foreach (var skeleton in skeletons)
                    {
                     if (skeleton.TrackingState != SkeletonTrackingState.Tracked) continue;

                        //右手ジョイントの位置を保存
                        jointHandRight = skeleton.Joints[JointType.HandRight];

                        //右手座標の表示
                        ColorImagePoint rightHandPoint = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(jointHandRight.Position, kinect.ColorStream.Format);
                        SkeletonPointXtextBox.Text = String.Format("{0:0.000}", jointHandRight.Position.X);
                        SkeletonPointYtextBox.Text = String.Format("{0:0.000}", jointHandRight.Position.Y);
                        SkeletonPointZtextBox.Text = String.Format("{0:0.000}", jointHandRight.Position.Z);

                        rawXtextBox.Text = String.Format("{0:000}", rightHandPoint.X);
                        rawYtextBox.Text = String.Format("{0:000}", rightHandPoint.Y);


                        //ジョイントの描画
                        foreach (Joint joint in skeleton.Joints)
                        {
                            if (joint.TrackingState != JointTrackingState.Tracked) continue;

                            //スケルトンの座標を「RGBカメラの座標」に変換して円を描く
                            ColorImagePoint point = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(joint.Position, kinect.ColorStream.Format);
                            g.DrawEllipse(new Pen(Brushes.Red), new Rectangle(point.X - R, point.Y - R, R * 2, R * 2));
                        }
                    }

                    if(isRecording && handEventType == InteractionHandEventType.Grip){
                        ColorImagePoint point = kinect.CoordinateMapper.MapSkeletonPointToColorPoint(jointHandRight.Position, kinect.ColorStream.Format);

                        //countColorFrame は EventInterval [ms] 毎に１ずつ増加するため
                        //乗算によって正確な ms 単位の経過時間が得られる。
                        //以下では 10[ms] 毎に座標を記録する。
                        long t = countColorFrame * EventInterval;
                        if (t % 10 == 0)
                        {
                            //rightHandCoordinates.Add(point);
                            rightHandCoordinates.Add(new HandPoint(point, jointHandRight.Position));
                        }

                        gHand.DrawEllipse(new Pen(Brushes.Red), new Rectangle(point.X, point.Y, 10, 10)); 

                        //リソースを解放する
                        gHand.Dispose();
                        //PictureBox1に表示する
                        pictureBoxHand.Image = canvas;
                    }

                    skeletonFrame.Dispose();
                }
            }
        }

        //アプリケーションの終了
        private void finishButton_Click(object sender, EventArgs e)
        {
            StopKinect(KinectSensor.KinectSensors[0]);

            //アプリケーションの終了
            this.Close();
        }

        private string getCurrentDateTime()
        {
            string dt = String.Format("{0:yyyyMMdd}_{1:hhmmss}", System.DateTime.Today, System.DateTime.Now);
            return dt;
        }

        private void setSaveFileName()
        {
            string prefix = textBoxSaveFileNamePrefix.Text;
            saveFileName = prefix + "_" + getCurrentDateTime() + ".log";
        }

        //入力開始ボタン
        private void buttonStartInput_Click(object sender, EventArgs e)
        {
            setSaveFileName();
            labelSaveFileName.Text = saveFileName;

            isRecording = true;
            buttonStartInput.Enabled = false;
            buttonFinishInput.Enabled = true;
            buttonAbortInput.Enabled = true;
        }

        //入力終了ボタン
        private void buttonFinishInput_Click(object sender, EventArgs e)
        {
            //記録した右手座標をコンソールに出力（とりあえず）
            StreamWriter sw = new StreamWriter(new FileStream(saveFileName, FileMode.Create));
            foreach (HandPoint pt in rightHandCoordinates)
            {
                //（注意）pt のうち ColorImage が従う座標系の縦軸は「下向きに正」であるため，その向きを反転する
                //（メモ）DPマッチングにおいてベクトルを扱う際，この変換が必要となる
                sw.WriteLine("{0,0:000} {1,0:000} {2,0:0.000} {3,0:0.000} {4,0:0.000}",
                    pt.colorImagePoint.X, pictureBoxRgb.Height - pt.colorImagePoint.Y,
                    pt.skeletonPoint.X, pt.skeletonPoint.Y, pt.skeletonPoint.Z);
                //System.Console.WriteLine("(%d, %d)", pt.X, pt.Y);
            }
            sw.Close();

            //保存完了メッセージを表示するメッセージボックス
            // http://dobon.net/vb/dotnet/form/msgbox.html
            string msg = "ファイル " + saveFileName + " に保存しました"; 
            MessageBox.Show(msg, "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //筆跡を描画する pictureBox のクリア
            erasePictureBoxHand();

            //右手座標列を保存しているリストを空にする
            rightHandCoordinates.Clear();

            isRecording = false;
            buttonStartInput.Enabled = true;
            buttonFinishInput.Enabled = false;
            buttonAbortInput.Enabled = false;

        }

        //入力中断ボタン
        private void buttonAbortInput_Click(object sender, EventArgs e)
        {
            rightHandCoordinates.Clear();

            //筆跡を描画する pictureBox のクリア
            erasePictureBoxHand();

            //右手座標列を保存しているリストを空にする
            rightHandCoordinates.Clear();

            isRecording = false;
            buttonStartInput.Enabled = true;
            buttonFinishInput.Enabled = false;
            buttonAbortInput.Enabled = false;
        }

        private void textBoxSaveFileNamePrefix_Changed(object sender, EventArgs e)
        {
            setSaveFileName();
            labelSaveFileName.Text = saveFileName;
        }

        private void linkLabelMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

    }
}
