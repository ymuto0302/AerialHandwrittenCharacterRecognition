namespace KinectFormsApplication
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxRgb = new System.Windows.Forms.PictureBox();
            this.comboBoxRange = new System.Windows.Forms.ComboBox();
            this.handConditionTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBoxHand = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.kinectInformationTextBox = new System.Windows.Forms.TextBox();
            this.eventTimer = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.frameCounterTextBox = new System.Windows.Forms.TextBox();
            this.finishButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rawXtextBox = new System.Windows.Forms.TextBox();
            this.rawYtextBox = new System.Windows.Forms.TextBox();
            this.buttonStartInput = new System.Windows.Forms.Button();
            this.buttonFinishInput = new System.Windows.Forms.Button();
            this.buttonAbortInput = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelSaveFileName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSaveFileNamePrefix = new System.Windows.Forms.TextBox();
            this.linkLabelMoreInfo = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.SkeletonPointXtextBox = new System.Windows.Forms.TextBox();
            this.SkeletonPointYtextBox = new System.Windows.Forms.TextBox();
            this.SkeletonPointZtextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRgb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRgb
            // 
            this.pictureBoxRgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRgb.Location = new System.Drawing.Point(12, 104);
            this.pictureBoxRgb.Name = "pictureBoxRgb";
            this.pictureBoxRgb.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxRgb.TabIndex = 0;
            this.pictureBoxRgb.TabStop = false;
            // 
            // comboBoxRange
            // 
            this.comboBoxRange.FormattingEnabled = true;
            this.comboBoxRange.Location = new System.Drawing.Point(12, 27);
            this.comboBoxRange.Name = "comboBoxRange";
            this.comboBoxRange.Size = new System.Drawing.Size(121, 20);
            this.comboBoxRange.TabIndex = 2;
            this.comboBoxRange.SelectedIndexChanged += new System.EventHandler(this.comboBoxRange_SelectedIndexChanged);
            // 
            // handConditionTextBox
            // 
            this.handConditionTextBox.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.handConditionTextBox.ForeColor = System.Drawing.Color.Red;
            this.handConditionTextBox.Location = new System.Drawing.Point(218, 27);
            this.handConditionTextBox.Multiline = false;
            this.handConditionTextBox.Name = "handConditionTextBox";
            this.handConditionTextBox.Size = new System.Drawing.Size(276, 27);
            this.handConditionTextBox.TabIndex = 3;
            this.handConditionTextBox.Text = "";
            // 
            // pictureBoxHand
            // 
            this.pictureBoxHand.BackColor = System.Drawing.Color.White;
            this.pictureBoxHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHand.Location = new System.Drawing.Point(418, 104);
            this.pictureBoxHand.Name = "pictureBoxHand";
            this.pictureBoxHand.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxHand.TabIndex = 4;
            this.pictureBoxHand.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(831, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "描画領域クリア";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "Right Hand";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Depth camera mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 512);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Information for Kinect sensor";
            // 
            // kinectInformationTextBox
            // 
            this.kinectInformationTextBox.Location = new System.Drawing.Point(12, 527);
            this.kinectInformationTextBox.Multiline = true;
            this.kinectInformationTextBox.Name = "kinectInformationTextBox";
            this.kinectInformationTextBox.Size = new System.Drawing.Size(410, 75);
            this.kinectInformationTextBox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(433, 512);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "frame counter";
            // 
            // frameCounterTextBox
            // 
            this.frameCounterTextBox.Location = new System.Drawing.Point(513, 509);
            this.frameCounterTextBox.Name = "frameCounterTextBox";
            this.frameCounterTextBox.Size = new System.Drawing.Size(100, 19);
            this.frameCounterTextBox.TabIndex = 12;
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(832, 93);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(115, 22);
            this.finishButton.TabIndex = 13;
            this.finishButton.Text = "終了";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y";
            // 
            // rawXtextBox
            // 
            this.rawXtextBox.Location = new System.Drawing.Point(274, 81);
            this.rawXtextBox.Name = "rawXtextBox";
            this.rawXtextBox.Size = new System.Drawing.Size(50, 19);
            this.rawXtextBox.TabIndex = 2;
            // 
            // rawYtextBox
            // 
            this.rawYtextBox.Location = new System.Drawing.Point(357, 81);
            this.rawYtextBox.Name = "rawYtextBox";
            this.rawYtextBox.Size = new System.Drawing.Size(50, 19);
            this.rawYtextBox.TabIndex = 3;
            // 
            // buttonStartInput
            // 
            this.buttonStartInput.Location = new System.Drawing.Point(833, 9);
            this.buttonStartInput.Name = "buttonStartInput";
            this.buttonStartInput.Size = new System.Drawing.Size(115, 24);
            this.buttonStartInput.TabIndex = 15;
            this.buttonStartInput.Text = "入力開始";
            this.buttonStartInput.UseVisualStyleBackColor = true;
            this.buttonStartInput.Click += new System.EventHandler(this.buttonStartInput_Click);
            // 
            // buttonFinishInput
            // 
            this.buttonFinishInput.Enabled = false;
            this.buttonFinishInput.Location = new System.Drawing.Point(832, 39);
            this.buttonFinishInput.Name = "buttonFinishInput";
            this.buttonFinishInput.Size = new System.Drawing.Size(114, 22);
            this.buttonFinishInput.TabIndex = 16;
            this.buttonFinishInput.Text = "入力終了 (保存)";
            this.buttonFinishInput.UseVisualStyleBackColor = true;
            this.buttonFinishInput.Click += new System.EventHandler(this.buttonFinishInput_Click);
            // 
            // buttonAbortInput
            // 
            this.buttonAbortInput.Enabled = false;
            this.buttonAbortInput.Location = new System.Drawing.Point(833, 66);
            this.buttonAbortInput.Name = "buttonAbortInput";
            this.buttonAbortInput.Size = new System.Drawing.Size(114, 21);
            this.buttonAbortInput.TabIndex = 17;
            this.buttonAbortInput.Text = "入力中断";
            this.buttonAbortInput.UseVisualStyleBackColor = true;
            this.buttonAbortInput.Click += new System.EventHandler(this.buttonAbortInput_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "保存ファイル名 : ";
            // 
            // labelSaveFileName
            // 
            this.labelSaveFileName.AutoSize = true;
            this.labelSaveFileName.Location = new System.Drawing.Point(629, 37);
            this.labelSaveFileName.Name = "labelSaveFileName";
            this.labelSaveFileName.Size = new System.Drawing.Size(0, 12);
            this.labelSaveFileName.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(544, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "保存先ファイル名の接頭辞 : ";
            // 
            // textBoxSaveFileNamePrefix
            // 
            this.textBoxSaveFileNamePrefix.Location = new System.Drawing.Point(693, 9);
            this.textBoxSaveFileNamePrefix.Name = "textBoxSaveFileNamePrefix";
            this.textBoxSaveFileNamePrefix.Size = new System.Drawing.Size(98, 19);
            this.textBoxSaveFileNamePrefix.TabIndex = 21;
            this.textBoxSaveFileNamePrefix.Text = "sample";
            this.textBoxSaveFileNamePrefix.TextChanged += new System.EventHandler(this.textBoxSaveFileNamePrefix_Changed);
            // 
            // linkLabelMoreInfo
            // 
            this.linkLabelMoreInfo.AutoSize = true;
            this.linkLabelMoreInfo.Location = new System.Drawing.Point(803, 579);
            this.linkLabelMoreInfo.Name = "linkLabelMoreInfo";
            this.linkLabelMoreInfo.Size = new System.Drawing.Size(145, 12);
            this.linkLabelMoreInfo.TabIndex = 22;
            this.linkLabelMoreInfo.TabStop = true;
            this.linkLabelMoreInfo.Text = "Click here to get more info.";
            this.linkLabelMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMoreInfo_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "ColorPoint";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(171, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 12);
            this.label12.TabIndex = 26;
            this.label12.Text = "SkeletonPoint";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(256, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "X";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(339, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 12);
            this.label13.TabIndex = 28;
            this.label13.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(426, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "Z";
            // 
            // SkeletonPointXtextBox
            // 
            this.SkeletonPointXtextBox.Location = new System.Drawing.Point(274, 58);
            this.SkeletonPointXtextBox.Name = "SkeletonPointXtextBox";
            this.SkeletonPointXtextBox.Size = new System.Drawing.Size(50, 19);
            this.SkeletonPointXtextBox.TabIndex = 30;
            // 
            // SkeletonPointYtextBox
            // 
            this.SkeletonPointYtextBox.Location = new System.Drawing.Point(360, 59);
            this.SkeletonPointYtextBox.Name = "SkeletonPointYtextBox";
            this.SkeletonPointYtextBox.Size = new System.Drawing.Size(50, 19);
            this.SkeletonPointYtextBox.TabIndex = 31;
            // 
            // SkeletonPointZtextBox
            // 
            this.SkeletonPointZtextBox.Location = new System.Drawing.Point(444, 60);
            this.SkeletonPointZtextBox.Name = "SkeletonPointZtextBox";
            this.SkeletonPointZtextBox.Size = new System.Drawing.Size(50, 19);
            this.SkeletonPointZtextBox.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(171, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 12);
            this.label15.TabIndex = 33;
            this.label15.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 603);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.SkeletonPointZtextBox);
            this.Controls.Add(this.SkeletonPointYtextBox);
            this.Controls.Add(this.SkeletonPointXtextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.linkLabelMoreInfo);
            this.Controls.Add(this.textBoxSaveFileNamePrefix);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelSaveFileName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAbortInput);
            this.Controls.Add(this.buttonFinishInput);
            this.Controls.Add(this.buttonStartInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rawYtextBox);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.rawXtextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.frameCounterTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kinectInformationTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxHand);
            this.Controls.Add(this.handConditionTextBox);
            this.Controls.Add(this.comboBoxRange);
            this.Controls.Add(this.pictureBoxRgb);
            this.Name = "Form1";
            this.Text = "Aerial hand written character recognition : Data entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRgb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRgb;
        private System.Windows.Forms.ComboBox comboBoxRange;
        private System.Windows.Forms.RichTextBox handConditionTextBox;
        private System.Windows.Forms.PictureBox pictureBoxHand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kinectInformationTextBox;
        private System.Windows.Forms.Timer eventTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox frameCounterTextBox;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rawXtextBox;
        private System.Windows.Forms.TextBox rawYtextBox;
        private System.Windows.Forms.Button buttonStartInput;
        private System.Windows.Forms.Button buttonFinishInput;
        private System.Windows.Forms.Button buttonAbortInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSaveFileName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSaveFileNamePrefix;
        private System.Windows.Forms.LinkLabel linkLabelMoreInfo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox SkeletonPointXtextBox;
        private System.Windows.Forms.TextBox SkeletonPointYtextBox;
        private System.Windows.Forms.TextBox SkeletonPointZtextBox;
        private System.Windows.Forms.Label label15;
    }
}

