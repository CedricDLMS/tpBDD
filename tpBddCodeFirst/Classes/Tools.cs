using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public static class Tools
    {
        public static void afficherVoiture(Client client)
        {
            if (client.Locations.Count() == 0)
            {
                Console.WriteLine("Cette personne n'a loué aucune voiture");
            }
            else
            {
                foreach (var location in client.Locations)
                {
                    Console.WriteLine("ID de la voiture : " + " " + location.Voiture.VoitureID + " Nom : " + location.Voiture.Name + " Marque : " + location.Voiture.Marque.Name);
                }
            }

        }
    }
}
