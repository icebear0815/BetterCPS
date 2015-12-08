using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class RXFrequency : Frequency
    {
        static int offset = 0x10; //16
        public static RXFrequency fromRaw(byte[] rawData)
        {
            RXFrequency rxf = new RXFrequency();
            byte[] bcdBytes = new byte[4];
            Array.Copy(rawData, offset, bcdBytes, 0, 4);
            rxf.fromBCD(bcdBytes);
            return rxf;
        }
        public byte[] toRaw(byte[] rawData)
        {
            byte[] bcdBytes = this.toBCD();
            Array.Copy(bcdBytes, 0, rawData, offset, 4);
            return rawData;
        }

        public override String ToString()
        {
            return base.ToString();
        }
    }
}
