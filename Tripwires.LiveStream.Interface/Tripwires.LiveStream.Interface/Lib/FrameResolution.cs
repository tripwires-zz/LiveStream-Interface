using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripwires.LiveStream.Interface.Lib
{
    class FrameResolution
    {
        private int height;
        private int width;

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

        public FrameResolution(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public FrameResolution(string resolution)
        {
            //1280x720
            this.CalculateResolutionfromString(resolution);
        }
        public FrameResolution(Vod currentVod, string text)
        {
            switch (text)
            {
                case "source":this.CalculateResolutionfromString(currentVod.Resolution.Source); break;
                case "high": this.CalculateResolutionfromString(currentVod.Resolution.High); break;
                case "medium": this.CalculateResolutionfromString(currentVod.Resolution.Medium); break;
                case "low": this.CalculateResolutionfromString(currentVod.Resolution.Low); break;
                case "mobile": this.CalculateResolutionfromString(currentVod.Resolution.Mobile); break;
                default: this.CalculateResolutionfromString(currentVod.Resolution.Source); break;
            }
        }
        private void CalculateResolutionfromString(string resolution)
        {
            string[] splittedResolution = resolution.Split('x');
            if (splittedResolution.Length == 2)
            {
                try
                {
                    this.Height = Int32.Parse(splittedResolution[0]);
                    this.Width = Int32.Parse(splittedResolution[1]);
                }
                catch (FormatException ex)
                {
                    throw new Exception("Height and width need to be numbers");
                }
            }
            else
            {
                throw new Exception("incorrect format for resolution (heightxwidth)");
            }
        }

    }
}
