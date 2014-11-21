using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; //for 矢印ペン
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace drawBrushstroke
{
    public partial class drawBrushstrokeForm : Form
    {
        Bitmap canvas, canvasVector;

        public drawBrushstrokeForm()
        {
            InitializeComponent();

            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvasVector = new Bitmap(pictureBoxVector.Width, pictureBoxVector.Height);
        }

        private void drawBrushstrokeForm_Load(object sender, EventArgs e)
        {
 
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                readFile(openFileDialog.FileName);
            }
        }

        private void readFile(string filename)
        {
            Graphics g = Graphics.FromImage(canvas);
            List<Point> pointList = new List<Point>();

            //string filename = "C:\\Users\\muto\\Source\\Repos\\KinectFormsApplication\\KinectFormsApplication\\bin\\x86\\Debug\\out.txt";
            //string filename = "out.txt";

            string line = "";
            StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open));
            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(' ');
                int x = int.Parse(data[0]);
                int y = int.Parse(data[1]);
                System.Console.WriteLine(x + " " + y);
                pointList.Add(new Point(x, y));
            }
            sr.Close();

            //座標をプロット
            drawImage(pointList);

            //ベクトル情報をプロット
            drawVectorImage(pointList);
        }

        private void drawImage(List<Point> pointList)
        {
            Graphics g = Graphics.FromImage(canvas);
            int R = 5;

            g.Clear(Color.White);

            //string filename = "C:\\Users\\muto\\Source\\Repos\\KinectFormsApplication\\KinectFormsApplication\\bin\\x86\\Debug\\out.txt";
            //string filename = "out.txt";
            foreach (var point in pointList)
            {
                g.DrawEllipse(new Pen(Brushes.Red), new Rectangle(point.X - R, point.Y - R, R * 2, R * 2));

                pictureBox1.Image = canvas;

            }
        }

        private double cosine(Point a, Point b)
        {
            double dotProduct = a.X * b.X + a.Y * b.Y;
            double sizeA = Math.Sqrt(a.X * a.X + a.Y * a.Y);
            double sizeB = Math.Sqrt(b.X * b.X + b.Y * b.Y);

            return dotProduct / (sizeA * sizeB);
        }

        private void drawVectorImage(List<Point> pointList)
        {
            Graphics g = Graphics.FromImage(canvasVector);

            g.Clear(Color.White);

            //矢印ペンを作る
            // http://dobon.net/vb/dotnet/graphics/drawarrow.html
            Pen arrowPen = new Pen(Color.Red, 1); //幅=1
            arrowPen.EndCap = LineCap.ArrowAnchor; //終点に矢印を付ける

            //最近傍のベクトルの候補
            Point[] bases = { new Point(1, 0), new Point(1,1), new Point(0,1), new Point(-1,1), new Point(-1, 0), new Point(-1,-1), new Point(0,-1), new Point(1,-1)};

            string sequence = "";

            //点の列からベクトル列および「ベクトルの向きに対応する文字列」を作る
            for (int i = 0; i < pointList.Count() - 1; i++)
            {
                Point begin = pointList.ElementAt(i);
                Point end = pointList.ElementAt(i+1);
                Point vec = new Point(end.X - begin.X, end.Y - begin.Y);

                int bestBase = 0;
                double bestCosine = cosine(vec, bases[0]);
                for (int j = 1; j < 8; j++)
                {
                    double c = cosine(vec, bases[j]);
                    if (c > bestCosine)
                    {
                        bestBase = j;
                        bestCosine = c;
                    }
                }

                //矢印の描画
                Point endPoint = new Point(begin.X + 8*bases[bestBase].X, begin.Y + 8*bases[bestBase].Y);
                g.DrawLine(arrowPen, begin, endPoint);

                pictureBoxVector.Image = canvasVector;

                //「ベクトルの向きに対応する文字列」の生成
                sequence += bestBase.ToString();
                /*
                switch (bestBase)
                {
                    case 0: sequence += 'a'; break;
                    case 1: sequence += 'b'; break;
                    case 2: sequence += 'c'; break;
                    case 3: sequence += 'd'; break;
                    case 4: sequence += 'e'; break;
                    case 5: sequence += 'f'; break;
                    case 6: sequence += 'g'; break;
                    case 7: sequence += 'h'; break;
                }
                */
            }

            textBox1.Text = sequence;
        }
    }
}
