﻿using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
            Opstine = opstinaDAO.GetList().OrderBy(x =>  x.NazivOpstine).ToList();
            VatrogasnaJedinica = vatrogasnaJedinica;
            if (vatrogasnaJedinica != null)
            {
                Naziv = VatrogasnaJedinica.Naziv;
                Adresa = VatrogasnaJedinica.Adresa;
                IzabranaOpstina = Opstine.Find(x => x.ID == VatrogasnaJedinica.OpstinaID);
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
                        OpstinaID = IzabranaOpstina.ID
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
                        OpstinaID = IzabranaOpstina.ID
                    };
                    try
                    {
                        vatrogasnaJedinicaDAO.Update(VatrogasnaJedinica);
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
            PorukaGreskeZaNaziv = "";
            PorukaGreskeZaAdresu = "";
            PorukaGreskeZaOpstinu = "";
            bool ispravanUnos = true;

            if (string.IsNullOrEmpty(Naziv))
            {
                PorukaGreskeZaNaziv = "Unesite naziv!";
                ispravanUnos = false;
            }
            else if (!Naziv.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNaziv = "Naziv sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Naziv.Trim().Length < 5 || Naziv.Trim().Length > 40)
            {
                PorukaGreskeZaNaziv = "Naziv mora sadržati od 5 do 40 slova!";
                ispravanUnos = false;
            }
            else if (vatrogasnaJedinicaDAO.PronadjiPoNazivu(Naziv.Trim()) != null)
            {
                if (vatrogasnaJedinica == null || (vatrogasnaJedinica != null && DisplayName != vatrogasnaJedinica.Naziv))
                {
                    PorukaGreskeZaNaziv = "Ovaj naziv je zauzet!";
                    ispravanUnos = false;
                }
            }
           

            if (string.IsNullOrEmpty(Adresa))
            {
                PorukaGreskeZaAdresu = "Unesite adresu!";
                ispravanUnos = false;
            }
            else if (!Adresa.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaAdresu = "Adresa sme sadržati samo slova i brojeve!";
                ispravanUnos = false;
            }
            else if (Adresa.Trim().Length < 6 || Adresa.Trim().Length > 30)
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
