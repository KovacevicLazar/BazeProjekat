using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository()
        {
        }

        public TEntity FindById(params object[] id)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public virtual List<TEntity> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity Insert(TEntity entity)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
                return entity;
            }
        }

        public void Delete(object id)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                DbSet<TEntity> dbSet = db.Set<TEntity>();
                TEntity entity = db.Set<TEntity>().Find(id);
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                db.Set<TEntity>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
