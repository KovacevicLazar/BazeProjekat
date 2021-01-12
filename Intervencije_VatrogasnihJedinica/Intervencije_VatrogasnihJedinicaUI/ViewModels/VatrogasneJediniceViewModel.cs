using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class VatrogasneJediniceViewModel : PropertyChangedBase
    {
        public VatrogasneJediniceViewModel()
        {
            SveJedinice = vatrogasnaJedinicaDAO.GetList();
        }

        private VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
        IWindowManager manager = new WindowManager();
        public List<VatrogasnaJedinica> sveJedinice = new List<VatrogasnaJedinica>();
        public List<VatrogasnaJedinica> SveJedinice { get { return sveJedinice; } set { sveJedinice = value; NotifyOfPropertyChange(() => sveJedinice); } }
        public VatrogasnaJedinica OznacenaJedinica { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeVatrogasneJediniceViewModel(), null, null);
            SveJedinice = vatrogasnaJedinicaDAO.GetList();
        }

        public void Obrisi()
        {
            if (OznacenaJedinica != null)
            {
                vatrogasnaJedinicaDAO.Delete(OznacenaJedinica.ID);
                SveJedinice = vatrogasnaJedinicaDAO.GetList();
                OznacenaJedinica = null;
            }
            else
            {

            }
        }
        public void Izmeni()
        {
            var i = OznacenaJedinica;
        }
    }
}
