using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    internal class Marque
    {
        public int MarqueID { get; set; }
        public required string Name { get; set; }
        public virtual List<Voiture> Voitures { get;}
    }
}
