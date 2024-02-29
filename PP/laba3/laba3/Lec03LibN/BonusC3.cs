using System;

namespace Lec03LibN
{
    internal class BonusC3 : IBonus
    {
        public float cost1hour { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float t { get; set; }

        public float calc(float number_hours)
        {
            return ((number_hours + x) * (cost1hour + y) * z) + t;
        }

        public BonusC3(float _cost1hour, float _x, float _y, float _z, float _t)
        {
            this.cost1hour = _cost1hour;
            this.x = _x;
            this.y = _y;
            this.z = _z;
            this.t = _t;
        }
    }
}
