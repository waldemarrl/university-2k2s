using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Attribute : ValidationAttribute
    {
        //Пользовательский атрибут для валидации процессора
        public override bool IsValid(object value)
        {
            Descipline descipline = value as Descipline;
            if (descipline != null)
            {
                if (descipline.LabCount != "0" && descipline.LabCount != "0")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
