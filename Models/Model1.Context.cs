﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeritagesProjectG6.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bdheritageEntities : DbContext
    {
        public bdheritageEntities()
            : base("name=bdheritageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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
