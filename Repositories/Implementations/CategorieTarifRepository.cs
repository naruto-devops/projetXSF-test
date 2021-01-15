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
            var res = new List<CategorieTarif>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select ct_intitule as categorie, CT_TTC as PrixTTC from P_cattarif  ";
                    dbConnection.Open();
                    res = dbConnection.Query<CategorieTarif>(sQuery).ToList();

                }

            }
            catch (Exception)
            {


            }

            return res;
        }


        public CategorieTarif GetById(string id)
        {
            var res = new CategorieTarif();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select   ct_intitule as categorie, CT_TTC as PrixTTC from P_cattarif where ct_intitule =@Id ";
                    dbConnection.Open();
                    res= dbConnection.Query<CategorieTarif>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {


            }
            return res;
        }


        public void Add(CategorieTarif frs)
        {
            var finput = frs;
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO  P_cattarif
                                    ( ct_intitule , CT_TTC    )
                                     VALUES  (@categorie,@PrixTTC )";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, frs);

                }

            }
            catch (Exception)
            {


            }

        }

        public void Delete(string id)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"Delete from P_cattarif where  ct_intitule = @Id ";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { ID = id });
                }

            }
            catch (Exception)
            {


            }

        }

        public void Update(CategorieTarif fts)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update  P_cattarif set  ct_intitule =@categorie , CT_TTC=@PrixTTC where ct_intitule =@categorie";

                    dbConnection.Open();
                    dbConnection.Execute(sQuery, fts);

                }

            }
            catch (Exception)
            {


            }

        }
    }
}
