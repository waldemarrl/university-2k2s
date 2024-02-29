using System;

namespace Lec03LibN
{
    internal class Factory3 : IFactory
    {
        public float a { get; set; }
        public float b { get; set; }

        public IBonus getA(float cost1hour) => new BonusA3(cost1hour, a, b);
        public IBonus getB(float cost1hour, float x) => new BonusB3(cost1hour, a, b, x);
        public IBonus getC(float cost1hour, float x, float y) => new BonusC3(cost1hour, a, b, x, y);

        public Factory3(float _a, float _b)
        {
            this.a = _a;
            this.b = _b;
        }
    }
}
