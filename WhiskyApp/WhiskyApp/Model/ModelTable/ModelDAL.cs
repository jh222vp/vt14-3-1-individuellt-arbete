using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WhiskyApp.Model.DAL;

namespace WhiskyApp.Model
{
    public class ModelDAL : DALBase
    {
        //GetContacts används för att hämta alla kontaktuppgifter samt kontakatuppgifter
        public static IEnumerable<WhiskyModel> GetWhiskyModels()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Customer-objekt.
                    var whiskyModel = new List<WhiskyModel>(100);
                    var cmd = new SqlCommand("appSchema.usp_ListModel", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutning till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har. Genom att använda GetOrdinal behöver du inte känna till
                        var ModelIDIndex = reader.GetOrdinal("ModelID");
                        var ModelIndex = reader.GetOrdinal("Model");

                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            whiskyModel.Add(new WhiskyModel
                            {
                                ModelID = reader.GetInt32(ModelIDIndex),
                                Model = reader.GetString(ModelIndex),
                            });
                        }
                    }
                    whiskyModel.TrimExcess();
                    return whiskyModel;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }



        public static void InsertWhisky(WhiskyModel whiskyModel)
        {
            using (SqlConnection conn = CreateConnection())

                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddWhiskyModel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Model", SqlDbType.VarChar, 50).Value = whiskyModel.Model;
                    cmd.Parameters.Add("@BrandID", SqlDbType.Int, 4).Value = whiskyModel.BrandID;
                    cmd.Parameters.Add("@ModelID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att "INSERT" till databasen
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    whiskyModel.ModelID = (int)cmd.Parameters["@ModelID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error i åtkomstlagret i databasen");
                }
        }
    }
}