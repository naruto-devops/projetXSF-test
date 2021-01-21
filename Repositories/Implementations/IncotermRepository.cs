using Dapper;
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
   public class IncotermRepository : IIncotermRepository
    {
        IConfiguration Configuration { get; }
        public IncotermRepository(IConfiguration configuration)
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

        public List<Incoterm> GetAll()
        {
            var res = new List<Incoterm>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select  IT_NO as Numero ,IT_Code as Code,IT_LIBELLE as Libelle,IT_DATECREATE as DateCreation,
                                                IT_DATEMODIF as DateModification,IT_USER as Utilisateur


                                                 
                                     from P_INCOTERMS
                                      ";
                    dbConnection.Open();
                    res = dbConnection.Query<Incoterm>(sQuery).ToList();

                }

            }
            catch (Exception)
            {
                return null;

            }

            return res;
        }


        public Incoterm GetById(int id)
        {
            var incoterm = new Incoterm();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select      
                                               IT_NO as Numero, IT_Code as Code,IT_LIBELLE as Libelle,IT_DATECREATE as DateCreation,
                                                IT_DATEMODIF as DateModification,IT_USER as Utilisateur


                                                 from P_INCOTERMS
                                                 where IT_NO  =@Id ";
                    dbConnection.Open();
                    incoterm = dbConnection.Query<Incoterm>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            return incoterm;
        }


        public Incoterm Add(Incoterm incoterm)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO   P_INCOTERMS
                                    (   IT_Code,IT_LIBELLE,IT_DATECREATE,IT_DATEMODIF,IT_USER

                                        )
                                     VALUES  (@Code,@Libelle,@DateCreation,@DateModification,@Utilisateur )";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, incoterm);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return incoterm;
        }

        public bool Delete(int id)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"Delete from  P_INCOTERMS where   IT_NO = @Id ";
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

        

        public Incoterm GetByClient(int id)
        {
            var incoterm = new Incoterm();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select      
                                               IT_NO as Numero, IT_Code as Code,IT_LIBELLE as Libelle,IT_DATECREATE as DateCreation,
                                                IT_DATEMODIF as DateModification,IT_USER as Utilisateur


                                                 from P_INCOTERMS
                                                 where IT_NO  =@Id and IT_code  in (select distinct IT_code from F_COMPTET) ";
                    dbConnection.Open();
                    incoterm = dbConnection.Query<Incoterm>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            return incoterm;
        }

        public Incoterm Update(Incoterm incoterm)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update  P_INCOTERMS  set  
                                      IT_Code=@Code,IT_LIBELLE=@Libelle,IT_DATECREATE=@DateCreation,IT_DATEMODIF=@DateModification,IT_USER=@Utilisateur

                                      where  IT_NO=@Numero";

                    dbConnection.Open();
                    dbConnection.Execute(sQuery, incoterm);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return incoterm;
        }
    }
}
