using Microsoft.EntityFrameworkCore;
using lab9.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Classes
{
    public class BooksRepository : IRepository<BOOKS> 
    {
        private ApplicationContext db;

        public BooksRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<BOOKS> GetAll()
        {
            return db.Books;
        }

        public BOOKS Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(BOOKS books)
        {
            db.Books.Add(books);
        }

        public void Update(BOOKS books)
        {
            db.Entry(books).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BOOKS books = db.Books.Find(id);
            if (books != null)
                db.Books.Remove(books);
        }
    }
}

