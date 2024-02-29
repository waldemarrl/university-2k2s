using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Search : Form
    {
        List<Descipline> desciplines = new List<Descipline> ();
        public Search()
        {
            InitializeComponent();
            using (var fs = new StreamReader("data.json"))
            {

                while (!fs.EndOfStream)
                {
                    var json = fs.ReadLine();

                    var descipline = JsonConvert.DeserializeObject<Descipline>(json);

                    desciplines.Add(descipline);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string descipline = textBox1.Text;
            string lektor = textBox2.Text;
            Regex regex = new Regex(@"^[a-zA-Z0-9]+$");

            if (descipline != "" && regex.IsMatch(descipline) && lektor == "")
            {
                var query = from el in desciplines
                            where el.DescName == descipline
                            select el;
                foreach (var el in query)
                {
                    listBox1.Items.Add(el.ToString());
                }
            }
            else if (descipline == "" && lektor != "" && regex.IsMatch(lektor))
            {
                var query = from el in desciplines
                            where el.Lektor.SurName == lektor
                            select el;
                foreach (var el in query)
                {
                    listBox1.Items.Add(el.ToString());
                }
            }
            else if (descipline != "" && lektor != "" && regex.IsMatch(descipline) && regex.IsMatch(lektor))
            {
                var query = from el in desciplines
                            where el.DescName == descipline && el.Lektor.SurName == lektor
                            select el;
                foreach (var el in query)
                {
                    listBox1.Items.Add(el.ToString());
                }
            }
            else
            {
                MessageBox.Show("Неверный ввод");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fs = new StreamWriter("search.json", true))
            {
                foreach (var el in listBox1.Items)
                {
                    fs.WriteLine(el.ToString());
                }
            }
        }
    }
}
