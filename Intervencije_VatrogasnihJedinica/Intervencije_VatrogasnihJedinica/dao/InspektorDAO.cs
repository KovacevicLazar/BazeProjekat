using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class InspektorDAO : Repository<Inspektor>
    {
        public Inspektor PronadjiPoBrojuTelefona(string brojTelefona)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Inspektori.Where(x => x.BrojTelefona == brojTelefona).FirstOrDefault();
            }
        }
    }
}
