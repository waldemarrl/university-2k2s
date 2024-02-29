using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        Descipline descipline = new Descipline();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                Lektor lektor = new Lektor();
                string NameLektor = LektorName.Text;
                string SurNameLektor = LektorSurName.Text;
                string FathNameLektor = LektorFathName.Text;
                string PulpitLektor = LektorPulpit.Text;
                var num = 0;
                if (!int.TryParse(Auditorium.Text, out num))
                {
                    throw new Exception("Не удовлетворяет условию");
                }
                string NumberAud = Auditorium.Text;
                if (NameLektor != "")
                {
                    lektor.Name = NameLektor;
                }
                else
                {
                    throw new Exception("Введите имя лектора");
                }
                if (SurNameLektor != "")
                {
                    lektor.SurName = SurNameLektor;
                }
                else
                {
                    throw new Exception("Введите фамилию лектора");
                }
                if (FathNameLektor != "")
                {
                    lektor.FathName = FathNameLektor;
                }
                else
                {
                    throw new Exception("Введите отчество лектора");
                }
                if (PulpitLektor != "")
                {
                    lektor.Pulpit = PulpitLektor;
                }
                else
                {
                    throw new Exception("Введите название кафедры");
                }
                if (NumberAud != "")
                {
                    lektor.Auditorium = NumberAud;
                }
                else
                {
                    throw new Exception("Введите номер аудитории");
                }
                descipline.Lektor = lektor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string NameDesc = DescName.Text;
                string NumSem = SemNum.Text;
                string NumCourse = "";
                string NameSpec = SpecName.Text;
                string CountLk = LkCount.Text;
                string CountLab = LabCount.Text;
                string ControlType = "";

                if (radioButton1.Checked)
                {
                    NumCourse = "1";
                }
                if (radioButton2.Checked)
                {
                    NumCourse = "2";
                }
                if (radioButton3.Checked)
                {
                    NumCourse = "3";
                }
                if (radioButton4.Checked)
                {
                    NumCourse = "4";
                }
                if (radioButton5.Checked)
                {
                    ControlType = "Зачет";
                }
                else if (radioButton6.Checked)
                {
                    ControlType = "Экзамен";
                }

                if (NameDesc == "")
                {
                    throw new Exception("Введите назвние дисциплины");
                }
                if (NumSem == "")
                {
                    throw new Exception("Введите номер семестра");
                }
                if (NumCourse == "")
                {
                    throw new Exception("Выберите номер курса");
                }
                if (NameSpec == "")
                {
                    throw new Exception("Введите назвние специальности");
                }
                if (CountLk == "")
                {
                    throw new Exception("Введите количество лекций");
                }
                if (CountLab == "")
                {
                    throw new Exception("Введите количество лаб");
                }
                if (ControlType == "")
                {
                    throw new Exception("Выберите тип контроля");
                }
                descipline.DescName = NameDesc;
                descipline.Sem = NumSem;
                descipline.Course = NumCourse;
                descipline.Spec = NameSpec;
                descipline.LectionCount = CountLk;
                descipline.LabCount = CountLab;
                descipline.Control = ControlType;

                var results = new List<ValidationResult>();
                var context = new ValidationContext(descipline);

                if (!Validator.TryValidateObject(descipline, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    MessageBox.Show("Все данные введены верно.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (var fs = new StreamWriter("data.json", true))
            {
                var json = JsonConvert.SerializeObject(descipline);
                fs.WriteLine(json);
            }
            descipline = new Descipline();
            DateTime date = DateTime.Now;
            toolStripStatusLabel1.Text = "Запись в файл " + date.ToString();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            List<Descipline> desciplines = new List<Descipline>();
            using (var fs = new StreamReader("data.json"))
            {
                while (!fs.EndOfStream)
                {
                    var json = fs.ReadLine();
                    var descipline = JsonConvert.DeserializeObject<Descipline>(json);
                    desciplines.Add(descipline);
                }
                MessageBox.Show(desciplines.Count.ToString());


                foreach (var el in desciplines)
                {
                    MessageBox.Show(el.ToString());
                }
                DateTime date = DateTime.Now;
                toolStripStatusLabel1.Text = "Вывод из файла " + date;
            }
        }

        private void LektorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
            DateTime date = DateTime.Now;
            toolStripStatusLabel1.Text = "Поиск " + date.ToString();
        }

        private void DisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sort sort = new Sort("Дисциплина");
            sort.Show();
            DateTime date = DateTime.Now;
            toolStripStatusLabel1.Text = "Сортировка по дисциплине " + date.ToString();
        }

        private void LecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sort sort = new Sort("Лектор");
            sort.Show();
            DateTime date = DateTime.Now;
            toolStripStatusLabel1.Text = "Сортировка по лектору " + date.ToString();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Version 1\nРазработчик: Лобанов Владимир Дмитриевич");
            DateTime date = DateTime.Now;
            toolStripStatusLabel1.Text = "О программе " + date.ToString();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void buttonMP_Click(object sender, EventArgs e)
        {
            string descipline = textBox1.Text;
            Regex regex = new Regex(@"^([A-Z]{2}[0-9]{7})?$");

            if (descipline != "" && regex.IsMatch(descipline))
            {
                MessageBox.Show("Правильный ввод");
            }
            else
            {
                MessageBox.Show("Неправильный ввод");
            }
        }
    }
}

        


