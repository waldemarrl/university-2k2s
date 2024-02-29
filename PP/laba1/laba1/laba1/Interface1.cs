using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    interface Interface1
    {
        string Name { get; }
        int this[int indexer] { get; set; } 
        public void Methd();
        // delegate void AccountHandler();
        event EventHandler Methd_Changed;
    }
}
