﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jens_EFVenner
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VennerEntities : DbContext
    {
        public VennerEntities()
            : base("name=VennerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alder> Alders { get; set; }
        public virtual DbSet<Favoritspil> Favoritspils { get; set; }
        public virtual DbSet<Hjemmeside> Hjemmesides { get; set; }
        public virtual DbSet<KaldeNavn> KaldeNavns { get; set; }
        public virtual DbSet<KaldenavnType> KaldenavnTypes { get; set; }
        public virtual DbSet<MailAdr> MailAdrs { get; set; }
        public virtual DbSet<MailType> MailTypes { get; set; }
        public virtual DbSet<MainVenneTabel> MainVenneTabels { get; set; }
        public virtual DbSet<PostByTabel> PostByTabels { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TelefonNr> TelefonNrs { get; set; }
        public virtual DbSet<TelefonType> TelefonTypes { get; set; }
    }
}