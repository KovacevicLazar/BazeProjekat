﻿using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.ObjectModel;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class OpstineViewModel : PropertyChangedBase
    {
        public OpstineViewModel()
        {
            SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        public string NazivOpstine { get; set; }
        public ObservableCollection<Opstina> sveOpstine = new ObservableCollection<Opstina>();
        public ObservableCollection<Opstina> SveOpstine { get { return sveOpstine; } set { sveOpstine = value; NotifyOfPropertyChange(() => SveOpstine); } }
        public Opstina OznacenaOpstina { get; set; }
        public OpstinaDAO OpstinaDAO { get => opstinaDAO; set => opstinaDAO = value; }

        public void Dodaj()
        {
            Opstina opstina = new Opstina();
            opstina.Naziv_Opstine = NazivOpstine;
            OpstinaDAO.Insert(opstina);
            SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }
        public void Obrisi()
        {
            if (OznacenaOpstina != null)
            {
                OpstinaDAO.Delete(OznacenaOpstina.ID);
                SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
                OznacenaOpstina = null;
            }
            else
            {
            }
        }
        public void Izmeni()
        {
        }
    }
}
