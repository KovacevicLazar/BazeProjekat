using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class IntervencijaDAO : Repository<Intervencija>
    {
        public override List<Intervencija> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Intervencije.Include("Opstina").Include("Uvidjaj.Inspektor").Include("RadniciSaSmenama.Radnik.VatrogasnaJedinica").Include("RadniciSaSmenama.Smena").ToList();
            }
        }

        public  List<Intervencija> GetFilteredList(List<int> opstineID, List<TipIntervencijeEnum> tipovi)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Intervencije.Include("Opstina").Include("Uvidjaj.Inspektor").Include("RadniciSaSmenama.Radnik.VatrogasnaJedinica").Include("RadniciSaSmenama.Smena").Where(x => (opstineID.Contains(x.OpstinaID) || opstineID.Count == 0) && (tipovi.Contains(x.Tip) || tipovi.Count == 0)).ToList();
            }
        }
    }
}
