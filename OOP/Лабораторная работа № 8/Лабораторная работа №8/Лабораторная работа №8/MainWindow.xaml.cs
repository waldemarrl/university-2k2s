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

using System.Data;

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;

namespace Лабораторная_работа__8
{
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection = null;
        DataBaseLaba8Entities entity = new DataBaseLaba8Entities();   
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBaseLaba8"].ConnectionString);

            sqlConnection.Open();

            if(sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("CONNECTION IS ESTABLISHED!");
            }
            else
            {
                MessageBox.Show("CONNECTION NOT ESTABLISHED!");
            }
        }

        private new void Show()
        {
            var query =
            from authors in entity.AUTHORS
            join books in entity.BOOKS
            on authors.ID_AUTHOR equals books.ID_AUTHOR
            join edition in entity.EDITION
            on books.ID_BOOK equals edition.ID_BOOK
            select new
            {
                authors.ID_AUTHOR,
                authors.FIO,
                books.ID_BOOK,
                books.NAME_BOOK,
                books.COUNT_BOOKS,
                books.THE_YEAR_OF_PUBLISHING,
                edition.ID_EDITION,
                edition.DATE_SURRENDER,
                edition.DATE_EDITION
            };
            table.ItemsSource = query.ToList();
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            Insert insert = new Insert();
            insert.ShowDialog();
            Show();
        } 

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (table.SelectedItem != null)
            {
                var indexAuthor = table.SelectedItem.GetType().GetProperty("ID_AUTHOR").GetValue(table.SelectedItem);
                var indexBook = table.SelectedItem.GetType().GetProperty("ID_BOOK").GetValue(table.SelectedItem);
                var indexEdition = table.SelectedItem.GetType().GetProperty("ID_EDITION").GetValue(table.SelectedItem);

                SqlCommand cmd = new SqlCommand("BEGIN TRANSACTION", sqlConnection);

                await cmd.ExecuteNonQueryAsync();
                cmd.CommandText = "DELETE FROM EDITION WHERE ID_EDITION = " + indexEdition;

                await cmd.ExecuteNonQueryAsync();
                cmd.CommandText = "DELETE FROM BOOKS WHERE ID_BOOK = " + indexBook;

                await cmd.ExecuteNonQueryAsync();
                cmd.CommandText = "DELETE FROM AUTHORS WHERE ID_AUTHOR = " + indexAuthor;

                await cmd.ExecuteNonQueryAsync();
                cmd.CommandText = "COMMIT";

                await cmd.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            Show();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update(table.SelectedItem);
            update.ShowDialog();
            Show();
        }

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            Show();
        }

        private void selectButton_Click(object sender, RoutedEventArgs e)
        {
           var query =
           from authors in entity.AUTHORS
           join books in entity.BOOKS
           on authors.ID_AUTHOR equals books.ID_AUTHOR
           join edition in entity.EDITION
           on books.ID_BOOK equals edition.ID_BOOK
           where books.COUNT_BOOKS > 150
           select new
           {
               authors.ID_AUTHOR,
               authors.FIO,
               books.ID_BOOK,
               books.NAME_BOOK,
               books.COUNT_BOOKS,
               books.THE_YEAR_OF_PUBLISHING,
               edition.ID_EDITION,
               edition.DATE_SURRENDER,
               edition.DATE_EDITION
           };
            table.ItemsSource = query.ToList();
        }

        private void procedureButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("EXEC SelectBooks @ID_BOOK = " + booksTextBox.Text + ", @DATE_EDITION = '" + dateTextBox.Text + "';", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            table.ItemsSource = dt.DefaultView;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            table.SelectedIndex = table.SelectedIndex + 1;
            if (table.SelectedIndex < 0)
                table.SelectedIndex = 0;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            table.SelectedIndex = table.SelectedIndex - 1;
            if (table.SelectedIndex < 0)
                table.SelectedIndex = 0;
        }

        private void table_SelectionChanged()
        {

        }
    }
}
