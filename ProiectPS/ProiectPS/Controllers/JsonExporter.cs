using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ProiectPS.Models;
using System.Data;

namespace ProiectPS
{
    public class JsonExporter : Exporter
    {

        AsigurareDBContext asigurare = new AsigurareDBContext();

        public void export()
        {
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
            string strFilePath = @"c:\temp\MyTestJSON.json";

            var JSONString = new StringBuilder();

            if (dtDataTable.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < dtDataTable.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < dtDataTable.Columns.Count; j++)
                    {
                        if (j < dtDataTable.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + dtDataTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dtDataTable.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == dtDataTable.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + dtDataTable.Columns[j].ColumnName.ToString() + "\":" + "\"" + dtDataTable.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == dtDataTable.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }



            System.IO.File.WriteAllText(strFilePath, JSONString.ToString());
        }

    }
}