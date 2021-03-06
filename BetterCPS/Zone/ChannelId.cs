﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.Zone
{
    class ChannelId : Parameter
    {
        public const int MAX_ID = 16;
        public ChannelId()
        {
            offset = 0x20;
        }
        public static ChannelId fromRaw(byte[] rawData, int id)
        {
            ChannelId ci = new ChannelId();
            int tmpOffset = ci.offset + (id * 2);
            byte lower = rawData[tmpOffset];
            byte upper = rawData[tmpOffset + 1];
            ci.value = upper;
            ci.value = ci.value << 8;
            ci.value ^= lower;
            return ci;
        }

        public byte[] toRaw(byte[] rawData, int id)
        {
            uint number = Convert.ToUInt32(value);
            byte upper = (byte) (number >> 8);
            byte lower = (byte) (number & 0xff);
            int tmpOffset = offset + (id * 2);
            rawData[tmpOffset] = lower;
            rawData[tmpOffset + 1] = upper;
            return rawData;
        }
    }
}
