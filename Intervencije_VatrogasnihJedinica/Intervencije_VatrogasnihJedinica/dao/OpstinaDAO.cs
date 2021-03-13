using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class OpstinaDAO : Repository<Opstina>
    {
        public override List<Opstina> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Opstine.Include("VatrogasneJedinice").Include("Intervencije").ToList();
            }
        }

        public Opstina pronadjiPoNazivu(string naziv)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Opstine.Where(x => x.Naziv_Opstine.ToUpper() == naziv.ToUpper()).FirstOrDefault();
            }
        }

        public void PRO(Opstina opstina)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                
                using (var transaction = db.Database.BeginTransaction())
                {
                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Opstine] ON;");
                    db.Opstine.Add(opstina);
                    db.SaveChanges();
                    transaction.Commit();
                }
                db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Opstine] OFF");
            }
            
        }
    }
}
