namespace CaputureVideo
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
        /// <param name="false">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.fpslabel = new System.Windows.Forms.Label();
			this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
			this.buttonSave = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownCutTime = new System.Windows.Forms.NumericUpDown();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxSavePath = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutTime)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(132, 7);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(214, 24);
			this.comboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.label1.Location = new System.Drawing.Point(9, 14);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "キャプチャデバイス";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.button1.Location = new System.Drawing.Point(350, 7);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(67, 27);
			this.button1.TabIndex = 2;
			this.button1.Text = "再取得";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.buttonStart.Location = new System.Drawing.Point(421, 7);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(68, 27);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// fpslabel
			// 
			this.fpslabel.AutoSize = true;
			this.fpslabel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.fpslabel.Location = new System.Drawing.Point(671, 10);
			this.fpslabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.fpslabel.Name = "fpslabel";
			this.fpslabel.Size = new System.Drawing.Size(50, 16);
			this.fpslabel.TabIndex = 4;
			this.fpslabel.Text = "Ready";
			// 
			// videoSourcePlayer
			// 
			this.videoSourcePlayer.AutoSizeControl = true;
			this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
			this.videoSourcePlayer.Location = new System.Drawing.Point(211, 138);
			this.videoSourcePlayer.Name = "videoSourcePlayer";
			this.videoSourcePlayer.Size = new System.Drawing.Size(322, 242);
			this.videoSourcePlayer.TabIndex = 5;
			this.videoSourcePlayer.VideoSource = null;
			this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.video_newFrame);
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.buttonSave.Location = new System.Drawing.Point(506, 7);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 27);
			this.buttonSave.TabIndex = 6;
			this.buttonSave.Text = "録画";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.numericUpDownCutTime);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.textBoxSavePath);
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.fpslabel);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.buttonStart);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(744, 65);
			this.panel1.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(659, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "分で区切る";
			// 
			// numericUpDownCutTime
			// 
			this.numericUpDownCutTime.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.numericUpDownCutTime.Location = new System.Drawing.Point(599, 40);
			this.numericUpDownCutTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpDownCutTime.Name = "numericUpDownCutTime";
			this.numericUpDownCutTime.Size = new System.Drawing.Size(54, 19);
			this.numericUpDownCutTime.TabIndex = 10;
			this.numericUpDownCutTime.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button2.Location = new System.Drawing.Point(545, 41);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(25, 18);
			this.button2.TabIndex = 9;
			this.button2.Text = "...";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.label2.Location = new System.Drawing.Point(12, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "保存先";
			// 
			// textBoxSavePath
			// 
			this.textBoxSavePath.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textBoxSavePath.Location = new System.Drawing.Point(132, 41);
			this.textBoxSavePath.Name = "textBoxSavePath";
			this.textBoxSavePath.Size = new System.Drawing.Size(407, 18);
			this.textBoxSavePath.TabIndex = 7;
			this.textBoxSavePath.Text = "D:\\";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.videoSourcePlayer);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 65);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(744, 519);
			this.panel2.TabIndex = 8;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 584);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCutTime)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label fpslabel;
		private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxSavePath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDownCutTime;
	}
}

