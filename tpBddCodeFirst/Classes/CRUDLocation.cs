using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public class CRUDLocation
    {
        public static void DisplayLocation()
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                foreach (var item in dbContext.Locations.Include(p => p.Client))
                {
                    Console.WriteLine(item.ToString() + item.Client.FirstName + item.Client.LastName + "\n");
                }
            }
        }
        public static void CreateLocation()
        {
            // Demande les champs du client 
            Console.WriteLine("Veuillez renseignez le nombre de Km");
            var KmNumberS = Console.ReadLine();
            var boolKm = Double.TryParse(KmNumberS, out double KmNumber);
            while (!boolKm)
            {
                Console.WriteLine("Nombre de KM invalide, recommencez !");
                KmNumberS = Console.ReadLine();
                boolKm = Double.TryParse(KmNumberS, out KmNumber);
            }

            // date debut
            Console.WriteLine("Veuillez renseignez la date de début (jj/mm/aaaa)");
            var dateDebutS = Console.ReadLine();
            DateOnly dateDebut = DateOnly.Parse(dateDebutS, new CultureInfo("fr-FR"));

            Console.WriteLine("Veuillez renseignez l'heure de début (xx:yy)");
            var dateTimeDebutS = Console.ReadLine();
            TimeOnly dateTimeDebut = TimeOnly.Parse(dateTimeDebutS, new CultureInfo("fr-FR"));

            DateTime dateDebutTimeAll = new DateTime(dateDebut, dateTimeDebut);

            // date de fin
            Console.WriteLine("Veuillez renseignez la date de fin (jj/mm/aaaa)");
            var dateFinS = Console.ReadLine();
            DateOnly dateFin = DateOnly.Parse(dateDebutS, new CultureInfo("fr-FR"));

            Console.WriteLine("Veuillez renseignez l'heure de fin (xx:yy)");
            var dateTimeFinS = Console.ReadLine();
            TimeOnly dateTimeFin = TimeOnly.Parse(dateTimeDebutS, new CultureInfo("fr-FR"));

            DateTime dateFinTimeAll = new DateTime(dateFin, dateTimeFin);

            // Client ID

            Console.WriteLine("Veuillez renseignez l'ID Client");
            var Client_IDs = Console.ReadLine();
            bool boolID = Int32.TryParse(Client_IDs, out int Client_ID);
            while (!boolID)
            {
                Console.WriteLine("ID invalide, recommencez !");
                Client_IDs = Console.ReadLine();
                boolID = Int32.TryParse(Client_IDs, out Client_ID);
            }

            // voiture ID

            Console.WriteLine("Veuillez renseignez l'ID Voiture");
            var Voiture_IdS = Console.ReadLine();
            bool boolVoiture = Int32.TryParse(Voiture_IdS, out int Voiture_ID);
            while (!boolID)
            {
                Console.WriteLine("ID invalide, recommencez !");
                Voiture_IdS = Console.ReadLine();
                boolVoiture = Int32.TryParse(Voiture_IdS, out Voiture_ID);
            }

            Location location = new Location { Date_Debut = dateDebutTimeAll, Date_Fin = dateFinTimeAll, Nb_Km = KmNumber, ClientID = Client_ID, VoitureID = Voiture_ID };


            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Add(location);
                dbContext.SaveChanges();
            }
        }
        public static Location GetLocation()
        {
            DisplayLocation();
            Console.WriteLine("Selectionnez l'ID du Location souhaité");
            var Idselect = Int32.TryParse(Console.ReadLine(), out int result);
            while (!Idselect)
            {
                Console.WriteLine("Id invalide, recommencez");
                Idselect = Int32.TryParse(Console.ReadLine(), out result);
            }
            Location Locations;
            using (AppDbContext dbContext = new AppDbContext())
            {
                var Location = dbContext.Locations.Find(result);
                Locations = Location;
            }
            Console.WriteLine($"Vous avez selectionnez le Location suivante : {Locations}");
            return Locations;
        }
        public static void removeLocation(Location location)
        {
            //DisplayLocation();
            Console.WriteLine("Etes vous sur de vouloir le supprimer ? y or n");
            var keyPressed = Console.ReadLine();
            if (keyPressed == "y")
            {
                using (AppDbContext dbContext = new AppDbContext())
                {
                    dbContext.Locations.Remove(location);
                    dbContext.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Vous ne souhaitez pas supprimer cette Location");
            }
        }
        public static void updateLocation(Location location)
        {
            Console.WriteLine("Veuillez renseignez le nouvel ID du client, laissez vide pour rien changer");
            var IDClientS = Console.ReadLine();
            bool boolIDClient = Int32.TryParse(IDClientS, out int IDclient);
            while(!boolIDClient && IDClientS.IsNullOrEmpty())
            {
                    IDClientS = location.ClientID.ToString();
            }
            Console.WriteLine("Veuillez renseignez le nouvel ID de voiture, laissez vide pour rien changer");
            var IDvoitureS = Console.ReadLine();
            bool boolIDvoiture = Int32.TryParse(IDvoitureS, out int IDvoiture);
            while (!boolIDvoiture && IDvoitureS.IsNullOrEmpty())
            {
                IDvoitureS = location.VoitureID.ToString();
            }
            
            Console.WriteLine("Veuillez renseignez les KM, laissez vide pour rien changer");
            var nbr_kmS = Console.ReadLine();
            double nbrKMtrue;
            if (nbr_kmS.IsNullOrEmpty())
            {
                nbr_kmS = location.Nb_Km.ToString();
                nbrKMtrue = location.Nb_Km;
            }
            else
            {
                double.TryParse(nbr_kmS, out nbrKMtrue);
            }

            // Date Debut
            Console.WriteLine("Veuillez renseignez la date de début (jj/mm/aaaa), laissez vide pour rien changer");
            var dateDebutS = Console.ReadLine();
            if(dateDebutS.IsNullOrEmpty())
            {
                dateDebutS = location.Date_Debut.ToShortDateString();
            }
            DateOnly dateOnlyDebut = DateOnly.Parse(dateDebutS, new CultureInfo("fr-FR"));

            Console.WriteLine("Veuillez renseignez l'heure de début (xx:yy)");
            var dateTimeDebutS = Console.ReadLine();
            if (dateTimeDebutS.IsNullOrEmpty())
            {
                dateTimeDebutS = location.Date_Debut.ToShortTimeString();
            }
            TimeOnly dateTimeDebut = TimeOnly.Parse(dateTimeDebutS, new CultureInfo("fr-FR"));

            DateTime dateDebutTimeAll = new DateTime(dateOnlyDebut, dateTimeDebut);

            // date de fin
            Console.WriteLine("Veuillez renseignez la date de fin (jj/mm/aaaa), laissez vide pour rien changer");
            var dateFinS = Console.ReadLine();
            if (dateFinS.IsNullOrEmpty())
            {
                dateFinS = location.Date_Fin.ToShortDateString();
            }
            DateOnly dateOnlyFin = DateOnly.Parse(dateFinS, new CultureInfo("fr-FR"));

            Console.WriteLine("Veuillez renseignez l'heure de fin (xx:yy)");
            var dateTimeFinS = Console.ReadLine();
            if (dateTimeFinS.IsNullOrEmpty())
            {
                dateTimeFinS = location.Date_Debut.ToShortTimeString();
            }
            TimeOnly dateTimeFin = TimeOnly.Parse(dateTimeFinS, new CultureInfo("fr-FR"));

            DateTime dateFinTimeAll = new DateTime(dateOnlyFin, dateTimeFin);

            using (AppDbContext dbContext = new AppDbContext())
            {
                var updateLocation = dbContext.Locations.Find(location.LocationID);
                updateLocation.ClientID = IDclient;
                updateLocation.Nb_Km = nbrKMtrue;
                updateLocation.Date_Debut = dateDebutTimeAll;
                updateLocation.Date_Fin = dateFinTimeAll;
                updateLocation.VoitureID = IDvoiture;
                dbContext.SaveChanges();
            }
        }
    }
}
