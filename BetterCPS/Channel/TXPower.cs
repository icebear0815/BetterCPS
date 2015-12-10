using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class TXPower : ChannelParameter
    {
        public const int LOW = 0x00;
        public const int HIGH = 0x20;
       

        public TXPower()
        {
            offset = 0x04;
            mask = 0x20;
        }
        
        
        public static TXPower FromRaw(byte[] rawData)
        {
            TXPower tx = new TXPower();
            byte oneByte = rawData[tx.offset];
            tx.Value = oneByte & tx.mask; //00100000 as bit 5 is used for power
            return tx;
        }

        public void FromString(String objStr)
        {
            if ("Low".Equals(objStr))
                value = LOW;
            else if ("High".Equals(objStr))
                value = HIGH;
            else throw new ArgumentException("Value " + objStr + " can not be converted to TXPower (\"Low\"/\"High\").");
        }
        
        public override string ToString()
        {
            if (LOW == value)
                return "Low";
            else if (HIGH == value)
                return "High";
            else
                return "Unknown";
        }
    }
}
