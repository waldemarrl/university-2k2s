using System;

namespace Lec03LibN
{
    internal class BonusB3 : IBonus
    {
        public float cost1hour { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public float calc(float number_hours)
        {
            return (number_hours + x) * (cost1hour + y) * z;
        }

        public BonusB3(float _cost1hour, float _x, float _y, float _z)
        {
            this.cost1hour = _cost1hour;
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }
    }
}
