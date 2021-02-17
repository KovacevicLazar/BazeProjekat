using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeVatrogasneJediniceViewModel : Screen
    {
        private VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        private SmenaDAO smenaDAO = new SmenaDAO();
        private VatrogasnaJedinica vatrogasnaJedinica;
        private string porukaGreskeZaNaziv = "";
        private string porukaGreskeZaAdresu = "";
        private string porukaGreskeZaOpstinu = "";

        public DodavanjeVatrogasneJediniceViewModel(VatrogasnaJedinica vatrogasnaJedinica)
        {
            Opstine = opstinaDAO.GetList();
            VatrogasnaJedinica = vatrogasnaJedinica;
            if (vatrogasnaJedinica != null)
            {
                Naziv = VatrogasnaJedinica.Naziv;
                Adresa = VatrogasnaJedinica.Adresa;
                IzabranaOpstina = Opstine.Find(x => x.ID == VatrogasnaJedinica.Id_Opstine);
                NotifyOfPropertyChange(() => IzabranaOpstina);
            }
        }

        public VatrogasnaJedinica VatrogasnaJedinica { get => vatrogasnaJedinica; set => vatrogasnaJedinica = value; }
        public List<Opstina> Opstine { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get; set; }
        public string PorukaGreskeZaNaziv { get => porukaGreskeZaNaziv; set { porukaGreskeZaNaziv = value; NotifyOfPropertyChange(() => PorukaGreskeZaNaziv); } }
        public string PorukaGreskeZaAdresu { get => porukaGreskeZaAdresu; set { porukaGreskeZaAdresu = value; NotifyOfPropertyChange(() => PorukaGreskeZaAdresu); } }
        public string PorukaGreskeZaOpstinu { get => porukaGreskeZaOpstinu; set { porukaGreskeZaOpstinu = value; NotifyOfPropertyChange(() => PorukaGreskeZaOpstinu); } }

        public void DodajIzmeni()
        {

            if (Validacija())
            {
                if (VatrogasnaJedinica == null)
                {
                    VatrogasnaJedinica = new VatrogasnaJedinica
                    {
                        Naziv = Naziv,
                        Adresa = Adresa,
                        Id_Opstine = IzabranaOpstina.ID
                    };
                    vatrogasnaJedinicaDAO.Insert(VatrogasnaJedinica);
                    Smena Smena;
                    List<string> naziviSmena = new List<string> { "Smena A", "Smena B", "Smena C", "Smena D" };
                    for (int i = 1; i < 5; i++)
                    {
                        Smena = new Smena { NazivSmene = naziviSmena[i - 1], VatrogasnaJedinicaID = VatrogasnaJedinica.ID, DatumPrvogDezurstva = new System.DateTime(2009, 1, i, 8, 0, 0) };
                        smenaDAO.Insert(Smena);
                    }
                }
                else
                {
                    VatrogasnaJedinica = new VatrogasnaJedinica
                    {
                        ID = VatrogasnaJedinica.ID,
                        Naziv = Naziv,
                        Adresa = Adresa,
                        Id_Opstine = IzabranaOpstina.ID
                    };
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
                ispravanUnos = false;
            }
            else if (!Naziv.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNaziv = "Naziv sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Naziv.Length < 5 || Naziv.Length > 40)
            {
                PorukaGreskeZaNaziv = "Naziv mora sadržati od 5 do 40 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Adresa))
            {
                PorukaGreskeZaAdresu = "Unesite adresu!";
                ispravanUnos = false;
            }
            else if (!Adresa.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaAdresu = "Adresa sme sadržati samo slova i brojeve!";
                ispravanUnos = false;
            }
            else if (Adresa.Length < 6 || Adresa.Length > 30)
            {
                PorukaGreskeZaAdresu = "Adresa mora sadržati od 6 do 30 karaktera!";
                ispravanUnos = false;
            }

            if (IzabranaOpstina == null)
            {
                PorukaGreskeZaOpstinu = "Izaberite opštinu!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
