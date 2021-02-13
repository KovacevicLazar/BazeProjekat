using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class IntervencijaDAO : BaseRepo<Intervencija>
    {
        public override List<Intervencija> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Intervencije.Include("Opstina").Include("Uvidjaj").ToList();
            }
        }
    }
}
