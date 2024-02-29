using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class Class4 : Class3
    {
        public int Click
        {
            get { return click; }
            set { click = value; }
        }

        public Class4(int _click)
        {
            click = _click;
        }

        public void Print()
        {
            Console.WriteLine($": {Click}");
        }
    }
}
