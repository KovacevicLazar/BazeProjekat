﻿using Caliburn.Micro;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using FastMember;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using Intervencije_VatrogasnihJedinicaUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class IntervencijeViewModel : PropertyChangedBase
    {
        private IntervencijaDAO intervencijaDAO = new IntervencijaDAO();
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        private VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
        public List<Intervencija> sveIntervencije = new List<Intervencija>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        InspektorDAO inspektorDAO = new InspektorDAO();
        UvidjajDAO uvidjajDAO = new UvidjajDAO();
        VoziloDAO voziloDAO = new VoziloDAO();
        SmenaDAO smenaDAO = new SmenaDAO();
        RadnikDAO radnikDAO = new RadnikDAO();
        AlatDAO alatDAO = new AlatDAO();
        KomandirDAO komandirDAO = new KomandirDAO();
        RadnikSmenaDAO radnikSmenaDAO = new RadnikSmenaDAO();
        TehnickaIntervencijaDAO tehnickaIntervencijaDAO = new TehnickaIntervencijaDAO();
        PozarDAO pozarDAO = new PozarDAO();
        NavalnoVoziloDAO navalnoVoziloDAO = new NavalnoVoziloDAO();
        TehnickoVoziloDAO tehnickoVoziloDAO = new TehnickoVoziloDAO();
        CisternaDAO cisternaDAO = new CisternaDAO();


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
            opstinaDAO.GetList().ForEach(x => Opstine.Add(new OpstinaIsSelected { Opstina = x, IsSelected = false }));
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
                Poruka = "Prvo morate selektovati intervenciju iz liste intervencija!";
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
                Poruka = "Prvo morate selektovati intervenciju iz liste intervencija!";
            }
        }

        public void DodajInformacijeOUvidjaju(object Intervencija)
        {
            manager.ShowDialog(new DodavanjeInformacijaOUvidjajuViewModel(Intervencija as Intervencija), null, null);
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

        public void Izvezi()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            DataTable dt = new DataTable();
                            dt.Clear();
                            dt.Columns.Add("Tip intervencije");
                            dt.Columns.Add("Opstina");
                            dt.Columns.Add("Adresa");
                            dt.Columns.Add("Datum i vreme");
                            dt.Columns.Add("Vozila");
                            dt.Columns.Add("Radnici");
                            dt.Columns.Add("Informacije o uvidjaju");

                            Dictionary<string, string> VsjRadnici;
                            Dictionary<string, string> VSJVozila;
                            string radnici = "";
                            SveIntervencije.ForEach(intervencija =>
                            {
                                VsjRadnici = new Dictionary<string, string>();
                                DataRow _ravi = dt.NewRow();
                                radnici = "";
                                _ravi["Tip intervencije"] = intervencija.Tip == TipIntervencijeEnum.POZAR ? "Požar" : "Tehnička intervencija";
                                _ravi["Opstina"] = intervencija.Opstina.Naziv_Opstine;
                                _ravi["Adresa"] = intervencija.Adresa;
                                _ravi["Datum i vreme"] = intervencija.Datum_I_Vreme;
                                _ravi["Vozila"] = "";
                                VSJVozila = new Dictionary<string,string>();
                                if (intervencija.Tip == TipIntervencijeEnum.POZAR)
                                {
                                    var vozila = new List<Navalno_Vozilo>();
                                    vozila = pozarDAO.FindById(intervencija.ID)?.Vozila?.ToList();
                                    foreach (var item in vozila)
                                    {
                                        if (VSJVozila.ContainsKey($"{item.VatrogasnaJedinica.Naziv}"))
                                        {
                                            VSJVozila[$"{item.VatrogasnaJedinica.Naziv}"] += $"     {item.Marka} {item.Model} {item.RegistarskaOznaka}\r\n";
                                            continue;
                                        }
                                        VSJVozila[$"{item.VatrogasnaJedinica.Naziv}"] = $" \r\n     {item.Marka} {item.Model} {item.RegistarskaOznaka}\r\n";
                                    } 
                                }                                
                                else
                                {
                                    var vozila = new List<Tehnicko_Vozilo>();
                                    vozila = tehnickaIntervencijaDAO.FindById(intervencija.ID)?.Vozila?.ToList();
                                    foreach (var item in vozila)
                                    {
                                        if (VSJVozila.ContainsKey($"{item.VatrogasnaJedinica.Naziv}"))
                                        {
                                            VSJVozila[$"{item.VatrogasnaJedinica.Naziv}"] += $"     {item.Marka} {item.Model} {item.RegistarskaOznaka}\r\n";
                                            continue;
                                        }
                                        VSJVozila[$"{item.VatrogasnaJedinica.Naziv}"] = $" \r\n     {item.Marka} {item.Model} {item.RegistarskaOznaka}\r\n";
                                    }
                                }
                                foreach (var eee in VSJVozila)
                                {
                                    _ravi["Vozila"] += $"VSJ:  {eee.Key} \r\n   Vozila:  {eee.Value} ";
                                }

                                foreach (var radnikSmena in intervencija.RadniciSaSmenama)
                                {
                                    
                                    if (VsjRadnici.ContainsKey($"VSJ: {radnikSmena.Radnik.VatrogasnaJedinica.Naziv} \r\n  Smena: {radnikSmena.Smena.NazivSmene}"))
                                    {
                                        VsjRadnici[$"VSJ: {radnikSmena.Radnik.VatrogasnaJedinica.Naziv} \r\n  Smena: {radnikSmena.Smena.NazivSmene}"] += $"       {radnikSmena.Radnik.JMBG} {radnikSmena.Radnik.Ime} {radnikSmena.Radnik.Prezime} {radnikSmena.Radnik.Radno_Mesto.ToString()}\r\n";
                                        continue;
                                    }
                                    VsjRadnici[$"VSJ: {radnikSmena.Radnik.VatrogasnaJedinica.Naziv} \r\n  Smena: {radnikSmena.Smena.NazivSmene}"] =  $"\r\n       {radnikSmena.Radnik.JMBG} {radnikSmena.Radnik.Ime} {radnikSmena.Radnik.Prezime} {radnikSmena.Radnik.Radno_Mesto.ToString()}\r\n";
                                }
                                foreach (var eee in VsjRadnici)
                                {
                                    radnici += $"{eee.Key} \r\n     Radnici: {eee.Value} ";
                                }
                                _ravi["Radnici"] = radnici;
                                _ravi["Informacije o uvidjaju"] = intervencija.Uvidjaj !=null ? $"Datum uvidjaja: {intervencija.Uvidjaj?.Datum}  \r\nInspektor: {intervencija.Uvidjaj.Inspektor?.Ime} {intervencija.Uvidjaj.Inspektor?.Prezime} {intervencija.Uvidjaj.Inspektor?.Broj_Telefona}  \r\nText zapisnika: {intervencija.Uvidjaj.Tekst_Zapisnika} " : null;
                                dt.Rows.Add(_ravi);
                            });

                            workbook.Worksheets.Add(dt, "proba");
                            workbook.Worksheet("proba").Cells().Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                            workbook.Worksheet("proba").Columns().AdjustToContents();
                            workbook.SaveAs(saveFileDialog.FileName);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        public void Uvezi()
        {
            using (OpenFileDialog saveFileDialog = new OpenFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook(saveFileDialog.FileName))
                        {
                            DataTable opstineDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("proba"));
                            for(int i=0; i < opstineDataTable.Rows.Count; i++)
                            {
                                DataRow row = opstineDataTable.Rows[i];
                                string tipIntervencije = row["Tip intervencije"].ToString();
                                string opstina = row["Opstina"].ToString();
                                string adresa = row["Adresa"].ToString();
                                string datum = row["Datum i vreme"].ToString();
                                if (ValidacijaPodataka(tipIntervencije, opstina, datum, i + 2))
                                {
                                    DateTime datumIVreme = DateTime.Parse(row["Datum i vreme"].ToString());
                                    string vozila = row["Vozila"].ToString();
                                    string radnici = row["Radnici"].ToString();
                                    string informacijeOUvidjaju = row["Informacije o uvidjaju"].ToString();
                                    KreiranjePodatakaOIntervenciji(tipIntervencije, adresa, opstina, datumIVreme, vozila, radnici, informacijeOUvidjaju);
                                }
                            }
                        }
                    } 
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            SveIntervencije = intervencijaDAO.GetList();
        }

        public void KreiranjePodatakaOIntervenciji(string tip, string adresa, string nazivOpstine, DateTime datum, string vozilaString, string radniciString, string informacijeOUvidjajuString)
        {
            TipIntervencijeEnum tipIntervencije = tip == "Požar" ? TipIntervencijeEnum.POZAR : TipIntervencijeEnum.TEHNICKA_INTERVENCIJA;
            Opstina opstinaIntervencije = opstinaDAO.pronadjiPoNazivu(nazivOpstine);
            if(opstinaIntervencije == null)
            {
                opstinaIntervencije = opstinaDAO.Insert(new Opstina { Naziv_Opstine = nazivOpstine });
            }

            List<Vozilo> vozilaNaIntervenciji = string.IsNullOrEmpty(vozilaString) ? new List<Vozilo>() : KreirajListuVozilaIzStringa(vozilaString, tipIntervencije, opstinaIntervencije);
            List<RadnikUSmeni> radniciISmene = string.IsNullOrEmpty(radniciString) ? new List<RadnikUSmeni>() : KreirajListuRadnikaIzStringa(radniciString, opstinaIntervencije, datum);
            Uvidjaj uvidjaj = string.IsNullOrEmpty(informacijeOUvidjajuString) ? null : KreirajUvidjajIzStringa(informacijeOUvidjajuString);

            if (tipIntervencije == TipIntervencijeEnum.POZAR)
            {
                var pozar = pozarDAO.Insert(new Pozar { Tip = tipIntervencije, Id_Opstine = opstinaIntervencije.ID, Adresa = adresa, Datum_I_Vreme = datum, Uvidjaj = uvidjaj});
                foreach (var radnikSmena in radniciISmene)
                {
                    pozarDAO.DodajSmenuIRadnikaNaIntervenciju(radnikSmena.SmenaID, radnikSmena.RadnikID, radnikSmena.Id, pozar.ID);
                }
                foreach (var vozilo in vozilaNaIntervenciji)
                {
                    pozarDAO.DodajVoziloNaIntervenciju(vozilo.ID, pozar.ID);
                }
            }
            else
            {
                var tehnickaIntervencija = tehnickaIntervencijaDAO.Insert(new Tehnicka_Intervencija { Tip = tipIntervencije, Id_Opstine = opstinaIntervencije.ID, Adresa = adresa, Datum_I_Vreme = datum, Uvidjaj = uvidjaj });
                foreach (var radnikSmena in radniciISmene)
                {
                    tehnickaIntervencijaDAO.DodajSmenuIRadnikaNaIntervenciju(radnikSmena.SmenaID, radnikSmena.RadnikID, radnikSmena.Id, tehnickaIntervencija.ID);
                }
                foreach (var vozilo in vozilaNaIntervenciji)
                {
                    tehnickaIntervencijaDAO.DodajVoziloNaIntervenciju(vozilo.ID, tehnickaIntervencija.ID);
                }
            }
        }

        private Uvidjaj KreirajUvidjajIzStringa(string informacijeOUvidjajuString)
        {
            if(!informacijeOUvidjajuString.Contains("Datum uvidjaja:") || !informacijeOUvidjajuString.Contains("Inspektor:") || !informacijeOUvidjajuString.Contains("Text zapisnika:"))
            {
                return null;
            }
            var informacijeOUvidjajuSPLIT = informacijeOUvidjajuString.Trim().Split(new string[] { "Datum uvidjaja:", "Inspektor:", "Text zapisnika:", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Uvidjaj uvidjaj = null;
            if (informacijeOUvidjajuSPLIT.Length == 3)
            {
                try
                {
                    DateTime datumUvidjaja = DateTime.Parse(informacijeOUvidjajuSPLIT[0]);
                    string tekstZapisnika = informacijeOUvidjajuSPLIT[2].Trim();
                    string[] inspektorPodaci = informacijeOUvidjajuSPLIT[1].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    string ime = inspektorPodaci[0].Trim();
                    string prezime = inspektorPodaci[1].Trim();
                    string brojTelefona = inspektorPodaci[2].Trim();
                    var inspektor = inspektorDAO.PronadjiPoBrojuTelefona(brojTelefona);
                    if(inspektor == null)
                    {
                        inspektor = inspektorDAO.Insert(new Inspektor { Ime = ime, Prezime = prezime, Broj_Telefona = brojTelefona });
                    }

                    uvidjaj = new Uvidjaj { Datum = datumUvidjaja, Tekst_Zapisnika = tekstZapisnika, InspektorID = inspektor.ID };
                }
                catch { }
            }
            return uvidjaj;
        }

        private List<Vozilo> KreirajListuVozilaIzStringa(string vozilaString, TipIntervencijeEnum tipIntervencije, Opstina opstinaIntervencije)
        {
            if (!vozilaString.Contains("VSJ:") || !vozilaString.Contains("Vozila:"))
            {
                return new List<Vozilo>();
            }
            var vatrogasneJedinice = vozilaString.Split(new string[] { "VSJ:" }, StringSplitOptions.RemoveEmptyEntries);
            List<Vozilo> vozilaNaIntervenciji = new List<Vozilo>();
            foreach (var vatrogasnaJednicaVozila in vatrogasneJedinice)
            {
                try
                {
                    var vatrogasnaJedinicaIVozila = vatrogasnaJednicaVozila.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (vatrogasnaJedinicaIVozila.Length < 3)
                    {
                        continue;
                    }
                    VatrogasnaJedinica vatrogasnaJedinica = null;
                    var nazivVatrogasnaJedinica = vatrogasnaJedinicaIVozila[0].Trim();
                    if (nazivVatrogasnaJedinica.Length < 3)
                    {
                        continue;
                    }
                    vatrogasnaJedinica = vatrogasnaJedinicaDAO.PronadjiPoNazivu(nazivVatrogasnaJedinica);
                    if (vatrogasnaJedinica == null)
                    {
                        vatrogasnaJedinica = vatrogasnaJedinicaDAO.Insert(new VatrogasnaJedinica { Naziv = nazivVatrogasnaJedinica, Adresa = "Nije definisana", Id_Opstine = opstinaIntervencije.ID });
                        Smena Smena;
                        List<string> naziviSmena = new List<string> { "Smena A", "Smena B", "Smena C", "Smena D" };
                        for (int i = 1; i < 5; i++)
                        {
                            Smena = new Smena { NazivSmene = naziviSmena[i - 1], VatrogasnaJedinicaID = vatrogasnaJedinica.ID, DatumPrvogDezurstva = new System.DateTime(2009, 1, i, 8, 0, 0) };
                            smenaDAO.Insert(Smena);
                        }
                    }
                    string[] podaciOVozilu;
                    for (int i = 2; i < vatrogasnaJedinicaIVozila.Length; i++)
                    {
                        try
                        {
                            podaciOVozilu = vatrogasnaJedinicaIVozila[i].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            var marka = podaciOVozilu[0].Trim();
                            var model = podaciOVozilu[1].Trim();
                            var regirtarsaOznaka = podaciOVozilu[2].Trim();
                            if (tipIntervencije == TipIntervencijeEnum.POZAR)
                            {
                                Navalno_Vozilo navalnoVozilo = navalnoVoziloDAO.PronadjiPoRegistarskojOznaci(regirtarsaOznaka);
                                if (navalnoVozilo == null)
                                {
                                    navalnoVozilo = navalnoVoziloDAO.Insert(new Navalno_Vozilo { Marka = marka, Model = model, RegistarskaOznaka = regirtarsaOznaka, Tip = TipVozila.NAVALNO, Id_VatrogasneJedinice = vatrogasnaJedinica.ID, Godiste = 2000, Nosivost = 3000 });
                                }
                                vozilaNaIntervenciji.Add(navalnoVozilo);
                                continue;
                            }
                            Tehnicko_Vozilo tehnickoVozilo = tehnickoVoziloDAO.PronadjiPoRegistarskojOznaci(regirtarsaOznaka);
                            if (tehnickoVozilo == null)
                            {
                                tehnickoVozilo = tehnickoVoziloDAO.Insert(new Tehnicko_Vozilo { Marka = marka, Model = model, RegistarskaOznaka = regirtarsaOznaka, Tip = TipVozila.TEHNICKO, Id_VatrogasneJedinice = vatrogasnaJedinica.ID, Godiste = 2000, Nosivost = 3000 });
                            }
                            vozilaNaIntervenciji.Add(tehnickoVozilo);
                        }
                        catch { }
                    }
                }
                catch
                {
                }
            }
            return vozilaNaIntervenciji;
        }

        private List<RadnikUSmeni> KreirajListuRadnikaIzStringa(string radniciString, Opstina opstinaIntervencije, DateTime datumIntervencije)
        {
            if(!radniciString.Contains("VSJ:") || !radniciString.Contains("Smena:"))
            {
                return new List<RadnikUSmeni>();
            }
            List<Radnik> radniciNaIntervenciji = new List<Radnik>();
            var vatrogasneJedinice = radniciString.Split(new string[] { "VSJ:" }, StringSplitOptions.RemoveEmptyEntries);
            string[] vatrogasnaJedinicaSaRadnicima;
            List<RadnikUSmeni> radniciISmene = new List<RadnikUSmeni>();
            foreach (var vatrogasnaJednicaRadnici in vatrogasneJedinice)
            {
                try
                {
                    vatrogasnaJedinicaSaRadnicima = vatrogasnaJednicaRadnici.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (vatrogasnaJedinicaSaRadnicima.Length < 4)
                    {
                        continue;
                    }
                    var nazivVatrogasnaJedinica = vatrogasnaJedinicaSaRadnicima[0].Trim();
                    if(nazivVatrogasnaJedinica.Length < 3)
                    {
                        continue;
                    }
                    var vatrogasnaJedinica = vatrogasnaJedinicaDAO.PronadjiPoNazivu(nazivVatrogasnaJedinica);
                    if (vatrogasnaJedinica == null)
                    {
                        vatrogasnaJedinica = vatrogasnaJedinicaDAO.Insert(new VatrogasnaJedinica { Naziv = nazivVatrogasnaJedinica, Adresa = "Nije definisana", Id_Opstine = opstinaIntervencije.ID });
                        Smena Smena;
                        List<string> naziviSmena = new List<string> { "Smena A", "Smena B", "Smena C", "Smena D" };
                        for (int i = 1; i < 5; i++)
                        {
                            Smena = new Smena { NazivSmene = naziviSmena[i - 1], VatrogasnaJedinicaID = vatrogasnaJedinica.ID, DatumPrvogDezurstva = new System.DateTime(2009, 1, i, 8, 0, 0) };
                            smenaDAO.Insert(Smena);
                        }
                    }

                    var nazivSmene = vatrogasnaJedinicaSaRadnicima[1].Trim().Split(new string[] { "Smena:" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                    Smena smena = smenaDAO.PronadjiPoNazivuIVatrogasnojJedinici(nazivSmene, vatrogasnaJedinica.ID);
                    if(smena == null)
                    {
                        continue;
                    }
                    Radnik radnik;
                    for (int i = 3; i < vatrogasnaJedinicaSaRadnicima.Length; i++)
                    {
                        try
                        {
                            var radnikPodaci = vatrogasnaJedinicaSaRadnicima[i].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            if (radnikPodaci.Length < 4)
                            {
                                continue;
                            }
                            var jmbg = radnikPodaci[0].Trim();
                            var ime = radnikPodaci[1].Trim();
                            var prezime = radnikPodaci[2].Trim();
                            var radno_mesto = radnikPodaci[3].Trim().ToLower() == "vatrogasac" ? RadnoMesto.Vatrogasac : RadnoMesto.Vozac;
                            radnik = radnikDAO.PronadjiPoJMBG(jmbg);
                            if (radnik == null)
                            {
                                radnik = radnikDAO.Insert(new Radnik { JMBG = jmbg, Ime = ime, Prezime = prezime, Radno_Mesto = radno_mesto, VatrogasnaJedinicaID = vatrogasnaJedinica.ID, SmenaID = smena.ID, DatumPocetkaRada = new DateTime(2009, 1, 1, 8, 0, 0) });
                                radnikSmenaDAO.Insert(new RadnikUSmeni { RadnikID = radnik.ID, SmenaID = smena.ID, DatumPocetkaRada = new DateTime(2009, 1, 1, 8, 0, 0), DatumKrajaRada = null });
                            }

                            try
                            {
                                var radnikSmena = radnikSmenaDAO.Insert(new RadnikUSmeni { RadnikID = radnik.ID, SmenaID = smena.ID, DatumPocetkaRada = new DateTime( datumIntervencije.AddDays(-1).Year , datumIntervencije.AddDays(-1).Month, datumIntervencije.AddDays(-1).Day,8,0,0), DatumKrajaRada = new DateTime(datumIntervencije.AddDays(1).Year, datumIntervencije.AddDays(1).Month, datumIntervencije.AddDays(1).Day, 8, 0, 0) });
                                radniciISmene.Add(radnikSmena);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        catch { }
                    }
                }
                catch { }
            }
            return radniciISmene;
        }

        public DataTable PreuzmiPodatkeIzExcelTabele(IXLWorksheet worksheet)
        {
            bool prviRed = true;
            string opsegCitanja = "";
            DataTable table = new DataTable();
            foreach (IXLRow row in worksheet.RowsUsed())
            {
                opsegCitanja = string.Format($"1:{row.LastCellUsed().Address.ColumnNumber}");
                if (prviRed)
                {
                    foreach (IXLCell cell in row.Cells(opsegCitanja))
                    {
                        table.Columns.Add(cell.Value.ToString());
                    }
                    prviRed = false;
                }
                else
                {
                    table.Rows.Add();
                    int cellIndex = 0;
                    foreach (IXLCell cell in row.Cells(opsegCitanja))
                    {
                        table.Rows[table.Rows.Count - 1][cellIndex] = cell.Value.ToString();
                        cellIndex++;
                    }
                }
            }
            if (prviRed)
            {
                MessageBox.Show("Dokument je prazan!");
            }
            return table;
        }

        private bool ValidacijaPodataka(string tipIntervencije, string opstina, string datumIVremeString, int brojVrste)
        {
            List<string> tipovi = new List<string> { "pozar", "požar", "tehnička intervencija", "tehnicka intervencija", "tehnička", "tehnicka" };
            if (string.IsNullOrEmpty(tipIntervencije) || !tipovi.Contains(tipIntervencije.Trim().ToLower()))
            {
                MessageBox.Show($"U vrsti {brojVrste} unutar izabranog dokumenta nije dobro definisan tip intervencije");
                return false;
            }
            if (string.IsNullOrEmpty(opstina.Trim()) || !opstina.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                MessageBox.Show($"U vrsti {brojVrste} unutar izabranog dokumenta nije dobro definisan naziv opstine");
                return false;
            }
            try
            {
                DateTime datumIVreme = DateTime.Parse(datumIVremeString);
            }
            catch
            {
                MessageBox.Show($"U vrsti {brojVrste} unutar izabranog dokumenta nije dobro definisan datum");
                return false;
            }
            return true;
        }
    }
}
