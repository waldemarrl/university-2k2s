using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab2
{
    [Serializable]
    public class Descipline
    {
        public Lektor Lektor { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Вы ввели слишком короткое название дисциплины", MinimumLength = 2)]
        public string DescName { get; set; }
        public string Sem { get; set; }
        public string Course { get; set; }
        public string Spec { get; set; }
        public string LectionCount { get; set; }
        public string LabCount { get; set; }
        public string Control { get; set; }

        public Descipline ()
        {
            DescName = "Null";
            Sem = "Null";
            Course = "Null";
            Spec = "Null";
            LectionCount = "Null";
            LabCount = "Null";
            Control = "Null";
        }
        public Descipline(Lektor _lektor, string _descName, string _sem, string _course, string _spec, string _lectionCount, string _labCount, string _control)
        {
            Lektor = _lektor;
            DescName = _descName;
            Sem = _sem;
            Course = _course;
            Spec = _spec;
            LectionCount = _lectionCount;
            LabCount = _labCount;
            Control = _control;
        }
        public override string ToString()
        {
            return string.Format("DescName: {0} Sem: {1} Course {2} Spec: {3} Lections: {4} Labs: {5} Control: {6} Lektor: {7}", DescName, Sem, Course, Spec, LectionCount, LabCount, Control, Lektor);
        }
    }
}
