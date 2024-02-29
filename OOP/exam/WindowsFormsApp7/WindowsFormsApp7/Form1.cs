using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            listBox1.Items.Add("Элемент 1");
            listBox1.Items.Add("Элемент 2");
            listBox1.Items.Add("Элемент 3");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (true)
            //{
            //    string rr = listBox1.SelectedItem.ToString();
            //    listBox2.Items.Add(rr);

            //    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            //}
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string rr = listBox2.SelectedItem.ToString();
            //listBox1.Items.Add(rr);

            //listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            if (listBox2.SelectedIndex != -1)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }
    }
}

//Разработайте программу на C# WinForms. Форма содержит два заполненных списка. При щелчке по элементу списка соответствующий элемент переносится в другой сипсок.

//Разработайте программу на С# WPF. Создайте привязку один к одному между двумя полями.