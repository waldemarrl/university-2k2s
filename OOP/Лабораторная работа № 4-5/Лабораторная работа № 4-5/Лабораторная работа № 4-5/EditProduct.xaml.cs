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
using Лабораторная_работа___4_5.Class;

namespace Лабораторная_работа___4_5
{
    /// <summary>
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public Product product;
        private Book book;
        public bool edited;
        public EditProduct(Book bookExample)
        {
            InitializeComponent();
            book = new Book();
            product = new Product();
            edited= false;

            NameBook.Text = bookExample.NameBook;
            FormatBook.Text = bookExample.FormatBook.ToString();
            CategoriesBook.Text = bookExample.Categories.ToString();
            PublishingBook.Text = bookExample.PublishingBook.ToString();
            CountryBook.Text = bookExample.Country.ToString();
            CostBook.Text = bookExample.CostBook.ToString();
            SizeBook.Text = bookExample.SizeBook.ToString();
            AuthorBook.Text = bookExample.AuthorBook.ToString();
        }

        private void editProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                book = new Book(NameBook.Text, FormatBook.Text, CategoriesBook.Text, PublishingBook.Text, CountryBook.Text, CostBook.Text, SizeBook.Text, AuthorBook.Text);
                edited = true;
                this.Close();
            }

             catch (Exception bookError)
            {
                MessageBox.Show(bookError.Message);
            }
        }

        private void clearProduct_Click(object sender, RoutedEventArgs e)
        {
            NameBook.Text = "";
            FormatBook.Text = "";
            CategoriesBook.Text = "";
            PublishingBook.Text = "";
            CountryBook.Text = "";
            CostBook.Text = "";
            SizeBook.Text = "";
            AuthorBook.Text = "";
        }

        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
