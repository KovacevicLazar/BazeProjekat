using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class SmenaDAO : BaseRepo<Smena>
    {
        public override List<Smena> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Smene.Include("VatrogasnaJedinica").Include("Intervencije").ToList();
            }
        }
    }
}
