using System;



namespace Lec03LibN 
{
    internal class Factory1 : IFactory
    {
        public IBonus getA(float cost1hour) => new BonusA1(cost1hour);
        public IBonus getB(float cost1hour, float x) => new BonusB1(cost1hour, x);
        public IBonus getC(float cost1hour, float x, float y) => new BonusC1(cost1hour, x, y);

        public Factory1() { }
    }
}
