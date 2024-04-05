using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    internal class Location
    {
        public int LocationID { get; set; }
        public required double Nb_Km {  get; set; }
        public required DateTime Date_Debut { get; set; }
        public required DateTime Date_Fin {  get; set; }

        public int ClientID { get; set; }
        public int VoitureID {  get; set; }
        
        public virtual Voiture Voiture { get; set; }
        
        public virtual Client Client { get; set; }
    }
}
