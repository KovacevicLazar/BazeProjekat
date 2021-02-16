using System;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class TehnickaIntervencijaDAO : BaseRepo<Tehnicka_Intervencija>
    {
        public Tehnicka_Intervencija FindById(int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Set<Tehnicka_Intervencija>().Include("Vozila").Include("Opstina").Include("RadniciSaSmenama").SingleOrDefault(x => x.ID == idIntervencije);
            }
        }

        public Tuple<bool, string> DodajVoziloNaIntervenciju(int idVozila, int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.PostaviTehnickoVoziloNaTehnickuIntervenciju(idVozila, idIntervencije, objectParameterSuccess, objectParameterMessage);
                return new Tuple<bool, string>((bool)objectParameterSuccess.Value, (string)objectParameterMessage.Value);
            }
        }

        public void UkloniVozilaSaIntervencije(int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.UkloniTehnickaVozilaSaIntervencije(idIntervencije, objectParameterSuccess, objectParameterMessage);
            }
        }

        public Tuple<bool, string> DodajSmenuIRadnikaNaIntervenciju(int smenaID, int radnikID, int radnikISmenaID, int intervencijaID)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.DodajSmenuIRadnikaNaIntervenciju(smenaID, radnikID, radnikISmenaID, intervencijaID, objectParameterSuccess, objectParameterMessage);
                return new Tuple<bool, string>((bool)objectParameterSuccess.Value, (string)objectParameterMessage.Value);
            }
        }

        public void UkloniRadnikeISmeneSaIntervencije(int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.UkloniRadnikeISmeneSaIntervencije(idIntervencije, objectParameterSuccess, objectParameterMessage);
            }
        }
    }
}
