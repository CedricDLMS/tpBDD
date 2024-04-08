using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public class Voiture
    {
        public required int VoitureID { get; set; }
        public required string Name { get; set; }
        public required string Immat { get; set; }
        public required string Couleur { get; set; }
        public int MarqueID { get; set; }
        public int CategorieID {  get; set; }
        
        public virtual Marque Marque { get; set; }
        
        public virtual Categorie Categorie { get; set; }

        public List<Location> locations { get; set; }
        //public override string ToString()
        //{
        //    return $" IDVoiture {} "
        //}
    }
}
