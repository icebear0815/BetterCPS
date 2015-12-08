using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class TXFrequency : Frequency
    {
        static int offset = 0x14; //20
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public static TXFrequency fromRaw(byte[] rawData)
        {
            TXFrequency txf = new TXFrequency();
            byte[] bcdBytes = new byte[4];
            Array.Copy(rawData, offset, bcdBytes, 0, 4);
            if ((bcdBytes[0] ^ 0xff) > 0 && (bcdBytes[1] ^ 0xff) > 0 && (bcdBytes[2] ^ 0xff) > 0 && (bcdBytes[3] ^ 0xff) > 0)
            {
                txf.fromBCD(bcdBytes);
            }
            else
            {
                txf.Value = -1;
            }
            return txf;
        }
        public byte[] toRaw(byte[] rawData)
        {
            byte[] bcdBytes;
            if (value == -1)
            {
                bcdBytes = new byte[] { 0xff, 0xff, 0xff, 0xff };
            }
            else
            {
                bcdBytes = this.toBCD();
            }
            Array.Copy(bcdBytes, 0, rawData, offset, 4);
            return rawData;
        }

        public override String ToString()
        {
            if (value == -1)
                return "40000000";
            else
                return base.ToString();
        }
    }
}
