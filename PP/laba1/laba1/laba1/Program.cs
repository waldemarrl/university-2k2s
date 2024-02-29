using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba1
{
    internal class Program
    {
        public int age;
        public string name;
        public void Print()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }

        public static void Main()
        {
            Class1 abc = new Class1();
            abc.Print();
            Class1 acb = new Class1(17);
            acb.Print();
            Class1 bac = new Class1("lecha", 16);
            bac.Print();

            Class2 class2 = new Class2(13, "Minsk");
            class2.Print();

            Class4 class4 = new Class4(20);
            class4.Method();
            Console.WriteLine("Value");
            class4.Print();

        }




    }
}
