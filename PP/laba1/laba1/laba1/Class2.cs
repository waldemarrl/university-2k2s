using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba1
{
    internal class Class2 : Interface1
    {
        private int Field;
        public int[] Field1;
        protected int Field2;
        public string city;
        
        public int FieldPr
        {
            get { return Field; }
            set {Field= value;}
        }

        void Interface1.Methd() { }
        string Interface1.Name { get; }

        event EventHandler Methd_Changed;

        event EventHandler Interface1.Methd_Changed
        {
            // to fix, uncomment the add and remove definitions

            add => Methd_Changed += value;
            remove => Methd_Changed -= value;

        }
        int Interface1.this[int index]
        {
            get => Field1[index];
            set => Field1[index] = value;
        }

        public Class2 (int _fieldpr, string _city)
        {
            Field = _fieldpr;
            city = _city;
        }

        public void Print()
        {
            Console.WriteLine($"Квадрат: {Field}  Город: {city}");
        }

        private void Func1()
        {

        }
        protected void Func2()
        {

        }
    }
}
