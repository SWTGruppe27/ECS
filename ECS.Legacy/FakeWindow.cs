using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Legacy
{
   

    public class FakeWindow : IWindow
    {
        public int OpenWindowCount { get; private set; }
        public int CloseWindowCount { get; private set; }

        public void Open()
        {
            OpenWindowCount++;
        }

        public void Close()
        {
            CloseWindowCount++;
        }
    }
}
