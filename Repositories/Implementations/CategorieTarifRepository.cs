using Microsoft.Extensions.Configuration;
using Models.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Repositories.Implementations
{
   public  class CategorieTarifRepository : ICategorieTarifRepository
    {
        IConfiguration Configuration { get; }
        public CategorieTarifRepository(IConfiguration configuration)
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

        public List<CategorieTarif> GetAll()
        {
            var categories = new List<CategorieTarif>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select ct_no as Numero,ct_intitule as categorie, CT_TTC as PrixTTC from P_cattarif  ";
                    dbConnection.Open();
                    categories = dbConnection.Query<CategorieTarif>(sQuery).ToList();

                }

            }
            catch (Exception)
            {
                return null;

            }

            return categories;
        }


        public CategorieTarif GetById(int id)
        {
            var categorie = new CategorieTarif();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select  ct_no as Numero, ct_intitule as categorie, CT_TTC as PrixTTC from P_cattarif
                                        where ct_no =@Id ";
                    dbConnection.Open();
                    categorie = dbConnection.Query<CategorieTarif>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {

                return null;
            }
            return categorie;
        }


        public CategorieTarif GetByClient(int id)
        {
            var categorie = new CategorieTarif();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select  ct_no as Numero,  ct_intitule as categorie, CT_TTC as PrixTTC 
                                    from P_cattarif where ct_no =@Id and Ct_NO in (select distinct N_catTarif from F_COMPTET)";
                    dbConnection.Open();
                    categorie = dbConnection.Query<CategorieTarif>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            return categorie;
        }


        public CategorieTarif Add(CategorieTarif categorie)
        {
         
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO  P_cattarif
                                    ( ct_intitule , CT_TTC    )
                                     VALUES  (@categorie,@PrixTTC )";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, categorie);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return categorie;
        }

       

        public CategorieTarif Update(CategorieTarif categorie)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update  P_cattarif set  ct_intitule =@categorie ,
                                    CT_TTC=@PrixTTC where ct_no =@numero";

                    dbConnection.Open();
                    dbConnection.Execute(sQuery, categorie);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return categorie;
        }

        public bool Delete(int id)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"Delete from P_cattarif where  ct_no = @Id ";
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
    }
}
