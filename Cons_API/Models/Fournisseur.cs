using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cons_API.Models
{
    public class Fournisseur
    {

        public string CT_Num { get; set; }
        public string CT_Intitule { get; set; }
        public int CT_Type { get; set; }
        public string CG_NumPrinc { get; set; }
        public string CT_Contact { get; set; }
        public string CT_Complement { get; set; }
        public string CT_CodePostal { get; set; }
        public string CT_Ville { get; set; }
        public string CT_CodeRegion { get; set; }
        public string CT_Pays { get; set; }
        public string CT_Raccourci { get; set; }
        public int BT_Num { get; set; }
        public string CT_Ape { get; set; }
        public string CT_Identifiant { get; set; }
        public string CT_Siret { get; set; }
        public float CT_Encours { get; set; }
        public string CT_NumPayeur { get; set; }
        public int N_CatTarif { get; set; }
        public int N_CatCompta { get; set; }
        public DateTime CT_DateCreate { get; set; }
        public int CT_Sommeil { get; set; }
        public int DE_No { get; set; }
        public string CT_Telephone { get; set; }
        public string CT_Telecopie { get; set; }
        public string CT_EMail { get; set; }
        public string CT_Site { get; set; }
        public string Timbre { get; set; }
        public float CT_Remise { get; set; }
        public string CT_CTVA { get; set; }
        public string CT_Categorie { get; set; }
        public int CT_Etranger { get; set; }
        public string CT_Devise { get; set; }
        public float CT_CoursDevise { get; set; }
        public string CT_LIVADRESSE { get; set; }
        public string CT_LIVCP { get; set; }
        public string CT_LIVVILLE { get; set; }
        public string CT_LIVPAYS { get; set; }
        public string CT_Qualite { get; set; }
        public string CT_Adresse { get; set; }
        public string CT_Commentaire { get; set; }
        public string CT_Classement { get; set; }
        public string CT_Jointe1 { get; set; }
        public string CT_Jointe2 { get; set; }
        public int CO_No { get; set; }
        public string EMR_Code { get; set; }
        public string IT_CODE { get; set; }
        public string CT_AUXI { get; set; }
        public string CT_ICE { get; set; }
        public int FC_NO { get; set; }
        public int CT_CREATEUR { get; set; }
        public int CT_MODIFICATEUR { get; set; }
    }
}
