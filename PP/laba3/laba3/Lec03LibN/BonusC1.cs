using System;

namespace Lec03LibN
{
    internal class BonusC1 : IBonus
    {
        public float cost1hour { get; set; }
        public float x { get; set; }
        public float y { get; set; }

        public float calc(float number_hours)
        {
            return (number_hours * cost1hour * x) + y;
        }

        public BonusC1(float _cost1hour, float _x, float _y)
        {
            this.cost1hour = _cost1hour;
            this.x = _x;
            this.y = _y;
        }
    }
}
