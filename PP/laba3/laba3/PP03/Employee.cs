using Lec03LibN;
using System;

namespace PP03
{
    public class Employee
    {
        public IBonus bonus { get; private set; }
        public Employee(IBonus bonus)
        {
            this.bonus = bonus;
        }
        public float calcBonus(float number_hours)
        {
            return bonus.calc(number_hours);
        }
    }
}
