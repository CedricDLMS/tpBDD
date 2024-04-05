using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tpBddCodeFirst.Classes;

namespace tpBddCodeFirst
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Client> Clients {  get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Voiture> Voitures { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DIGI-MP1N5ZRH\SQLEXPRESS;Database=tpTest;Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
