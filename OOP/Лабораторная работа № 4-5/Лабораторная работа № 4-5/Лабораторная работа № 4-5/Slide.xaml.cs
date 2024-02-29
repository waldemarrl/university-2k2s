using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Лабораторная_работа___4_5
{
    /// <summary>
    /// Логика взаимодействия для Slide.xaml
    /// </summary>
    public partial class Slide : UserControl
    {
        public Slide()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            tb_search.Text = "";
            tb_search.Focus();
        }
    }
}
