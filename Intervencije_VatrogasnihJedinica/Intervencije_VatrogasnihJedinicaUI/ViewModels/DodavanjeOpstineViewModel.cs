using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeOpstineViewModel : Screen
    {
        private Opstina opstina;
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        private string porukaGreskeZaNaziv = "";

        public DodavanjeOpstineViewModel(Opstina postojecaOpstina)
        {
            if (postojecaOpstina != null)
            {
                Opstina = postojecaOpstina;
                NazivOpstine = postojecaOpstina.Naziv_Opstine;
            }
        }

        public string NazivOpstine { get; set; }
        public Opstina Opstina { get => opstina; set => opstina = value; }
        public string PorukaGreskeZaNaziv { get => porukaGreskeZaNaziv; set { porukaGreskeZaNaziv = value; NotifyOfPropertyChange(() => PorukaGreskeZaNaziv); } }

        public void DodajIzmeni()
        {
            if (ValidacijaNaziva(NazivOpstine))
            {
                if (Opstina == null)
                {
                    Opstina = new Opstina { Naziv_Opstine = NazivOpstine };
                    opstinaDAO.Insert(Opstina);
                }
                else
                {
                    Opstina.Naziv_Opstine = NazivOpstine;
                    opstinaDAO.Update(Opstina);
                }
                TryClose();
            }
        }

        private bool ValidacijaNaziva(string naziv)
        {
            PorukaGreskeZaNaziv = "";
            if (string.IsNullOrEmpty(naziv))
            {
                PorukaGreskeZaNaziv = "Unesite naziv za opštinu!";
                return false;
            }
            else if (!naziv.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNaziv = "Naziv sme sadrzati samo slova!";
                return false;
            }
            else if (naziv.Length < 2 || naziv.Length > 30)
            {
                PorukaGreskeZaNaziv = "Naziv mora sadrzati od 2 do 30 slova!";
                return false;
            }
            else if (opstinaDAO.pronadjiPoNazivu(NazivOpstine) != null)
            {
                PorukaGreskeZaNaziv = "Opstina sa istim nazivom je uneta!";
                return false;
            }
            return true;
        }
    }
}
