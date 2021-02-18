﻿using System;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class TehnickoVoziloDAO : BaseRepo<Tehnicko_Vozilo>
    {
        public int DatumPrveIntervencije(int id)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var vozilo = db.Set<Tehnicko_Vozilo>().Include("Intervencije").SingleOrDefault(x => x.ID == id);
                if(vozilo.Intervencije.Count != 0)
                {
                    return vozilo.Intervencije.Min(x => x.Datum_I_Vreme).Year;
                }
                return DateTime.Now.Year;
            }
        }
    }
}
