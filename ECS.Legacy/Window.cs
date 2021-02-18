using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECS.Legacy
{
    public class Window : IWindow
    {
        public void Open()
        {
            Console.WriteLine("Window opened.");
        }

        public void Close()
        {
            Console.WriteLine("Window closed.");
        }
    }
}
