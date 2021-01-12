using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(params object[] id);
        List<TEntity> GetList();

        void Insert(TEntity entity);

        void Delete(object id);

        void Update(TEntity entity);

    }
}
