using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
   public  class Incoterm
    {
        public int Numero { get; set; }
        public string Code { get; set; }
        public string Libelle { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public int Utilisateur { get; set; }

    }
}
