using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectPS.Models
{
    public class Autovehicul
    {

        [Key]
        public string Sasiu { get; set; }
        public string NrInmatriculare { get; set; }
        public string TipVehicul { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }  
        public string TipCombustibil { get; set; }
        public int AnFabricatie { get; set; }
        public int CapacitateCilindrica { get; set; }
        public int Putere { get; set; }
        public int NrLocuri { get; set; }
        public int MasaTotala { get; set; }

      
    }


    public class AutovehiculDBContext : DbContext
    {
        public DbSet<Autovehicul> Autovehicule { get; set; }
    }
}