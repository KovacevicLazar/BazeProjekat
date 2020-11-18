using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeRadnikaViewModel : Screen
    {
        public enum PozicijeEnum { VATROGASAC , VOZAC , KOMANDIR}
        public DodavanjeRadnikaViewModel()
        {
            Pozicije = Enum.GetValues(typeof(PozicijeEnum)).Cast<PozicijeEnum>().ToList();
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();

            var smenaDAO = new SmenaDAO();
            Smene = smenaDAO.GetList();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Jmbg { get; set; }

        public int RadniStaz { get; set; }



        public PozicijeEnum RadnaPozicija { get; set; }
        public IReadOnlyList<PozicijeEnum> Pozicije { get; }

        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }

        public List<Smena> Smene { get; set; }
        public Smena IzabranaSmena { get; set; }


        public void Dodaj()
        {
            Radnik radnik = new Radnik();


            switch (RadnaPozicija)
            {
                case (PozicijeEnum.VATROGASAC):
                    Vatrogasac vatrogasac = new Vatrogasac(Jmbg,Ime,Prezime, (int)RadnaPozicija,RadniStaz);
                    vatrogasac.VatrogasnaJedinicaId_VSJ = IzabranaVatrogasnaJedinica.Id_VSJ;
                    vatrogasac.SmenaSmenaId = IzabranaSmena.SmenaId;
                    VatrogasacDAO vatrogasacDAO= new VatrogasacDAO();
                    vatrogasacDAO.Insert(vatrogasac);

                    break;
                case (PozicijeEnum.VOZAC):
                    Vozac vozac = new Vozac(Jmbg, Ime, Prezime, (int)RadnaPozicija, RadniStaz);
                    vozac.VatrogasnaJedinicaId_VSJ = IzabranaVatrogasnaJedinica.Id_VSJ;
                    vozac.SmenaSmenaId = IzabranaSmena.SmenaId;
                    VozacDAO vozacDAO = new VozacDAO();
                    vozacDAO.Insert(vozac);

                    break;
                case (PozicijeEnum.KOMANDIR):
                    Komandir komandir = new Komandir(Jmbg, Ime, Prezime, (int)RadnaPozicija, RadniStaz);
                    komandir.VatrogasnaJedinicaId_VSJ = IzabranaVatrogasnaJedinica.Id_VSJ;
                    komandir.SmenaSmenaId = IzabranaSmena.SmenaId;
                    KomandirDAO komandirDAO = new KomandirDAO();
                    komandirDAO.Insert(komandir);

                    break;

            }
            TryClose();
        }
    }
}
