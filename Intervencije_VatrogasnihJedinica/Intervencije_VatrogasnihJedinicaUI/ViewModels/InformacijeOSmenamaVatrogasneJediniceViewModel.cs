using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.ObjectModel;


namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class InformacijeOSmenamaVatrogasneJediniceViewModel : Screen
    {
        private SmenaDAO smenaDAO = new SmenaDAO();
        private RadnikSmenaDAO radnikSmenaDAO = new RadnikSmenaDAO();
        RadnikDAO radnikDAO = new RadnikDAO();
        IWindowManager manager = new WindowManager();
        private Radnik oznacenRadnik;
        public InformacijeOSmenamaVatrogasneJediniceViewModel(VatrogasnaJedinica vatrogasnaJedinica)
        {
            RadniciSmenaA = new ObservableCollection<Radnik>();
            RadniciSmenaB = new ObservableCollection<Radnik>();
            RadniciSmenaC = new ObservableCollection<Radnik>();
            RadniciSmenaD = new ObservableCollection<Radnik>();
            var smene = smenaDAO.SmeneUnutarJedneVSJ(vatrogasnaJedinica.ID);
            foreach (var item in smene.Find(x => x.NazivSmene == "Smena A").Radnici)
            {
                RadniciSmenaA.Add(item);
            }
            foreach (var item in smene.Find(x => x.NazivSmene == "Smena B").Radnici)
            {
                RadniciSmenaB.Add(item);
            }
            foreach (var item in smene.Find(x => x.NazivSmene == "Smena C").Radnici)
            {
                RadniciSmenaC.Add(item);
            }
            foreach (var item in smene.Find(x => x.NazivSmene == "Smena D").Radnici)
            {
                RadniciSmenaD.Add(item);
            }

            IDSmenaA = smene.Find(x => x.NazivSmene == "Smena A").ID;
            IDSmenaB = smene.Find(x => x.NazivSmene == "Smena B").ID;
            IDSmenaC = smene.Find(x => x.NazivSmene == "Smena C").ID;
            IDSmenaD = smene.Find(x => x.NazivSmene == "Smena D").ID;
            VatrogasnaJedinica = vatrogasnaJedinica;
        }

        private int IDSmenaA = 0;
        private int IDSmenaB = 0;
        private int IDSmenaC = 0;
        private int IDSmenaD = 0;
        
        public VatrogasnaJedinica VatrogasnaJedinica { get; set; }
        public ObservableCollection<Radnik> RadniciSmenaA { get; set; }
        public ObservableCollection<Radnik> RadniciSmenaB { get; set; }
        public ObservableCollection<Radnik> RadniciSmenaC { get; set; }
        public ObservableCollection<Radnik> RadniciSmenaD { get; set; }
        public Radnik OznacenRadnik { get => oznacenRadnik; set { oznacenRadnik = value; NotifyOfPropertyChange(() => OznacenRadnik); } }

        public void Dropped(string smena)
        {
            if(OznacenRadnik == null)
            {
                return;
            }
            var unosDatuma = new UnosDatumaViewModel(radnikSmenaDAO.DatumPoslednjeIntervencijeRadnikaSaSmenom(OznacenRadnik.ID, OznacenRadnik.SmenaID), (DateTime)radnikSmenaDAO.DatumPoslednjePromeneSmene(OznacenRadnik.ID, OznacenRadnik.SmenaID));
            switch (smena)
            {
                case "Smena A":
                    if (RadniciSmenaA.Contains(OznacenRadnik))
                    {
                        break;
                    }
                    this.manager.ShowDialog(unosDatuma);
                    if (unosDatuma.NastaviPromenuSmene == false)
                    {
                        return;
                    }

                    PomenaSmene(OznacenRadnik, IDSmenaA, unosDatuma.Datum); 
                    RadniciSmenaA.Add(OznacenRadnik);
                    RadniciSmenaB.Remove(OznacenRadnik);
                    RadniciSmenaC.Remove(OznacenRadnik);
                    RadniciSmenaD.Remove(OznacenRadnik);
                    break;
                case "Smena B":
                    if (RadniciSmenaB.Contains(OznacenRadnik))
                    {
                        break;
                    }
                    this.manager.ShowDialog(unosDatuma);
                    if (unosDatuma.NastaviPromenuSmene == false)
                    {
                        return;
                    }

                    PomenaSmene(OznacenRadnik, IDSmenaB, unosDatuma.Datum);
                    RadniciSmenaB.Add(OznacenRadnik);
                    RadniciSmenaA.Remove(OznacenRadnik);
                    RadniciSmenaC.Remove(OznacenRadnik);
                    RadniciSmenaD.Remove(OznacenRadnik);
                    break;
                case "Smena C":
                    if (RadniciSmenaC.Contains(OznacenRadnik))
                    {
                        break;
                    }
                    this.manager.ShowDialog(unosDatuma);
                    if (unosDatuma.NastaviPromenuSmene == false)
                    {
                        return;
                    }

                    PomenaSmene(OznacenRadnik, IDSmenaC, unosDatuma.Datum);
                    RadniciSmenaC.Add(OznacenRadnik);
                    RadniciSmenaB.Remove(OznacenRadnik);
                    RadniciSmenaA.Remove(OznacenRadnik);
                    RadniciSmenaD.Remove(OznacenRadnik);
                    break;
                case "Smena D":
                    if (RadniciSmenaD.Contains(OznacenRadnik))
                    {
                        break;
                    }
                    this.manager.ShowDialog(unosDatuma);
                    if (unosDatuma.NastaviPromenuSmene == false)
                    {
                        return;
                    }

                    PomenaSmene(OznacenRadnik, IDSmenaD , unosDatuma.Datum);
                    RadniciSmenaD.Add(OznacenRadnik);
                    RadniciSmenaB.Remove(OznacenRadnik);
                    RadniciSmenaC.Remove(OznacenRadnik);
                    RadniciSmenaA.Remove(OznacenRadnik);
                    break;
                default:
                    break;
            }
        }

        public void PomenaSmene(Radnik radnik, int novaSmenaID, DateTime datumPremestaja)
        {
            radnikSmenaDAO.PostaviDatumKrajaRadaUsmeni(radnik.ID, radnik.SmenaID, datumPremestaja);
            radnikSmenaDAO.Insert(new RadnikUSmeni
            {
                 RadnikID = radnik.ID,
                 SmenaID = novaSmenaID,
                 DatumPocetkaRada = datumPremestaja
            });
            radnik = new Radnik
            {
                 ID = radnik.ID,
                 Ime = radnik.Ime,
                 Prezime = radnik.Prezime,
                 DatumPocetkaRada = radnik.DatumPocetkaRada,
                 JMBG = radnik.JMBG,
                 Radno_Mesto = radnik.Radno_Mesto,
                 VatrogasnaJedinicaID = radnik.VatrogasnaJedinicaID,
                 SmenaID = novaSmenaID
            };
            OznacenRadnik.SmenaID = novaSmenaID;
            radnikDAO.Update(radnik);
        }
    }
}
