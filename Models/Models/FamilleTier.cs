using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Models.Models
{
   public  class FamilleTier
    {
       
        public string Code { get; set; }
        public string Libelle { get; set; }
        public int CategorieTarif { get; set; }
        public int   Exonere { get; set; }
    }
}
