using System;
using System;

namespace Lec03LibN
{
    public interface IBonus
    {
        float cost1hour { get; set; }
        float calc(float number_hours);
    }
}
