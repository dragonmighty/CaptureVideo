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

namespace CaputureVideo
{
	public partial class Form1 : Form
	{
		private bool DeviceExitst = false;
		private FilterInfoCollection videoDevices;
		private VideoCaptureDevice videoSource = null;

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
					videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
					videoSource.NewFrame += new NewFrameEventHandler(video_newFrame);
					CloseVideoSource();
					videoSource.Start();
					buttonStart.Text = "Stop";
					timer1.Enabled = true;
				}
			}
			else
			{
				if (videoSource.IsRunning)
				{
					timer1.Enabled = false;
					CloseVideoSource();
					buttonStart.Text = "Start";
				}
			}
		}

		/// <summary>
		/// 新フレームが準備可能となった際に呼ばれるイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void video_newFrame(object sender, NewFrameEventArgs eventArgs)
		{
			Bitmap img = (Bitmap)eventArgs.Frame.Clone();
			pictureBox1.Image = img;
		}

		private  void CloseVideoSource()
		{
			if (!(videoSource == null))
			{
				if (videoSource == null)
				{
					if (videoSource.IsRunning)
					{
						videoSource = null;
					}
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label2.Text = "Device running..." + videoSource.FramesReceived.ToString() + "FPS.";
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			CloseVideoSource();
		}
	}
}
