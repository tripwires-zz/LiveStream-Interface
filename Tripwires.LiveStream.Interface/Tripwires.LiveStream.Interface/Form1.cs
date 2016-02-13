using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Tripwires.LiveStream.Interface.Lib;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Hudl.FFmpeg.Settings.BaseTypes;
using Hudl.FFmpeg.Settings;
using Hudl.FFmpeg.Command;
using Hudl.FFmpeg.Resources.BaseTypes;
using Hudl.FFmpeg.Sugar;
using Hudl.FFmpeg.Resources;
using Hudl.FFmpeg;
using System.Reflection;
using Hudl.FFmpeg.Enums;

namespace Tripwires.LiveStream.Interface
{
    public partial class frmMain : Form
    {
        private Vod[] vods;
        private string liveStreamerPath;
        private string saveFileName;
        private List<DownloadableVod> vodsToDownload = new List<DownloadableVod>();
        private Vod currentVod;
        private string quality;

        internal List<DownloadableVod> VodsToDownload
        {
            get
            {
                return vodsToDownload;
            }

            set
            {
                vodsToDownload = value;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("Path");
            if (pathContainsLiveStreamer(path))
            {
                this.liveStreamerPath = this.GetLiveStreamerPath(path);
            }
            else
            {
                MessageBox.Show("Please install livestreamer before using this program. You might need to reboot after the installation of livestreamer.", "LiveStreamer Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool pathContainsLiveStreamer(string path)
        {
            string[] paths = path.Split(";".ToCharArray());
            List<string> result = (from p in paths where p.Contains("Livestreamer") select p).ToList();
            return result.Count > 0 && result.Count < 2;
        }

        private string GetLiveStreamerPath(string path)
        {
            string[] paths = path.Split(";".ToCharArray());
            List<string> result = (from p in paths where p.Contains("Livestreamer") select p).ToList();
            return result[0];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtChannelName.Text != string.Empty)
            {
                TwitchHandler test = new TwitchHandler(this.txtChannelName.Text);
                try
                {
                    loadListBox(test.GetVODS((int)nmrNumberOfVideos.Value, this.cmbVodType.Text));
                }
                catch (WebException webEx)
                {
                    MessageBox.Show(webEx.Message);
                }
            }
            else
            {
                MessageBox.Show("The channelname must be filled in.");
            }

        }

        private void loadListBox(Vod[] result)
        {

            this.vods = result;
            lstVods.DataSource = this.vods;
            lstVods.DisplayMember = "Title";
        }

        private void lstVods_SelectedValueChanged(object sender, EventArgs e)
        {
            Vod selectedVod = (Vod)lstVods.SelectedItem;
            if (selectedVod != null)
            {
                this.showResolutions(selectedVod);
                loadImage(selectedVod);
            }
        }

        private void showResolutions(Vod vod)
        {
            this.cmbResolutions.Items.Clear();
            if (!string.IsNullOrEmpty(vod.Resolution.Source))
            {
                this.cmbResolutions.Items.Add("source");
            }
            if (!string.IsNullOrEmpty(vod.Resolution.High))
            {
                this.cmbResolutions.Items.Add("high");
            }
            if (!string.IsNullOrEmpty(vod.Resolution.Medium))
            {
                this.cmbResolutions.Items.Add("medium");
            }
            if (!string.IsNullOrEmpty(vod.Resolution.Low))
            {
                this.cmbResolutions.Items.Add("low");
            }
            if (!string.IsNullOrEmpty(vod.Resolution.Mobile))
            {
                this.cmbResolutions.Items.Add("mobile");
            }
            this.cmbResolutions.Update();
        }

        private void loadImage(Vod selectedVod)
        {
            pcbThumbnail.LoadAsync(selectedVod.ThumbNails[0].Url);
            pcbThumbnail.LoadCompleted += PcbThumbnail_LoadCompleted;
        }

        /// <summary>
        /// once the image is loaded, replace by a scaled version
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PcbThumbnail_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pcbThumbnail.Image = new Bitmap((Bitmap)pcbThumbnail.Image, 160, 90);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.lstVods.Update();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (this.lstVods.SelectedItem != null && this.cmbResolutions.Text != null)
            {
                this.quality = this.cmbResolutions.Text;
                this.currentVod = this.lstVods.SelectedItem as Vod;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.DefaultExt += ".ts";
                dialog.AddExtension = true;
                dialog.Title = "Select the location where you want to save the file";
                dialog.FileOk += Dialog_FileOk;
                dialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a valid vod first");
            }

        }

        private void Dialog_FileOk(object sender, CancelEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "livestreamer";
            //startInfo.UseShellExecute = true;
            string quality = (!string.IsNullOrEmpty(this.cmbResolutions.Text)) ? this.cmbResolutions.Text : "source";
            this.saveFileName = ((SaveFileDialog)sender).FileName;
            startInfo.Arguments = string.Format(@"""{0}"" {1} -o ""{2}""", (this.currentVod).Url.Replace("http://www.", ""), quality, ((SaveFileDialog)sender).FileName);
            // need to figure out the correct path needed
            Process liveStreamer = Process.Start(startInfo);
            liveStreamer.EnableRaisingEvents = true;
            liveStreamer.Exited += LiveStreamer_Exited;
        }

        private void LiveStreamer_Exited(object sender, EventArgs e)
        {
            if (File.Exists(this.saveFileName))
            {
                MessageBox.Show("Video will start transcoding now.");
                FrameResolution outputResolution = new FrameResolution(this.currentVod, this.quality);
                var settings = SettingsCollection.ForOutput(
                  new CodecVideo(VideoCodecType.Libx264),
                  new CodecAudio(AudioCodecType.Libvo_AacEnc),
                  new BitRateVideo(3500),
                  new Hudl.FFmpeg.Settings.Size(outputResolution.Width, outputResolution.Height),
                  new OverwriteOutput());

                var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
                var FFmpegPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ffmpeg\\FFmpeg.exe";
                var FFprobePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ffmpeg\\FFprobe.exe";

                ResourceManagement.CommandConfiguration = CommandConfiguration.Create(outputPath, FFmpegPath, FFprobePath);

                //we need to create an instance of a command factory.   
                var factory = CommandFactory.Create();

                //staging all input video streams for concatenation, filtering, and mapping to output
                factory.CreateOutputCommand()
                       .WithInput<VideoStream>(this.saveFileName)
                       .WithInput<AudioStream>(this.saveFileName)
                       .MapTo<Mp4>(this.saveFileName + ".mp4", settings);
                //the render command will start feeding the commands to FFmpeg
                factory.Render();
                MessageBox.Show("Video transcoding is finished!");
            }
            else
            {
                MessageBox.Show("Download failed for some reason!");
            }
        }

        private void cmbResolutions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            if (this.lstVods.SelectedItem != null)
            {
                this.VodsToDownload.Add(new DownloadableVod(this.lstVods.SelectedItem as Vod));
            }
        }
    }
}
