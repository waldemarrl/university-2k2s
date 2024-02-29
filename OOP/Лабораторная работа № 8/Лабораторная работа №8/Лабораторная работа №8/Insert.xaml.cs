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
    public partial class Insert : Window
    {
        private SqlConnection sqlConnection = null;
        public Insert()
        {
            InitializeComponent();
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

            SqlCommand addAuthors = new SqlCommand("INSERT INTO [AUTHORS] (ID_AUTHOR, FIO) VALUES (@ID_AUTHOR, @FIO)", sqlConnection);

            addAuthors.Parameters.AddWithValue("ID_AUTHOR", id_authorTextBox.Text);
            addAuthors.Parameters.AddWithValue("FIO",  fio_authorTextBox.Text);
            await addAuthors.ExecuteNonQueryAsync();

            SqlCommand addBooks = new SqlCommand("INSERT INTO [BOOKS] (ID_BOOK, NAME_BOOK, ID_AUTHOR, THE_YEAR_OF_PUBLISHING, COUNT_BOOKS)" +
                "VALUES (@ID_BOOK, @NAME_BOOK, @ID_AUTHOR, @THE_YEAR_OF_PUBLISHING, @COUNT_BOOKS)", sqlConnection);

            addBooks.Parameters.AddWithValue("ID_BOOK", id_bookTextBox.Text);
            addBooks.Parameters.AddWithValue("NAME_BOOK", name_bookTextBox.Text);
            addBooks.Parameters.AddWithValue("ID_AUTHOR", id_authorTextBox.Text);
            addBooks.Parameters.AddWithValue("THE_YEAR_OF_PUBLISHING", the_year_of_publishingTextBox.Text);
            addBooks.Parameters.AddWithValue("COUNT_BOOKS", count_booksTextBox.Text);
            await addBooks.ExecuteNonQueryAsync();

            SqlCommand addEdition = new SqlCommand("INSERT INTO [EDITION] (ID_EDITION, ID_BOOK ,DATE_EDITION, DATE_SURRENDER)" +
                "VALUES (@ID_EDITION, @ID_BOOK, @DATE_EDITION, @DATE_SURRENDER)", sqlConnection);

            addEdition.Parameters.AddWithValue("ID_EDITION", id_editionTextBox.Text);
            addEdition.Parameters.AddWithValue("ID_BOOK", id_bookTextBox.Text);
            addEdition.Parameters.AddWithValue("DATE_EDITION", date_editionTextBox.Text);
            addEdition.Parameters.AddWithValue("DATE_SURRENDER", date_surrenderTextBox.Text);
            await addEdition.ExecuteNonQueryAsync();

            transaction.CommandText = "COMMIT";
            await transaction.ExecuteNonQueryAsync();

            sqlConnection.Close();

            this.Close();
        }

        private void id_bookTextBox_TextChanged()
        {

        }
    }
}
