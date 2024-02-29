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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private Book book;
        public Product product;
        public AddProduct()
        {
            InitializeComponent();
            book = new Book();
            product = new Product();
        }
        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();

            book = new Book(NameBook.Text, FormatBook.Text, CategoriesBook.Text, PublishingBook.Text, CountryBook.Text, CostBook.Text, SizeBook.Text, AuthorBook.Text);

            var productList = Serialize.DataDeserialize();
            if (productList != null)
                foreach (var item in productList.bookList)
                    product.Add(item);
            product.Add(book);
            Serialize.DataSerialize(product);

            this.Close();
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

        private void CostBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
