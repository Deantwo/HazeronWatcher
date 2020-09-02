using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace HazeronWatcher
{
    [Serializable]
    [XmlRoot(ElementName = "HazeronWatcherSettings", Namespace = "")]
    public class HazeronWatcherSettings
    {
        [XmlElement]
        public HazeronWatcherSettingsOptions Options { get; set; }
        
        [XmlArray("AvatarList")]
        [XmlArrayItem("Avatar")]
        public List<Avatar> AvatarList { get; set; }
        
        [XmlArray("EmpireList")]
        [XmlArrayItem("Empire")]
        public List<Empire> EmpireList { get; set; }
        
        [XmlArray("WatchGroupList")]
        [XmlArrayItem("WatchGroup")]
        public List<WatchGroup> WatchGroupList { get; set; }

        public HazeronWatcherSettings()
        {
            Options = new HazeronWatcherSettingsOptions();
            AvatarList = new List<Avatar>();
            EmpireList = new List<Empire>();
            WatchGroupList = new List<WatchGroup>();
        }

        public void Save(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HazeronWatcherSettings));
            TextWriter textWriter = new StreamWriter(filePath);
            serializer.Serialize(textWriter, this);
            textWriter.Close();
        }

        public static HazeronWatcherSettings Load(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HazeronWatcherSettings));
            TextReader reader = new StreamReader(filePath);
            HazeronWatcherSettings data = (HazeronWatcherSettings)serializer.Deserialize(reader);
            reader.Close();

            return data;
        }
    }

    public class HazeronWatcherSettingsOptions
    {
        [XmlAttribute]
        public int Version { get; set; }

        [XmlElement]
        public bool ShowIdColumn { get; set; }

        [XmlElement]
        public bool ShowWatchHighlight { get; set; }

        [XmlElement]
        public bool ShowWatchList { get; set; }

        [XmlElement]
        public bool ShowRecentList { get; set; }

        [XmlElement]
        public bool PlaySound { get; set; }

        [XmlElement]
        public bool BallonTip { get; set; }

        [XmlElement]
        public bool MinimizeToTray { get; set; }

        public HazeronWatcherSettingsOptions()
        {
            Version = 2;
            ShowIdColumn = false;
            ShowWatchHighlight = true;
            ShowWatchList = true;
            ShowRecentList = true;
            PlaySound = true;
            BallonTip = true;
            MinimizeToTray = false;
        }
    }
}
