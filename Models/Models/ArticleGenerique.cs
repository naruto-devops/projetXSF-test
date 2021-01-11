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
        public DateTime AR_DateModifiction { get; set; }
        public float AR_PrixAch { get; set; }
        public float AR_Coef { get; set; }
        public float AR_PrixVen { get; set; }
        public int AR_PrixTTC { get; set; }
        public int AR_SuiviStock { get; set; }
        public string AR_CodeFiscal { get; set; }
        public string AR_Pays { get; set; }
        public string FA_CodeFamille { get; set; }
        public float AR_PUNet { get; set; }
        public int AR_NotImp { get; set; }
        public float AR_Remise { get; set; }
        public string AR_CodeBarre { get; set; }
        public float AR_PrixAchDern { get; set; }
        public int  AR_TaxeVente1 { get; set; }
        public int  AR_TaxeVente2 { get; set; }
        public int  AR_TaxeAchat1 { get; set; }
        public int  AR_TaxeAchat2 { get; set; }
        public int  AR_Sommeil { get; set; }
        public int AR_Conditionne { get; set; }
        public float AR_QteConditionne { get; set; }
        public string  AR_ImageName { get; set; }
        public int AR_TypeArt { get; set; }
        public string DIM_CODE1 { get; set; }
        public string DIM_CODE2 { get; set; }
        public int AR_Statut { get; set; }
        public string  AR_FRSPR { get; set; }
        public string  AR_Jointe1 { get; set; }
        public string AR_Jointe2 { get; set; }
        public float AR_Poids { get; set; }
        public string AR_REFFRS { get; set; }
        public int  CA_NO { get; set; }
        public int  AR_EMBALLAGE { get; set; }
        public float  AR_STOCKMIN { get; set; }
        public float AR_FEINTEPROD { get; set; }
        public int AR_DELAIAPPRO { get; set; }
        public float AR_FEINTAPPRO { get; set; }
        public int FA0_NO { get; set; }
        public string AR_LOTENCOURS { get; set; }
        public int AR_CREATEUR { get; set; }
        public int AR_MODIFICATEUR { get; set; }


    }
}
