using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class QTReverse : ChannelParameter
    {
        public const int _120 = 0x01;
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
