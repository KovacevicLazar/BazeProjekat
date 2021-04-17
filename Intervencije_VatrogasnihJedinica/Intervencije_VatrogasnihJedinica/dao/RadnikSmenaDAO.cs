﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class RadnikSmenaDAO : Repository<RadnikUSmeni>
    {
        public override RadnikUSmeni Insert(RadnikUSmeni entity)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var radnikSmena = db.RadniciUSmenama.Where(x => x.RadnikID == entity.RadnikID && x.SmenaID == entity.SmenaID && x.DatumPocetkaRada <= entity.DatumPocetkaRada && x.DatumKrajaRada >= entity.DatumKrajaRada).FirstOrDefault();
                if (radnikSmena == null)
                {
                    return base.Insert(entity);
                }
                return radnikSmena;
            }

        }

        public void PostaviDatumKrajaRadaUsmeni(int radnikID, int smenaID, DateTime datumKrajaRada)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var RadnikUSmeni = db.RadniciUSmenama.Where(x => x.RadnikID == radnikID && x.SmenaID == smenaID && x.DatumKrajaRada == null).FirstOrDefault();
                if (RadnikUSmeni.DatumPocetkaRada == datumKrajaRada)
                {
                    db.Set<RadnikUSmeni>().Attach(RadnikUSmeni);
                    db.Entry(RadnikUSmeni).State = EntityState.Deleted;
                    db.SaveChanges();
                    return;
                }
                RadnikUSmeni.DatumKrajaRada = datumKrajaRada;
                db.Set<RadnikUSmeni>().Attach(RadnikUSmeni);
                db.Entry(RadnikUSmeni).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public DateTime? DatumPoslednjePromeneSmene(int radnikID, int smenaID)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var RadnikUSmeni = db.RadniciUSmenama.Where(x => x.RadnikID == radnikID && x.SmenaID == smenaID && x.DatumKrajaRada == null).FirstOrDefault();
                return RadnikUSmeni?.DatumPocetkaRada;
            }
        }

        public DateTime? DatumPoslednjeIntervencijeRadnikaSaSmenom(int radnikID, int smenaID)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                var radnikUSmeni = db.RadniciUSmenama.Include("Intervencije").Where(x => x.RadnikID == radnikID && x.SmenaID == smenaID && x.DatumKrajaRada == null).FirstOrDefault();
                if (radnikUSmeni.Intervencije.Count != 0)
                {
                    return radnikUSmeni.Intervencije.Max(x => x.DatumIVreme);
                }
                return null; // ako nije imao intervencije sa smenom,
            }
        }

        public List<RadnikUSmeni> ListaRadnikaIzSmeneZaDatum(List<int> smeneID, DateTime datum)
        {
            if (smeneID.Count != 0)
            {
                using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
                {
                    return db.RadniciUSmenama.Include("Radnik").Include("Smena").Where(x => smeneID.Contains(x.SmenaID) && x.DatumPocetkaRada < datum && (x.DatumKrajaRada == null || datum < x.DatumKrajaRada)).ToList();
                }
            }
            return new List<RadnikUSmeni>();
        }
    }
}
