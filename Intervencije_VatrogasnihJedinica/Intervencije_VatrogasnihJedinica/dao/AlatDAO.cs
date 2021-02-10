using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class AlatDAO : BaseRepo<Alat>
    {
        public List<Alat> AlatiZaNavalnaVozila()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Alati.Where(x => x.Tip == TipAlataEnum.AlatOpsteNamene || x.Tip == TipAlataEnum.ProtivPozarniAlat).ToList();
            }
        }

        public List<Alat> AlatiZaTehnickaVozila()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Alati.Where(x => x.Tip == TipAlataEnum.AlatOpsteNamene || x.Tip == TipAlataEnum.TehnickiAlat).ToList();
            }
        }
    }
}
