using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
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


using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;
using System.Net;

namespace lab9
{
    public partial class Insert : Window
    {
        private AUTHORS author;
        private BOOKS book;
        private EDITION edition;
        public Insert()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        edition = new EDITION
                        {
                            ID_EDITION = int.Parse(id_editionTextBox.Text),
                            ID_BOOK = int.Parse(id_bookTextBox.Text),
                            DATE_EDITION = int.Parse(date_editionTextBox.Text),
                            DATE_SURRENDER = int.Parse(date_surrenderTextBox.Text)
                        };
                        book = new BOOKS
                        {
                            ID_BOOK = int.Parse(id_bookTextBox.Text),
                            NAME_BOOK = name_bookTextBox.Text,
                            ID_AUTHOR = int.Parse(id_authorTextBox.Text),
                            THE_YEAR_OF_PUBLISHING = int.Parse(the_year_of_publishingTextBox.Text),
                            COUNT_BOOKS = int.Parse(count_booksTextBox.Text)
                        };
                        author = new AUTHORS
                        {
                            ID_AUTHOR = int.Parse(id_authorTextBox.Text),
                            FIO = fio_authorTextBox.Text
                        };
                        
                        db.Authors.Add(author);
                        db.Books.Add(book);
                        db.Edition.Add(edition);        
                        db.SaveChanges();
                        transaction.Commit();

                        Show();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback(); 
                    }
                    Close();
                }
            }
        }
    }
}
