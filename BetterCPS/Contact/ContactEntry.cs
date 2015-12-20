using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BetterCPS.Helper;

namespace BetterCPS.Contact
{
    class ContactEntry
    {
        /*
           Contacts (36 bytes per entry)
            Byte	function
            0	ID low byte			FF if blank
            1	ID mid byte			FF if blank
            2	ID high byte		FF if blank
            3	Bit
         *          7       unknown, high
         *          6       unknown, high
         *          5       Call Receive tone low = no, high = yes
         *          4       unknown, low
         *          3       unknown, low
         *          2       unknown, low
         *          1       Type high bit
         *          0       Type low bit
         *                  Type      0=blank, 1=Group, 2=Private, 3=All   (Ex=Call Tone)
            4	Name Low byte of first character
            5	Name High byte of first character
            6-35	Name, remaining 15 characters.
         */

        public const int offset = 0x061A5;
        public const int Length = 36;

        public const int _GUID = -1;
        public const int _NAME = 0;
        public const int _TYPE = 1;
        public const int _CALLID = 2;
        public const int _CALLRECEIVETONE = 3;

        byte[] rawData;

        private CallId callId;
        private CType cType;
        private BaseName name;

        internal String ContactName
        {
            get { return name.Value; }
            set { name.Value = value; }
        }
        private CallReceiveTone callReceiveTone = new CallReceiveTone(0x03, 5);
        private String guid;

        public ContactEntry()
        {
            guid = System.Guid.NewGuid().ToString();
            initializeRawData();
            setDataFromRawData();
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
            rawData = new byte[] { 0x00, 0x00, 0x00, 0xC0,  
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                   0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        }
        private void setRawDataFromData()
        {
            initializeRawData();

            rawData = callId.toRaw(rawData);
            rawData = cType.toRaw(rawData);
            rawData = callReceiveTone.toRaw(rawData);
            rawData = name.toRaw(rawData);
        }
        private void setDataFromRawData()
        {
            callId = CallId.fromRaw(rawData);
            cType = CType.fromRaw(rawData);
            callReceiveTone.fromRaw(rawData);
            name = Name.fromRaw(rawData);
        }

        public void SetDataFromCSV(String csvData)
        {
            String[] allFields = csvData.Split(';');
            //guid = allFields[_GUID];
            name.Value = allFields[_NAME];
            cType.FromString(allFields[_TYPE]);
            callId.FromString(allFields[_CALLID]);
            callReceiveTone.FromString(allFields[_CALLRECEIVETONE]);
        }

       public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(guid);
            //sb.Append(";");
            sb.Append(name);
            sb.Append(";");
            sb.Append(cType);
            sb.Append(";");
            sb.Append(callId);
            sb.Append(";");
            sb.Append(callReceiveTone);
            
            return sb.ToString();
        }

    }
}
