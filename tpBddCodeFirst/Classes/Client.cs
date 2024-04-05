using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    internal class Client
    {
        public int ClientID { get; set; }
        public required string? LastName { get; set; }
        public required string? FirstName { get; set; }
        public required string Adresse { get; set; }
        public required string Code_Postal { get; set; }
        public required string Ville {  get; set; }
        public List<Location> Locations { get; set; }
    }
}
