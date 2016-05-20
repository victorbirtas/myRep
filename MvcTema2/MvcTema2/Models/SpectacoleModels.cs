using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTema2.Models
{
    public class Spectacol
    {

        [Key]
        public string Titlul { get; set; }
        public string Regia { get; set; }
        public string Distributia { get; set; }
        public DateTime Premiera { get; set; }
        public int NrBilete { get; set; }

      
    }


    public class SpectacolDBContext : DbContext
    {
        public DbSet<Spectacol> Spectacole { get; set; }
    }
         
    }
