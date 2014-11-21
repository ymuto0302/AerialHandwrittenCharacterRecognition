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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.YtextBox = new System.Windows.Forms.TextBox();
            this.XtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rawYtextBox = new System.Windows.Forms.TextBox();
            this.rawXtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.kinectInformationTextBox = new System.Windows.Forms.TextBox();
            this.eventTimer = new System.Windows.Forms.Timer(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.frameCounterTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRgb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxRgb
            // 
            this.pictureBoxRgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRgb.Location = new System.Drawing.Point(12, 194);
            this.pictureBoxRgb.Name = "pictureBoxRgb";
            this.pictureBoxRgb.Size = new System.Drawing.Size(410, 299);
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
            this.handConditionTextBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.handConditionTextBox.ForeColor = System.Drawing.Color.Red;
            this.handConditionTextBox.Location = new System.Drawing.Point(147, 27);
            this.handConditionTextBox.Name = "handConditionTextBox";
            this.handConditionTextBox.Size = new System.Drawing.Size(275, 43);
            this.handConditionTextBox.TabIndex = 3;
            this.handConditionTextBox.Text = "";
            // 
            // pictureBoxHand
            // 
            this.pictureBoxHand.BackColor = System.Drawing.Color.White;
            this.pictureBoxHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHand.Location = new System.Drawing.Point(428, 194);
            this.pictureBoxHand.Name = "pictureBoxHand";
            this.pictureBoxHand.Size = new System.Drawing.Size(385, 299);
            this.pictureBoxHand.TabIndex = 4;
            this.pictureBoxHand.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(813, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "描画領域クリア";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YtextBox);
            this.groupBox1.Controls.Add(this.XtextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rawYtextBox);
            this.groupBox1.Controls.Add(this.rawXtextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(473, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 68);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "right hand\'s coordinates";
            // 
            // YtextBox
            // 
            this.YtextBox.Location = new System.Drawing.Point(195, 42);
            this.YtextBox.Name = "YtextBox";
            this.YtextBox.Size = new System.Drawing.Size(100, 19);
            this.YtextBox.TabIndex = 7;
            // 
            // XtextBox
            // 
            this.XtextBox.Location = new System.Drawing.Point(196, 21);
            this.XtextBox.Name = "XtextBox";
            this.XtextBox.Size = new System.Drawing.Size(100, 19);
            this.XtextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "X";
            // 
            // rawYtextBox
            // 
            this.rawYtextBox.Location = new System.Drawing.Point(54, 42);
            this.rawYtextBox.Name = "rawYtextBox";
            this.rawYtextBox.Size = new System.Drawing.Size(100, 19);
            this.rawYtextBox.TabIndex = 3;
            // 
            // rawXtextBox
            // 
            this.rawXtextBox.Location = new System.Drawing.Point(54, 20);
            this.rawXtextBox.Name = "rawXtextBox";
            this.rawXtextBox.Size = new System.Drawing.Size(100, 19);
            this.rawXtextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "rawY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "rawX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "hand status";
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
            this.label7.Location = new System.Drawing.Point(10, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Information for Kinect sensor";
            // 
            // kinectInformationTextBox
            // 
            this.kinectInformationTextBox.Location = new System.Drawing.Point(12, 98);
            this.kinectInformationTextBox.Multiline = true;
            this.kinectInformationTextBox.Name = "kinectInformationTextBox";
            this.kinectInformationTextBox.Size = new System.Drawing.Size(410, 90);
            this.kinectInformationTextBox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "frame counter";
            // 
            // frameCounterTextBox
            // 
            this.frameCounterTextBox.Location = new System.Drawing.Point(527, 98);
            this.frameCounterTextBox.Name = "frameCounterTextBox";
            this.frameCounterTextBox.Size = new System.Drawing.Size(100, 19);
            this.frameCounterTextBox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 505);
            this.Controls.Add(this.frameCounterTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kinectInformationTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxHand);
            this.Controls.Add(this.handConditionTextBox);
            this.Controls.Add(this.comboBoxRange);
            this.Controls.Add(this.pictureBoxRgb);
            this.Name = "Form1";
            this.Text = "KinectApplication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRgb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRgb;
        private System.Windows.Forms.ComboBox comboBoxRange;
        private System.Windows.Forms.RichTextBox handConditionTextBox;
        private System.Windows.Forms.PictureBox pictureBoxHand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox rawYtextBox;
        private System.Windows.Forms.TextBox rawXtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YtextBox;
        private System.Windows.Forms.TextBox XtextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox kinectInformationTextBox;
        private System.Windows.Forms.Timer eventTimer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox frameCounterTextBox;
    }
}

