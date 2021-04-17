﻿using Caliburn.Micro;
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

        public DodavanjeOpstineViewModel(Opstina opstina)
        {
            Opstina = opstina;
            NazivOpstine = opstina?.NazivOpstine;
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
                    Opstina = new Opstina
                    {
                        NazivOpstine = NazivOpstine
                    };
                    opstinaDAO.Insert(Opstina);
                }
                else
                {
                    Opstina.NazivOpstine = NazivOpstine;
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
            else if (!naziv.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNaziv = "Naziv sme sadržati samo slova!";
                return false;
            }
            else if (naziv.Trim().Length < 2 || naziv.Trim().Length > 25)
            {
                PorukaGreskeZaNaziv = "Naziv mora sadržati od 2 do 25 slova!";
                return false;
            }
            else if (opstinaDAO.pronadjiPoNazivu(NazivOpstine.Trim()) != null)
            {
                if (Opstina == null || (Opstina != null && NazivOpstine != Opstina.NazivOpstine))
                {
                    PorukaGreskeZaNaziv = "Opština sa istim nazivom je uneta!";
                    return false;
                }
            }
         
            return true;
        }
    }
}
