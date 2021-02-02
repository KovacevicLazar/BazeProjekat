using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class VoziloDAO : BaseRepo<Vozilo>
    {
        public override List<Vozilo> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vozila.Include("VatrogasnaJedinica").Include("Alati").ToList();
            }
        }
    }
}
