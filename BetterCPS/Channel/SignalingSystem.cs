using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class SignalingSystem : ChannelParameter
    {
        public const int OFF = 0x00;
        public const int DTMF1 = 0x01;
        public const int DTMF2 = 0x02;
        public const int DTMF3 = 0x03;
        public const int DTMF4 = 0x04;
        public const int OFFSET_RX = 0x1C;
        public const int OFFSET_TX = 0x1D;
        //private const int mask = 0x08;
       
        public SignalingSystem(int offset)
        {
            this.offset = offset;
        }
        public static SignalingSystem fromRaw(byte[] rawData, int offset)
        {
            SignalingSystem sis = new SignalingSystem(offset);
            byte oneByte = rawData[offset];
            sis.Value = oneByte;
            return sis;
        }
        public override byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            oneByte = (byte)value;
            rawData[offset] = oneByte;
            return rawData;
        }

        public void FromString(String objStr)
        {
            if ("Off".Equals(objStr))
                value = OFF;
            else if ("DTFM1".Equals(objStr))
                value = DTMF1;
            else if ("DTFM2".Equals(objStr))
                value = DTMF2;
            else if ("DTFM3".Equals(objStr))
                value = DTMF3;
            else if ("DTFM4".Equals(objStr))
                value = DTMF4;
            else
                throw new ArgumentException("Value : " + objStr + " can not be converted to SignalingSystem. Was expecting: \"Off\", \"DTMF1\", \"DTMF2\", \"DTMF3\", \"DTMF4\".");
        }

        public override string ToString()
        {
            if (OFF == value)
                return "Off";
            else if (DTMF1 == value)
                return "DTMF1";
            else if (DTMF2 == value)
                return "DTMF2";
            else if (DTMF3 == value)
                return "DTMF3";
            else if (DTMF4 == value)
                return "DTMF4";
            else
                return "Unknown";
        }
    }
}
