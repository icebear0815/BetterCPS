using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class Frequency
    {
        int freq; //in Hz

        public int Freq
        {
            get { return freq; }
            set { freq = value; }
        }

        public byte[] toBCD()
        {
            String freqStr = "" + freq;
            if ((freqStr.Length % 2) > 0)
                freqStr = "0" + freqStr;
            byte[] bcdBytes = new byte[(freqStr.Length/2)];
            int cnt = 0;
            for (int i = freqStr.Length; i > 0; i -= 2)
            {
                String sub = freqStr.Substring(i - 2, 2);
                int value = Convert.ToInt32(sub, 16);
                bcdBytes[cnt++] = (byte)value;
            }
            return bcdBytes;
        }
        public void fromBCD(byte[] bcdBytes)
        {
            //00 25 99 43 = 439.92500
            StringBuilder sb = new StringBuilder();
            for (int i = bcdBytes.Length-1; i >= 0; i--)
            {
                sb.Append(string.Format("{0:X2}", bcdBytes[i]));
            }
            String freqStr = sb.ToString();
            try
            {
                freq = Int32.Parse(freqStr);
            }
            catch (FormatException f)
            {
                Console.WriteLine("Error parsing BCD Code: " + freqStr);
                Console.WriteLine(f.StackTrace);
            }
        }

        public override String ToString()
        {
            return "" + freq;
            //return string.Format("{##,#}", freq);
        }
    }
    
}
