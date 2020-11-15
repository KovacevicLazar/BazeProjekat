using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class OpstinaDAO : BaseRepo<Opstina>
    {
        //public Opstina FindById( int idOpstine)
        //{
        //    using(var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
        //    {
        //        return db.Opstine.Find(idOpstine);
        //    }
        //}

        //public List<Opstina> sveOpstine()
        //{
        //    using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
        //    {
        //        return db.Opstine.ToList();
        //    }

        //}

        //public void DodavanjeOpstine(Opstina opstina)
        //{
        //    using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
        //    {
        //        db.Opstine.Add(opstina);
        //        db.SaveChanges();
        //    }
        //}


        //public void BrisanjeOpstine(int idOpstine)
        //{
        //    using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
        //    {
        //        Opstina opstina = db.Opstine.Find(idOpstine);
        //        db.Entry(opstina).State = System.Data.Entity.EntityState.Deleted;
        //        db.SaveChanges();
        //    }
        //}


        //public void IzmenaOpstine(Opstina opstina)
        //{
        //    using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
        //    {
        //        db.Entry(opstina).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}

    }
}
