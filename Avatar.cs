using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace HazeronWatcher
{
    [XmlRoot(ElementName = "Avatar", Namespace = "")]
    public class Avatar
    {
        public static Avatar GetAvatar(string id)
        {
            string httpHeaderLine = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"https://Hazeron.com/EmpireStandings/p" + id + ".php");
                request.Timeout = 5000;
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8);
                        string httpLine;
                        while ((httpLine = sr.ReadLine()) != null)
                        {
                            if (httpLine.Contains("Shores of Hazeron"))
                            {
                                httpHeaderLine = httpLine;
                                break;
                            }
                        }
                    }
                }
            }
            catch (System.Net.WebException)
            {
                // Blackhole.
            }
            if (httpHeaderLine == null)
            {
                try
                {
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        using (var stream = client.OpenRead(@"https://hazeron.com/status.php"))
                        {
                            throw new HazeronAvatarNotFoundException(id);
                        }
                    }
                }
                catch (System.Net.WebException ex)
                {
                    throw new HazeronWebsiteNotFoundException(ex);
                }
            }
            const string start = "<title>Shores of Hazeron - ";
            const string end = "</title>";
            int startIndex = httpHeaderLine.IndexOf(start) + start.Length;
            int endIndex = httpHeaderLine.IndexOf(end) - startIndex;
            string name = httpHeaderLine.Substring(startIndex, endIndex);
            return new Avatar(name, id);
        }

        protected string _id;
        [XmlAttribute]
        public string ID
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

        protected int _empire;
        [XmlIgnore]
        public int Empire
        {
            get { return _empire; }
            set { _empire = value; }
        }

        protected bool _online;
        [XmlIgnore]
        public bool Online
        {
            get { return _online; }
            set { _online = value; }
        }

        //protected DateTime _lastOnline;
        //[System.Xml.Serialization.XmlAttribute]
        //public DateTime LastOnline
        //{
        //    get { return _lastOnline; }
        //    set { _lastOnline = value; }
        //}

        // Backward capatibility. Convert to WatchGroup.
        /// <summary>
        /// Obsolete property, use WatchGroup instead.
        /// </summary>
        [XmlAttribute, System.ComponentModel.DefaultValue(0)]
        public int Relation { get; set; }

        protected int _watchGroup = 0;
        [XmlAttribute]
        public int WatchGroup
        {
            get { return _watchGroup; }
            set { _watchGroup = value; }
        }

        // Backward capatibility. Convert to Notify.
        /// <summary>
        /// Obsolete property, use Nnotify instead.
        /// </summary>
        [XmlAttribute, System.ComponentModel.DefaultValue(false)]
        public bool Watch { get; set; }

        protected bool _notify;
        [XmlAttribute]
        public bool Notify
        {
            get { return _notify; }
            set { _notify = value; }
        }

        protected string _note;
        [XmlAttribute]
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public bool IsWatchListed
        {
            get { return _notify || _watchGroup != 0 || !String.IsNullOrEmpty(_note); }
        }

        protected System.Windows.Forms.DataGridViewRow _onlineRow;
        [XmlIgnore]
        public System.Windows.Forms.DataGridViewRow OnlineRow
        {
            get { return _onlineRow; }
            set { _onlineRow = value; }
        }

        protected System.Windows.Forms.DataGridViewRow _avatarWatchRow;
        [XmlIgnore]
        public System.Windows.Forms.DataGridViewRow AvatarWatchRow
        {
            get { return _avatarWatchRow; }
            set { _avatarWatchRow = value; }
        }

        protected System.Windows.Forms.DataGridViewRow _recentRow;
        [XmlIgnore]
        public System.Windows.Forms.DataGridViewRow RecentRow
        {
            get { return _recentRow; }
            set { _recentRow = value; }
        }

        public Avatar()
            : this(string.Empty, "A")
        {
        }
        public Avatar(string name, string id)
        {
            _id = id;
            _name = name;
            _note = string.Empty;
        }

        public void Unlist()
        {
            _watchGroup = 0;
            _notify = false;
            _note = string.Empty;
        }

        public void RecheckName()
        {
            _name = GetAvatar(_id).Name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
