using Microsoft.EntityFrameworkCore;
using lab9.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9.Classes
{
    public class EditionRepository : IRepository<EDITION>
    {
        private ApplicationContext db;

        public EditionRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<EDITION> GetAll()
        {
            return db.Edition;
        }

        public EDITION Get(int id)
        {
            return db.Edition.Find(id);
        }

        public void Create(EDITION edition)
        {
            db.Edition.Add(edition);
        }

        public void Update(EDITION edition)
        {
            db.Entry(edition).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            EDITION edition = db.Edition.Find(id);
            if (edition != null)
                db.Edition.Remove(edition);
        }
    }
}
