using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ProiectPS.Controllers;
using ProiectPS.Models;
using System.Data;

namespace ProiectPS
{
    public class CsvExporter : Exporter
    {

        AsigurareDBContext asigurare = new AsigurareDBContext();

        public void export()
        {
            //  var spectacole = from m in spectacol.Spectacole
            //                 select m;
            DataTable dtDataTable = new DataTable();
            dtDataTable.Columns.Add("Proprietar", typeof(string));
            dtDataTable.Columns.Add("NrInmatriculare", typeof(string));
            dtDataTable.Columns.Add("Data", typeof(DateTime));
            dtDataTable.Columns.Add("Durata", typeof(int));

            var asigurari = asigurare.Asigurari;
            foreach (Asigurare a in asigurari)
            {
                DataRow row = dtDataTable.NewRow();
                row["Proprietar"] = a.Proprietar;
                row["NrInmatriculare"] = a.NrInmatriculare;
                row["Data"] = a.DataValabilitate;
                row["Durata"] = a.Durata;
                dtDataTable.Rows.Add(row);
                

            }

            string strFilePath = @"c:\temp\MyTest2.csv";


            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
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
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }  


    }
}