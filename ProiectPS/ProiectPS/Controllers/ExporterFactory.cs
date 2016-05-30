using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProiectPS
{
    public class ExporterFactory
    {

        public Exporter getExporter(String exporterType)
        {

            if (exporterType.Equals("CSV"))
            {
                return new CsvExporter();
            }
            else if (exporterType.Equals("JSON"))
            {
                return new JsonExporter();
            }
            return null;

        }

    }
}