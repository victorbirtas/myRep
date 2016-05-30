using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectPS.Models
{
    public class Proprietar
    {

        [Key]
        public string Cnp {get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }

    }


    public class ProprietarDBContext : DbContext
    {
        public DbSet<Proprietar> Proprietari { get; set; }
    }
    
}