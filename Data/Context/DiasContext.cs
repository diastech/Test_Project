using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class DiasContext : DbContext
    {

        public DiasContext(DbContextOptions<DiasContext> options)
            : base(options)
        {
        }        
        public DbSet<Bina> Binas { get; set; }
        public DbSet<Oda> Odas { get; set; }
        public DbSet<Envanter> Envanters{ get; set; }
        public DbSet<IsEmri> IsEmris { get; set; }
        public DbSet<Depo> Depos{ get; set; }
        public DbSet<UrunYolu> UrunYolus { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
