using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tripwires.LiveStream.Interface.Lib
{
    class Thumb
    {
        #region JSON Output
        /*
        url: "https://static-cdn.jtvnw.net/v1/AUTH_system/vods_dba0/tripwires_19298171232_393425866//thumb/thumb39662014-320x240.jpg",
        type: "generated"
        */
        #endregion
        private string url;
        private string type;

        [JsonProperty("url")]
        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public Thumb(string url, string type)
        {
            this.Url = url;
            this.Type = type;
        }

    }
}
