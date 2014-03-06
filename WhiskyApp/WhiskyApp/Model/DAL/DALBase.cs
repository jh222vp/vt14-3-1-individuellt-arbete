using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WhiskyApp.Model.DAL
{
    public class DALBase
    {
        //Fält
        private static string _connectionString;

        //CreateConnections skapar och returnerar en referens till ett anslutningsobjekt. 
        protected static SqlConnection CreateConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch (Exception)
            {
                throw new ApplicationException("Oväntat fel");
            }
        }
        //Konstruktor som initierar det statiska fältet genom att hämta anslutningssträngen från filen Web.config
        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["AdventureWorksAssignmentConnectionString"].ConnectionString;
        }
    }
}