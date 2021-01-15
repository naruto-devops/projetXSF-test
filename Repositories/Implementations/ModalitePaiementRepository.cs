using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Repositories.Implementations
{
  public   class ModalitePaiementRepository : IModalitePaiementRepository
    {
        IConfiguration Configuration { get; }
        public ModalitePaiementRepository(IConfiguration configuration)
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

        public List<ModalitePaiement> GetAll()
        {
            var res = new List<ModalitePaiement>();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select    EMR_NO as Numero,
                                            EMR_Intitule as Intitule,
                                            EMR_Code as Code,
                                            EMR_Description as Description

                                     from F_MODELREGENT
                                      ";
                    dbConnection.Open();
                    res = dbConnection.Query<ModalitePaiement>(sQuery).ToList();

                }

            }
            catch (Exception)
            {


            }

            return res;
        }


        public ModalitePaiement GetById(int id)
        {
            var res = new ModalitePaiement();
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"select    EMR_NO as Numero,
                                            EMR_Intitule as Intitule,
                                            EMR_Code as Code,
                                            EMR_Description as Description

                                     from F_MODELREGENT
                                     where EMR_NO  =@Id ";
                    dbConnection.Open();
                    res = dbConnection.Query<ModalitePaiement>(sQuery, new { Id = id }).FirstOrDefault();

                }

            }
            catch (Exception)
            {


            }
            return res;
        }


        public void Add(ModalitePaiement mlt)
        {
            
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"INSERT INTO   F_MODELREGENT
                                    (   EMR_Intitule,EMR_Code,EMR_Description
                                        )
                                     VALUES  (@Intitule,@Code,@Description )";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, mlt);

                }

            }
            catch (Exception)
            {


            }

        }

        public void Delete(int id)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"Delete from F_MODELREGENT where   EMR_NO = @Id ";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new { ID = id });
                }

            }
            catch (Exception)
            {


            }

        }

        public void Update(ModalitePaiement mlt)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string sQuery = @"update  F_MODELREGENT set  
                                      EMR_Intitule=@Intitule,EMR_Code=@Code,EMR_Description=@Description
                                      where  EMR_NO=@Numero";

                    dbConnection.Open();
                    dbConnection.Execute(sQuery, mlt);

                }

            }
            catch (Exception)
            {


            }

        }
    }
}
