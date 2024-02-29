using System;

namespace Lec03LibN
{
    internal class BonusB1 : IBonus
    {
        public float cost1hour { get; set; }
        public float x { get; set; }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour * x;
        }

        public BonusB1(float _cost1hour, float _x)
        {
            this.cost1hour = _cost1hour;
            this.x = _x;
        }
    }
}
