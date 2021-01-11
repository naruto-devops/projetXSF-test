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
    public class FournisseurRepository :IFournisseurRepository
    {

        IConfiguration Configuration { get; }
        public FournisseurRepository(IConfiguration configuration)
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

        public List<Fournisseur> GetAll()
        {
            var res = new List<Fournisseur>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select * from F_COMPTET where CT_Type = '1' ";
                    dbConnection.Open();
                    res = dbConnection.Query<Fournisseur>(sQuery).ToList();

                }

            }
            catch (Exception)
            {


            }
            return res;
        }
    }
}
