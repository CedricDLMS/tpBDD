using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public class CRUDClient
    {
        
        public static void DisplayClient()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                foreach (var item in dbContext.Clients)
                {     
                Console.WriteLine(item.ToString());
                }
            }
        }
        public static void CreateClient()
        {
            // Demande les champs du client 
            Console.WriteLine("Veuillez renseignez le nom du client");
            var nomClient = Console.ReadLine();
            Console.WriteLine("Veuillez renseignez son Prénom");
            var prenomClient = Console.ReadLine();
            Console.WriteLine("Veuillez renseignez sa date de naissance (jj/mm/aaaa)");
            var ageClientS = Console.ReadLine();
            DateOnly dateNaissance = DateOnly.Parse(ageClientS,new CultureInfo("fr-FR"));
            Console.WriteLine("Sa ville :");
            var villeClient = Console.ReadLine();
            Console.WriteLine("Le code postal : ");
            var postalClient = Console.ReadLine();
            Console.WriteLine("Le numéro et nom de voie (Ex : 2 rue du fou)");
            var voieClient = Console.ReadLine();
            
            Client client = new Client { Adresse=voieClient,Ville=villeClient,Code_Postal=postalClient,FirstName=prenomClient,LastName=nomClient,DateNaissance=dateNaissance};
            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Add(client);
                dbContext.SaveChanges();
            }
        }
        public static Client GetClient()
        {
            DisplayClient();
            Console.WriteLine("Selectionnez l'ID du client souhaité");
            var Idselect = Int32.TryParse(Console.ReadLine(),out int result);
            while (!Idselect) 
            {
                Console.WriteLine("Id invalide, recommencez");
                Idselect = Int32.TryParse(Console.ReadLine(), out result);
            }
            Client clients;
            using (AppDbContext dbContext = new AppDbContext())
            {
                var client = dbContext.Clients.Find(result);
                clients = client;
            }
            Console.WriteLine($"Vous avez selectionnez le client suivant : {clients}");
            return clients;
        }
        public static Client GetClientWithCar()
        {
            
            Console.WriteLine("Selectionnez l'ID du client souhaité");
            var Idselect = Int32.TryParse(Console.ReadLine(), out int result);
            while (!Idselect)
            {
                Console.WriteLine("Id invalide, recommencez");
                Idselect = Int32.TryParse(Console.ReadLine(), out result);
            }
            Client clients;
            using (AppDbContext dbContext = new AppDbContext())
            {
                var client = dbContext.Clients.Include(l => l.Locations).ThenInclude(v => v.Voiture).ThenInclude(m => m.Marque).ThenInclude(c => c.Voitures).FirstOrDefault(c => c.ClientID == result);
                clients = client;
            }
            //Console.WriteLine($"Vous avez selectionnez le client suivant : {clients}");
            return clients;
        }
        public static void removeClient(Client client)
        {
            //DisplayClient();
            Console.WriteLine("Etes vous sur de vouloir le supprimer ? y or n");
            var keyPressed = Console.ReadLine();
            if (keyPressed == "y")
            {
                using (AppDbContext dbContext = new AppDbContext())
                {
                    dbContext.Clients.Remove(client);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Vous ne souhaitez pas supprimer ce client");
            }
        }
        public static void updateClient(Client client)
        {
            Console.WriteLine("Veuillez renseignez le nouveau nom du client, laissez vide pour rien changer");
            var nomClient = Console.ReadLine();
            if (nomClient.IsNullOrEmpty())
            {
                nomClient = client.LastName;
            }
            Console.WriteLine("Veuillez renseignez son Prénom, laissez vide pour rien changer");
            var prenomClient = Console.ReadLine();
            if (prenomClient.IsNullOrEmpty())
            {
                prenomClient = client.FirstName;
            }
            Console.WriteLine("Veuillez renseignez sa date de naissance (jj/mm/aaaa), laissez vide pour rien changer");
            var ageClientS = Console.ReadLine();
            if (ageClientS.IsNullOrEmpty())
            {
                ageClientS = client.DateNaissance.ToString();
            }
            DateOnly dateNaissance = DateOnly.Parse(ageClientS, new CultureInfo("fr-FR"));
            Console.WriteLine("Sa ville :");
            var villeClient = Console.ReadLine();
            if (villeClient.IsNullOrEmpty())
            {
                villeClient = client.Ville;
            }
            Console.WriteLine("Le code postal (laissez vide pour rien changer): ");
            var postalClient = Console.ReadLine();
            if (postalClient.IsNullOrEmpty())
            {
                postalClient = client.Code_Postal;
            }
            Console.WriteLine("Le numéro et nom de voie (Ex : 2 rue du fou)");
            var voieClient = Console.ReadLine();
            if (voieClient.IsNullOrEmpty())
            {
                voieClient = client.Adresse;
            }
            using (AppDbContext db = new AppDbContext())
            {
                var updateClient = db.Clients.Find(client.ClientID);
                updateClient.Adresse = voieClient;
                updateClient.DateNaissance = dateNaissance;
                updateClient.FirstName = prenomClient;
                updateClient.LastName = nomClient;
                updateClient.Ville = villeClient;
                updateClient.Code_Postal = postalClient;
                db.SaveChanges();
            }

        }
        
    }
}
