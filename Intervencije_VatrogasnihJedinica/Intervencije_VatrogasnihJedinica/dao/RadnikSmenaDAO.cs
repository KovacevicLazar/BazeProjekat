using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class RadnikSmenaDAO : BaseRepo<RadnikUSmeni>
    {
        public void PostaviDatumKrajaRadaUsmeni(int radnikID, int smenaID, DateTime datumKrajaRada)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var RadnikUSmeni = db.RadniciUSmenama.Where(x => x.RadnikID == radnikID && x.SmenaID == smenaID && x.DatumKrajaRada == null).FirstOrDefault();
                RadnikUSmeni.DatumKrajaRada = datumKrajaRada;
                db.Set<RadnikUSmeni>().Attach(RadnikUSmeni);
                db.Entry(RadnikUSmeni).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public DateTime DatumPoslednjePromeneSmene(int radnikID, int smenaID)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var RadnikUSmeni = db.RadniciUSmenama.Where(x => x.RadnikID == radnikID && x.SmenaID == smenaID && x.DatumKrajaRada == null).FirstOrDefault();
                return RadnikUSmeni.DatumPocetkaRada;
            }
        }

        public DateTime DatumPoslednjeIntervencijeRadnikaSaSmenom(int radnikID, int smenaID)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var radnikUSmeni = db.RadniciUSmenama.Include("Intervencije").Where(x => x.RadnikID == radnikID && x.SmenaID == smenaID && x.DatumKrajaRada == null).FirstOrDefault();
                if (radnikUSmeni.Intervencije.Count != 0)
                {
                    return radnikUSmeni.Intervencije.Max(x => x.Datum_I_Vreme);
                }
                return radnikUSmeni.DatumPocetkaRada; // ako nije imao intervencije sa smenom, vrati datum od kog radi u smeni
            }
        }

        public List<RadnikUSmeni> ListaRadnikaIzSmeneZaDatum(List<int> smeneID, DateTime datum)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var RadnikUSmeni = db.RadniciUSmenama.Include("Radnik").Include("Smena").Where(x => smeneID.Contains(x.SmenaID) && x.DatumPocetkaRada < datum).ToList();
                return RadnikUSmeni.Where(x => datum < PreuzmiDatumKrajaRadaUSmeni(x.DatumKrajaRada)).ToList();
            }
        }

        private DateTime PreuzmiDatumKrajaRadaUSmeni(DateTime? datum)
        {
            return (datum == null) ? DateTime.Now : (DateTime)datum;
        }
    }
}
