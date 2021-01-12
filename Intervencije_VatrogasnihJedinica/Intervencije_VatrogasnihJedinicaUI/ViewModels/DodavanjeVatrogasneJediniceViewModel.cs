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
    public class DodavanjeVatrogasneJediniceViewModel : Screen
    {
        public DodavanjeVatrogasneJediniceViewModel()
        {
            OpstinaDAO opstinaDAO = new OpstinaDAO();
            Opstine = opstinaDAO.GetList();
        }
        
        public List<Opstina> Opstine { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get; set; }

        public void Dodaj()
        {
            VatrogasnaJedinica vatrogasnaJedinica = new VatrogasnaJedinica();
            vatrogasnaJedinica.Naziv = Naziv;
            vatrogasnaJedinica.Adresa = Adresa;
            vatrogasnaJedinica.Id_Opstine = IzabranaOpstina.ID;
            VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
            vatrogasnaJedinicaDAO.Insert(vatrogasnaJedinica);
            TryClose();
        }
    }
}
