using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class ChannelMode : ChannelParameter
    {
        public const int DIGITAL = 0x02;
        public const int ANALOG = 0x01;
        private int mode;
        public static ChannelMode fromRaw(byte[] rawData)
        {
            ChannelMode m = new ChannelMode();
            byte oneByte = rawData[0];
            m.mode = oneByte & 0x03; //00000011 as bits 0 and 1 are used for mode
            return m;
        }
        public override byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[0];
            oneByte |= (byte)mode;
            rawData[0] = oneByte;
            return rawData;
        }
        public ChannelMode()
        {

        }
        public ChannelMode(int mode)
        {
            this.mode = mode;
        }
        public int Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        public void fromString(String modeString)
        {
            if ("Analog".Equals(modeString))
                mode = ANALOG;
            else if ("Digital".Equals(modeString))
                mode = DIGITAL;
            else
                throw new Exception("Invalid mode: "+modeString+" (Analog/Digital)");
        }
        public override String ToString()
        {
            if (mode == null)
                return null;
            if (mode == DIGITAL)
                return "Digital";
            if (mode == ANALOG)
                return "Analog";
            return "Unknown";
        }
    }
}
