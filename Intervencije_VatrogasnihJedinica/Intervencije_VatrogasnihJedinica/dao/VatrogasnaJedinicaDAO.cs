using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class VatrogasnaJedinicaDAO : BaseRepo<VatrogasnaJedinica>
    {
        public override  List<VatrogasnaJedinica> GetList() {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vatrogasne_Jedinice.Include("Opstina").Include("Komandir").Include("Radnici").Include("Vozila").ToList();
            }
        }
    }
}
