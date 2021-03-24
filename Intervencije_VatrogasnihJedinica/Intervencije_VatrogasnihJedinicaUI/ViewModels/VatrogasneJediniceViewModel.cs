﻿using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class VatrogasneJediniceViewModel : PropertyChangedBase
    {
        private VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
        public List<VatrogasnaJedinica> sveJedinice = new List<VatrogasnaJedinica>();
        IWindowManager manager = new WindowManager();
        private string poruka;
        private GlavniViewModel glavniView;
        public VatrogasneJediniceViewModel(GlavniViewModel glavniVieww)
        {
            glavniView = glavniVieww;
            GetListAsync();
        }

        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<VatrogasnaJedinica> SveJedinice { get { return sveJedinice; } set { sveJedinice = value; NotifyOfPropertyChange(() => sveJedinice); } }
        public VatrogasnaJedinica OznacenaJedinica { get; set; }

        private async void GetListAsync()
        {
            SveJedinice = await vatrogasnaJedinicaDAO.GetListAsync();
        }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeVatrogasneJediniceViewModel(null), null, null);
            GetListAsync();
        }

        public void Obrisi()
        {
            Poruka = "";
            if (OznacenaJedinica != null)
            {
                try
                {
                    vatrogasnaJedinicaDAO.Delete(OznacenaJedinica.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }
                GetListAsync();
                OznacenaJedinica = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati vatrogasnu jedinicu iz liste!";
            }
        }

        public void Izmeni()
        {
            Poruka = "";
            if (OznacenaJedinica != null)
            {
                manager.ShowDialog(new DodavanjeVatrogasneJediniceViewModel(OznacenaJedinica), null, null);
                GetListAsync();
                OznacenaJedinica = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati vatrogasnu jedinicu iz liste!";
            }
        }

        public void InformacijeOSmenama(object vatrogasnaJedinica)
        {
            glavniView.ActivateItem(new InformacijeOSmenamaVatrogasneJediniceViewModel(vatrogasnaJedinica as VatrogasnaJedinica, glavniView));
            //manager.ShowDialog(new InformacijeOSmenamaVatrogasneJediniceViewModel(vatrogasnaJedinica as VatrogasnaJedinica), null, null);
        }

        public void DodajKomandira(object vatrogasnaJedinica)
        {
            manager.ShowDialog(new DodavanjeKomandiraViewModel(vatrogasnaJedinica as VatrogasnaJedinica), null, null);
            GetListAsync();
        }
    }
}
