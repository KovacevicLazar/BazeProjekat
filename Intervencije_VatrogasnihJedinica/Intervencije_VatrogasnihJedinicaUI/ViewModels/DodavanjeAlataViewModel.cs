using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class DodavanjeAlataViewModel : Screen
    {
        public DodavanjeAlataViewModel(Alat alat)
        {
            TipoviAlata = Enum.GetValues(typeof(TipAlataEnum)).Cast<TipAlataEnum>().ToList();
            Alat = alat;
            if (alat != null)
            {
                NazivAlata = alat.Naziv_Alata;
                TipAlata = alat.Tip;
            }
        }
        public List<TipAlataEnum> TipoviAlata { get; set; }
        public TipAlataEnum TipAlata { get; set; }
        public Alat Alat { get; set; }
        public string NazivAlata { get; set; }

        private string porukaGreskeZaNazivAlata = "";
        public string PorukaGreskeZaNazivAlata { get => porukaGreskeZaNazivAlata; set { porukaGreskeZaNazivAlata = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivAlata); } }
        
        public void DodajIzmeni()
        {
            if (Validacija())
            {
                AlatDAO alataDAO = new AlatDAO();
                if (Alat == null)
                {
                    Alat alat = new Alat { Naziv_Alata = NazivAlata, Tip = TipAlata };
                    alataDAO.Insert(alat);
                }
                else
                {
                    Alat = new Alat { ID = Alat.ID, Naziv_Alata = NazivAlata, Tip = TipAlata };;
                    alataDAO.Update(Alat);
                }
                TryClose();
            }
        }
        private bool Validacija()
        {
            PorukaGreskeZaNazivAlata = "";
            bool ispravanUnos = true;
            if (string.IsNullOrEmpty(NazivAlata))
            {
                PorukaGreskeZaNazivAlata = "Unesite naziv!";
                ispravanUnos = false;
            }
            else if (!NazivAlata.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNazivAlata = "Naziv sme sadrzati samo slova!";
                ispravanUnos = false;
            }
            else if (NazivAlata.Length < 4 || NazivAlata.Length > 30)
            {
                PorukaGreskeZaNazivAlata = "Naziv mora sadrzati od 4 do 30 slova!";
                ispravanUnos = false;
            }

            return ispravanUnos;
        }
    }
}
