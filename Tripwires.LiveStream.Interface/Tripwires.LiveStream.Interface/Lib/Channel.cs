using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Tripwires.LiveStream.Interface.Lib
{
    class Channel
    {
        #region json output
        /*
                    _total: 12,
            _links: {
            self: "https://api.twitch.tv/kraken/channels/tripwires/videos?broadcasts=true&limit=10&offset=0&user=tripwires",
            next: "https://api.twitch.tv/kraken/channels/tripwires/videos?broadcasts=true&limit=10&offset=10&user=tripwires"
            }
            videos: []
        */
        #endregion
        private int total;
        private Vod[] videos;
        private PageLink link;

        public Channel()
        {

        }
        public Channel(int total, Vod[] videos)
        {
            this.Total = total;
            this.Videos = videos;
        }
        [JsonProperty("_total")]
        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
        [JsonProperty("videos")]
        public Vod[] Videos
        {
            get
            {
                return videos;
            }

            set
            {
                videos = value;
            }
        }
        [JsonProperty("_links")]
        public PageLink Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }
    }
}
