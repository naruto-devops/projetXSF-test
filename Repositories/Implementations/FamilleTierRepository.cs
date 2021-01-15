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
   public  class FamilleTierRepository: IFamilleTierRepository

    {
        IConfiguration Configuration { get; }
        public FamilleTierRepository(IConfiguration configuration)
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

        public List<FamilleTier> GetAll()
        {
            var res = new List<FamilleTier>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select FC_NO as Numero, FC_Code as Code, FC_Libelle as Libelle, FC_CAttarif as CategorieTarif, Fc_Exonere as Exonere  from F_FamilleTier  ";
                    dbConnection.Open();
                    res = dbConnection.Query<FamilleTier>(sQuery).ToList();

                }

            }
            catch (Exception)
            {


            }

            return res;
        }


        public FamilleTier GetById(string id)
        {
            var res = new FamilleTier();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select  FC_Code as Code, FC_Libelle as Libelle, FC_CAttarif as CategorieTarif, Fc_Exonere as Exonere from F_FamilleTier where FC_CODE =@Id ";
                    dbConnection.Open();
                    res= dbConnection.Query<FamilleTier>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {


            }
            return res;
        }


        public void Add(FamilleTier frs)
        {
            var finput = frs; 
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO F_FamilleTier
                                    ( fc_code,fc_libelle,fc_cattarif,fc_exonere                )
                                     VALUES  (@Code,@Libelle,@CategorieTarif,@Exonere)";
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
                    string sQuery = @"Delete from F_FamilleTier where FC_Code = @Id ";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { ID = id });
                }

            }
            catch (Exception)
            {


            }

        }

        public void Update( FamilleTier fts)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update F_FamilleTier set  fc_libelle =@libelle , fc_cattarif=@categorietarif, fc_exonere=@exonere   where fc_code =@code ";
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
