// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using tpBddCodeFirst;
using tpBddCodeFirst.Classes;

Console.WriteLine("Hello, World!");

AppDbContext appDbContext = new AppDbContext();



//CRUDClient.CreateClient();

//CRUDClient.DisplayClient();
//CRUDClient.removeClient(CRUDClient.GetClient());

//CRUDClient.updateClient(CRUDClient.GetClient());
//CRUDClient.DisplayClient();

//CRUDLocation.CreateLocation();
//CRUDLocation.DisplayLocation();

//CRUDLocation.updateLocation(CRUDLocation.GetLocation());

//CRUDLocation.DisplayLocation();
while (true)
{
    Menu.Accueil();
}
