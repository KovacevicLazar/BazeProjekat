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
                return db.Set<Tehnicka_Intervencija>().Include("Vozila").Include("Smene").Include("Opstina").SingleOrDefault(x => x.ID == idIntervencije);
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

        public Tuple<bool, string> DodajSmenuNaIntervenciju(int smenaID, int intervencijaID)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.DodajSmenuNaIntervenciju(smenaID, intervencijaID, objectParameterSuccess, objectParameterMessage);
                return new Tuple<bool, string>((bool)objectParameterSuccess.Value, (string)objectParameterMessage.Value);
            }
        }

        public void UkloniSmeneSaIntervencije(int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.UkloniSmeneSaIntervencije(idIntervencije, objectParameterSuccess, objectParameterMessage);
            }
        }
    }
}
