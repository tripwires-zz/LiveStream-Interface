using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripwires.LiveStream.Interface.Lib
{
    /// <summary>
    /// represents a VOD with extra properties for keeping its state throughout the download etc.
    /// </summary>
    class DownloadableVod:Vod
    {

        private string rawPath;
        private string encodedpath;
        private bool downloaded;
        private bool encoded;
        private int height;
        private int width;
        private int bitrate;

        /// <summary>
        /// contains the path of the raw video feed
        /// </summary>
        public string RawPath
        {
            get
            {
                return rawPath;
            }

            set
            {
                rawPath = value;
            }
        }

        /// <summary>
        /// contains the path of the encoded video
        /// </summary>
        public string Encodedpath
        {
            get
            {
                return encodedpath;
            }

            set
            {
                encodedpath = value;
            }
        }

        /// <summary>
        /// Indicates if the feed has been downloaded
        /// </summary>
        public bool Downloaded
        {
            get
            {
                return downloaded;
            }

            set
            {
                downloaded = value;
            }
        }

        /// <summary>
        /// indicates if the feed has been encoded
        /// </summary>
        public bool Encoded
        {
            get
            {
                return encoded;
            }

            set
            {
                encoded = value;
            }
        }
        
        /// <summary>
        /// The height of one frame in the vod
        /// </summary>
        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }
        
        /// <summary>
        /// The width of one frame ion the vod
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        /// <summary>
        /// The bitrate the video that it needs to be converted to
        /// </summary>
        public int Bitrate
        {
            get
            {
                return bitrate;
            }

            set
            {
                bitrate = value;
            }
        }
        public DownloadableVod(Vod vod)
        {
            this.TakeOverAllValues(vod);
        }

        private void TakeOverAllValues(Vod vod)
        {
            this.BroadcastId = vod.BroadcastId;
            this.DeleteAt = vod.DeleteAt;
            this.Description = vod.Description;
            this.Game = vod.Game;
            this.Id = vod.Id;
            this.IsMuted = vod.IsMuted;
            this.Length = vod.Length;
            this.Preview = vod.Preview;
            this.RecordedAt = vod.RecordedAt;
            this.Resolution = vod.Resolution;
            this.Status = vod.Status;
            this.TagList = vod.TagList;
            this.ThumbNails = vod.ThumbNails;
            this.Title = vod.Title;
            this.Url = vod.Url;
            this.VodType = vod.VodType;
        }
    }
}
