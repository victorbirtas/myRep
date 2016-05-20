using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcTema2.Models
{
    public class Bilet
    {
        [Key]
        public int ID { get; set; }
        public string Spectacol { get; set; }
        public int Rand { get; set; }
        public int Numar { get; set; }
       
    }

    public class BiletDBContext : DbContext
    {
        public DbSet<Bilet> Bilete { get; set; }
       
    }
}