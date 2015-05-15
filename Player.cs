using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronWatcher
{
    public class Player
    {
        public static Player GetAvatar(string id)
        {
            string httpLine = null;
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    string[] httpArray = client.DownloadString(@"http://Hazeron.com/EmpireStandings2015/p" + id + ".html").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (httpArray.Length != 0)
                        httpLine = httpArray[0];
                }
            }
            catch (System.Net.WebException)
            {
                // Blackhole.
            }
            if (httpLine == null || !httpLine.Contains("Shores of Hazeron"))
            {
                throw new HazeronAvatarNotFoundException("Avatar Not Found");
            }
            const string start = "<title>Shores of Hazeron - ";
            const string end = "</title>";
            int startIndex = httpLine.IndexOf(start) + start.Length;
            int endIndex = httpLine.IndexOf(end) - startIndex;
            string name = httpLine.Substring(startIndex, endIndex);
            return new Player(name, id);
        }

        protected string _id;
        [System.Xml.Serialization.XmlAttribute]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        protected string _name;
        [System.Xml.Serialization.XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected string _mainId;
        [System.Xml.Serialization.XmlAttribute]
        public string MainID
        {
            get { return _mainId; }
            set { _mainId = value; }
        }
        public bool Alt
        {
            get { return !String.IsNullOrEmpty(_mainId); }
        }

        protected bool _online;
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public bool Online
        {
            get { return _online; }
            set { _online = value; }
        }

        protected int _relation;
        [System.Xml.Serialization.XmlAttribute]
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
        [System.Xml.Serialization.XmlAttribute]
        public bool Watch
        {
            get { return _watch; }
            set { _watch = value; }
        }

        protected string _note;
        [System.Xml.Serialization.XmlAttribute]
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public bool IsWatchListed
        {
            get { return _watch || _relation != 0 || !String.IsNullOrEmpty(_mainId) || !String.IsNullOrEmpty(_note); }
        }

        protected System.Windows.Forms.DataGridViewRow _listRow;
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public System.Windows.Forms.DataGridViewRow ListRow
        {
            get { return _listRow; }
            set { _listRow = value; }
        }

        protected System.Windows.Forms.DataGridViewRow _watchRow;
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public System.Windows.Forms.DataGridViewRow WatchRow
        {
            get { return _watchRow; }
            set { _watchRow = value; }
        }

        public Player()
        {
            _id = "A";
            _name = "";
            _mainId = "";
            _note = "";
        }
        public Player(string name, string id)
        {
            _id = id;
            _name = name;
            _mainId = "";
            _note = "";
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(_mainId))
                return _name;
            else
                return "<alt>" + _name + "</alt>";
        }
    }

    public class HazeronAvatarNotFoundException : Exception
    {
        public HazeronAvatarNotFoundException(string message)
            : base(message)
        {
        }
    }
}
