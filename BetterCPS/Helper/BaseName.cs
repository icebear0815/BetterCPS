using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS.Helper
{
    class BaseName : Parameter
    {
        new protected String value;
        public BaseName()
        {
            offset = 0x04;
        }
        public BaseName(int offset)
        {
            this.offset = offset;
        }
        public BaseName(int offset, byte[] rawData) : this(offset)
        {
            value = System.Text.Encoding.Unicode.GetString(rawData, offset, 32);
            if (value != null)
               value = value.Replace("\0", " ").Trim();
        }
        new public String Value
        {
            get { return value; }
            set { this.value = value; }
        }
        
        public override byte[] toRaw(byte[] rawData)
        {
            if (value != null)
            {
                if (value.Length == 0) value = " ";
                value = value.PadRight(16, '\0');
                byte[] buffer = System.Text.Encoding.Unicode.GetBytes(value.Substring(0, 16));
                Array.Copy(buffer, 0, rawData, offset, 32);
            }
            return rawData;
        }

        public override string ToString()
        {
            return value;
        }
    }
}
