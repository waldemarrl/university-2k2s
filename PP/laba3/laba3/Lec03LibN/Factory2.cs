using System;

namespace Lec03LibN
{
    internal class Factory2 : IFactory
    {
        public float a {  get; set; }

        public IBonus getA(float cost1hour) => new BonusA2(cost1hour, a);
        public IBonus getB(float cost1hour, float x) => new BonusB2(cost1hour, a, x);
        public IBonus getC(float cost1hour, float x, float y) => new BonusC2(cost1hour, a, x, y);

        public Factory2(float _a)
        {
            this.a = _a;
        }
    }
}
