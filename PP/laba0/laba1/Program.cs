using System;

namespace laba1
{
    class Program : Interface1
    {
        private int height;
        public string word;
        public class Heri : Program
        {
            public string Text
            {
                get { return word; }
                set { word = value; }
            }

            public int Fly
            {
                get { return height; }
                set { height = value > 0 ? value : throw new Exception(); }
            }

            public Heri( string _text, int _fly)
            {
                Text = _text;
                Fly = _fly;
            }

            public struct List : Interface1
            {
                void Interface1.Add() { return; }
            }
        }

        void Interface1.Add()
        {
            Console.WriteLine("AA");
        }

        void Add()
        {
            Console.WriteLine("GG");
        }

        public override string ToString()
        {
            string rez = this.word + this.height;
            return rez;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program f = new Program();
            f.Add();
            Interface1 ff = new Program();
            ff.Add();
        }
    }
}
