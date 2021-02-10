using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(params object[] id);
        List<TEntity>  GetList();
        TEntity Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity);
    }
}
