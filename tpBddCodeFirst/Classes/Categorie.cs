using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public class Categorie
    {
        public int CategorieID { get; set; }
        public required string Libelle { get; set; }
        public required double Prix_Km { get; set; }
        public virtual List<Voiture>? VoitureList { get;}

    }
}
