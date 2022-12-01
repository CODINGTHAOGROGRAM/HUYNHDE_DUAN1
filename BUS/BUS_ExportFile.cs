using Aspose.Cells;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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

        private void SaveDataGridViewToCSV(string filepath,DataTable dataGrid)
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
            // Create LoadOptions for CSV file
            LoadOptions loadOptions = new LoadOptions(LoadFormat.CSV);

            // Create a Workbook object and initialize with CSV file's path and the LoadOptions object
            Workbook workbook = new Workbook($"{xlsx}", loadOptions);

            // Save CSV file as XLSX
            workbook.Save($"{xlsx}", SaveFormat.Xlsx);

            // edit file 
            
        }

        private void ConvertXLSXtoPDF(string pdf)
        {
            Workbook workbook = new Workbook(pdf);

            workbook.Save($"{pdf}", SaveFormat.Pdf);
        }
    }
}