using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class JsonExporter : Exporter
    {
        SpectacoleDAO spectacol = new SpectacoleDAO();
        public void export()
        {
            string strFilePath = @"c:\temp\MyTest.json";
            DataTable dtDataTable;
            dtDataTable = spectacol.getSpectacole();


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
