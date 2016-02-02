using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripwires.LiveStream.Interface.Lib
{
    public class Consts
    {
        enum VodType
        {
            [Description("Hightlight")]
            HIGHLIGHT,
            [Description("Past Broadcast")]
            PASTBROADCAST
        }
    }
}
