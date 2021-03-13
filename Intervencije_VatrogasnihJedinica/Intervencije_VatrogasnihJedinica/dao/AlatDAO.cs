using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class AlatDAO : Repository<Alat>
    {
        public List<Alat> AlatiZaNavalnaVozila()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Alati.Where(x => x.Tip == TipAlataEnum.Alat_Opste_Namene || x.Tip == TipAlataEnum.Protivpozarni_Alat).ToList();
            }
        }

        public List<Alat> AlatiZaTehnickaVozila()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Alati.Where(x => x.Tip == TipAlataEnum.Alat_Opste_Namene || x.Tip == TipAlataEnum.Tehnicki_Alat).ToList();
            }
        }
    }
}
