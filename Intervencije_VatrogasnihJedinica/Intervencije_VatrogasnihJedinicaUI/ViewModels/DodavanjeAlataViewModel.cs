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
    public  class DodavanjeAlataViewModel : Screen
    {

        public DodavanjeAlataViewModel()
        {
            var voziloDAO = new VoziloDAO();
            Vozila = voziloDAO.GetList();
        }

        public string NazivAlata { get; set; }


        public List<Vozilo> Vozila { get; set; }
        public Vozilo IzabranoVozilo { get; set; }

        public void Dodaj()
        {
            Alat alat = new Alat(NazivAlata, IzabranoVozilo.Id_Vozila);
         
            AlatDAO alataDAO = new AlatDAO();
            alataDAO.Insert(alat);
            TryClose();
        }
    }
}
