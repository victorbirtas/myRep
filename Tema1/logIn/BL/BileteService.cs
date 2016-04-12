using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class BileteService
    {

        BileteDAO bilet = new BileteDAO();

        public void adaugaBilet(String spectacol,int rand,int numar)
        {
            bilet.insertBilet(spectacol,rand,numar);
        }

        public DataTable afisareBilete(String spectacol)
        {

            DataTable dt;
            dt = bilet.getBilete(spectacol);
            return dt;
        }

    }
}
