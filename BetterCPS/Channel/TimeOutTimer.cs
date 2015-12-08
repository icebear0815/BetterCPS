using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class TimeOutTimer : ChannelParameter
    {
        private int tot;

        public TimeOutTimer()
        {
            offset = 0x08;
        }
        public int Tot
        {
            get { return tot; }
            set { tot = value; }
        }

        public static TimeOutTimer fromRaw(byte[] rawData)
        {
            TimeOutTimer to = new TimeOutTimer();
            byte oneByte = rawData[to.offset];
            to.Tot = oneByte;
            return to;
        }
        public override byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            oneByte |= (byte)tot;
            rawData[offset] = oneByte;
            return rawData;
        }

        public void fromString(String value)
        {
            int val = Int32.Parse(value);
            if ((val % 15 == 0) && val <= 555)
            {
                val /= 15;
                tot = val;
            }
            else
                throw new Exception("Unknown value for TOT[s]. Try to convert value: " + value);
        }
        public override string ToString()
        {
            return "" + (tot * 15);
        }
    }
}
