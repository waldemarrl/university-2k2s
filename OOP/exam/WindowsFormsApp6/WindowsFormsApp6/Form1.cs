using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public string password;
        public string confirm;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = true;
            password = textBox1.Text;
            Regex check = new Regex(@"^(?=.*[a-zA-Z])(?=.*\d).{6,12}$");
            if (password != "" && check.IsMatch(password))
            {
                label2.Text = "OK";
                textBox2.ReadOnly = false;
            }
            else
            {
                label2.Text = "Bad passowrd";
                textBox2.ReadOnly = true;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            confirm = textBox2.Text;
            if (confirm != password)
            {
                label1.Text = "Does not match";
            }
            else
            {
                label1.Text = "Matches";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
