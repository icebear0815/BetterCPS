using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class ColorCode : ChannelParameter
    {
        public ColorCode()
        {
            offset = 0x01;
        }
        public static ColorCode fromRaw(byte[] rawData)
        {
            ColorCode cc = new ColorCode();
            byte oneByte = rawData[cc.offset];
            cc.value = oneByte >> 4;
            return cc;
        }
        public override byte[] toRaw(byte[] rawData)
        {
            byte oneByte = rawData[offset];
            byte lower = (byte) (oneByte & 0x0f);
            byte higher = (byte)(value << 4);
            oneByte = (byte) (higher ^ lower);
            rawData[offset] = oneByte;
            return rawData;
        }
    }
}
