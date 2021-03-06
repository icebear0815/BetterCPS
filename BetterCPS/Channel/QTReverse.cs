﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class QTReverse : ChannelParameter
    {
        public const int _120 = 0x08;
        public const int _180 = 0x00;
        

        public QTReverse()
        {
            mask = 0x08;
            offset = 0x04;
        }
        
        public static QTReverse fromRaw(byte[] rawData)
        {
            QTReverse qt = new QTReverse();
            byte oneByte = rawData[qt.offset];
            qt.Value = oneByte & qt.mask; 
            return qt;
        }

        public void FromString(String objStr)
        {
            if ("120".Equals(objStr))
                value = _120;
            else if ("180".Equals(objStr))
                value = _180;
            else
                throw new ArgumentException("Value: " + objStr + " can not be converted to QTReverse. Was Expecting \"120\",\"180\".");
        }
        
        public override string ToString()
        {
            if (_120 == value)
                return "120";
            else if (_180 == value)
                return "180";
            else
                return "Unknown";
        }
    }
}
