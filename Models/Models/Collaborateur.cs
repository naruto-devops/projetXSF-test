using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
   public class Collaborateur
    {
        public string    Nom { get; set; }
         public string   Prenom { get; set; }
        public string    Fonction { get; set; }
        public string    Adresse { get; set; }
        public string    CodePostal { get; set; }
        public string    Ville { get; set; }
        public string    Service { get; set; }
        public string   Telephone { get; set; }
        public string    EMail { get; set; }
        public string    Matricule { get; set; }
        public int      Type { get; set; }
        public int Numero { get; set; }
    }
}
