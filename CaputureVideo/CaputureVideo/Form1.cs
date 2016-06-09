﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;

using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace CaputureVideo
{
    public partial class Form1 : Form
    {
        private bool DeviceExitst = false;
        private FilterInfoCollection videoDevices;

		private Stopwatch stopWatch = null;
		Timer recordTimer = new Timer();
		private AForge.Video.FFMPEG.VideoFileWriter writer = new AForge.Video.FFMPEG.VideoFileWriter();

		Timer timer1 = new Timer();
		String strsaveFileName = String.Empty;

		Boolean IsRecording = false;
		object syncObject = new object();

		Size imageSize;

		private static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			LOG.Info("アプリケーションの起動");
			getCamList();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;

			recordTimer.Tick += new EventHandler(recordTimer_tick);
        }

        /// <summary>
        /// デバイスの一覧を取得する
        /// </summary>
        private void getCamList()
        {
            try
            {
				LOG.Info("カメラ一覧の読み込み");
				videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0) throw new ApplicationException();

                DeviceExitst = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                DeviceExitst = false;
                comboBox1.Items.Add("キャプチャデバイスがありません");
				LOG.Info("キャプチャデバイスがありません");
            }
			catch (Exception e)
			{
				LOG.Fatal(e.Message);
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
            getCamList();
        }

		// Toggle Start and stop button
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:ローカライズされるパラメーターとしてリテラルを渡さない", MessageId = "System.Windows.Forms.Control.set_Text(System.String)")]
		private void buttonStart_Click(object sender, EventArgs e)
        {
			try
			{
				LOG.Info("Start/Stopボタンの押下");
				if (buttonStart.Text == "Start")
				{
					if (DeviceExitst)
					{
						VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
						openVideoSource(videoSource);

						buttonStart.Text = "Stop";
						timer1.Enabled = true;
					}
				}
				else
				{
					if (videoSourcePlayer.IsRunning)
					{
						timer1.Enabled = false;
						recordTimer.Stop();
						CloseVideoWriter();
						CloseVideoSource();
						buttonStart.Text = "Start";
					}
				}
			}
			catch (Exception ex)
			{
				LOG.Fatal(ex.Message);
			}
		}

		// Open Video Source
		private void openVideoSource (IVideoSource source)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;

				// stop current video source
				CloseVideoSource();


				// start new video source
				videoSourcePlayer.VideoSource = source;
				videoSourcePlayer.Start();

				timer1.Start();

				buttonSave.Enabled = true;

				this.Cursor = Cursors.Default;
			}
			catch (Exception e)
			{
				LOG.Fatal(e.Message);
			}
		}

		// New frame received by the player
        private void video_newFrame(object sender, ref Bitmap image)
        {
			try
			{
				System.Threading.Monitor.Enter(syncObject);
				// paint current time
				AddDateCaptionwithBorder(ref image);

				imageSize = image.Size;

				if (IsRecording)
				{
					if ((writer != null) && (image != null) && (writer.IsOpen))
						writer.WriteVideoFrame(image);
				}
				System.Threading.Monitor.Exit(syncObject);
			}
			catch (Exception e)
			{
				LOG.Fatal(e.Message);
			}
		}

		// Close video source if it is running.
        private void CloseVideoSource()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
				videoSourcePlayer.SignalToStop();

				for (int i = 0; i< 30; i++)
				{
					if (!videoSourcePlayer.IsRunning)
					{
						break;
					}
					System.Threading.Thread.Sleep(100);
				}

				if (videoSourcePlayer.IsRunning)
				{
					videoSourcePlayer.Stop();
				}

				videoSourcePlayer.VideoSource = null;

				buttonSave.Enabled = false;
            }
        }

		private void toggleVideoWriter()
		{

			if (IsRecording)
			{
				recordTimer.Stop();
				Task.Run(() => CloseVideoWriter());
			}
			else
			{
				Task.Run(() => OpenVideoWriter());
				recordTimer.Interval = 1000 * 60 * Convert.ToInt32(numericUpDownCutTime.Value);

				recordTimer.Start();
			}
		}

		private void CloseVideoWriter()
		{
			System.Threading.Monitor.Enter(syncObject);
			if (writer != null)
			{
				LOG.Info("録画の終了");
				writer.Close();
				if ((strsaveFileName != String.Empty) && (System.IO.File.Exists(strsaveFileName + ".tmp")))
					System.IO.File.Move(strsaveFileName + ".tmp", strsaveFileName + ".mp4");
				LOG.Debug("ロック用オブジェクトの使用開始");
				IsRecording = false;
				LOG.Debug("ロック用オブジェクトの使用終了");
				LOG.Info("IsRecording ->" + IsRecording.ToString());
			}
			System.Threading.Monitor.Exit(syncObject);
		}

		private void OpenVideoWriter()
		{
			System.Threading.Monitor.Enter(syncObject);
			if (writer != null)
			{
				if (System.IO.Directory.Exists(textBoxSavePath.Text))
				{
					strsaveFileName = textBoxSavePath.Text + @"\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss_fff");
					LOG.Info("録画の開始: " + strsaveFileName + ".tmp");

					writer.Open(strsaveFileName + ".tmp", imageSize.Width, imageSize.Height, 25, AForge.Video.FFMPEG.VideoCodec.MPEG4);

					LOG.Debug("ロック用オブジェクトの使用開始");
					IsRecording = true;
					LOG.Debug("ロック用オブジェクトの使用終了");
					LOG.Info("IsRecording ->" + IsRecording.ToString());
				}
				else
				{
					LOG.Info("書き込み先ディレクトリが存在しない ->" + textBoxSavePath.Text);
				}
			}
			else
			{
				LOG.Info("writerがnull");
			}
			System.Threading.Monitor.Exit(syncObject);
		}

		// On time event - gather statistics
		private void timer1_Tick(object sender, EventArgs e)
        {
			IVideoSource videoSource = videoSourcePlayer.VideoSource;
			if (videoSource != null)
			{
				// get number of frames since the last timer tick
				int framesReceived = videoSource.FramesReceived;

				if ( stopWatch == null)
				{
					stopWatch = new Stopwatch();
					stopWatch.Start();
				}
				else
				{
					stopWatch.Stop();

					float fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
					fpslabel.Text = fps.ToString("F2") + "fps";

					stopWatch.Reset();
					stopWatch.Start();
				}

				if (IsRecording)
				{
					buttonSave.Text = "●REC";
					buttonSave.ForeColor = Color.Red;
				}
				else
				{
					buttonSave.Text = "録画";
					buttonSave.ForeColor = Color.Black;
				}
			}

            //fpslabel.Text = "Device running..." + videoSourcePlayer.VideoSource.FramesReceived.ToString() + "FPS.";
			//GC.Collect();
        }

		async private void recordTimer_tick(object sender, EventArgs e)
		{
			LOG.Info("録画分割タイマーが呼ばれました");

			//recordTimer.Stop();

			await Task.Run(() =>
			{
				CloseVideoWriter();

				System.Threading.Thread.Sleep(500);

				OpenVideoWriter();
			});

			//recordTimer.Interval = 1000 * 60 * Convert.ToInt32(numericUpDownCutTime.Value);
			//recordTimer.Start();

			LOG.Info("IsRecording ->" + IsRecording.ToString());


		}

		//private void AddDateCaption(ref Bitmap image)
		//{
		//	//Bitmap bitmapResult = new Bitmap(source.Size.Width, source.Size.Height);
		//	using (Graphics g = Graphics.FromImage(image))
		//	using (Brush b = new SolidBrush(Color.Red))
		//	using (Font f = new Font("Arial", 30))
		//	{

		//		try
		//		{
		//			//g.DrawImage(source, 0, 0, bitmapResult.Width, bitmapResult.Height);
		//			g.DrawString(DateTime.Now.ToString(), f, b, new PointF(0, image.Size.Height - 50));
		//		}
		//		finally
		//		{

		//		}
		//	}
		//}

		// draw date time with border
		static private void AddDateCaptionwithBorder(ref Bitmap image)
		{
			using (System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath())
			using (Graphics g = Graphics.FromImage(image))
			using (Brush b = new SolidBrush(Color.Red))
			// graphicPathではFontFamilyを使用する。
			using (FontFamily fontFamily = new FontFamily("Arial"))
			// 幅２のペンを作成
			using (Pen p = new Pen(Color.Black, 2))
			{

				try
				{
					// パスを作成する。
					graphicsPath.AddString(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff"), fontFamily, (Int32)FontStyle.Bold, 50, new Point(0, image.Size.Height - 50), StringFormat.GenericDefault);

					// パスの中を塗りつぶす
					g.FillPath(Brushes.White, graphicsPath);

					// 塗りつぶした後で、パスをペンで描画する。
					g.DrawPath(p, graphicsPath);
				}
				finally
				{

				}
			}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			LOG.Info("録画切り替えボタンの押下");
			toggleVideoWriter();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				fbd.Description = "保存先を選択してください。";

				if (System.IO.Directory.Exists(textBoxSavePath.ToString()))
					fbd.SelectedPath = textBoxSavePath.ToString();


				if (fbd.ShowDialog() == DialogResult.OK)
				{
					textBoxSavePath.Text = fbd.SelectedPath;
				}
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			LOG.Info("アプリケーションの終了");
			CloseVideoWriter();
			CloseVideoSource();
		}
	}
}
