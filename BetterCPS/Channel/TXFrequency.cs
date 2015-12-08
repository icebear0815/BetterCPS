using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class TXFrequency : Frequency
    {
        static int offset = 0x14; //20
        public static TXFrequency fromRaw(byte[] rawData)
        {
            TXFrequency txf = new TXFrequency();
            byte[] bcdBytes = new byte[4];
            Array.Copy(rawData, offset, bcdBytes, 0, 4);
            txf.fromBCD(bcdBytes);
            return txf;
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
