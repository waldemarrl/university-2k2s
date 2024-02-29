using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1
{
    public partial class Form1 : Form
    {
        Calculator calculator = new Calculator();

        public Form1()
        {
            InitializeComponent();
            mainLable.Text = null;
        }

        private void button_Click(object sender, EventArgs e)
        {
            mainLable.Text += ((Button)sender).Text;
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            mainLable.Text = null;
            secondLabel.Text = null;
            calculator.Clean();
        }

        private void buttonOperations_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            secondLabel.Text = button.Text;
            calculator.SetOperation(button.Tag.ToString());
        }

        private void buttonDegree_Click(object sender, EventArgs e)
        {
            calculator.SetOperation(((Button)sender).Tag.ToString());
            if (calculator.SetVarA(mainLable.Text))
            {
                secondLabel.Text = mainLable.Text + "^";
            }
            else
            {
                secondLabel.Text = null;
            }
            mainLable.Text = null;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            secondLabel.Text = null;
            mainLable.Text = calculator.Equal(mainLable.Text);
        }

        private void buttonLastMem_Click(object sender, EventArgs e)
        {
            secondLabel.Text = null;
            mainLable.Text = calculator.ShowLastMemory();
        }

        private void buttonNextMem_Click(object sender, EventArgs e)
        {
            secondLabel.Text = null;
            mainLable.Text = calculator.ShowNextMemory();
        }
    }
}

