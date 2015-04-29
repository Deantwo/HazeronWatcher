using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronWatcher
{
    public class Player
    {
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
            //_id = "A";
            //_name = "";
        }
        public Player(string name, string id)
        {
            _id = id;
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
