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

using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Configuration;
using System.Data;
using System.IdentityModel.Metadata;
using lab9.Classes;

namespace lab9
{
    public partial class MainWindow : Window
    {
        private SqlConnection sqlConnection = null;
        private UnitOfWork unitOfwork;
        public MainWindow()
        {
            InitializeComponent();
            unitOfwork = new UnitOfWork();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Show();
        }
        private new void Show()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                var query =
                from authors in db.Authors
                join books in db.Books
                on authors.ID_AUTHOR equals books.ID_AUTHOR
                join edition in db.Edition
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
            }
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            Insert insert = new Insert();
            insert.ShowDialog();
            Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    if (table.SelectedItem != null)
                    {
                        var author = db.Authors.Where(p => p.ID_AUTHOR ==
                        (int)table.SelectedItem.GetType().GetProperty("ID_AUTHOR").GetValue(table.SelectedItem)).FirstOrDefault();
                        var book = db.Books.Where(a => a.ID_BOOK ==
                        (int)table.SelectedItem.GetType().GetProperty("ID_BOOK").GetValue(table.SelectedItem)).FirstOrDefault();
                        var edition = db.Edition.Where(p => p.ID_EDITION == 
                        (int)table.SelectedItem.GetType().GetProperty("ID_EDITION").GetValue(table.SelectedItem)).FirstOrDefault();

                        unitOfwork.Edition.Delete(edition.ID_EDITION);
                        unitOfwork.Books.Delete(book.ID_BOOK);
                        unitOfwork.Authors.Delete(author.ID_AUTHOR);
                        unitOfwork.Save();
                        transaction.Commit();
                    }
                    Show();
                }
            }
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
            using (ApplicationContext db = new ApplicationContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var query =
                    from authors in db.Authors
                    join books in db.Books
                    on authors.ID_AUTHOR equals books.ID_AUTHOR
                    join edition in db.Edition
                    on books.ID_BOOK equals edition.ID_BOOK
                    where books.COUNT_BOOKS > int.Parse(booksTextBox.Text)
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
            }
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
    }
}
