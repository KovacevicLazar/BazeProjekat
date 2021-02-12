using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class InformacijeOSmenamaVatrogasneJediniceViewModel
    {
        public InformacijeOSmenamaVatrogasneJediniceViewModel(VatrogasnaJedinica vatrogasnaJedinica)
        {
            SmenaDAO smenaDAO = new SmenaDAO();
            var smene = smenaDAO.SmeneUnutarJedneVSJ(vatrogasnaJedinica.ID);
            SmenaA = smene.Find(x => x.NazivSmene == "Smena A");
            SmenaB = smene.Find(x => x.NazivSmene == "Smena B");
            SmenaC = smene.Find(x => x.NazivSmene == "Smena C");
            SmenaD = smene.Find(x => x.NazivSmene == "Smena D");
            VatrogasnaJedinica = vatrogasnaJedinica;
        }
        public VatrogasnaJedinica VatrogasnaJedinica { get; set; }
        public Smena SmenaA { get; set; }
        public Smena SmenaB { get; set; }
        public Smena SmenaC { get; set; }
        public Smena SmenaD { get; set; }
    }
}
