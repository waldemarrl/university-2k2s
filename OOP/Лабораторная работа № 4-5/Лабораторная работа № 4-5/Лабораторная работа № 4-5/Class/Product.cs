using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Лабораторная_работа___4_5.Class
{
    [Serializable]
    public class Product
    {
        [XmlArray("Books"), XmlArrayItem("Book")]
        public List<Book> bookList;
        public Product()
        {
            bookList = new List<Book>();
        }
        public void Add(Book book)
        {
            bookList.Add(book);
        }
    }
}
