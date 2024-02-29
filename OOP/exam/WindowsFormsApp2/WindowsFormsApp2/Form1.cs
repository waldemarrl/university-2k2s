using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int s = Convert.ToInt32(textBox1.Text);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Вы ввели символ! Пожалуйста,введите цифрy");
                textBox1.Clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string texted = textBox1.Text;
            int num = Int32.Parse(texted);

            double result = Math.Cos(num);
            textBox2.Text = result.ToString();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string texted = textBox1.Text;
            int num = Int32.Parse(texted);

            double result = Math.Sin(num);
            textBox2.Text = result.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string texted = textBox1.Text;
            int num = Int32.Parse(texted);

            double result = Math.Tan(num);
            textBox2.Text = result.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            string texted = textBox1.Text;
            int num = Int32.Parse(texted);

            double result = 1f / Math.Tan(num);
            textBox2.Text = result.ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }
    }
}
