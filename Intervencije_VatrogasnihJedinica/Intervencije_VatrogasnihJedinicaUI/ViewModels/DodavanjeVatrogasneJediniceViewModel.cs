using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeVatrogasneJediniceViewModel : Screen
    {
        public DodavanjeVatrogasneJediniceViewModel(VatrogasnaJedinica postojecaVatrogasnaJedinica)
        {
            if (postojecaVatrogasnaJedinica != null)
            {
                VatrogasnaJedinica = postojecaVatrogasnaJedinica;
                Naziv = VatrogasnaJedinica.Naziv;
                Adresa = VatrogasnaJedinica.Adresa;
                IzabranaOpstina = VatrogasnaJedinica.Opstina;
                NotifyOfPropertyChange(() => IzabranaOpstina);
            }
            OpstinaDAO opstinaDAO = new OpstinaDAO();
            Opstine = opstinaDAO.GetList();
        }
        VatrogasnaJedinica vatrogasnaJedinica;
        public VatrogasnaJedinica VatrogasnaJedinica { get => vatrogasnaJedinica; set => vatrogasnaJedinica = value; }
    public List<Opstina> Opstine { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get; set; }

        private string porukaGreskeZaNaziv = "";
        private string porukaGreskeZaAdresu = "";
        private string porukaGreskeZaOpstinu = "";
        public string PorukaGreskeZaNaziv { get => porukaGreskeZaNaziv; set { porukaGreskeZaNaziv = value; NotifyOfPropertyChange(() => PorukaGreskeZaNaziv); } }
        public string PorukaGreskeZaAdresu { get => porukaGreskeZaAdresu; set { porukaGreskeZaAdresu = value; NotifyOfPropertyChange(() => PorukaGreskeZaAdresu);} }
        public string PorukaGreskeZaOpstinu { get => porukaGreskeZaOpstinu; set { porukaGreskeZaOpstinu = value; NotifyOfPropertyChange(() => PorukaGreskeZaOpstinu); } }

        public void DodajIzmeni()
        {
            VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
            if (Validacija())
            {
                if (VatrogasnaJedinica == null)
                {
                    VatrogasnaJedinica = new VatrogasnaJedinica { Naziv = Naziv, Adresa = Adresa, Id_Opstine= IzabranaOpstina.ID};
                    vatrogasnaJedinicaDAO.Insert(VatrogasnaJedinica);
                }
                else
                {
                    VatrogasnaJedinica = new VatrogasnaJedinica { ID=VatrogasnaJedinica.ID, Naziv = Naziv, Adresa = Adresa, Id_Opstine = IzabranaOpstina.ID };
                    vatrogasnaJedinicaDAO.Update(VatrogasnaJedinica);
                }
                TryClose();
            }
        }

        private bool Validacija()
        {
            PorukaGreskeZaNaziv = "";
            PorukaGreskeZaAdresu = "";
            PorukaGreskeZaOpstinu = "";
            bool ispravanUnos = true;
            if (string.IsNullOrEmpty(Naziv))
            {
                PorukaGreskeZaNaziv = "Unesite naziv!";
                ispravanUnos =  false;
            }
            else if (!Naziv.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNaziv = "Naziv sme sadrzati samo slova!";
                ispravanUnos = false;
            }
            else if (Naziv.Length < 5 || Naziv.Length > 40)
            {
                PorukaGreskeZaNaziv = "Naziv mora sadrzati od 5 do 40 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Adresa))
            {
                PorukaGreskeZaAdresu = "Unesite adresu!";
                ispravanUnos = false;
            }
            else if (!Adresa.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaAdresu = "Adresa sme sadrzati samo slova i brojeve!";
                ispravanUnos = false;
            }
            else if (Adresa.Length < 6 || Adresa.Length > 30 )
            {
                PorukaGreskeZaAdresu = "Adresa mora sadrzati od 6 do 30 karaktera!";
                ispravanUnos = false;
            }

            if (IzabranaOpstina == null)
            {
                PorukaGreskeZaOpstinu = "Izaberite opstinu!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
