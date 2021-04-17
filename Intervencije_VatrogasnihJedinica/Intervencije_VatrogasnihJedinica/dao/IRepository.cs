using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinica.dao
{
    interface IRepository<TEntity> where TEntity : class
    {
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(params object[] id);
        TEntity FindById(params object[] id);
        List<TEntity> GetList();
    }
}
