using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public static class Menu
    {
        public static void Accueil()
        {
            Console.WriteLine("---BIENVENUE---");
            Console.WriteLine("---------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----CLIENTS----");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1 - Afficher les clients");
            Console.WriteLine("2 - Creer un client");
            Console.WriteLine("3 - Supprimer un client");
            Console.WriteLine("4 - Modifier un client");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----LOCATION---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5 - Afficher les locations");
            Console.WriteLine("6 - Creer une nouvelle location");
            Console.WriteLine("7 - Supprimer une location");
            Console.WriteLine("8 - Modifier une location");

            Console.WriteLine(" FAITES VOTRE CHOIX ");
            var keyPressed = Int32.TryParse(Console.ReadLine(), out int keyPressedInt);
            MenuChoix(keyPressedInt);
        }
        public static void MenuChoix(int choix)
        {
            switch (choix)
            {
                case 1:
                    CRUDClient.DisplayClient();
                    Console.WriteLine("Action à effectuer possible : 1 - afficher les véhicule loué par IDclient 0 - Appuyez sur entré pour revenir au menu sans rien");
                    if(Console.ReadLine() == "1")
                    {
                        Tools.afficherVoiture(CRUDClient.GetClientWithCar());
                    }
                    break;
                case 2:
                    CRUDClient.CreateClient();
                    break;
                case 3:
                    CRUDClient.removeClient(CRUDClient.GetClient());
                    break;
                case 4:
                    CRUDClient.updateClient(CRUDClient.GetClient());
                    break;
                case 5:
                    CRUDLocation.DisplayLocation();
                    break;
                case 6:
                    CRUDLocation.CreateLocation();
                    break;
                case 7:
                    CRUDLocation.removeLocation(CRUDLocation.GetLocation());
                    break;
                case 8:
                    CRUDLocation.updateLocation(CRUDLocation.GetLocation());
                    break;
                default:
                    Console.WriteLine("Choix invalide, recommencez");
                    choix = Int32.Parse(Console.ReadLine());
                    MenuChoix(choix);
                    break;
            }
            Console.WriteLine("Faites entrer pour revenir au menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
