using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace HazeronWatcher
{
    namespace HazeronWatcherOLD
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

        public class Player
        {
            protected string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            protected string _id;
            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }

            protected bool _online;
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public bool Online
            {
                get { return _online; }
                set { _online = value; }
            }

            protected int _relation;
            public int Relation
            {
                get { return _relation; }
                set { _relation = value; }
            }
            public bool Empire
            {
                get { return _relation >= 2; }
            }
            public bool Friend
            {
                get { return _relation == 1; }
            }
            public bool Unsure
            {
                get { return _relation == -1; }
            }
            public bool Enemy
            {
                get { return _relation <= -2; }
            }

            protected bool _watch;
            public bool Watch
            {
                get { return _watch; }
                set { _watch = value; }
            }

            protected System.Windows.Forms.DataGridViewRow _listRow;
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public System.Windows.Forms.DataGridViewRow ListRow
            {
                get { return _listRow; }
                set { _listRow = value; }
            }

            protected System.Windows.Forms.DataGridViewRow _WatchRow;
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public System.Windows.Forms.DataGridViewRow WatchRow
            {
                get { return _WatchRow; }
                set { _WatchRow = value; }
            }

            public Player()
            {
            }
            public Player(string name, string id)
            {
                _name = name;
                _id = id;
            }

            public HazeronWatcher.Player ToNewPlayer()
            {
                HazeronWatcher.Player newPlayer = new HazeronWatcher.Player();
                newPlayer.ID = _id;
                newPlayer.Name = _name;
                newPlayer.Relation = _relation;
                newPlayer.Watch = _watch;
                return newPlayer;
            }

            public override string ToString()
            {
                return _name;
            }
        }
    }
}