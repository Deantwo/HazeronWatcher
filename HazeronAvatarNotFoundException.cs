using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HazeronWatcher
{
    [Serializable]
    public class HazeronAvatarNotFoundException : Exception
    {
        string AvatarName = null;
        string AvatarId = null;

        public HazeronAvatarNotFoundException()
            : base("Avatar not found.")
        {
        }
        public HazeronAvatarNotFoundException(Exception innerException)
            : base("Avatar not found.", innerException)
        {
        }
        public HazeronAvatarNotFoundException(string avatarId)
            : base("Avatar (ID:" + avatarId + ") not found.")
        {
            AvatarId = avatarId;
        }
        public HazeronAvatarNotFoundException(string avatarId, string avatarName)
            : base("Avatar (\"" + avatarName + "\" ID:" + avatarId + ") not found.")
        {
            AvatarName = avatarName;
            AvatarId = avatarId;
        }
    }
}
