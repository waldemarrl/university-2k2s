using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace Лабораторная_работа__8
{
    public partial class Update : Window
    {
        private SqlConnection sqlConnection = null;
        int[] idArray;
        public Update(object item)
        {
            InitializeComponent();
            fio_authorTextBox.Text = item.GetType().GetProperty("FIO").GetValue(item).ToString();
            id_bookTextBox.Text = item.GetType().GetProperty("ID_BOOK").GetValue(item).ToString();
            name_bookTextBox.Text = item.GetType().GetProperty("NAME_BOOK").GetValue(item).ToString();
            the_year_of_publishingTextBox.Text = item.GetType().GetProperty("THE_YEAR_OF_PUBLISHING").GetValue(item).ToString();
            count_booksTextBox.Text = item.GetType().GetProperty("COUNT_BOOKS").GetValue(item).ToString();
            id_editionTextBox.Text = item.GetType().GetProperty("ID_EDITION").GetValue(item).ToString();
            date_editionTextBox.Text = item.GetType().GetProperty("DATE_EDITION").GetValue(item).ToString();
            date_surrenderTextBox.Text = item.GetType().GetProperty("DATE_SURRENDER").GetValue(item).ToString();
            idArray = new int[3] {(int)item.GetType().GetProperty("ID_AUTHOR").GetValue(item),
                (int)item.GetType().GetProperty("ID_BOOK").GetValue(item),
                (int)item.GetType().GetProperty("ID_EDITION").GetValue(item)};
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBaseLaba8"].ConnectionString);

            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("CONNECTION IS ESTABLISHED!");
            }
            else
            {
                MessageBox.Show("CONNECTION NOT ESTABLISHED!");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand transaction = new SqlCommand("BEGIN TRANSACTION", sqlConnection);
            await transaction.ExecuteNonQueryAsync();

            SqlCommand addAuthors = new SqlCommand("UPDATE [AUTHORS] SET FIO = @FIO WHERE ID_AUTHOR = " + idArray[0], sqlConnection);

            addAuthors.Parameters.AddWithValue("FIO", fio_authorTextBox.Text);
            await addAuthors.ExecuteNonQueryAsync();

            SqlCommand addBooks = new SqlCommand("UPDATE [BOOKS] SET NAME_BOOK = @NAME_BOOK, THE_YEAR_OF_PUBLISHING = @THE_YEAR_OF_PUBLISHING, COUNT_BOOKS = @COUNT_BOOKS WHERE ID_BOOK = " + idArray[1], sqlConnection);

            addBooks.Parameters.AddWithValue("NAME_BOOK", name_bookTextBox.Text);
            addBooks.Parameters.AddWithValue("THE_YEAR_OF_PUBLISHING", the_year_of_publishingTextBox.Text);
            addBooks.Parameters.AddWithValue("COUNT_BOOKS", count_booksTextBox.Text);
            await addBooks.ExecuteNonQueryAsync();

            SqlCommand addEdition = new SqlCommand("UPDATE [EDITION] SET DATE_EDITION = @DATE_EDITION, DATE_SURRENDER = @DATE_SURRENDER WHERE ID_EDITION = " + idArray[2], sqlConnection);

            addEdition.Parameters.AddWithValue("DATE_EDITION", date_editionTextBox.Text);
            addEdition.Parameters.AddWithValue("DATE_SURRENDER", date_surrenderTextBox.Text);
            await addEdition.ExecuteNonQueryAsync();

            transaction.CommandText = "COMMIT";
            await transaction.ExecuteNonQueryAsync();

            sqlConnection.Close();

            this.Close();
        }
    }
}
