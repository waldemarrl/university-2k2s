using System;

namespace Lec03LibN
{
    internal class BonusA2 : IBonus
    {
        public float cost1hour { get; set; }
        public float x { get; set; }

        public float calc(float number_hours)
        {
            return (number_hours + x) * cost1hour;
        }

        public BonusA2(float _cost1hour, float _x)
        {
            this.cost1hour = _cost1hour;
            this.x = _x;
        }
    }
}

