using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
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

namespace lab9
{
    public partial class Update : Window
    {
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var author = db.Authors.Where(p => p.ID_AUTHOR == idArray[0]).FirstOrDefault();
                        var book = db.Books.Where(a => a.ID_BOOK == idArray[1]).FirstOrDefault();
                        var edition = db.Edition.Where(p => p.ID_EDITION == idArray[2]).FirstOrDefault();

                        author.FIO = fio_authorTextBox.Text;
                        book.NAME_BOOK = name_bookTextBox.Text;
                        book.THE_YEAR_OF_PUBLISHING = Convert.ToInt16(the_year_of_publishingTextBox.Text);
                        book.COUNT_BOOKS = Convert.ToInt16(count_booksTextBox.Text);
                        edition.DATE_SURRENDER = Convert.ToInt16(date_surrenderTextBox.Text);
                        edition.DATE_EDITION = Convert.ToInt16(date_editionTextBox.Text);
                        db.SaveChanges();
                        transaction.Commit();
                        Close();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
