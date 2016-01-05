using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterCPS
{
    public class Project
    {
        private String projectPath;

        public String ProjectPath
        {
            get { return projectPath; }
            set { projectPath = value; }
        }
        private String channelPath;

        public String ChannelPath
        {
            get { return channelPath; }
            set { channelPath = value; }
        }
        private String contactPath;

        public String ContactPath
        {
            get { return contactPath; }
            set { contactPath = value; }
        }
        private String scanListPath;

        public String ScanListPath
        {
            get { return scanListPath; }
            set { scanListPath = value; }
        }
        private String zonePath;

        public String ZonePath
        {
            get { return zonePath; }
            set { zonePath = value; }
        }
        private String rxGroupPath;

        public String RxGroupPath
        {
            get { return rxGroupPath; }
            set { rxGroupPath = value; }
        }
        private String codeplugName;

        public String CodeplugName
        {
            get { return codeplugName; }
            set { codeplugName = value; }
        }

        private byte[] codeplugRawData;

        public byte[] CodeplugRawData
        {
            get { return codeplugRawData; }
            set { codeplugRawData = value; }
        }
        
        public Project()
        {
            //codeplugName = "No codeplug imported";
        }

        public void ExportToXML(String path)
        {
            System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(Project));

            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, this);

            file.Close();
        }

        public static Project ImportFromXML(String path)
        {
            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(Project));

            System.IO.FileStream file = System.IO.File.OpenRead(path);

            Project newProject = (Project)reader.Deserialize(file);

            file.Close();
            return newProject;
        }
    }
}
