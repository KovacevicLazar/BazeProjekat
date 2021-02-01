using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Linq;
using System.Text.RegularExpressions;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeOpstineViewModel : Screen
    {
        public DodavanjeOpstineViewModel(Opstina postojecaOpstina)
        {
            if(postojecaOpstina != null)
            {
                Opstina = postojecaOpstina;
                NazivOpstine = postojecaOpstina.Naziv_Opstine;
            }
        }
        private Opstina opstina;
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        public string NazivOpstine { get; set; }
        public OpstinaDAO OpstinaDAO { get => opstinaDAO; set => opstinaDAO = value; }
        public Opstina Opstina { get => opstina; set => opstina = value; }
        private string porukaGreskeZaNaziv = "";
        public string PorukaGreskeZaNaziv { get => porukaGreskeZaNaziv; set {  porukaGreskeZaNaziv = value; NotifyOfPropertyChange(() => PorukaGreskeZaNaziv); } }

        public void DodajIzmeni()
        {
            if (ValidacijaNaziva(NazivOpstine))
            {
                if (Opstina == null)
                {
                    Opstina = new Opstina { Naziv_Opstine = NazivOpstine };
                    OpstinaDAO.Insert(Opstina);
                }
                else
                {
                    Opstina.Naziv_Opstine = NazivOpstine;
                    OpstinaDAO.Update(Opstina);
                }
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
