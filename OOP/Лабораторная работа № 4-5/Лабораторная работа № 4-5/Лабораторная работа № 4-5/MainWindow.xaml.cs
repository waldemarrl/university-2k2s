using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool styleCheck = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        //private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonEnglish_Click(object sender, RoutedEventArgs e)
        {
            var url = new Uri("/Dictionary/EnglishLanguage.xaml", UriKind.Relative);
            var resourceDict = Application.LoadComponent(url) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            styleCheck = true;
        }

        private void ButtonRussian_Click(object sender, RoutedEventArgs e)
        {
            var url = new Uri("/Dictionary/RussianLanguage.xaml", UriKind.Relative);
            var resourceDict = Application.LoadComponent(url) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            styleCheck = false;
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void ShowProduct_Click(object sender, RoutedEventArgs e)
        {
            ShowProduct showProduct = new ShowProduct();
            showProduct.Show();
        }

        private void ChangeThemes_Click(object sender, RoutedEventArgs e)
        {
            if (styleCheck == true)
            {
                var url = new Uri("/Dictionary/LiteTheme.xaml", UriKind.Relative);
                var resourceDict = Application.LoadComponent(url) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                styleCheck = false;
            }
            else
            {
                var url = new Uri("/Dictionary/GrayTheme.xaml", UriKind.Relative);
                var resourceDict = Application.LoadComponent(url) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                styleCheck = true;
            }
        }

        private void Outer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click to Outer!");
        }

        private void Tunneling_MouseDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.ToString() + "\n" + e.Source.ToString() + "\n\n");
        }

        private void First_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
        }

        private void Second_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2");
        }

        private void Third_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("3");
        }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.Close();
        }
    }
    public class WindowCommands
    {
        static WindowCommands()
        {
            Exit = new RoutedCommand("Exit", typeof(MainWindow)); //команда exit, констр перед назв команд и элемент-влад
        }
        public static RoutedCommand Exit { get; set; }//команда
    }
}
