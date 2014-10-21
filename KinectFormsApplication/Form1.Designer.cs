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
            this.pictureBoxRgb = new System.Windows.Forms.PictureBox();
            this.pictureBoxDepth = new System.Windows.Forms.PictureBox();
            this.comboBoxRange = new System.Windows.Forms.ComboBox();
            this.handConditionTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBoxHand = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRgb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxRgb
            // 
            this.pictureBoxRgb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxRgb.Location = new System.Drawing.Point(12, 49);
            this.pictureBoxRgb.Name = "pictureBoxRgb";
            this.pictureBoxRgb.Size = new System.Drawing.Size(455, 352);
            this.pictureBoxRgb.TabIndex = 0;
            this.pictureBoxRgb.TabStop = false;
            // 
            // pictureBoxDepth
            // 
            this.pictureBoxDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDepth.Location = new System.Drawing.Point(811, 49);
            this.pictureBoxDepth.Name = "pictureBoxDepth";
            this.pictureBoxDepth.Size = new System.Drawing.Size(326, 254);
            this.pictureBoxDepth.TabIndex = 1;
            this.pictureBoxDepth.TabStop = false;
            // 
            // comboBoxRange
            // 
            this.comboBoxRange.FormattingEnabled = true;
            this.comboBoxRange.Location = new System.Drawing.Point(12, 12);
            this.comboBoxRange.Name = "comboBoxRange";
            this.comboBoxRange.Size = new System.Drawing.Size(121, 20);
            this.comboBoxRange.TabIndex = 2;
            this.comboBoxRange.SelectedIndexChanged += new System.EventHandler(this.comboBoxRange_SelectedIndexChanged);
            // 
            // handConditionTextBox
            // 
            this.handConditionTextBox.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.handConditionTextBox.ForeColor = System.Drawing.Color.Red;
            this.handConditionTextBox.Location = new System.Drawing.Point(192, 0);
            this.handConditionTextBox.Name = "handConditionTextBox";
            this.handConditionTextBox.Size = new System.Drawing.Size(419, 43);
            this.handConditionTextBox.TabIndex = 3;
            this.handConditionTextBox.Text = "";
            // 
            // pictureBoxHand
            // 
            this.pictureBoxHand.BackColor = System.Drawing.Color.White;
            this.pictureBoxHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHand.Location = new System.Drawing.Point(473, 49);
            this.pictureBoxHand.Name = "pictureBoxHand";
            this.pictureBoxHand.Size = new System.Drawing.Size(331, 352);
            this.pictureBoxHand.TabIndex = 4;
            this.pictureBoxHand.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(806, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "描画領域クリア";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 505);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxHand);
            this.Controls.Add(this.handConditionTextBox);
            this.Controls.Add(this.comboBoxRange);
            this.Controls.Add(this.pictureBoxDepth);
            this.Controls.Add(this.pictureBoxRgb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRgb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRgb;
        private System.Windows.Forms.PictureBox pictureBoxDepth;
        private System.Windows.Forms.ComboBox comboBoxRange;
        private System.Windows.Forms.RichTextBox handConditionTextBox;
        private System.Windows.Forms.PictureBox pictureBoxHand;
        private System.Windows.Forms.Button button1;
    }
}

