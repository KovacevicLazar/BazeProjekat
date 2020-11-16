﻿using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class RadniciViewModel : PropertyChangedBase
    {

        public RadniciViewModel()
        {
            SviRadnici = radnikDAO.GetList();
        }

        public List<Radnik> sviRadnici = new List<Radnik>();

        public List<Radnik> SviRadnici { get { return sviRadnici; } set { sviRadnici = value; NotifyOfPropertyChange(() => sviRadnici); } }
        public Radnik OznacenRadnik { get; set; }

        private RadnikDAO radnikDAO = new RadnikDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeRadnikaViewModel(), null, null);
            SviRadnici = radnikDAO.GetList();
        }

        public void Obrisi()
        {
            if (OznacenRadnik != null)
            {
                radnikDAO.Delete(OznacenRadnik.JMBG);
                SviRadnici = radnikDAO.GetList();
                OznacenRadnik = null;
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
