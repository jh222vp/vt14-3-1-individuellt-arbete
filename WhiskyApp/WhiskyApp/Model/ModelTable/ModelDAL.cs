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
        //GetWhiskyModels används för att hämta alla whiskymodeller med hjälp av bl.a den lagrade proceduren appSchema.usp_ListModel
        public static IEnumerable<WhiskyModel> GetWhiskyModels()
        {
            //Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser.
                    var whiskyModel = new List<WhiskyModel>(100);
                    var cmd = new SqlCommand("appSchema.usp_ListModel", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutning till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //Tar reda på vilket index de olika kolumnerna har.
                        var ModelIDIndex = reader.GetOrdinal("ModelID");
                        var ModelIndex = reader.GetOrdinal("Model");

                        //Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler
                        //poster returnerar Read false.
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

                    //TrimExcess tar bort överflödig plats från listan labelBrands, avallokerar minne
                    //som inte används.
                    whiskyModel.TrimExcess();
                    return whiskyModel;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //GetWhiskyModelByID används för att hämta ut specifik whiskymodell med hjälp av bl.a den lagrade proceduren appSchema.usp_GetWhiskyModelByID
        public WhiskyModel GetWhiskyModelByID(int modelID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetWhiskyModelByID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Tar reda på vilket index de olika kolumnerna har.
                    cmd.Parameters.Add(@"ModelID", SqlDbType.Int, 4).Value = modelID;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
                        //Read false.
                        if (reader.Read())
                        {
                            var ModelIDIndex = reader.GetOrdinal("ModelID");
                            return new WhiskyModel
                            {
                                ModelID = reader.GetInt32(ModelIDIndex)
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    throw new ApplicationException("Lyckades inte uppdatera whiksymärket");
                }
            }
            //Hamnar aldrig vid returnen nedan. Eftersom catchen fångar fel.
            return null;
        }

        //Metoden DeleteModel tar bort en whiskymodell
        public static void DeleteModel(int modelID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteModel", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModelID", SqlDbType.Int, 4).Value = modelID;

                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att plocka bort information.
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod när uppgifterna plockades bort från databasen.");
                }
            }
        }

        //Metoden GetModelUpdate updaterar en whiskymodell
        public WhiskyModel GetModelUpdate(WhiskyModel whiskyModel)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateModelWhisky", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(@"ModelID", SqlDbType.Int, 4).Value = whiskyModel.ModelID;
                    cmd.Parameters.Add(@"Model", SqlDbType.VarChar, 30).Value = whiskyModel.Model;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
                        //Read false.
                        if (reader.Read())
                        {
                            var modelIDIndex = reader.GetOrdinal("modelID");
                            var modelIndex = reader.GetOrdinal("Model");

                            return new WhiskyModel
                            {
                                ModelID = reader.GetInt32(modelIDIndex),
                                Model = reader.GetString(modelIndex)
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    throw new ApplicationException("Lyckades inte uppdatera whiksymärket");
                }
            }
            //Hamnar aldrig vid returnen nedan. Eftersom catchen fångar fel.
            return null;
        }

        //Metoden InsertWhisky lägger till en whiskymodell
        public void InsertWhisky(WhiskyModel whiskyModel)
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