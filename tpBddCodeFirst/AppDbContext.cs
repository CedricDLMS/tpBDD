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
        public DbSet<Client> Clients { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Voiture> Voitures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DIGI-MP1N5ZRH\SQLEXPRESS;Database=tpTest;Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Données de semence pour la table Marques
            modelBuilder.Entity<Marque>().HasData(
                new Marque { MarqueID = 1, Name = "Marque A" },
                new Marque { MarqueID = 2, Name = "Marque B" },
                new Marque { MarqueID = 3, Name = "Marque C" }
            );

            // Données de semence pour la table Categories
            modelBuilder.Entity<Categorie>().HasData(
                new Categorie { CategorieID = 1, Libelle = "Categorie X", Prix_Km = 35 },
                new Categorie { CategorieID = 2, Libelle = "Categorie Y", Prix_Km = 35 },
                new Categorie { CategorieID = 3, Libelle = "Categorie Z", Prix_Km = 35 }
            );
            modelBuilder.Entity<Voiture>().HasData(
        new Voiture
                {
                VoitureID = 1,
                Name = "Voiture A",
                Immat = "123-ABC",
                Couleur = "Rouge",
                MarqueID = 1, // Assurez-vous que cet ID existe dans vos données de semence Marque
                CategorieID = 1 // Assurez-vous que cet ID existe dans vos données de semence Categorie
                },
                new Voiture
                {
                VoitureID = 2,
                Name = "Voiture B",
                Immat = "456-DEF",
                Couleur = "Bleu",
                MarqueID = 2, // Assurez-vous que cet ID existe dans vos données de semence Marque
                CategorieID = 2 // Assurez-vous que cet ID existe dans vos données de semence Categorie
                }
           );
        }
    }
}
