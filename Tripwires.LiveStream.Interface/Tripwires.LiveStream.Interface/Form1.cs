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
using Tripwires.LiveStream.Interface.Lib;

namespace Tripwires.LiveStream.Interface
{
    public partial class frmMain : Form
    {
        private Vod[] vods;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
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
            MessageBox.Show(((Vod)this.lstVods.SelectedItem).Url);
        }
    }
}
