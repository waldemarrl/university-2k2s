using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace lab2
{
    [Serializable]
    public class Lektor
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FathName { get; set; }
        public string Pulpit { get; set; }
        public string Auditorium { get; set; }

        public Lektor()
        {
            Name = "NoName";
            SurName = "NoSurName";
            FathName = "NoFathName";
            Pulpit = "NoPulpit";
            Auditorium = "NoAuditorium";
        }
        public Lektor (string _name, string _surname, string _fathname, string _pulpit, string _auditorium )
        {
            Name = _name;
            SurName = _surname;
            FathName = _fathname;
            Pulpit = _pulpit;
            Auditorium = _auditorium;
        }
        public override string ToString()
        {
            return $" Name: {Name}" + $" Surname: {SurName}" + $" Fathername: {FathName}" + $" Pulpit: {Pulpit}" +  $" Auditorium: {Auditorium}";
        }
    }
}
