using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tripwires.LiveStream.Interface.Lib
{
    public class Resolution
    {
        //        resolutions: {
//medium: "852x480",
//mobile: "400x226",
//high: "1280x720",
//low: "640x360",
//chunked: "1280x720"
//}
        private string medium;
        private string mobile;
        private string high;
        private string low;
        private string source;

        [JsonProperty("medium")]
        public string Medium
        {
            get
            {
                return medium;
            }

            set
            {
                medium = value;
            }
        }
        [JsonProperty("mobile")]
        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
            }
        }
        [JsonProperty("high")]
        public string High
        {
            get
            {
                return high;
            }

            set
            {
                high = value;
            }
        }
        [JsonProperty("low")]
        public string Low
        {
            get
            {
                return low;
            }

            set
            {
                low = value;
            }
        }
        [JsonProperty("chunked")]
        public string Source
        {
            get
            {
                return source;
            }

            set
            {
                source = value;
            }
        }
    }
}
