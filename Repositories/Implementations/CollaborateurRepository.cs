﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositories.Implementations
{
   public class CollaborateurRepository : ICollaborateurRepository
    {
        IConfiguration Configuration { get; }
        public CollaborateurRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            }

        }

        public List<Collaborateur> GetAll()
        {
            var collaborateurs = new List<Collaborateur>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select       CO_Nom     as Nom , 
                                     CO_Prenom     as            Prenom  ,
                                     CO_Fonction     as            Fonction  ,
                                     CO_Adresse     as            Adresse  ,
                                     CO_CodePostal     as            CodePostal  ,
                                     CO_Ville     as            Ville  ,
                                     CO_Service     as            Service  ,
                                     CO_Telephone     as            Telephone  ,
                                     CO_EMail     as            EMail  ,
                                     CO_Matricule     as            Matricule  ,
                                     CO_Type          as            Type  ,
                                     CO_NO as Numero
                                     from F_COLLABORATEUR
                                      ";
                    dbConnection.Open();
                    collaborateurs = dbConnection.Query<Collaborateur>(sQuery).ToList();

                }

            }
            catch (Exception)
            {
                return null;

            }

            return collaborateurs;
        }


        public Collaborateur GetById(int id)
        {
            var collaborateur = new Collaborateur();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select       CO_Nom     as Nom , 
                                     CO_Prenom     as            Prenom  ,
                                     CO_Fonction     as            Fonction  ,
                                     CO_Adresse     as            Adresse  ,
                                     CO_CodePostal     as            CodePostal  ,
                                     CO_Ville     as            Ville  ,
                                     CO_Service     as            Service  ,
                                     CO_Telephone     as            Telephone  ,
                                     CO_EMail     as            EMail  ,
                                     CO_Matricule     as            Matricule  ,
                                     CO_Type          as            Type  ,
                                     CO_NO as Numero
                                     from F_COLLABORATEUR
                                     where CO_NO =@Id ";
                    dbConnection.Open();
                    collaborateur = dbConnection.Query<Collaborateur>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            return collaborateur;
        }


        public Collaborateur Add(Collaborateur collaborateur)
        {
            
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO  F_COLLABORATEUR
                                    (   CO_Nom   , CO_Prenom   , CO_Fonction  , CO_Adresse  , CO_CodePostal     
                                    ,  CO_Ville     , CO_Service ,  CO_Telephone ,  CO_EMail  ,  CO_Matricule , CO_Type  )
                                     VALUES  (
                                    @Nom,  @Prenom,@Fonction,@Adresse,@CodePostal, @Ville,@Service,@Telephone,@EMail,@Matricule,@Type)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, collaborateur);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return collaborateur;
        }

        public bool Delete(int id)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"Delete from F_COLLABORATEUR where   CO_No = @Id ";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { ID = id });
                }

            }
            catch (Exception)
            {
                return false;

            }
            return true;
        }

        public Collaborateur Update(Collaborateur collaborateur)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update  F_COLLABORATEUR set  
                                      CO_Nom=@Nom,  CO_Prenom=@Prenom,CO_Fonction=@Fonction,CO_Adresse=@Adresse,
                                        CO_CodePostal=@CodePostal,CO_Ville=@Ville,CO_Service=@Service, CO_Telephone=@Telephone,
                                        CO_EMail=@EMail,CO_Matricule=@Matricule,CO_Type=@Type


                                where  CO_NO = @Numero";

                    dbConnection.Open();
                    dbConnection.Execute(sQuery, collaborateur);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return collaborateur;
        }

      public  Collaborateur GetByClient(int id)
        {

            var collaborateur = new Collaborateur();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select       CO_Nom     as Nom , 
                                     CO_Prenom     as            Prenom  ,
                                     CO_Fonction     as            Fonction  ,
                                     CO_Adresse     as            Adresse  ,
                                     CO_CodePostal     as            CodePostal  ,
                                     CO_Ville     as            Ville  ,
                                     CO_Service     as            Service  ,
                                     CO_Telephone     as            Telephone  ,
                                     CO_EMail     as            EMail  ,
                                     CO_Matricule     as            Matricule  ,
                                     CO_Type          as            Type  ,
                                     CO_NO as Numero
                                     from F_COLLABORATEUR
                                     
                                     where CO_NO =@id and CO_NO in (select distinct CO_NO from F_COMPTET) ";
                    dbConnection.Open();
                    collaborateur = dbConnection.Query<Collaborateur>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            
            return collaborateur;


        }
    }
}
