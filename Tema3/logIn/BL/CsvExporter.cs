using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.IO;

namespace BL
{
    class CsvExporter : Exporter
    {

        SpectacoleDAO spectacol = new SpectacoleDAO();
        public void export()
        {
            string strFilePath = @"c:\temp\MyTest.csv";
            DataTable dtDataTable;
            dtDataTable = spectacol.getSpectacole();


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
