using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class PrivacyNo : ChannelParameter
    {
        public PrivacyNo()
        {
            offset = 0x02;
        }
        public static PrivacyNo fromRaw(byte[] rawData)
        {
            PrivacyNo pn = new PrivacyNo();
            byte oneByte = rawData[pn.offset];
            pn.value = oneByte & 0x0f;
            return pn;
        }
        public override byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            oneByte = (byte)(oneByte & 0xf0);
            byte tmpValue = (byte)(value & 0x0f);
            oneByte = (byte)(oneByte ^ tmpValue);
            rawData[offset] = oneByte;
            return rawData;
        }
        public void FromString(String objString)
        {
            base.FromString(objString);
            value--;
        }
        public override string ToString()
        {
            return Convert.ToString(value+1);
        }
    }
}
