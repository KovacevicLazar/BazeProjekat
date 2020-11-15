using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class VatrogasneJediniceViewModel
    {
        private VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeVatrogasneJediniceViewModel(), null, null);

        }

        public void Obrisi()
        {
            
        }

        public void Izmeni()
        {
           
        }
    }
}
