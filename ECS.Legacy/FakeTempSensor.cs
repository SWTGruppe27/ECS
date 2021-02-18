using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy
{
    public class FakeTempSensor : ITempSensor
    {
        public int GetTemp()
        {
            return 10;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
