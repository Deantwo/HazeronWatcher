using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace HazeronWatcher
{
    [XmlRoot(ElementName = "WatchGroup", Namespace = "")]
    public class WatchGroup
    {
        protected int _id;
        [XmlAttribute]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        protected string _name;
        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

#if Argb
        protected int _groupColorArgb;
        [XmlAttribute]
        public int GroupColorArgb
        {
            get { return _groupColorArgb; }
            set { _groupColorArgb = value; }
        }
        [XmlIgnore]
        public System.Drawing.Color GroupColor
        {
            get { return System.Drawing.Color.FromArgb(_groupColorArgb); }
            set { _groupColorArgb = value.ToArgb(); }
        }
#else
        protected System.Drawing.Color _groupColor;
        [XmlIgnore]
        public System.Drawing.Color GroupColor
        {
            get { return _groupColor; }
            set { _groupColor = value; }
        }
        [XmlAttribute]
        public int GroupColorArgb
        {
            get { return _groupColor.ToArgb(); }
            set { _groupColor = System.Drawing.Color.FromArgb(value); }
        }
#endif

        protected bool _notify;
        [XmlAttribute]
        public bool Notify
        {
            get { return _notify; }
            set { _notify = value; }
        }

        protected string _notifySound;
        [XmlAttribute]
        public string NotifySound
        {
            get { return _notifySound; }
            set { _notifySound = value; }
        }
        [XmlIgnore]
        public System.IO.FileInfo NotifySoundFile
        {
            get
            {
                if (_notifySound != null)
                    return new System.IO.FileInfo(_notifySound);
                else
                    return null;
            }
            set
            {
                if (value != null)
                    _notifySound = value.FullName;
                else
                    _notifySound = null;
            }
        }

        protected string _note;
        [XmlAttribute]
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        protected System.Windows.Forms.DataGridViewRow _groupRow;
        [XmlIgnore]
        public System.Windows.Forms.DataGridViewRow GroupRow
        {
            get { return _groupRow; }
            set { _groupRow = value; }
        }

        public WatchGroup()
        {
            _id = 0;
            _name = string.Empty;
            _note = string.Empty;
        }
        public WatchGroup(string name, int id)
        {
            _id = id;
            _name = name;
            _note = string.Empty;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
