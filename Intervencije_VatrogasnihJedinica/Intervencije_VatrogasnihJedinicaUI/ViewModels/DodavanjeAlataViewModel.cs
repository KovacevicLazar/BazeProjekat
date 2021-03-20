using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeAlataViewModel : Screen
    {
        private AlatDAO alataDAO = new AlatDAO();
        private string porukaGreskeZaNazivAlata = "";

        public DodavanjeAlataViewModel(Alat alat)
        {
            TipoviAlata = new ObservableCollection<TipAlataEnum>(Enum.GetValues(typeof(TipAlataEnum)).Cast<TipAlataEnum>().ToList());
            Alat = alat;
            if (alat != null)
            {
                NazivAlata = alat.Naziv_Alata;
                TipAlata = alat.Tip;
            }
        }

        public ObservableCollection<TipAlataEnum> TipoviAlata { get; set; }
        public TipAlataEnum TipAlata { get; set; }
        public Alat Alat { get; set; }
        public string NazivAlata { get; set; }
        public string PorukaGreskeZaNazivAlata { get => porukaGreskeZaNazivAlata; set { porukaGreskeZaNazivAlata = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivAlata); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Alat == null)
                {
                    Alat alat = new Alat
                    {
                        Naziv_Alata = NazivAlata,
                        Tip = TipAlata
                    };
                    alataDAO.Insert(alat);
                }
                else
                {
                    Alat = new Alat { ID = Alat.ID, Naziv_Alata = NazivAlata, Tip = TipAlata };
                    try
                    {
                        alataDAO.Update(Alat);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.InnerException?.InnerException?.Message, "Greška!!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                TryClose();
            }
        }

        private bool Validacija()
        {
            PorukaGreskeZaNazivAlata = "";
            NazivAlata = NazivAlata.Trim();

            bool ispravanUnos = true;
            if (string.IsNullOrEmpty(NazivAlata))
            {
                PorukaGreskeZaNazivAlata = "Unesite naziv!";
                ispravanUnos = false;
            }
            else if (!NazivAlata.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNazivAlata = "Naziv sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (NazivAlata.Length < 4 || NazivAlata.Length > 30)
            {
                PorukaGreskeZaNazivAlata = "Naziv mora sadržati od 4 do 30 slova!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
