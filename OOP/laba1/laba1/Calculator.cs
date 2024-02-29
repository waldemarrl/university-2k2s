using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    internal class Calculator : ICalc
    {
        private double VarA;
        private double VarB;
        private double VarResult;
        private int CurrentNumMemory = 0;
        private string Operation;
        private List<double> Memory = new List<double>();

        public bool SetVarA(string varA)
        {
            try
            {
                VarA = Convert.ToDouble(varA);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неверное число");
                return false;
            }
        }

        public bool SetVarB(string varB)
        {
            try
            {
                VarB = Convert.ToDouble(varB);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Введено неверное число");
                return false;
            }
        }

        public void SetOperation(string operation)
        {
            Operation = operation;
        }

        public string ShowLastMemory()
        {
            if (Memory.Count == 0)
            {
                return "";
            }
            else if (CurrentNumMemory == 0)
            {
                return Memory[CurrentNumMemory].ToString();
            }
            else
            {
                return Memory[--CurrentNumMemory].ToString();
            }
        }

        public string ShowNextMemory()
        {
            if (Memory.Count == 0 || Memory.Count - 1 < CurrentNumMemory)
            {
                return "";
            }
            else if (Memory.Count - 1 == CurrentNumMemory)
            {
                CurrentNumMemory++;
                return "";
            }
            else
            {
                return Memory[++CurrentNumMemory].ToString();
            }
        }

        public void Clean()
        {
            CurrentNumMemory = Memory.Count;
        }

        public string Equal(string varB)
        {
            if (!SetVarB(varB))
            {
                return "";
            }

            switch (Operation)
            {
                case "sin":
                    VarResult = Math.Sin(VarB);
                    break;

                case "cos":
                    VarResult = Math.Cos(VarB);
                    break;

                case "tan":
                    VarResult = Math.Tan(VarB);
                    break;

                case "cot":
                    VarResult = 1 / Math.Tan(VarB);
                    break;

                case "asin":
                    VarResult = Math.Asin(VarB);
                    break;

                case "acos":
                    VarResult = Math.Acos(VarB);
                    break;

                case "degree":
                    VarResult = Math.Pow(VarA, VarB);
                    break;

                case "sqrt2":
                    VarResult = Math.Sqrt(VarB);
                    break;

                case "sqrt3":
                    VarResult = (VarB < 0) ? -Math.Pow(-VarB, 1.0 / 3.0) : Math.Pow(VarB, 1.0 / 3.0);
                    break;

                default:
                    return "";
            }

            Operation = "";
            if (Double.IsNaN(VarResult))
            {
                MessageBox.Show("Ответ не является числом");
                return "";
            }
            Memory.Add(VarResult);
            CurrentNumMemory++;
            return Convert.ToString(VarResult);
        }
    }
}