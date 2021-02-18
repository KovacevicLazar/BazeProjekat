using System;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class NavalnoVoziloDAO : BaseRepo<Navalno_Vozilo>
    {
        public int DatumPrveIntervencije(int id)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var vozilo = db.Set<Navalno_Vozilo>().Include("Pozari").SingleOrDefault(x => x.ID == id);
                if (vozilo.Pozari.Count != 0)
                {
                    return vozilo.Pozari.Min(x => x.Datum_I_Vreme).Year;
                }
                return DateTime.Now.Year;
            }
        }
    }
}
