using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Tripwires.LiveStream.Interface.Lib;
using System.Diagnostics;

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
                    loadListBox(test.getVODS());
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
                pcbThumbnail.LoadAsync(selectedVod.ThumbNails[0].Url);
                pcbThumbnail.LoadCompleted += PcbThumbnail_LoadCompleted;
            }
        }

        private void PcbThumbnail_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //add code to scale thumbnail to correct dimmensions
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.lstVods.Update();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (this.lstVods.SelectedItem != null)
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
            startInfo.Arguments = string.Format(@"""{0}"" source -o ""{1}""", (this.lstVods.SelectedItem as Vod).Url.Replace("http://www.",""), ((SaveFileDialog)sender).FileName);
            // need to figure out the correct path needed
            Process x = Process.Start(startInfo);
        }
    }
}
