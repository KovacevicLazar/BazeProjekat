using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using Caliburn.Micro;

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
        private string porukaGreskeZaSmenu = "Prvo Izaberite Vatrogasnu Jedinicu";
        private string radnikInfo = "";
        private DateTime datumPoslednjeIntervencije;

        public PromenaVSJISmeneZaRadnikaViewModel(Radnik radnik)
        {
            Radnik = radnik;
            datumPoslednjeIntervencije = radnikSmenaDAO.DatumPoslednjeIntervencijeRadnikaSaSmenom(radnik.ID, radnik.SmenaID);
            RadnikInfo = $"{radnik.Ime} {radnik.Prezime} jmbg:{radnik.JMBG}";
            VatrogasneJedinice = jedinicaDAO.GetList();
            Smene = smenaDAO.SmeneUnutarJedneVSJ(radnik.VatrogasnaJedinica.ID);
            IzabranaVatrogasnaJedinica = VatrogasneJedinice.Find(x => x.ID == radnik.VatrogasnaJedinicaID);
            NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            IzabranaSmena = Smene.Find(x => x.ID == radnik.SmenaID);
            NotifyOfPropertyChange(() => IzabranaSmena);
        }

        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public List<Smena> Smene { get => smene; set { smene = value; NotifyOfPropertyChange(() => Smene); } }
        public Smena IzabranaSmena { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get => izabranaVatrogasnaJedinica; set { izabranaVatrogasnaJedinica = value; Smene = smenaDAO.SmeneUnutarJedneVSJ(value.ID); PorukaGreskeZaSmenu = (Smene.Count == 0) ? "Nisu dodate smene za ovu Vatrogasnu jedinicu!" : ""; } }
        public Radnik Radnik { get; set; }
        public string PorukaGreskeZaSmenu { get => porukaGreskeZaSmenu; set { porukaGreskeZaSmenu = value; NotifyOfPropertyChange(() => PorukaGreskeZaSmenu); } }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaDatumPremestaja { get => porukaGreskeZaDatumPremestaja; set { porukaGreskeZaDatumPremestaja = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatumPremestaja); } }
        public DateTime DatumPremestaja { get => datumPremestaja; set { datumPremestaja = new DateTime(value.Year, value.Month, value.Day, 8, 0, 0); NotifyOfPropertyChange(() => DatumPremestaja); } }
        public string RadnikInfo { get => radnikInfo; set { radnikInfo = value; NotifyOfPropertyChange(() => RadnikInfo); } }

        public void SacuvajIzmene()
        {
            DateTime datumPoslednjePromene = radnikSmenaDAO.DatumPoslednjePromeneSmene(Radnik.ID, Radnik.SmenaID);
            if (Validacija(datumPoslednjePromene))
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
                    Radno_Mesto = Radnik.Radno_Mesto,
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

            if (DatumPremestaja > DateTime.Now)
            {
                PorukaGreskeZaDatumPremestaja = "Moguce je izabrati samo datum koji je prošao!";
                return false;
            }
            else if (DatumPremestaja < datumPoslednjePromene)
            {
                PorukaGreskeZaDatumPremestaja = $"Zanja promena je bila:{datumPoslednjePromene.ToShortDateString()}, moguće je uneti samo datum posle pomenutog!";
                return false;
            }
            else if (DatumPremestaja < datumPoslednjeIntervencije)
            {
                PorukaGreskeZaDatumPremestaja = $"Radnik je učestvovao na intervenciji:{datumPoslednjeIntervencije.ToShortDateString()}, sa prethodnom smenom, moguće je uneti samo datum posle pomenutog!";
                return false;
            }

            return true;
        }
    }
}
