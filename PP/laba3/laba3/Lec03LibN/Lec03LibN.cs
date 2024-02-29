using System;
using System.Collections.Generic;
using System;

namespace Lec03LibN
{
    static public partial class Lec03BLib
    {
        static public IFactory getL1() => new Factory1();
        static public IFactory getL2(float x) => new Factory2(x);
        static public IFactory getL3(float x, float y) => new Factory3(x, y);
    }
}
