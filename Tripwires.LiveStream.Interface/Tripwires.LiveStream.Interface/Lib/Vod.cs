using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Tripwires.LiveStream.Interface.Lib
{
    public class Vod
    {
        #region json output
        /*
        title: "boats...boats...boats...",
        description: "",
        broadcast_id: 19298171232,
        status: "recorded",
        tag_list: "",
        _id: "v39662014",
        recorded_at: "2016-02-01T20:37:39Z",
        game: "Rise of the Tomb Raider",
        length: 615,
        delete_at: "2016-02-15T20:37:39Z",
        vod_type: "highlight",
        is_muted: false,
        preview: "https://static-cdn.jtvnw.net/v1/AUTH_system/vods_dba0/tripwires_19298171232_393425866//thumb/thumb39662014-320x240.jpg",
        thumbnails: [
        {
        url: "https://static-cdn.jtvnw.net/v1/AUTH_system/vods_dba0/tripwires_19298171232_393425866//thumb/thumb39662014-320x240.jpg",
        type: "generated"
        }
        ],
        url: "http://www.twitch.tv/tripwires/v/39662014",
        views: 0,
        fps: {
        audio_only: 0,
        chunked: 29.9998853811398
        },
        resolutions: {
        chunked: "1280x720"
        },
        broadcast_type: "highlight",
        created_at: "2016-02-01T23:13:46Z",
        */
        #endregion  

        private string title;
        private string description;
        private string broadcastId;
        private string status;
        private string tagList;
        private string id;
        private DateTime recordedAt;
        private string url;
        private string game;
        private string length;
        private DateTime deleteAt;
        private string vodType;
        private bool isMuted;
        private Uri preview;
        private Thumb[] thumbNails;
        private Resolution resolution;


        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        [JsonProperty("description")]
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        [Browsable(false)]
        [JsonProperty("broadcast_id")]
        public string BroadcastId
        {
            get
            {
                return broadcastId;
            }

            set
            {
                broadcastId = value;
            }
        }
        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
        [JsonProperty("tag_list")]
        public string TagList
        {
            get
            {
                return tagList;
            }

            set
            {
                tagList = value;
            }
        }
        [JsonProperty("_id")]
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [JsonProperty("recorded_at")]
        public DateTime RecordedAt
        {
            get
            {
                return recordedAt;
            }

            set
            {
                recordedAt = value;
            }
        }
        [JsonProperty("game")]
        public string Game
        {
            get
            {
                return game;
            }

            set
            {
                game = value;
            }
        }
        [JsonProperty("length")]
        public string Length
        {
            get
            {
                return length;
            }

            set
            {
                length = value;
            }
        }
        [JsonProperty("delete_at")]
        public DateTime DeleteAt
        {
            get
            {
                return deleteAt;
            }

            set
            {
                deleteAt = value;
            }
        }
        [JsonProperty("vod_type")]
        public string VodType
        {
            get
            {
                return vodType;
            }

            set
            {
                vodType = value;
            }
        }
        [JsonProperty("is_muted")]
        public bool IsMuted
        {
            get
            {
                return isMuted;
            }

            set
            {
                isMuted = value;
            }
        }
        [JsonProperty("preview")]
        public Uri Preview
        {
            get
            {
                return preview;
            }

            set
            {
                preview = value;
            }
        }
        [JsonProperty("thumbnails")]
        internal Thumb[] ThumbNails
        {
            get
            {
                return thumbNails;
            }

            set
            {
                thumbNails = value;
            }
        }
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
        [Browsable(false)]
        [JsonProperty("resolutions")]
        public Resolution Resolution
        {
            get
            {
                return resolution;
            }

            set
            {
                resolution = value;
            }
        }
    }
}