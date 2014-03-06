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
                        var PercentsIndex = reader.GetOrdinal("Percents");

                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            bottle.Add(new Bottle
                            {
                                BottleID = reader.GetInt32(BottleIdIndex),
                                Year = reader.GetInt32(YearIndex),
                                Price = reader.GetDecimal(PriceIndex),
                                Amount = reader.GetInt32(AmountIndex),
                                Percents = reader.GetDecimal(PercentsIndex),
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
    }
}