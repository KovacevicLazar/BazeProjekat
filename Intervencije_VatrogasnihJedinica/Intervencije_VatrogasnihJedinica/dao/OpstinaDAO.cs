using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class OpstinaDAO : BaseRepo<Opstina>
    {
        public override List<Opstina> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Opstine.Include("VatrogasneJedinice").Include("Intervencije").ToList();
            }
        }

        public Opstina pronadjiPoNazivu(string naziv)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Opstine.Where(x => x.Naziv_Opstine.ToUpper() == naziv.ToUpper()).FirstOrDefault();
            }
        }
    }
}
