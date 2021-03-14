using Caliburn.Micro;
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
                            DataTable table = new DataTable();
                            using (var reader = ObjectReader.Create(opstinaDAO.GetList(), "ID", "Naziv_Opstine"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Opstine");
                            table = new DataTable();
                            using (var reader = ObjectReader.Create(SveIntervencije, "ID", "Adresa", "Datum_I_Vreme", "Id_Opstine", "Tip"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Intervencije");

                            table = new DataTable();
                            InspektorDAO inspektorDAO = new InspektorDAO();
                            using (var reader = ObjectReader.Create(inspektorDAO.GetList(), "ID", "Ime", "Prezime", "Broj_Telefona"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Inspektori");

                            table = new DataTable();
                            UvidjajDAO uvidjajDAO = new UvidjajDAO();
                            using (var reader = ObjectReader.Create(uvidjajDAO.GetList(), "ID", "Datum", "Tekst_Zapisnika", "InspektorID"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Uvidjaji");

                            table = new DataTable();
                            VatrogasnaJedinicaDAO vatrogasnaJedinicaDAO = new VatrogasnaJedinicaDAO();
                            using (var reader = ObjectReader.Create(vatrogasnaJedinicaDAO.GetList(), "ID", "Naziv", "Adresa", "Id_Opstine"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Vatrogasne jedinice");

                            table = new DataTable();
                            VoziloDAO voziloDAO = new VoziloDAO();
                            using (var reader = ObjectReader.Create(voziloDAO.GetList(), "ID", "Marka", "Model", "Tip", "Godiste", "Nosivost", "Id_VatrogasneJedinice"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Vozila");

                            table = new DataTable();
                            SmenaDAO smenaDAO = new SmenaDAO();
                            using (var reader = ObjectReader.Create(smenaDAO.GetList(), "ID", "NazivSmene", "VatrogasnaJedinicaID", "DatumPrvogDezurstva"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Smene");

                            table = new DataTable();
                            RadnikDAO radnikDAO = new RadnikDAO();
                            using (var reader = ObjectReader.Create(radnikDAO.GetList(), "ID", "JMBG", "Ime", "Prezime", "Radno_Mesto", "DatumPocetkaRada", "VatrogasnaJedinicaID", "SmenaID"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Radnici");

                            table = new DataTable();
                            AlatDAO alatDAO = new AlatDAO();
                            using (var reader = ObjectReader.Create(alatDAO.GetList(), "ID", "Naziv_Alata", "Tip"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Alati");

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
                            DataTable opstineDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Opstine"));
                            Dictionary<int, Opstina> opstine = opstineDataTable.AsEnumerable().ToDictionary<DataRow, int, Opstina>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new Opstina
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                Naziv_Opstine = row.Field<string>("Naziv_Opstine"),
                            });
                            List<int> keys = new List<int>(opstine.Keys);
                            keys.Sort();
                            foreach (var key in keys)
                            {
                                if (opstinaDAO.pronadjiPoNazivu(opstine[key].Naziv_Opstine) == null)
                                {
                                    opstine[key] = opstinaDAO.Insert(opstine[key]);
                                }
                            }


                            DataTable inspektoriDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Inspektori"));
                            Dictionary<int, Inspektor> inspektori = inspektoriDataTable.AsEnumerable().ToDictionary<DataRow, int, Inspektor>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new Inspektor
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                Ime = row.Field<string>("Ime"),
                                Prezime = row.Field<string>("Prezime"),
                                Broj_Telefona = row.Field<string>("Broj_Telefona"),
                            });
                            keys = new List<int>(inspektori.Keys);
                            keys.Sort();
                            InspektorDAO inspektorDAO = new InspektorDAO();
                            foreach (var key in keys)
                            {
                                if (inspektorDAO.FindById(key) == null)
                                {
                                    inspektori[key] = inspektorDAO.Insert(inspektori[key]);
                                }
                            }



                            DataTable intervencijeDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Intervencije"));
                            DataTable uvidjajiDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Uvidjaji"));
                            
                            Dictionary<int, Uvidjaj> uvidjaji = uvidjajiDataTable.AsEnumerable().ToDictionary<DataRow, int, Uvidjaj>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new Uvidjaj
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                Tekst_Zapisnika = row.Field<string>("Tekst_Zapisnika"),
                                Datum = DateTime.Parse(row.Field<string>("Datum")),
                                InspektorID = inspektori[int.Parse(row.Field<string>("InspektorID"))].ID,
                            });


                            Dictionary<int, Intervencija> intervencije = intervencijeDataTable.AsEnumerable().ToDictionary<DataRow, int, Intervencija>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new Intervencija
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                Adresa = row.Field<string>("Adresa"),
                                Datum_I_Vreme = DateTime.Parse(row.Field<string>("Datum_I_Vreme")),
                                Obrisana = false,
                                Id_Opstine = int.Parse(row.Field<string>("Id_Opstine")),
                                Tip = (TipIntervencijeEnum)int.Parse(row.Field<string>("Tip")),
                                Uvidjaj = uvidjaji.ContainsKey(int.Parse(row.Field<string>("ID"))) ? uvidjaji[int.Parse(row.Field<string>("ID"))] : null
                            });
                            keys = new List<int>(intervencije.Keys);
                            keys.Sort();
                            foreach (var key in keys)
                            {
                                if (intervencijaDAO.FindById(key) == null)
                                {
                                    intervencije[key].Id_Opstine = opstine[intervencije[key].Id_Opstine].ID; //dodeli novokreirani id opstine
                                    intervencije[key] = intervencijaDAO.Insert(intervencije[key]);
                                }
                            }

                         
                            DataTable vatrogasneJediniceDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Vatrogasne jedinice"));
                            Dictionary<int, VatrogasnaJedinica> vatrogasneJedinice = vatrogasneJediniceDataTable.AsEnumerable().ToDictionary<DataRow, int, VatrogasnaJedinica>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new VatrogasnaJedinica
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                Adresa = row.Field<string>("Adresa"),
                                Naziv = row.Field<string>("Naziv"),
                                Id_Opstine = int.Parse(row.Field<string>("Id_Opstine"))
                            });
                            keys = new List<int>(vatrogasneJedinice.Keys);
                            keys.Sort();
                            foreach (var key in keys)
                            {
                                if (vatrogasnaJedinicaDAO.FindById(key) == null)
                                {
                                    vatrogasneJedinice[key].Id_Opstine = opstine[vatrogasneJedinice[key].Id_Opstine].ID; //dodeli novokreirani id opstine
                                    vatrogasneJedinice[key] = vatrogasnaJedinicaDAO.Insert(vatrogasneJedinice[key]);
                                }
                            }

                            DataTable smeneDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Smene"));
                            Dictionary<int, Smena> smene = smeneDataTable.AsEnumerable().ToDictionary<DataRow, int, Smena>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new Smena
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                NazivSmene = row.Field<string>("NazivSmene"),
                                DatumPrvogDezurstva = DateTime.Parse(row.Field<string>("DatumPrvogDezurstva")),
                                VatrogasnaJedinicaID = int.Parse(row.Field<string>("VatrogasnaJedinicaID"))
                            });
                            keys = new List<int>(smene.Keys);
                            keys.Sort();
                            SmenaDAO smenaDAO = new SmenaDAO();
                            foreach (var key in keys)
                            {
                                if (smenaDAO.FindById(key) == null)
                                {
                                    smene[key].VatrogasnaJedinicaID = vatrogasneJedinice[smene[key].VatrogasnaJedinicaID].ID; //dodeli novokreirani id 
                                    smene[key] = smenaDAO.Insert(smene[key]);
                                }
                            }


                            DataTable radniciDataTable = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Radnici"));
                            Dictionary<int, Radnik> radnici = radniciDataTable.AsEnumerable().ToDictionary<DataRow, int, Radnik>(
                            row => int.Parse(row.Field<string>("ID")),
                            row => new Radnik
                            {
                                ID = int.Parse(row.Field<string>("ID")),
                                Ime = row.Field<string>("Ime"),
                                Prezime = row.Field<string>("Prezime"),
                                JMBG = row.Field<string>("JMBG"),
                                Radno_Mesto = (RadnoMesto)int.Parse(row.Field<string>("Radno_Mesto")),
                                DatumPocetkaRada = DateTime.Parse(row.Field<string>("DatumPocetkaRada")),
                                SmenaID = int.Parse(row.Field<string>("SmenaID")),
                                VatrogasnaJedinicaID = int.Parse(row.Field<string>("VatrogasnaJedinicaID"))
                            });
                            keys = new List<int>(radnici.Keys);
                            keys.Sort();
                            RadnikDAO radnikDAO = new RadnikDAO();
                            foreach (var key in keys)
                            {
                                if (radnikDAO.FindById(key) == null)
                                {
                                    radnici[key].VatrogasnaJedinicaID = vatrogasneJedinice[radnici[key].VatrogasnaJedinicaID].ID; //dodeli novokreirani id 
                                    radnici[key].SmenaID = smene[radnici[key].SmenaID].ID; //dodeli novokreirani id 
                                    radnici[key] = radnikDAO.Insert(radnici[key]);
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
    }
}
