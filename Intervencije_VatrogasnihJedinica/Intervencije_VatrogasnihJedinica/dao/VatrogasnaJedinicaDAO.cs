using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class VatrogasnaJedinicaDAO : Repository<VatrogasnaJedinica>
    {
        public override List<VatrogasnaJedinica> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vatrogasne_Jedinice.Include("Opstina").Include("Smene").Include("Komandir").Include("Radnici").Include("Vozila").ToList();
            }
        }

        public async Task<List<VatrogasnaJedinica>> GetListAsync()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return await Task.Run(() => db.Vatrogasne_Jedinice.Include("Opstina").Include("Smene").Include("Komandir").Include("Radnici").Include("Vozila").ToListAsync());
            }
        }
    }
}
