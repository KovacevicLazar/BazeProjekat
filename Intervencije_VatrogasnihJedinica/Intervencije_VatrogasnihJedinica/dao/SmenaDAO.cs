﻿using System.Collections.Generic;
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
    }
}
