using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Channel
{
    class ChannelName : ChannelParameter
    {
        private const int maxLength = 16;
        private String name;
        public ChannelName()
        {
            offset = 0x20;
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public static ChannelName fromRaw(byte[] rawData)
        {
            ChannelName cn = new ChannelName();
            cn.Name = System.Text.Encoding.Unicode.GetString(rawData, cn.offset, 32);
            if (cn.Name != null)
                cn.Name = cn.Name.Replace("\0"," ").Trim();
            return cn;
        }

        public override byte[] toRaw(byte[] rawData)
        {
            if (name != null)
            {
                if (name.Length == 0) name = "\0";
                name = name.PadRight(maxLength, '\0');
                byte[] buffer = System.Text.Encoding.Unicode.GetBytes(name.Substring(0, maxLength));
                Array.Copy(buffer, 0, rawData, offset, (maxLength*2));
            }
            return rawData;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
