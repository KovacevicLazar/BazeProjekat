using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class UvidjajDAO : BaseRepo<Uvidjaj>
    {
        public Uvidjaj FindById(int idUvidjaja)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Uvidjaji.Include("Inspektor").SingleOrDefault(x => x.ID == idUvidjaja);
            }
        }
    }
}
