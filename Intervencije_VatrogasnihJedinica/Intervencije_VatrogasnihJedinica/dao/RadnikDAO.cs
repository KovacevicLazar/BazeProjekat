using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class RadnikDAO : Repository<Radnik>
    {
        public override List<Radnik> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Radnici.Include("VatrogasnaJedinica").Include("Smena").ToList();
            }
        }

        public Radnik PronadjiPoJMBG(string jmbg)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Radnici.Include("VatrogasnaJedinica").Include("Smena").Where(x => x.JMBG == jmbg).FirstOrDefault();
            }
        }
    }
}
