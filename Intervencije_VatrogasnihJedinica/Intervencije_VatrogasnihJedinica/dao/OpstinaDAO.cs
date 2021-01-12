using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class OpstinaDAO : BaseRepo<Opstina>
    {
        public override List<Opstina> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Opstine.Include("VatrogasneJedinice").Include("Intervencije").ToList();
            }
        }
    }
}
