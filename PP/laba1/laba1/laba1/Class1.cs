using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace laba1
{
    internal class Class1
    {
        private const int A = 1;
        public const int B = 2;
        protected const int C = 3;
        private int Field;
        public int Field1;
        public string City;
        protected int Field2;

        private void Func1()
        {
            Console.WriteLine("Hello");
        }
        protected void Func2()
        {

        }

        public int construct
        {
            get { return Field; }
            set { Field = value; }
        }
        public int construct1 { get; set; }
        public int construct2 { get; set; }

        public Class1() { Field1 = 12; }
        public Class1(int n) { Field1 = n; }
        public Class1(string _city, int _field1)
        {
            City = _city;
            Field1 = _field1;
        }
        public Class1(Class1 d)
        {
            this.City = d.City;
            this.Field1 = d.Field1;
            this.construct = d.construct;
            this.construct1 = d.construct1;
            this.construct2 = d.construct2; 
            this.Field = d.Field;
            this.Field2 = d.Field2;
        }
        public void Print()
        {
            Console.WriteLine($"Имя: {City}  Возраст: {Field1}");
        }



    }
}