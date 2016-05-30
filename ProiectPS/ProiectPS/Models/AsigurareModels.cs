using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectPS.Models
{
    public class Asigurare
    {
        [Key]
        public string NrInmatriculare { get; set; }
        public string Proprietar { get; set; }
        public DateTime DataValabilitate { get; set; }
        public int Durata { get; set; }
       
    }

    public class AsigurareDBContext : DbContext
    {
        public DbSet<Asigurare> Asigurari { get; set; }
       
    }
}