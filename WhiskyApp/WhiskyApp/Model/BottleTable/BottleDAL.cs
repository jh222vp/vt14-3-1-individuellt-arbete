using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WhiskyApp.Model.BottleTable
{
    public class BottleDAL : DAL.DALBase
    {
        //GetContacts används för att hämta alla kontaktuppgifter samt kontakatuppgifter
        public static IEnumerable<Bottle> GetBottleInfo()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Customer-objekt.
                    var bottle = new List<Bottle>(100);
                    var cmd = new SqlCommand("appSchema.usp_ListAllBottleProperties", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutning till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har. Genom att använda GetOrdinal behöver du inte känna till
                        var BottleIdIndex = reader.GetOrdinal("BottleID");
                        var YearIndex = reader.GetOrdinal("Year");
                        var PriceIndex = reader.GetOrdinal("Price");
                        var AmountIndex = reader.GetOrdinal("Amount");

                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            bottle.Add(new Bottle
                            {
                                BottleID = reader.GetInt32(BottleIdIndex),
                                Year = reader.GetInt32(YearIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Amount = reader.GetInt32(AmountIndex),
                            });
                        }
                    }
                    bottle.TrimExcess();
                    return bottle;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public static void InsertBottleProperties(Bottle bottle)
        {
            using (SqlConnection conn = CreateConnection())

                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddBottleProperties", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                   
                    cmd.Parameters.Add("@ModelID", SqlDbType.Int, 50).Value = bottle.ModelID;
                    cmd.Parameters.Add("@Year", SqlDbType.Int, 50).Value = bottle.Year;
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = bottle.Price;
                    cmd.Parameters.Add("@Amount", SqlDbType.Int, 50).Value = bottle.Amount;


                    cmd.Parameters.Add("@BottleID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att "INSERT" till databasen
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    bottle.BottleID = (int)cmd.Parameters["@BottleID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error i åtkomstlagret i databasen");
                }
        }





        
    }
}