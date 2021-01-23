using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class RadnikDAO : BaseRepo<Radnik>
    {
        public override List<Radnik> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Radnici.Include("VatrogasnaJedinica").ToList();
            }
        }
    }
}
