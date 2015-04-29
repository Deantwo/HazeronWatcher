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
        public bool ShowIdColumn { get; set; }

        [XmlElement]
        public bool ShowWatchHighlight { get; set; }

        [XmlElement]
        public bool ShowNonWatched { get; set; }

        [XmlElement]
        public bool PlaySound { get; set; }

        [XmlElement]
        public List<Player> PlayerList { get; set; }

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
}
