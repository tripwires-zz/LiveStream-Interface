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

namespace Tripwires.LiveStream.Interface
{
    public partial class frmMain : Form
    {
        private Vod[] vods;
        private string liveStreamerPath;
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
                SaveFileDialog dialog = new SaveFileDialog();
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
            startInfo.FileName =  "livestreamer";
            startInfo.UseShellExecute = true;
            string quality = (!string.IsNullOrEmpty(this.cmbResolutions.Text)) ? this.cmbResolutions.Text : "source";
            startInfo.Arguments = string.Format(@"""{0}"" {1} -o ""{2}""", (this.lstVods.SelectedItem as Vod).Url.Replace("http://www.",""), quality, ((SaveFileDialog)sender).FileName);
            // need to figure out the correct path needed
            Process x = Process.Start(startInfo);
        }
    }
}
