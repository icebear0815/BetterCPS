using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class Privacy : ChannelParameter
    {
        public const int NONE = 0x00;
        public const int BASIC = 0x10;
        public const int ENHANCED = 0x20;

        public Privacy()
        {
            offset = 0x02;
            mask = 0x30;
        }

        public static Privacy fromRaw(byte[] rawData)
        {
            Privacy pri = new Privacy();
            byte oneByte = rawData[pri.offset];
            pri.Value = oneByte & pri.mask; 
            return pri;
        }

        public void fromString(String valStr)
        {
            if ("None".Equals(valStr))
                value = NONE;
            else if ("Basic".Equals(valStr))
                value = BASIC;
            else if ("Enhanced".Equals(valStr))
                value = ENHANCED;
            else
                throw new Exception("Unknown Value for Privacy! Got: "+valStr+" was expecting (\"None\", \"Basic\", \"Enhanced\").");
        }

        public override string ToString()
        {
            if (NONE == value)
                return "None";
            else if (BASIC == value)
                return "Basic";
            else if (ENHANCED == value)
                return "Enhanced";
            else
                return "Unknown";
        }
    }
}
