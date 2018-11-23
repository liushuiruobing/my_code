using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWorkstation
{
    public abstract class AbstractCommunication
    {
        public abstract bool InitializeCommu();
        public abstract bool Write(byte[] WrBuf, int WrCount);
        public abstract bool Read(ref string RdBuf, ref int RdCount);
        public abstract bool Query(byte[] WrBuf, int WrCount, ref string RdBuf, ref int RdCount);
        public abstract void Close();
    }
}
