using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class CTCSS : Frequency
    {
        public const int OFFSET_ENC = 0x1A;
        public const int OFFSET_DEC = 0x18;
        private int offset;
        //private int value;

        /*public int Value
        {
          get { return this.value; }
          set { this.value = value; }
        }*/
        public CTCSS(int offset)
        {
            this.offset = offset;
        }
        public static CTCSS fromRaw(byte[] rawData,int offset)
        {
            CTCSS ctcss = new CTCSS(offset);
            byte[] bcdBytes = new byte[2];
            Array.Copy(rawData, offset, bcdBytes, 0, 2);
            if ((bcdBytes[0] ^ 0xff) > 0 && (bcdBytes[1] ^ 0xff) > 0)
            {
                ctcss.fromBCD(bcdBytes);
            }
            else
            {
                ctcss.Freq = 0xffff;
            }
            return ctcss;
        }
        public byte[] toRaw(byte[] rawData)
        {
            byte[] bcdBytes;
            if (Freq == 0xffff)
            {
                bcdBytes = new byte[] { 0xff, 0xff };
            }
            else
            {
                bcdBytes = this.toBCD();
            }
            Array.Copy(bcdBytes, 0, rawData, offset, 2);
            return rawData;
        }
        /*
        public void FromString(String objStr)
        {
            if ("None".Equals(objStr))
                value = -1;
            base.FromString(objStr);
        }*/
        public override String ToString()
        {
            if (Freq == 0xffff)
                return "None";
            else
                return base.ToString();
        }
    }
}
