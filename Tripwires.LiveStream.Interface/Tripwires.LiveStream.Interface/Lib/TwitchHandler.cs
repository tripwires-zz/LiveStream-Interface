using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tripwires.LiveStream.Interface.Lib
{
    public class TwitchHandler
    {
        private string channelName;
        private bool pastBroadcasts;
        //private VodsLoadedDelegate vodsLoaded;

        public string ChannelName
        {
            get
            {
                return channelName;
            }

            set
            {
                channelName = value;
            }
        }

        public bool PastBroadcasts
        {
            get
            {
                return pastBroadcasts;
            }

            set
            {
                pastBroadcasts = value;
            }
        }

        public TwitchHandler()
        {

        }
        public TwitchHandler(string channelName)
        {
            this.ChannelName = channelName;
        }

        //public VodsLoadedDelegate VodsLoaded {
        //    get { return this.vodsLoaded; }
        //    set { this.vodsLoaded = value; }
        //}

        public TwitchHandler(string channelName, bool pastBroadcasts)
        {
            this.ChannelName = channelName;
            this.PastBroadcasts = pastBroadcasts;
        }

        /// <summary>
        /// load the number of pages with videos in it
        /// </summary>
        /// <param name="numberOfVideos">The number of videos that need to be loaded it is rounded to the closest 10 videos</param>
        /// <returns>an array with the video data in it</returns>
        public Vod[] GetVODS(int numberOfVideos,string vodType)
        {
            //init variables with default values
            List<Vod> result = new List<Vod>();
            int numberOfPages = (int)(decimal)numberOfVideos/10;
            bool pastBroadCasts = vodType.Equals("Past Broadcasts");
            string initUrl = string.Format("https://api.twitch.tv/kraken/channels/{0}/videos?broadcasts={1}", this.ChannelName, pastBroadCasts.ToString().ToLower());
            //load first page otherwise we don't know the links we want to go to (Link.Next)
            Channel firstPage = this.GetPage(initUrl);
            //check if there are any vods there we want to avoid unnecessary loads
            if (firstPage.Videos != null)
            {
                 result.AddRange(firstPage.Videos);
                Channel page = firstPage;
                //now go through the other pages
                for (int i = 1; i < numberOfPages; i++)
                {
                    page = this.GetPage(page.Link.Next);
                    if(page.Videos != null)
                    {
                        result.AddRange(page.Videos);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// load a JSON page with a given url
        /// </summary>
        /// <param name="url">the url of the page that you want to load</param>
        /// <returns>the Channel that is on that URL</returns>
        internal Channel GetPage(string url)
        {
            Channel channel;
            var req = HttpWebRequest.Create(url);
            req.Method = WebRequestMethods.Http.Get;
            req.ContentType = "application/json";
            using (var resp = req.GetResponse())
            {
                string results = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                //need to fix thumbnail discrepency sometimes returns an arary of thumbs and in other cases it returns a string
                channel = JsonConvert.DeserializeObject<Channel>(results);
            }
            return channel;
        }
    }

    //public delegate void VodsLoadedDelegate(Vod[]loadedVods);

}
