using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
//что все операции с базой данных должны выполняться через единую точку входа - объект Unit of Work. Этот объект отслеживает все
//изменения, которые были сделаны в объектах сущностей, и сохраняет их в базе данных в одной транзакции.
namespace lab9.Classes
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext db = new ApplicationContext();
        private AuthorsRepository authorsRepository;
        private BooksRepository booksRepository;
        private EditionRepository editionRepository;

        public AuthorsRepository Authors
        {
            get
            {
                if (authorsRepository == null)
                    authorsRepository = new AuthorsRepository(db);
                return authorsRepository;
            }
        }

        public BooksRepository Books
        {
            get
            {
                if (booksRepository == null)
                    booksRepository = new BooksRepository(db);
                return booksRepository;
            }
        }

        public EditionRepository Edition
        {
            get
            {
                if (editionRepository == null)
                    editionRepository= new EditionRepository(db);
                return editionRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
