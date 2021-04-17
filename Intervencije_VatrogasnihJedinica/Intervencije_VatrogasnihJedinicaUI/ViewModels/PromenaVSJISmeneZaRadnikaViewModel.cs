using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Windows;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class PromenaVSJISmeneZaRadnikaViewModel : Screen
    {
        private SmenaDAO smenaDAO = new SmenaDAO();
        private VatrogasnaJedinicaDAO jedinicaDAO = new VatrogasnaJedinicaDAO();
        private RadnikDAO radnikDAO = new RadnikDAO();
        private RadnikSmenaDAO radnikSmenaDAO = new RadnikSmenaDAO();
        private VatrogasnaJedinica izabranaVatrogasnaJedinica;
        private List<Smena> smene;
        private DateTime datumPremestaja = DateTime.Now;
        private string porukaGreskeZaDatumPremestaja = "Nije moguće naknadno menjati datum! Unesite ga pažljivo!";
        private string porukaGreskeZaVSJ = "";
        private string porukaGreskeZaSmenu = "Prvo izaberite vatrogasnu jedinicu";
        private string radnikInfo = "";
        private DateTime? datumPoslednjeIntervencije;

        public PromenaVSJISmeneZaRadnikaViewModel(Radnik radnik)
        {
            Radnik = radnik;
            datumPoslednjeIntervencije = radnikSmenaDAO.DatumPoslednjeIntervencijeRadnikaSaSmenom(radnik.ID, radnik.SmenaID);
            RadnikInfo = $"{radnik.Ime} {radnik.Prezime} jmbg:{radnik.JMBG}";
            VatrogasneJedinice = jedinicaDAO.GetList().OrderBy(x => x.Naziv).ToList();
            Smene = smenaDAO.SmeneUnutarJedneVSJ(radnik.VatrogasnaJedinica.ID);
            IzabranaVatrogasnaJedinica = VatrogasneJedinice.Find(x => x.ID == radnik.VatrogasnaJedinicaID);
            NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            IzabranaSmena = Smene.Find(x => x.ID == radnik.SmenaID);
            NotifyOfPropertyChange(() => IzabranaSmena);
        }

        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public List<Smena> Smene { get => smene; set { smene = value; NotifyOfPropertyChange(() => Smene); } }
        public Smena IzabranaSmena { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get => izabranaVatrogasnaJedinica; set { izabranaVatrogasnaJedinica = value; Smene = smenaDAO.SmeneUnutarJedneVSJ(value.ID); PorukaGreskeZaSmenu = (Smene.Count == 0) ? "Nisu dodate smene za ovu vatrogasnu jedinicu!" : ""; } }
        public Radnik Radnik { get; set; }
        public string PorukaGreskeZaSmenu { get => porukaGreskeZaSmenu; set { porukaGreskeZaSmenu = value; NotifyOfPropertyChange(() => PorukaGreskeZaSmenu); } }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaDatumPremestaja { get => porukaGreskeZaDatumPremestaja; set { porukaGreskeZaDatumPremestaja = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatumPremestaja); } }
        public DateTime DatumPremestaja { get => datumPremestaja; set { datumPremestaja = new DateTime(value.Year, value.Month, value.Day, 8, 0, 0); NotifyOfPropertyChange(() => DatumPremestaja); } }
        public string RadnikInfo { get => radnikInfo; set { radnikInfo = value; NotifyOfPropertyChange(() => RadnikInfo); } }

        public void SacuvajIzmene()
        {
            
            DateTime? datumPoslednjePromene = radnikSmenaDAO.DatumPoslednjePromeneSmene(Radnik.ID, Radnik.SmenaID);
            if (datumPoslednjePromene != null && Validacija((DateTime)datumPoslednjePromene))
            {
                radnikSmenaDAO.PostaviDatumKrajaRadaUsmeni(Radnik.ID, Radnik.SmenaID, DatumPremestaja);
                radnikSmenaDAO.Insert(new RadnikUSmeni
                {
                    RadnikID = Radnik.ID,
                    SmenaID = IzabranaSmena.ID,
                    DatumPocetkaRada = DatumPremestaja
                });
                Radnik = new Radnik
                {
                    ID = Radnik.ID,
                    Ime = Radnik.Ime,
                    Prezime = Radnik.Prezime,
                    DatumPocetkaRada = Radnik.DatumPocetkaRada,
                    JMBG = Radnik.JMBG,
                    RadnoMesto = Radnik.RadnoMesto,
                    VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID,
                    SmenaID = IzabranaSmena.ID
                };
                radnikDAO.Update(Radnik);
                TryClose();
            }
        }

        private bool Validacija(DateTime datumPoslednjePromene)
        {
            if (IzabranaSmena.ID == Radnik.SmenaID)
            {
                PorukaGreskeZaDatumPremestaja = "Radnik trenutno radu u izabranoj smeni. Izaberite drugu smenu!";
                return false;
            }

            if (DatumPremestaja > DateTime.Now.AddDays(7))
            {
                PorukaGreskeZaDatumPremestaja = "Moguće je izabrati samo datum koji je prošao ili u narednih 7 dana!";
                return false;
            }
            else if (DatumPremestaja < datumPoslednjePromene)
            {
                PorukaGreskeZaDatumPremestaja = $"Zadnja promena je bila:{datumPoslednjePromene.ToShortDateString()}, moguće je uneti samo datum posle pomenutog!";
                return false;
            }
            else if (datumPoslednjeIntervencije != null && DatumPremestaja <= datumPoslednjeIntervencije)
            {
                PorukaGreskeZaDatumPremestaja = $"Radnik je učestvovao na intervenciji:{((DateTime)datumPoslednjeIntervencije).ToShortDateString()} sa prethodnom smenom, moguće je uneti samo datum posle pomenutog!";
                return false;
            }

            if (DatumPremestaja == datumPoslednjePromene)
            {
                var Result= MessageBox.Show($"Radnik je vec menjao smenu za ovaj datum! Da li želite ponovnu promenu smene za isti datum?", "Promena smene za isti datum" , MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(Result == MessageBoxResult.Yes)
                {
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}
