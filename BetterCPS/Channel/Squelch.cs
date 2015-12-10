using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class Squelch : ChannelParameter
    {
        public const int NORMAL = 0x20;
        public const int TIGHT = 0x00;

        public Squelch()
        {
            offset = 0x00;
            mask = 0x20;
        }

        public static Squelch fromRaw(byte[] rawData)
        {
            Squelch sq = new Squelch();
            byte oneByte = rawData[sq.offset];
            sq.Value = oneByte & sq.mask; //00100000 as bit 5 is used for squelch
            return sq;
        }

        public void FromString(String objStr)
        {
            if ("Normal".Equals(objStr))
                value = NORMAL;
            else if ("Tight".Equals(objStr))
                value = TIGHT;
            else
                throw new ArgumentException("Value " + objStr + " can not be converted to a squelch setting (\"Normal\"/\"Tight\").");
        }
        public override string ToString()
        {
            if (NORMAL == value)
                return "Normal";
            else if (TIGHT == value)
                return "Tight";
            else
                return "Unknown";
        }
    }
}
