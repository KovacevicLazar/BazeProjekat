using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class KomandirDAO : Repository<Komandir>
    {
        public override List<Komandir> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Komandiri.Include("VatrogasnaJedinica").ToList();
            }
        }
    }
}
