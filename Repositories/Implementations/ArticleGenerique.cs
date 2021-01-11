using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Reposiotries.Implementations
{
    public class ArticleGeneriqueRepository : IArticleGeneriqueRepository
    {
        IConfiguration Configuration { get; }
        public ArticleGeneriqueRepository(IConfiguration configuration)
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

        public List<ArticleGenerique> GetAll()
        {
            var res = new List<ArticleGenerique>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select * from F_article  ";
                    dbConnection.Open();
                    res = dbConnection.Query<ArticleGenerique>(sQuery).ToList();

                }

            }
            catch (Exception)
            {


            }
            return res;
        }


        public ArticleGenerique GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM F_Article where cbMarq =@Id  ";
                dbConnection.Open();
                return dbConnection.Query<ArticleGenerique>(sQuery, new { Id = id }).FirstOrDefault();

            }

        }
        public IEnumerable<ArticleGenerique> GetByPO(string i)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM F_Article where Ar_Ref in (select Ar_Ref from F_Docligne where  DO_Piece =@i ) ";
                dbConnection.Open();
                return dbConnection.Query<ArticleGenerique>(sQuery, new { I = i }).ToList();

            }

        }
    }
}

