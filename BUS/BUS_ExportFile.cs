using Aspose.Cells;
using Aspose.Cells.Drawing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
namespace BUS
{
    public class BUS_ExportFile
    {
        private static BUS_ExportFile instance;

        public static BUS_ExportFile Instance
        {
            get { if (instance == null) instance = new BUS_ExportFile(); return BUS_ExportFile.instance; }

            private set { BUS_ExportFile.instance = value; }
        }

        public void ExportFileXLSX(string filepath, DataTable dataGrid)
        {
            SaveDataGridViewToCSV(filepath, dataGrid);
            ConvertCSVtoXLSX(filepath);
        }

        public void ExportFilePDF(string filepath, DataTable dataGrid)
        {
            SaveDataGridViewToCSV(filepath, dataGrid);
            ConvertCSVtoXLSX(filepath);
            ConvertXLSXtoPDF(filepath);

        }

        private void SaveDataGridViewToCSV(string filepath, DataTable dataGrid)
        {
            StreamWriter sw = new StreamWriter(filepath, false);
            for (int i = 0; i < 6; i++)
            {
                sw.Write(sw.NewLine);
            }
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                sw.Write(dataGrid.Columns[i]);
                if (i < dataGrid.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dataGrid.Rows)
            {
                for (int i = 0; i < dataGrid.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dataGrid.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void ConvertCSVtoXLSX(string xlsx)
        {
            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;

            // Create LoadOptions for CSV file
            LoadOptions loadOptions = new LoadOptions(LoadFormat.CSV);

            // Create a Workbook object and initialize with CSV file's path and the LoadOptions object
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook($"{xlsx}", loadOptions);

            // Save CSV file as XLSX
            workbook.Save($"{xlsx}", SaveFormat.Xlsx);

            // edit file
            Aspose.Cells.Workbook Edit = new Aspose.Cells.Workbook(xlsx);
            Worksheet editSheet = Edit.Worksheets[0];

            byte[] imgBytes = File.ReadAllBytes("../../img/huynhde_small.png");
            MemoryStream ms = new MemoryStream();
            ms.Write(imgBytes, 0, imgBytes.Length);

            editSheet.Pictures.Add(0, 0, ms);

            editSheet.Cells.SetRowHeight(6, 50);
            for (int i = 2; i <= 4; i++)
            {
                editSheet.Cells.SetColumnWidth(i, 15);
            }
            for (int i = 5; i <= 12; i++)
            {
                editSheet.Cells.SetColumnWidth(i, 20);
            }

            Cell cellTitle = editSheet.Cells["F2"];
            cellTitle.PutValue("THÔNG TIN GIAO DỊCH CỦA CHỨNG KHOÁN CÁC CHỨNG KHOÁN");
            Style styleTitle = cellTitle.GetStyle();
            styleTitle.HorizontalAlignment = TextAlignmentType.Left;
            styleTitle.VerticalAlignment = TextAlignmentType.Center;
            styleTitle.Font.IsBold = true;
            styleTitle.Font.Size= 14;
            cellTitle.SetStyle(styleTitle);

            DateTime today = DateTime.Today;
            Cell celldate = editSheet.Cells["G4"];
            celldate.PutValue($"Ngày xuất dữ liệu: {today.ToString("dd/MM/yyyy")}");
            Style styleDate = celldate.GetStyle();
            styleDate.HorizontalAlignment = TextAlignmentType.Left;
            styleDate.VerticalAlignment = TextAlignmentType.Center;
            styleDate.Font.Size = 12;
            celldate.SetStyle(styleDate);

            List<char> c = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M' };
            for (int i = 0; i < c.Count; i++)
            {
                Cell cell = editSheet.Cells[$"{c[i].ToString()}7"];
                Style style = cell.GetStyle();
                style.HorizontalAlignment = TextAlignmentType.Center;
                style.VerticalAlignment = TextAlignmentType.Center;
                style.Font.IsBold = true;
                style.IsTextWrapped = true;

                // Setting the color
                style.Borders[BorderType.TopBorder].Color = Color.Black;
                style.Borders[BorderType.BottomBorder].Color = Color.Black;
                style.Borders[BorderType.LeftBorder].Color = Color.Black;
                style.Borders[BorderType.RightBorder].Color = Color.Black;
                // Setting the line style
                style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thick;
                style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thick;
                style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thick;
                style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thick;

                cell.SetStyle(style);
            }

            int index = 8;
            bool checknull = false;
            while (true)
            {
                for (int i = 0; i < c.Count; i++)
                {
                    Cell celldata = editSheet.Cells[$"{c[i].ToString()}{index}"];
                    switch (celldata.Type)
                    {
                        case CellValueType.IsNull:
                            checknull = true;
                            break;
                    }
                    if (!checknull)
                    {
                        Style style = celldata.GetStyle();
                        // Setting the color
                        style.Borders[BorderType.TopBorder].Color = Color.Black;
                        style.Borders[BorderType.BottomBorder].Color = Color.Black;
                        style.Borders[BorderType.LeftBorder].Color = Color.Black;
                        style.Borders[BorderType.RightBorder].Color = Color.Black;
                        // Setting the line style
                        style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                        style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                        style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                        style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                        celldata.SetStyle(style);

                    }
                    else
                    {
                        break;
                    }
                }
                    
                index++;
                if (checknull == true)
                {
                    break;
                }
            }
                Edit.Worksheets.RemoveAt(1);
                Edit.Save(xlsx);


            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(xlsx, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Excel.Sheets worksheets = xlWorkBook.Worksheets;
            worksheets[2].Delete();
            xlWorkBook.Save();
            xlWorkBook.Close();
        }

        private void ConvertXLSXtoPDF(string pdf)
        {
            var workbook = new Workbook("input.xlsx");
            workbook.Save("Output.pdf");
        }
    }
}