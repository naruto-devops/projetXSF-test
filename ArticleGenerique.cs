using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class ArticleGenerique
    {
        public int CBMARQ { get; set; }
        public string AR_Ref { get; set; }
        public string AR_Design { get; set; }
        public string AR_UniteVen { get; set; }
        public string Dim_code1 { get; set; }
        public string Dim_code2 { get; set; }

        public string AR_Description { get; set; }
        public DateTime AR_DateCreation { get; set; }
    }
}
