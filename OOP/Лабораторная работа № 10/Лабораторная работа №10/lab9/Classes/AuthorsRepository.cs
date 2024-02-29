using Microsoft.EntityFrameworkCore;
using lab9.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//Принцип использования паттерна Repository заключается в том, что все операции с данными выполняются через объекты репозитория,
//которые предоставляют методы для получения, добавления, изменения и удаления данных.
namespace lab9.Classes
{
    public class AuthorsRepository : IRepository<AUTHORS>
    {
        private ApplicationContext db;
        public AuthorsRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public IEnumerable<AUTHORS> GetAll()
        {
            return db.Authors;
        }

        public AUTHORS Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(AUTHORS author)
        {
            db.Authors.Add(author);
        }

        public void Update(AUTHORS author)
        {
            db.Entry(author).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AUTHORS author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }

    }
}
