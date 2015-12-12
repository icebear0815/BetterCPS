using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BetterCPS.Contact;
using BetterCPS.RXGroup;
using BetterCPS.ScanList;
using BetterCPS.Zone;

namespace BetterCPS.Channel
{
    class Channels
    {
        public const int OFFSET = 0x1f025;
        public const int DATA_WIDTH = 64; 
        public const int MAX = 1000;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int CHANNEL = 2;
        private DataTable allChannels;
        

        public Channels()
        {
            initDataTable();
        }
        private void initDataTable()
        {
            allChannels = new DataTable();
            allChannels.Columns.Add("GUID", typeof(String));
            allChannels.Columns.Add("Name", typeof(String));
            allChannels.Columns.Add("DATA", typeof(ChannelObject));
        }

        public byte[] RawDataFromChannels()
        {
            byte[] rawData = new byte[DATA_WIDTH * MAX];
            int tmpOffset = 0;
            for (int i = 0; i < allChannels.Rows.Count; i++)
            {
                ChannelObject oneChannel = (ChannelObject)allChannels.Rows[i].ItemArray[CHANNEL];
                Array.Copy(oneChannel.RawData, 0, rawData, tmpOffset, DATA_WIDTH);
                tmpOffset += DATA_WIDTH;
            }
            return rawData;
        }

        public void ChannelsFromRawData(byte[] rawData, bool debug)
        {
            initDataTable();
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                String hex;
                byte[] oneChannelRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneChannelRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                ChannelObject ch = new ChannelObject();
                ch.RawData = oneChannelRaw;
                AddChannel(ch);
                if (debug)
                {
                    Console.WriteLine(ch.ToString());
                    oneChannelRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneChannelRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        private int IdConvInput(int id)
        {
            return id - 1;
        }
        private int IdConvOutput(int id)
        {
            return id + 1;
        }
           
        public void AddChannel(ChannelObject oneChannel)
        {
            allChannels.Rows.Add(oneChannel.GUID, oneChannel.Name, oneChannel);
        }

        public ChannelObject getObjectById(int id)
        {
            return (ChannelObject)allChannels.Rows[IdConvInput(id)].ItemArray[CHANNEL];
        }

        public ChannelObject getObjectByGUID(String guid)
        {
            DataRow[] result = allChannels.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ChannelObject) result[0].ItemArray[CHANNEL];
            return null;
        }
        
        public String getNameById(int id)
        {
            if (IdConvInput(id) < 0)
                return "";
            else
                return (String)allChannels.Rows[IdConvInput(id)].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allChannels.Rows[IdConvInput(id)].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allChannels.Select("GUID = '" + guid + "'");
            if (result != null)
                return IdConvOutput(allChannels.Rows.IndexOf(result[0]));
            return -1;
        }

        public int getIdByName(String name)
        {
            DataRow[] result = allChannels.Select("Name = '" + name + "'");
            if (result != null)
                return IdConvOutput(allChannels.Rows.IndexOf(result[0]));
            return -1;
        }

        public String[] ToCSV(Contacts allContacts, RXGroups allRXGroups, ScanLists allScanLists, Zones allZones)
        {
            int size = allChannels.Rows.Count + 1; //count + header line
            String[] allLines = new String[size];
            allLines [0] = "GUID;Mode;ChannelName;RxFreq;TxFreq;BW;ScnLst;Sql;RxRef;TxRef;TOT;Rekey;Power;Admit;AScn;RxOnly;Lone;VOX;ATA;Enc;Dec;QtRev;RxSig;TxSig;RBurst;PTTID;Dec1;Dec2;Dec3;Dec4;Dec5;Dec6;Dec7;Dec8;PCC;EAA;DCC;UDP;ESyst;Contact;GrpLst;Color;Priv;PrivNo;Slot";
            for (int i = 0; i < allChannels.Rows.Count; i++)
            {
                ChannelObject oneChannel = (ChannelObject)allChannels.Rows[i].ItemArray[CHANNEL];
                if (oneChannel.Mode.Mode == ChannelMode.ANALOG || oneChannel.Mode.Mode == ChannelMode.DIGITAL)
                    allLines[i+1] = oneChannel.ToString(allContacts, allRXGroups, allScanLists, allZones);

            }
            return allLines;
        }

        public void FromCSV(String[] csvData, Contacts allContacts, RXGroups allRXGroups, ScanLists allScanLists, Zones allZones, bool debug)
        {
            initDataTable();
            for (int i = 1; i < csvData.Length; i++) //skip line with index 0 - it's the header line
            {
                if (csvData[i].Length > 0)
                {
                    ChannelObject oneChannel = new ChannelObject();
                    oneChannel.SetDataFromCSV(csvData[i], allContacts, allRXGroups, allScanLists, allZones);
                    if (debug)
                    {
                        Console.WriteLine("In:  " + csvData[i]);
                        Console.WriteLine("Out: " + oneChannel.ToString(allContacts, allRXGroups, allScanLists, allZones));
                    }
                    AddChannel(oneChannel);
                }
            }
        }
    }
}
