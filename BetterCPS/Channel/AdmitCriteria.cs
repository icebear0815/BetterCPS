using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class AdmitCriteria : ChannelParameter
    {
        public const int ALWAYS = 0x00;
        public const int CHANNEL_FREE = 0x40;
        public const int COLOR_CODE = 0xC0;
       

        public AdmitCriteria()
        {
            mask = 0xC0;
            offset = 0x04;
        }
        public static AdmitCriteria fromRaw(byte[] rawData)
        {
            AdmitCriteria ac = new AdmitCriteria();
            byte oneByte = rawData[ac.offset];
            ac.Value = oneByte & ac.mask; //00000011 as bit 3 is used for bandwidth
            return ac;
        }

        public void FromString(String objStr)
        {
            if ("Always".Equals(objStr))
                value = ALWAYS;
            else if ("Channel Free".Equals(objStr))
                value = CHANNEL_FREE;
            else if ("Color Code".Equals(objStr))
                value = COLOR_CODE;
            else
                throw new ArgumentException("Value " + objStr + " can not be converted to Color-Code (\"Always\"/\"Channel Free\"/\"Color Code\").");
        }
        public override string ToString()
        {
            if (ALWAYS == value)
                return "Always";
            else if (CHANNEL_FREE == value)
                return "Channel Free";
            else if (COLOR_CODE == value)
                return "Color Code";
            else
                return "Unknown";
        }
    }
}
