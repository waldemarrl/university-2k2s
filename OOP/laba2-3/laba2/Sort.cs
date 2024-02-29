using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Sort : Form
    {
        List<Descipline> desciplines = new List<Descipline>();
        public Sort(string sort)
        {
            InitializeComponent();
            label1.Text = sort;
            using (var fs = new StreamReader("data.json"))
            {
                while (!fs.EndOfStream)
                {
                    var json = fs.ReadLine();
                    var descipline = JsonConvert.DeserializeObject<Descipline>(json);
                    desciplines.Add(descipline);
                }
            }
            if (sort == "Дисциплина")
            {
                var query = from el in desciplines
                            orderby el.DescName
                            select el;
                foreach (var el in query)
                {
                    listBox1.Items.Add(el.ToString());
                }
            }
            else if (sort == "Лектор")
            {
                var query = from el in desciplines
                            orderby el.Lektor.SurName
                            select el;
                foreach (var el in query)
                {
                    listBox1.Items.Add(el.ToString());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fs = new StreamWriter("sort.json"))
            {
                foreach (var el in listBox1.Items)
                {
                    var json = JsonConvert.SerializeObject(el);
                    fs.WriteLine(json);
                }
            }
        }
    }
}
