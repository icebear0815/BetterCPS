using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class RxTxRefFrequency : ChannelParameter
    {
        public const int LOW = 0x00;
        public const int MEDIUM = 0x01;
        public const int HIGH = 0x02;
        public const int OFFSET_RX = 0x03;
        public const int OFFSET_TX = 0x04;

        public RxTxRefFrequency(int offset)
        {
            this.offset = offset;
            mask = 0x03;
        }
        protected int Offset
        {
            get { return offset; }
            set { offset = value; }
        }
        
        public static RxTxRefFrequency fromRaw(byte[] rawData, int offset)
        {
            RxTxRefFrequency rtr = new RxTxRefFrequency(offset);
            byte oneByte = rawData[offset];
            rtr.Value = oneByte & rtr.mask; //00000011 as bit 3 is used for bandwidth
            return rtr;
        }
        public void FromString(String objStr)
        {
            if ("Low".Equals(objStr))
                value = LOW;
            else if ("Medium".Equals(objStr))
                value = MEDIUM;
            else if ("High".Equals(objStr))
                value = HIGH;
            else throw new ArgumentException("Value " + objStr + " can not be converted to RefFrequency (\"Low\"/\"Medium\"/\"High\").");
        }

        public override string ToString()
        {
            if (LOW == value)
                return "Low";
            else if (MEDIUM == value)
                return "Medium";
            else if (HIGH == value)
                return "High";
            else
                return "Unknown";
        }
    }
}
