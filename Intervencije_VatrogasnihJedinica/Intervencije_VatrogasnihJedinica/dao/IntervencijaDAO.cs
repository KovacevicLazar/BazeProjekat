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
                return db.Intervencije.Include("Opstina").Include("Uvidjaj").Include("RadniciSaSmenama").ToList();
            }
        }

        public  List<Intervencija> GetFilteredList(List<int> opstineID, List<TipIntervencijeEnum> tipovi)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Intervencije.Include("Opstina").Include("Uvidjaj").Where(x => (opstineID.Contains(x.Id_Opstine) || opstineID.Count == 0) && (tipovi.Contains(x.Tip) || tipovi.Count == 0)).ToList();
            }
        }
    }
}
