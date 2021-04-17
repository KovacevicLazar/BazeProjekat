using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeAlataViewModel : Screen
    {
        private AlatDAO alataDAO = new AlatDAO();
        private string porukaGreskeZaNazivAlata = "";
        private string porukaGreskeZaTip = "";

        public DodavanjeAlataViewModel(Alat alat)
        {
            TipoviAlata = new ObservableCollection<TipAlataEnum>(Enum.GetValues(typeof(TipAlataEnum)).Cast<TipAlataEnum>().ToList());
            Alat = alat;
            if (alat != null)
            {
                NazivAlata = alat.NazivAlata;
                TipAlata = alat.Tip;
            }
        }

        public ObservableCollection<TipAlataEnum> TipoviAlata { get; set; }
        public TipAlataEnum TipAlata { get; set; }
        public Alat Alat { get; set; }
        public string NazivAlata { get; set; }
        public string PorukaGreskeZaNazivAlata { get => porukaGreskeZaNazivAlata; set { porukaGreskeZaNazivAlata = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivAlata); } }
        public string PorukaGreskeZaTip { get => porukaGreskeZaTip; set { porukaGreskeZaTip = value; NotifyOfPropertyChange(() => PorukaGreskeZaTip); }
}

public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Alat == null)
                {
                    Alat alat = new Alat
                    {
                        NazivAlata = NazivAlata,
                        Tip = TipAlata
                    };
                    alataDAO.Insert(alat);
                }
                else
                {
                    Alat = new Alat { ID = Alat.ID, NazivAlata = NazivAlata, Tip = TipAlata };
                    try
                    {
                        alataDAO.Update(Alat);
                    }
                    catch (Exception ex)
                    {
                        PorukaGreskeZaTip = ex.InnerException?.InnerException?.Message;
                        return;
                    }
                }
                TryClose();
            }
        }

        private bool Validacija()
        {
            PorukaGreskeZaNazivAlata = "";
            PorukaGreskeZaTip = "";
            bool ispravanUnos = true;
            if (string.IsNullOrEmpty(NazivAlata))
            {
                PorukaGreskeZaNazivAlata = "Unesite naziv!";
                ispravanUnos = false;
            }
            else if (!NazivAlata.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNazivAlata = "Naziv sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (NazivAlata.Trim().Length < 4 || NazivAlata.Trim().Length > 30)
            {
                PorukaGreskeZaNazivAlata = "Naziv mora sadržati od 4 do 30 slova!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
