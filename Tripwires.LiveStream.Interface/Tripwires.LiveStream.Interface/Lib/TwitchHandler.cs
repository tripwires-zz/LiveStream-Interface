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

        public Vod[] getVODS()
        {
            Channel channel;
            var req = HttpWebRequest.Create(string.Format("https://api.twitch.tv/kraken/channels/{0}/videos?broadcasts=true",this.ChannelName));
            req.Method = WebRequestMethods.Http.Get;
            req.ContentType = "application/json";
            using (var resp = req.GetResponse())
            {
                string results = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                channel = JsonConvert.DeserializeObject<Channel>(results);
            }

            return channel.Videos;
        }
    }

    //public delegate void VodsLoadedDelegate(Vod[]loadedVods);

}
