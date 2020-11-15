using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class OpstineViewModel : PropertyChangedBase
    {
        public OpstineViewModel()
        {
            SveOpstine = new  ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }

        IWindowManager manager = new WindowManager();

        private OpstinaDAO opstinaDAO = new OpstinaDAO();

        public string IdOpstine { get; set; }

        public string NazivOpstine { get; set; }

        public ObservableCollection<Opstina> sveOpstine = new ObservableCollection<Opstina>();

        public ObservableCollection<Opstina> SveOpstine { get { return sveOpstine; } set { sveOpstine = value; NotifyOfPropertyChange(() => SveOpstine); } }

        public Opstina OznacenaOpstina { get; set; }

        public OpstinaDAO OpstinaDAO { get => opstinaDAO; set => opstinaDAO = value; }

        public void Dodaj()
        {
            Opstina opstina = new Opstina();
            opstina.Id_Opstine = 5;// int.Parse( IdOpstine);
            opstina.Naziv_Opstine = NazivOpstine;
           
            OpstinaDAO.Insert(opstina);
            SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }

        public void Obrisi()
        {
            OpstinaDAO.Delete( OznacenaOpstina.Id_Opstine);
            SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }

        public void Izmeni()
        {
            var v = OznacenaOpstina;
        }

    }
}
