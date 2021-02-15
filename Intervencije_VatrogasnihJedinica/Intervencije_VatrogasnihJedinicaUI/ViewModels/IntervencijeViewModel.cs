using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using Intervencije_VatrogasnihJedinicaUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class IntervencijeViewModel : PropertyChangedBase
    {
        private IntervencijaDAO intervencijaDAO = new IntervencijaDAO();
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        public List<Intervencija> sveIntervencije = new List<Intervencija>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        public IntervencijeViewModel()
        {
            SveIntervencije = intervencijaDAO.GetList();
            TipoviIntervencije = new ObservableCollection<TipIntervencijeIsSelected>();
            Opstine = new ObservableCollection<OpstinaIsSelected>();
            var tipovi = Enum.GetValues(typeof(TipIntervencijeEnum));
            foreach (var tip in tipovi)
            {
                TipoviIntervencije.Add(new TipIntervencijeIsSelected { Tip = (TipIntervencijeEnum)tip, IsSelected = false });
            }
            opstinaDAO.GetList().ForEach(x => Opstine.Add(new OpstinaIsSelected { Opstina = x, IsSelected=false }));
        }

        public ObservableCollection<TipIntervencijeIsSelected> TipoviIntervencije { get; }
        public ObservableCollection<OpstinaIsSelected> Opstine { get; set; }
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Intervencija> SveIntervencije { get { return sveIntervencije; } set { sveIntervencije = value; NotifyOfPropertyChange(() => sveIntervencije); } }
        public Intervencija OznacenaIntervencija { get; set; }
        public TipIntervencijeIsSelected FilterTip { get; set; }

        public OpstinaIsSelected FilterOpstina { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeIntervencijeViewModel(null), null, null);
            SveIntervencije = intervencijaDAO.GetList();
        }

        public void Obrisi()
        {
            Poruka = "";
            if (OznacenaIntervencija != null)
            {
                try
                {
                    intervencijaDAO.Delete(OznacenaIntervencija.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }
                SveIntervencije = intervencijaDAO.GetList();
                OznacenaIntervencija = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati intervenciju iz liste intervencija";
            }
        }

        public void Izmeni()
        {
            Poruka = "";
            if (OznacenaIntervencija != null)
            {
                manager.ShowDialog(new DodavanjeIntervencijeViewModel(OznacenaIntervencija), null, null);
                SveIntervencije = intervencijaDAO.GetList();
                OznacenaIntervencija = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati intervenciju iz liste intervencija";
            }
        }

        public void DodajInformacijeOUvidjaju( object Intervencija )
        {
            manager.ShowDialog(new DodavanjeInformacijaOUvidjajuViewModel(Intervencija  as Intervencija), null, null);
            SveIntervencije = intervencijaDAO.GetList();
        }

        public void FilterList()
        {
            List<int> opstineID = new List<int>();
            List<TipIntervencijeEnum> tipovi = new List<TipIntervencijeEnum>();
            foreach (var opstina in Opstine)
            {
                if (opstina.IsSelected)
                {
                    opstineID.Add(opstina.Opstina.ID);
                }
            }
            foreach (var tip in TipoviIntervencije)
            {
                if (tip.IsSelected)
                {
                    tipovi.Add(tip.Tip);
                }
            }
            SveIntervencije = intervencijaDAO.GetFilteredList(opstineID, tipovi);
        }

        
    }
}
