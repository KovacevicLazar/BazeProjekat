using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace Intervencije_VatrogasnihJedinica.dao
{
    public class VoziloDAO : Repository<Vozilo>
    {
        public override List<Vozilo> GetList()
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vozila.Include("VatrogasnaJedinica").Include("Alati").ToList();
            }
        }

        public Tuple<bool, string> DodajAlatVozilu(int idAlata, int idVozila)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
               ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.DodeliAlatVozilu(idAlata, idVozila, objectParameterSuccess, objectParameterMessage);
                return new Tuple<bool, string>((bool)objectParameterSuccess.Value, (string)objectParameterMessage.Value);
            }
        }

        public void UkloniAlateIzVozila(int idVozila)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                ObjectParameter objectParameterSuccess = new ObjectParameter("success", typeof(bool));
                ObjectParameter objectParameterMessage = new ObjectParameter("outputMessage", typeof(string));
                db.UkloniAlateIzVozila(idVozila, objectParameterSuccess, objectParameterMessage);
            }
        }

        public List<Vozilo> VozilaVatrogasneJedinice(int idVatrogasneJedinice)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vozila.Include("VatrogasnaJedinica").Where(x => x.VatrogasnaJedinicaID == idVatrogasneJedinice).ToList();
            }
        }

        public List<Vozilo> ListaVozilaZaIzabranuOpstinu(int idOpstine)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vozila.Include("VatrogasnaJedinica").Where(x => x.VatrogasnaJedinica.Opstina.ID == idOpstine).ToList();
            }
        }

        public Vozilo PronadjiPoRegistarskojOznaci(string redistarskaOznaka)
        {
            using (var db = new Model_Intervencije_VatrogasnihJedinicaContainer())
            {
                return db.Vozila.Where(x => x.RegistarskaOznaka.Trim().ToLower() == redistarskaOznaka.Trim().ToLower()).FirstOrDefault();
            }
        }
    }
}
