using System;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class PozarDAO : BaseRepo<Pozar>
    {
        public Pozar FindById(int idPozara)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Set<Pozar>().Include("Vozila").Include("Smene").Include("Opstina").SingleOrDefault(x => x.ID == idPozara);
            }
        }

        public Tuple<bool, string> DodajVoziloNaIntervenciju(int idVozila, int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.PostaviNavalnoVoziloNaIntervenciju(idVozila, idIntervencije, objectParameterSuccess, objectParameterMessage);
                return new Tuple<bool, string>((bool)objectParameterSuccess.Value, (string)objectParameterMessage.Value);
            }
        }

        public void UkloniVozilaSaIntervencije(int idIntervencije)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.UkloniNavalnaVozilaSaIntervencije(idIntervencije, objectParameterSuccess, objectParameterMessage);
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
