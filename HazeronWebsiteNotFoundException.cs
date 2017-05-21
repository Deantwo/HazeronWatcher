using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronWatcher
{
    [Serializable]
    public class HazeronWebsiteNotFoundException : Exception
    {
        public HazeronWebsiteNotFoundException()
            : base("Hazeron.com not found.")
        {
        }
        public HazeronWebsiteNotFoundException(Exception innerException)
            : base("Hazeron.com not found.", innerException)
        {
        }
    }
}
