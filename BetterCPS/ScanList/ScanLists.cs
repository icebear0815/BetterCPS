using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BetterCPS.ScanList
{
    class ScanLists
    {
        public const int OFFSET = 0x18A85;
        public const int DATA_WIDTH = 104; 
        public const int MAX = 250;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int ScanList = 2;
        private DataTable allScanLists;


        public ScanLists()
        {
            allScanLists = new DataTable();
            allScanLists.Columns.Add("GUID", typeof(String));
            allScanLists.Columns.Add("Name", typeof(String));
            allScanLists.Columns.Add("DATA", typeof(ScanListObject));
        
        }

        public void ScanListsFromRawData(byte[] rawData, bool debug)
        {
            int offset = OFFSET;
            for (int i = 0; i < MAX; i++)
            {
                //Console.WriteLine("ScanLists: "+i);
                String hex;
                byte[] oneScanListRaw = new byte[DATA_WIDTH];
                for (int j = 0; j < DATA_WIDTH; j++)
                {
                    byte value = rawData[offset + j];
                    oneScanListRaw[j] = value;
                    if (debug)
                    {
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                }
                if (debug) Console.WriteLine();
                offset += DATA_WIDTH;
                ScanListObject ch = new ScanListObject();
                ch.RawData = oneScanListRaw;
                AddScanList(ch);
                if (debug)
                {
                    Console.WriteLine(ch.toString());
                    oneScanListRaw = ch.RawData;
                    for (int j = 0; j < DATA_WIDTH; j++)
                    {
                        byte value = oneScanListRaw[j];
                        hex = string.Format("{0:X2}", value);
                        Console.Write(hex + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void AddScanList(ScanListObject oneScanList)
        {
            allScanLists.Rows.Add(oneScanList.GUID, oneScanList.ScanListName, oneScanList);
        }

        public ScanListObject getObjectById(int id)
        {
            return (ScanListObject)allScanLists.Rows[id-1].ItemArray[ScanList];
        }

        public ScanListObject getObjectByGUID(String guid)
        {
            DataRow[] result = allScanLists.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ScanListObject) result[0].ItemArray[ScanList];
            return null;
        }
        
        public String getNameById(int id)
        {
            return (String)allScanLists.Rows[id].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allScanLists.Rows[id].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            DataRow[] result = allScanLists.Select("GUID = '" + guid + "'");
            if (result != null)
                return allScanLists.Rows.IndexOf(result[0]);
            return -1;
        }

    }
}
