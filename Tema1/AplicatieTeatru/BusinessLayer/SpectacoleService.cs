using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BusinessLayer
{
    
    public class SpectacoleService
    {
        SpectacoleDAO spectacol = new SpectacoleDAO();

        public void adaugareSpectacol(String titlu, String regia, String distributia, DateTime premiera, int nrbilete)
        {
            spectacol.insertSpectacol(titlu,regia,distributia,premiera,nrbilete);
        }


        public DataTable afisareSpectacole()
        {

            DataTable dt;
            dt = spectacol.getSpectacole();
            return dt;
        }

        public void deleteSpectacolBusiness(String titlu)
        {
            spectacol.deleteSpectacol(titlu);
        }

        public void updateSpectacolBusiness(String titlu, String regia,String distributia, DateTime premiera,int nrbilete)
        {
            spectacol.updateSpectacol(titlu, regia, distributia, premiera,nrbilete);
        }

        public int getNrBileteSpectacol(String titlu)
        {
            return spectacol.getNrBileteSpectacol(titlu);
        }
    }

   


   

}
