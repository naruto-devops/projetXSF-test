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
   public  class ClientRepository : IClientRepository
   {
        
            IConfiguration Configuration { get; }
            public ClientRepository(IConfiguration configuration)
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

            public List<Client> GetAll()
            {
                var res = new List<Client>();
                try
                {
                    using (IDbConnection dbConnection = Connection)
                    {
                        string sQuery = @"select * from F_COMPTET where CT_Type = '0' ";
                        dbConnection.Open();
                        res = dbConnection.Query<Client>(sQuery).ToList();

                    }

                }
                catch (Exception)
                {


                }
                return res;
              }
        public Client GetById(int id)
        {
            var res = new Client();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select * from F_COMPTET where CT_Type = '0' and cbMarq =@Id ";
                    dbConnection.Open();
                    return dbConnection.Query<Client>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {


            }
            return res;
        }
        

   }
}
