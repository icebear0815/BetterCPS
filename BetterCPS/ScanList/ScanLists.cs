﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BetterCPS.Channel;
using BetterCPS.Helper;

namespace BetterCPS.ScanList
{
    public class ScanLists
    {
        public const int OFFSET = 0x18A85;
        public const int DATA_WIDTH = 104; 
        public const int MAX = 250;

        private const int GUID = 0;
        private const int NAME = 1;
        private const int SCANLIST = 2;
        private DataTable allScanLists;


        public ScanLists()
        {
            initDataTable();
        }

        public void initDataTable()
        {
            allScanLists = new DataTable();
            allScanLists.TableName = "BetterCPS.ScanLists";
            allScanLists.Columns.Add("GUID", typeof(String));
            allScanLists.Columns.Add("Name", typeof(String));
            allScanLists.Columns.Add("DATA", typeof(ScanListObject));
        }
        public byte[] RawDataFromScanLists()
        {
            byte[] rawData = new byte[DATA_WIDTH * MAX];
            int tmpOffset = 0;
            for (int i = 0; i < allScanLists.Rows.Count; i++)
            {
                ScanListObject oneScanList = (ScanListObject)allScanLists.Rows[i].ItemArray[SCANLIST];
                Array.Copy(oneScanList.RawData, 0, rawData, tmpOffset, DATA_WIDTH);
                tmpOffset += DATA_WIDTH;
            }
            return rawData;
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
                    Console.WriteLine(ch.ToString());
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
            return (ScanListObject)allScanLists.Rows[IdConvInput(id)].ItemArray[SCANLIST];
        }

        public ScanListObject getObjectByGUID(String guid)
        {
            DataRow[] result = allScanLists.Select("GUID = '" + guid + "'");
            if (result != null)
                return (ScanListObject)result[0].ItemArray[SCANLIST];
            return null;
        }

        private int IdConvInput(int id)
        {
            return id - 1;
        }
        private int IdConvOutput(int id)
        {
            return id + 1;
        }
        public String getNameById(int id)
        {
            return (String)allScanLists.Rows[IdConvInput(id)].ItemArray[NAME];
        }

        public String getGUIDById(int id)
        {
            return (String)allScanLists.Rows[IdConvInput(id)].ItemArray[GUID];
        }

        public int getIdByGUID(String guid)
        {
            if ("None".Equals(guid)) return 0;
            DataRow[] result = allScanLists.Select("GUID = '" + guid + "'");
            if (result != null)
                return IdConvOutput(allScanLists.Rows.IndexOf(result[0]));
            return 0;
        }

        public int getIdByName(String name)
        {
            if ("None".Equals(name)) return 0;
            DataRow[] result = allScanLists.Select("Name = '" + name + "'");
            if (result != null && result.Length>0)
                return IdConvOutput(allScanLists.Rows.IndexOf(result[0]));
            return 0;
        }

        public String[] ToCSV(Channels allChannels, bool withGUID)
        {
            int size = allScanLists.Rows.Count + 1; //count + header line
            String[] allLines = new String[size];
            allLines[0] = "GUID;Name;Channel1;Channel2;Channel3;Channel4;Channel5;Channel6;Channel7;Channel8;Channel9;Channel10;Channel11;Channel12;Channel13;Channel14;Channel15;Channel16";
            for (int i = 0; i < allScanLists.Rows.Count; i++)
            {
                ScanListObject oneScanList = (ScanListObject)allScanLists.Rows[i].ItemArray[SCANLIST];
                if (withGUID && !Tools.IsEmpty(oneScanList.ScanListName))
                {
                    allLines[i + 1] = oneScanList.ToString(allChannels, true);
                }
                else
                {
                    if (!Tools.IsEmpty(oneScanList.ScanListName))
                        allLines[i + 1] = oneScanList.ToString(allChannels);
                }

            }
            return allLines;
        }
        public String[] ToCSV(Channels allChannels)
        {
            return ToCSV(allChannels, false);
        }

        public void FromCSV(String[] csvData, Channels allChannels, bool withGUID)
        {
            initDataTable();
            for (int i = 1; i < csvData.Length; i++) //skip line with index 0 - it's the header line
            {
                if (csvData[i].Length > 0)
                {
                    ScanListObject oneScanList = new ScanListObject();
                    oneScanList.SetDataFromCSV(csvData[i], allChannels, withGUID);
                    if (Debug.GetInstance().DebugOn)
                    {
                        Console.WriteLine("In:  " + csvData[i]);
                        Console.WriteLine("Out: " + oneScanList.ToString(allChannels));
                    }
                    AddScanList(oneScanList);
                }
            }
        }
        public void SaveToXML(String path)
        {
            allScanLists.WriteXml(path);
        }
        public void ReadFromXML(String path)
        {
            allScanLists.ReadXml(path);
        }
    }
}
