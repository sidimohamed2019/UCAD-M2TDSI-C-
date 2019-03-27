using HeritageProjectGrp6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace HeritageProjetGrp6.Models 
{
    public class bdheritageEntities : DbContext
    {
        public bdheritageEntities(DbContextOptions<bdheritageEntities> options) : base(options)
        {

        }

        public virtual DbSet<AYANTDROIT> AYANTDROIT { get; set; }
        public virtual DbSet<BIENS> BIENS { get; set; }
        public virtual DbSet<ECOLE> ECOLE { get; set; }
        public virtual DbSet<HERITAGE> HERITAGE { get; set; }
        public virtual DbSet<HERITIER> HERITIER { get; set; }
        public virtual DbSet<REGLE> REGLE { get; set; }
        public virtual DbSet<SOURCE> SOURCE { get; set; }
        public virtual DbSet<UTILISATEUR> UTILISATEUR { get; set; }
    }
}
