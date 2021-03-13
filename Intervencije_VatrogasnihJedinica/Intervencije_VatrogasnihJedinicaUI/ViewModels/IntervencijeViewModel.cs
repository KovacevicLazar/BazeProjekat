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
                            table.Clear();
                            using (var reader = ObjectReader.Create(SveIntervencije, "ID", "Adresa", "Datum_I_Vreme", "Id_Opstine", "Tip"))
                            {
                                table.Load(reader);
                            }
                            workbook.Worksheets.Add(table, "Intervencije");
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
                            Dictionary<int,Opstina> opstineLista = new Dictionary<int,Opstina>();
                            DataTable opstine = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Opstine"));
                            for (int i = 0; i < opstine.Rows.Count; i++)
                            {
                                int opstinaID = int.Parse(opstine.Rows[i]["ID"].ToString() );
                                string opstinaNaziv = opstine.Rows[i]["Naziv_Opstine"].ToString() ;
                                opstineLista.Add(opstinaID, new Opstina { ID = opstinaID, Naziv_Opstine = opstinaNaziv });
                                if (opstinaDAO.pronadjiPoNazivu(opstinaNaziv) == null)
                                {
                                    opstinaDAO.Insert(new Opstina { ID = opstinaID, Naziv_Opstine = opstinaNaziv });
                                }
                            }
                            DataTable intervencije = PreuzmiPodatkeIzExcelTabele(workbook.Worksheet("Intervencije"));
                            for (int i = 0; i < intervencije.Rows.Count; i++)
                            {
                                int inteID = int.Parse(intervencije.Rows[i]["ID"].ToString());
                                string Adresa = intervencije.Rows[i]["Adresa"].ToString();
                                DateTime Datum_I_Vreme = DateTime.Parse(intervencije.Rows[i]["Datum_I_Vreme"].ToString());
                                int Id_Opstine = int.Parse(intervencije.Rows[i]["Id_Opstine"].ToString());
                                TipIntervencijeEnum Tip = (TipIntervencijeEnum)int.Parse(intervencije.Rows[i]["Tip"].ToString());
                                Intervencija intervencija = new Intervencija { ID = inteID, Adresa = Adresa, Datum_I_Vreme = Datum_I_Vreme, Obrisana = false, Tip = Tip };
                                intervencija.Id_Opstine = opstinaDAO.pronadjiPoNazivu(opstineLista[Id_Opstine].Naziv_Opstine).ID;
                                if (intervencijaDAO.FindById(inteID) == null)
                                {
                                    intervencijaDAO.Insert(intervencija);
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
