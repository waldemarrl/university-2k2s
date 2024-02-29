using System;
using Lec03LibN;

namespace PP03
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа # 3");

            IFactory l1 = Lec03BLib.getL1();

            Employee employee1 = new Employee(l1.getA(25f));
            Console.WriteLine($"Bonus-L1-A = {employee1.calcBonus(4f)}");

            Employee employee2 = new Employee(l1.getB(25f, 1.1f));
            Console.WriteLine($"Bonus-L1-B = {employee2.calcBonus(4f)}");

            Employee employee3 = new Employee(l1.getC(25f, 1.1f, 5.0f));
            Console.WriteLine($"Bonus-L1-C = {employee2.calcBonus(4f)}");

            IFactory l2 = Lec03BLib.getL2(1f);

            Employee employee4 = new Employee(l2.getA(25f));
            Console.WriteLine($"Bonus-L2-A = {employee4.calcBonus(4f)}");

            Employee employee5 = new Employee(l2.getB(25f, 1.1f));
            Console.WriteLine($"Bonus-L2-B = {employee5.calcBonus(4f)}");

            Employee employee6 = new Employee(l2.getC(25f, 1.1f, 5.0f));
            Console.WriteLine($"Bonus-L2-C = {employee6.calcBonus(4f)}");

            IFactory l3 = Lec03BLib.getL3(1f, 0.5f);

            Employee employee7 = new Employee(l3.getA(25f));
            Console.WriteLine($"Bonus-L3-A = {employee7.calcBonus(4f)}");

            Employee employee8 = new Employee(l3.getB(25f, 1.1f));
            Console.WriteLine($"Bonus-L3-B = {employee8.calcBonus(4f)}");

            Employee employee9 = new Employee(l3.getC(25f, 1.1f, 0.5f));
            Console.WriteLine($"Bonus-L3-C = {employee9.calcBonus(4f)}");
        }
    }
}