using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpBddCodeFirst.Classes
{
    public class Location
    {
        public int LocationID { get; set; }
        public required double Nb_Km {  get; set; }
        public required DateTime Date_Debut { get; set; }
        public required DateTime Date_Fin {  get; set; }

        public int ClientID { get; set; }
        public int VoitureID {  get; set; }
        
        public virtual Voiture Voiture { get; set; }
        
        public virtual Client Client { get; set; }
        public override string ToString()
        {
            return $"ID : {LocationID} | VoitureID : {VoitureID} | Nb_KM : {Nb_Km} | Debut : {Date_Debut} | Fin : {Date_Fin} | ClientId < {ClientID} > ";
        }
    }
}
