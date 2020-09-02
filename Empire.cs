using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace HazeronWatcher
{
    [XmlRoot(ElementName = "Empire", Namespace = "")]
    public class Empire
    {
        //public static Empire GetEmpires()
        //{
        //    string httpHeaderLine = null;
        //    try
        //    {
        //        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"https://hazeron.com/EmpireStandings/AvatarsByEmpire.php");
        //        request.Timeout = 5000;
        //        request.Method = "GET";
        //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //        {
        //            using (Stream receiveStream = response.GetResponseStream())
        //            {
        //                StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8);
        //                string httpLine;
        //                while ((httpLine = sr.ReadLine()) != null)
        //                {
        //                    if (httpLine.Contains("src=\"" + id.ToString() + ".png\">"))
        //                    {
        //                        httpHeaderLine = httpLine;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (WebException)
        //    {
        //        // Blackhole.
        //    }
        //    if (httpHeaderLine == null)
        //    {
        //        try
        //        {
        //            using (WebClient client = new WebClient())
        //            {
        //                using (var stream = client.OpenRead(@"https://hazeron.com/status.php"))
        //                {
        //                    throw new HazeronEmpireNotFoundException(id);
        //                }
        //            }
        //        }
        //        catch (WebException ex)
        //        {
        //            throw new HazeronWebsiteNotFoundException(ex);
        //        }
        //    }
        //    const string EMPIRE_START = ".png\"><br></td><td valign=\"middle\"><span style=\"font-family: sans-serif;\"><big><b>";
        //    const string EMPIRE_END = "</b></big></span></td>";
        //    int startIndex = httpHeaderLine.IndexOf(EMPIRE_START) + EMPIRE_START.Length;
        //    int endIndex = httpHeaderLine.IndexOf(EMPIRE_END) - startIndex;
        //    string name = httpHeaderLine.Substring(startIndex, endIndex);
        //    return new Empire(name, id);
        //}

        public static Empire GetEmpire(int id)
        {
            string httpHeaderLine = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(@"https://hazeron.com/EmpireStandings/AvatarsByEmpire.php");
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
                            if (httpLine.Contains("src=\"" + id.ToString() + ".png\">"))
                            {
                                httpHeaderLine = httpLine;
                                break;
                            }
                        }
                    }
                }
            }
            catch (WebException)
            {
                // Blackhole.
            }
            if (httpHeaderLine == null)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        using (var stream = client.OpenRead(@"https://hazeron.com/status.php"))
                        {
                            throw new HazeronEmpireNotFoundException(id);
                        }
                    }
                }
                catch (WebException ex)
                {
                    throw new HazeronWebsiteNotFoundException(ex);
                }
            }
            const string EMPIRE_START = ".png\"><br></td><td valign=\"middle\"><span style=\"font-family: sans-serif;\"><big><b>";
            const string EMPIRE_END = "</b></big></span></td>";
            int startIndex = httpHeaderLine.IndexOf(EMPIRE_START) + EMPIRE_START.Length;
            int endIndex = httpHeaderLine.IndexOf(EMPIRE_END) - startIndex;
            string name = httpHeaderLine.Substring(startIndex, endIndex);
            return new Empire(name, id);
        }

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

        protected int _watchGroup;
        [XmlAttribute]
        public int WatchGroup
        {
            get { return _watchGroup; }
            set { _watchGroup = value; }
        }

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

        protected System.Windows.Forms.DataGridViewRow _empireWatchRow;
        [XmlIgnore]
        public System.Windows.Forms.DataGridViewRow EmpireWatchRow
        {
            get { return _empireWatchRow; }
            set { _empireWatchRow = value; }
        }

        public Empire()
            : this(string.Empty, 0)
        {
        }
        public Empire(int id)
            : this("<no name>", id)
        {
        }
        public Empire(string name, int id)
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
            _name = GetEmpire(_id).Name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
