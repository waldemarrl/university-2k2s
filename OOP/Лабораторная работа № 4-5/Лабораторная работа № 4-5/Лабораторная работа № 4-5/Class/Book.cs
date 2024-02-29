using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Лабораторная_работа___4_5.Class
{
    [Serializable]
    [XmlRoot("Book")]
    public class Book
    {
        public string NameBook { get; set; }
        public string FormatBook { get; set; }
        public string Categories { get; set; }
        public string PublishingBook { get; set;}
        public string Country { get; set; }
        public string CostBook { get; set; }
        public string SizeBook { get; set; }
        public string AuthorBook { get; set; }

        public Book()
        {

        }

        public Book(string nameBook, string formatBook, string categories, string publishingBook, string country, string costBook, string sizeBook, string authorBook)
        {
            NameBook = nameBook;
            FormatBook = formatBook;
            Categories = categories;
            Categories = categories;
            PublishingBook = publishingBook;
            Country = country;
            CostBook = costBook;
            SizeBook = sizeBook;
            AuthorBook = authorBook;
        }
    }
}
