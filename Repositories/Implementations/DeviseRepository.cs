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
   public class DeviseRepository :IDeviseRepository
    {
        IConfiguration Configuration { get; }
        public DeviseRepository(IConfiguration configuration)
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

        public List<Devise> GetAll()
        {
            var res = new List<Devise>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select DV_NO as Numero, DV_DEVISE as DEVISE ,    DV_CodeISO as CODEISO,DV_Codebanque as CODEBANQUE,
                                        DV_libelle as LIBELLE, DV_Symbole as  SYMBOLE,DV_Decimale as  DECIMALE , 
                                        DV_Cours as  COURS  from P_DEVISE  ";
                    dbConnection.Open();
                    res = dbConnection.Query<Devise>(sQuery).ToList();

                }

            }
            catch (Exception)
            {
                return null;

            }

            return res;
        }


        public Devise GetById(int id)
        {
            var res = new Devise();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select   DV_NO as Numero,
                                     DV_DEVISE as DEVISE ,    DV_CodeISO as CODEISO,DV_Codebanque as CODEBANQUE,
                                        DV_libelle as LIBELLE, DV_Symbole as  SYMBOLE,DV_Decimale as  DECIMALE,  
                                        DV_Cours as  cours   from P_DEVISE 
                                     where DV_NO  =@Id ";
                    dbConnection.Open();
                    res = dbConnection.Query<Devise>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            return res;
        }

        public Devise GetByClient(int id)
        {
            var res = new Devise();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select   DV_NO as Numero,
                                     DV_DEVISE as DEVISE ,    DV_CodeISO as CODEISO,DV_Codebanque as CODEBANQUE,
                                        DV_libelle as LIBELLE, DV_Symbole as  SYMBOLE,DV_Decimale as  DECIMALE,  
                                        DV_Cours as  cours   from P_DEVISE 
                                     where DV_NO  =@Id and DV_DEVISE in (select distinct ct_DEVISE from F_COMPTET) ";
                    dbConnection.Open();
                    res = dbConnection.Query<Devise>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {
                return null;

            }
            return res;
        }

        public Devise Add(Devise dvs)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO P_Devise
                                    (  DV_DEVISE  ,    DV_CodeISO  ,DV_Codebanque ,
                                        DV_libelle  , DV_Symbole  ,DV_Decimale    ,   DV_Cours    )
                                     VALUES  (@DEVISE,@CODEISO,@CODEBANQUE,@LIBELLE,@SYMBOLE,@DECIMALE,@COURS)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, dvs);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return dvs;
        }

        public bool Delete(int id)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"Delete from P_devise where DV_NO = @Id ";
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

        public Devise Update(Devise devise)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update P_Devise set  
                                DV_DEVISE=@DEVISE , DV_CodeISO =@CODEISO,DV_Codebanque =@CODEBANQUE,
                                DV_libelle =@LIBELLE, DV_Symbole =@SYMBOLE,DV_Decimale =@DECIMALE, DV_Cours =@cours 
                                where  DV_no=@Numero ";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, devise);

                }

            }
            catch (Exception)
            {
                return null;

            }
            return devise;
        }
    }
}
