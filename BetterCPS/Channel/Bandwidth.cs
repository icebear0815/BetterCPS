using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class Bandwidth : ChannelParameter
    {
        public const int _12khz = 0x00;
        public const int _25khz = 0x08;
        
        public Bandwidth()
        {
            offset = 0x00;
            mask = 0x08;
        }
       

        public static Bandwidth fromRaw(byte[] rawData)
        {
            Bandwidth bw = new Bandwidth();
            byte oneByte = rawData[bw.offset];
            bw.Value = oneByte & bw.mask; //00001000 as bit 3 is used for bandwidth
            return bw;
        }
        

        public override string ToString()
        {
            if (_12khz == value)
                return "12.5kHz";
            else if (_25khz == value)
                return "25kHz";
            else
                return "Unknown";
        }
    }
}
