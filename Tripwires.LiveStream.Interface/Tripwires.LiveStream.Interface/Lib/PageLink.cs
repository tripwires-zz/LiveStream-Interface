using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Tripwires.LiveStream.Interface.Lib
{
    public class PageLink
    {
        private string self;
        private string next;
        private string prev;

        [JsonProperty("self")]
        public string Self
        {
            get
            {
                return self;
            }

            set
            {
                self = value;
            }
        }
        [JsonProperty("next")]
        public string Next
        {
            get
            {
                return next;
            }

            set
            {
                next = value;
            }
        }
        [JsonProperty("prev")]
        public string Prev
        {
            get
            {
                return prev;
            }

            set
            {
                prev = value;
            }
        }
    }
}
