using System;

namespace Lec03LibN
{
    internal class BonusA1 : IBonus
    {
        public float cost1hour { get; set; }

        public float calc(float number_hours)
        {
            return number_hours * cost1hour;
        }

        public BonusA1(float _number_hours)
        {
            this.cost1hour = _number_hours;
        }
    }
}

