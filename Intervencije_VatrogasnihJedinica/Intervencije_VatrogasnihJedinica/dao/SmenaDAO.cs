﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class SmenaDAO : BaseRepo<Smena>
    {
        public override List<Smena> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return  db.Smene.Include("VatrogasnaJedinica").Include("Intervencije").ToList();
            }
        }
        public  List<Smena> SmeneUnutarJedneVSJ(int idVSJ)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Smene.Include("VatrogasnaJedinica").Include("Intervencije").Where(x => x.VatrogasnaJedinicaID == idVSJ).ToList();
            }
        }

        public List<Smena> ListaDezurnihSmenaNaDatum(DateTime datumIntervencije)
        {
            List<Smena> sveSmene = new List<Smena>();
            List<Smena> smene = new List<Smena>();
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                sveSmene = db.Smene.Include("VatrogasnaJedinica").Include("Intervencije").Include("Radnici").ToList();
            }
            foreach(var smena in sveSmene)
            {
                if (SmenaDezuraZaVremeIntervencije(datumIntervencije, smena.DatumPrvogDezurstva))
                {
                    smene.Add(smena);
                }
            }
            return smene;
        }

        private bool SmenaDezuraZaVremeIntervencije(DateTime datumIntervencije, DateTime datumPrvogDezurstvaSmene)
        {
            double ukupanBrojCasova = 0;
            ukupanBrojCasova = (datumIntervencije - datumPrvogDezurstvaSmene).TotalHours;
            double brojCasovaOdPocetkaPoslednjegDnevnogDezurstva = ukupanBrojCasova % 96; //jer smena krece u sledece dnevno dezurstvo 96sati od pocetka poslednjeg dnevnog dezurstva
            if( 0 <= brojCasovaOdPocetkaPoslednjegDnevnogDezurstva && brojCasovaOdPocetkaPoslednjegDnevnogDezurstva < 12) //(Dnevno dezurstvo) ako je broj sati od starta dnevnog dezurstva manji od 12 smena trenutno dezura 
            {
                return true;
            }
            else if(36 <= brojCasovaOdPocetkaPoslednjegDnevnogDezurstva && brojCasovaOdPocetkaPoslednjegDnevnogDezurstva < 48) //(Nocno dezurstvo)- nakon 36 sati od starta dnevne smene, smena ponovo dezura
            {
                return true;
            }
            return false;
        }
        
    }
}
