using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class RXFrequency : Frequency
    {
        static int offset = 0x10; //16
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public static RXFrequency fromRaw(byte[] rawData)
        {
            RXFrequency rxf = new RXFrequency();
            byte[] bcdBytes = new byte[4];
            Array.Copy(rawData, offset, bcdBytes, 0, 4);
            if ((bcdBytes[0] ^ 0xff) > 0 && (bcdBytes[1] ^ 0xff) > 0 && (bcdBytes[2] ^ 0xff) > 0 && (bcdBytes[3] ^ 0xff) > 0)
            {
                rxf.fromBCD(bcdBytes);
            }
            else
            {
                rxf.Value = -1;
            }
            
            return rxf;
        }
        public byte[] toRaw(byte[] rawData)
        {
            byte[] bcdBytes;
            if (value == -1)
            {
                bcdBytes = new byte[] { 0xff, 0xff , 0xff, 0xff};
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
