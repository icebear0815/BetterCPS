using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class ContactId : ChannelParameter
    {
        public ContactId()
        {
            offset = 0x06;
        }
        public static ContactId fromRaw(byte[] rawData)
        {
            ContactId ci = new ContactId();
            byte lower = rawData[ci.offset];
            byte upper = rawData[ci.offset + 1];
            ci.value = upper;
            ci.value = ci.value << 8;
            ci.value ^= lower;
            return ci;
        }

        public override byte[]  toRaw(byte[] rawData)
        {
            ushort number = Convert.ToUInt16(value);
            byte upper = (byte) (number >> 8);
            byte lower = (byte) (number & 0xff);
            rawData[offset] = lower;
            rawData[offset + 1] = upper;
            return rawData;
        }
    }
}
