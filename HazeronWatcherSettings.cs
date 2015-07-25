using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace HazeronWatcher
{
    [Serializable]
    public class HazeronWatcherSettings
    {
        [XmlElement]
        public HazeronWatcherSettingsOptions Options { get; set; }

        [XmlElement]
        public HazeronWatcherSettingsAvatars AvatarList { get; set; }

        public HazeronWatcherSettings()
        {
            Options = new HazeronWatcherSettingsOptions();
            AvatarList = new HazeronWatcherSettingsAvatars();
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
        public bool PlaySound { get; set; }

        public HazeronWatcherSettingsOptions()
        {
            Version = 0;
            ShowIdColumn = false;
            ShowWatchHighlight = true;
            ShowWatchList = true;
            PlaySound = true;
        }
    }

    public class HazeronWatcherSettingsAvatars
    {
        [XmlElement]
        public List<Avatar> Avatar { get; set; }

        public HazeronWatcherSettingsAvatars()
        {
            Avatar = new List<Avatar>();
        }
    }
}
