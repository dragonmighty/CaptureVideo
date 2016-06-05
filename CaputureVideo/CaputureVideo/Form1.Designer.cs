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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(116, 14);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(163, 20);
			this.comboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 16);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "キャプチャデバイス";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(301, 13);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(67, 19);
			this.button1.TabIndex = 2;
			this.button1.Text = "再取得";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(388, 10);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(56, 18);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// fpslabel
			// 
			this.fpslabel.AutoSize = true;
			this.fpslabel.Location = new System.Drawing.Point(461, 14);
			this.fpslabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.fpslabel.Name = "fpslabel";
			this.fpslabel.Size = new System.Drawing.Size(37, 12);
			this.fpslabel.TabIndex = 4;
			this.fpslabel.Text = "Ready";
			// 
			// videoSourcePlayer
			// 
			this.videoSourcePlayer.AutoSizeControl = true;
			this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
			this.videoSourcePlayer.Location = new System.Drawing.Point(279, 253);
			this.videoSourcePlayer.Name = "videoSourcePlayer";
			this.videoSourcePlayer.Size = new System.Drawing.Size(322, 242);
			this.videoSourcePlayer.TabIndex = 5;
			this.videoSourcePlayer.VideoSource = null;
			this.videoSourcePlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.video_newFrame);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(880, 748);
			this.Controls.Add(this.fpslabel);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.videoSourcePlayer);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Label fpslabel;
		private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
	}
}

