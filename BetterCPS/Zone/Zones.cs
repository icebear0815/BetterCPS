using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BetterCPS.Channel;

namespace BetterCPS.Zone
{
    class Zones
    {
        public const int OFFSET = 0x14C05;
        public const int DATA_WIDTH = 64; 
        public const int MAX = 250;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int ZONE = 2;
        private DataTable allZones;

        
        public Zones()
        {
            initDataTable();
        }

        private void initDataTable()
        {
            allZones = new DataTable();
            allZones.Columns.Add("GUID", typeof(String));
            allZones.Columns.Add("Name", typeof(String));
            allZones.Columns.Add("DATA", typeof(ZoneObject));
        }
        public void ZonesFromRawData(byte[] rawData, bool debug)
        {
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                //Console.WriteLine("Zones: "+i);
                String hex;
                byte[] oneZoneRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneZoneRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                ZoneObject ch = new ZoneObject();
                ch.RawData = oneZoneRaw;
                AddZone(ch);
                if (debug)
                {
                    Console.WriteLine(ch.toString());
                    oneZoneRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneZoneRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddZone(ZoneObject oneZone)
        {
            allZones.Rows.Add(oneZone.GUID, oneZone.ZoneName, oneZone);
        }

        public ZoneObject getObjectById(int id)
        {
            return (ZoneObject)allZones.Rows[id - 1].ItemArray[ZONE];
        }
        private int IdConvInput(int id)
        {
            return id - 1;
        }
        private int IdConvOutput(int id)
        {
            return id + 1;
        }
        public ZoneObject getObjectByGUID(String guid)
        {
            DataRow[] result = allZones.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ZoneObject)result[0].ItemArray[ZONE];
            return null;
        }
        
        public String getNameById(int id)
        {
            return (String)allZones.Rows[IdConvInput(id)].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allZones.Rows[IdConvInput(IdConvInput(id))].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allZones.Select("GUID = '" + guid + "'");
            if (result != null)
                return IdConvOutput(allZones.Rows.IndexOf(result[0]));
            return -1;
        }

        public String[] ToCSV(Channels allChannels)
        {
            int size = allZones.Rows.Count + 1; //count + header line
            String[] allLines = new String[size];
            allLines[0] = "GUID;Name;Channel1;Channel2;Channel3;Channel4;Channel5;Channel6;Channel7;Channel8;Channel9;Channel10;Channel11;Channel12;Channel13;Channel14;Channel15;Channel16";
            for (int i = 0; i < allZones.Rows.Count; i++)
            {
                ZoneObject oneZone = (ZoneObject)allZones.Rows[i].ItemArray[ZONE];
                if (!"".Equals(oneZone.ZoneName) && !oneZone.ZoneName.StartsWith("\0"))
                    allLines[i + 1] = oneZone.ToString(allChannels);

            }
            return allLines;
        }

        public void FromCSV(String[] csvData, Channels allChannels)
        {
            initDataTable();
            for (int i = 1; i < csvData.Length; i++) //skip line with index 0 - it's the header line
            {
                ZoneObject oneZone = new ZoneObject();
                oneZone.SetDataFromCSV(csvData[i], allChannels);
                Console.WriteLine("In:  " + csvData[i]);
                Console.WriteLine("Out: " + oneZone.ToString(allChannels));
                AddZone(oneZone);
            }
        }
    }
}
