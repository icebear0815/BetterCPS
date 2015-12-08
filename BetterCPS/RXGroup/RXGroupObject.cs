using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.RXGroup
{
    /*
        Rx Groups (96 bytes per entry)
            Byte	function
            0	Name Low Byte of first character 
            1	Name High Byte of first character 
            2-31	Name, Remaining 15 characters
            32	Index number of Contact Low Byte
            33	Index number of Contact High Byte
            34-95	Index numbers of remaining Contacts (up to 32entries 2 bytes per entry)

     */

    class RXGroupObject
    {
        public const int offset = 0x0EE45;
        public const int Length = 96;
        public const int maxCount = 250;

        byte[] rawData;
        BaseName name;

        internal String RXGroupName
        {
            get { return name.Value; }
            set { name.Value = value; }
        }
        ContactId[] contactIDs = new ContactId[ContactId.MAX_ID];
        private String guid;

        public RXGroupObject()
        {
            guid = System.Guid.NewGuid().ToString();
        }

        public String GUID
        {
            get { return guid; }
            set { guid = value; }
        }

        public byte[] RawData
        {
            get
            {
                setRawDataFromData();
                return rawData;
            }
            set
            {
                rawData = value;
                setDataFromRawData();
            }
        }

        private void initializeRawData()
        {
            rawData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        }
        private void setRawDataFromData()
        {
            initializeRawData();

            rawData = name.toRaw(rawData);
            for (int i = 0; i < ContactId.MAX_ID; i++)
            {
                rawData = contactIDs[i].toRaw(rawData, i);
            }
        }

        private void setDataFromRawData()
        {
            name = Name.fromRaw(rawData);
            for (int i = 0; i < ContactId.MAX_ID; i++)
            {
                contactIDs[i] = ContactId.fromRaw(rawData, i);
            }
        }

        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(guid);
            sb.Append(";");
            sb.Append(name);
            for (int i = 0; i < ContactId.MAX_ID; i++)
            {
                sb.Append(";");
                sb.Append(contactIDs[i]);
            }
            return sb.ToString();
        }
    }
}
