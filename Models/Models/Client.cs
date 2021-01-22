using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public  class Client
    {

        public string Numero { get; set; }
         public string Intitule { get; set; }
        public int  Type { get; set; }
        public string NumeroPrincipale { get; set; }
        public string ContactPrincipale { get; set; }
        public string Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string CodeRegion { get; set; }
        public string Pays { get; set; }
        public string Raccourcis { get; set; }
        public int BT_Num { get; set; }
        public string Ape { get; set; }
        public string MatriculeFiscale { get; set; }
        public string Siret { get; set; }
        public float  Encours { get; set; }
        public string NumeroPayeur { get; set; }
        public int CategorieTarif { get; set; }
        public int CategorieComptabilite { get; set; }
        public DateTime DateCreation { get; set; }
        public int Sommeil { get; set; }
        public int Depot { get; set; }
        public string Telephone { get; set; }
        public string Telecopie { get; set; }
        public string EMail { get; set; }
        public string SiteWeb { get; set; } 
        public string Timbre { get; set; }
        public float TauxRemise { get; set; }
        public string CategorieTVA { get; set; }
        public string Categorie { get; set; }
        public int Etranger { get; set; }
        public string Devise { get; set; }
        public float CoursDevise { get; set; }
        public string ADRESSELivraison { get; set; }
        public string CodePostalLivraison { get; set; }
        public string VilleLivraison { get; set; }
        public string PaysLivraison { get; set; }
        public string Qualite { get; set; }
        public string Adresse { get; set; }
        public string Commentaire { get; set; }
        public string Classement { get; set; }
        public string Jointe1 { get; set; }
        public string Jointe2 { get; set; }
        public int Collaborateur { get; set; }
        public string ModalitePaiement { get; set; }
        public string Incoterm { get; set; }
        public string CompteAuxiliaire { get; set; }
        public string ICE { get; set; }
        public int Familletier { get; set; }
        public int CREATEUR { get; set; }
        public int MODIFICATEUR { get; set; }
    }
}
