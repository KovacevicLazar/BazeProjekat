using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class AlatDAO : BaseRepo<Alat>
    {
        public override List<Alat> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Alati.Include("Vozilo").ToList();
            }
        }
    }
}
