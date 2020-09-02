using System;
using System.Runtime.Serialization;

namespace HazeronWatcher
{
    [Serializable]
    internal class HazeronEmpireNotFoundException : Exception
    {
        string EmpireName = null;
        int EmpireId = 0;

        public HazeronEmpireNotFoundException()
            : base("Empire not found.")
        {
        }
        public HazeronEmpireNotFoundException(Exception innerException)
            : base("Empire not found.", innerException)
        {
        }
        public HazeronEmpireNotFoundException(int empireId)
            : base("Empire (ID:" + empireId.ToString() + ") not found.")
        {
            EmpireId = empireId;
        }
        public HazeronEmpireNotFoundException(int empireId, string empireName)
            : base("Empire (\"" + empireName + "\" ID:" + empireId.ToString() + ") not found.")
        {
            EmpireName = empireName;
            EmpireId = empireId;
        }
    }
}