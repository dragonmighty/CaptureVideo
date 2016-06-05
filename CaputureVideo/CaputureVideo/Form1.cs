using System;
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
namespace CaputureVideo
{
    public partial class Form1 : Form
    {
        private bool DeviceExitst = false;
        private FilterInfoCollection videoDevices;

		private Stopwatch stopWatch = null;

        Timer timer1 = new Timer();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getCamList();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
        }

        /// <summary>
        /// デバイスの一覧を取得する
        /// </summary>
        private void getCamList()
        {
            try
            {

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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getCamList();
        }

        // Toggle Start and stop button
        private void buttonStart_Click(object sender, EventArgs e)
        {
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
                    CloseVideoSource();
                    buttonStart.Text = "Start";
                }
            }
        }

		// Open Video Source
		private void openVideoSource (IVideoSource source)
		{
			this.Cursor = Cursors.WaitCursor;

			// stop current video source
			CloseVideoSource();

			// start new video source
			videoSourcePlayer.VideoSource = source;
			videoSourcePlayer.Start();

			timer1.Start();

			this.Cursor = Cursors.Default;
		}

		// New frame received by the player
        private void video_newFrame(object sender, ref Bitmap image)
        {
			// paint current time
			AddDateCaption(ref image);
       //     Bitmap img = (Bitmap)eventArgs.Frame.Clone();

			// 日付と時刻を入れられるように追加
			//pictureBox1.Image = AddDateCaption(img);
		//	img.Dispose();
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
            }
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
			}

            //fpslabel.Text = "Device running..." + videoSourcePlayer.VideoSource.FramesReceived.ToString() + "FPS.";
			//GC.Collect();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }

		private void AddDateCaption(ref Bitmap image)
		{
			//Bitmap bitmapResult = new Bitmap(source.Size.Width, source.Size.Height);
			using (Graphics g = Graphics.FromImage(image))
			using (Brush b = new SolidBrush(Color.Red))
			using (Font f = new Font("Arial", 30))
			{

				try
				{
					//g.DrawImage(source, 0, 0, bitmapResult.Width, bitmapResult.Height);
					g.DrawString(DateTime.Now.ToString(), f, b, new PointF(0, image.Size.Height - 50));
				}
				finally
				{

				}
			}
		}
    }
}
