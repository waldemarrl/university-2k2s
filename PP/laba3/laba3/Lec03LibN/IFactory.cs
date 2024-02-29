using System;
using System;

namespace Lec03LibN
{
    public interface IFactory
    {
        IBonus getA(float const1hour);
        IBonus getB(float cost1hour, float x);
        IBonus getC(float cost1hour, float x, float y);
    }
}
