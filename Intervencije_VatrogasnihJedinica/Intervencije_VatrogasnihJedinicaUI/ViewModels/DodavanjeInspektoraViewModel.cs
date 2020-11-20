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
    public class DodavanjeInspektoraViewModel : Screen
    {
        public DodavanjeInspektoraViewModel()
        {
           
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Telefon { get; set; }

        public void Dodaj()
        {
            InspektorDAO inspektorDAO = new InspektorDAO();
            Inspektor inspektor = new Inspektor();
            inspektor.Ime = Ime;
            inspektor.Prezime = Prezime;
            inspektor.Broj_Telefona = Telefon;

            inspektorDAO.Insert(inspektor);
            TryClose();
        }
    }
}
