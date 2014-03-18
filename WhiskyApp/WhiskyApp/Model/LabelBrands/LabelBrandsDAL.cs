using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WhiskyApp.Model.DAL;

namespace WhiskyApp.Model
{
    public class LabelBrandsDAL : DALBase
    {
        //GetWhiskyBrands används för att hämta alla whiskymärken med hjälp av den lagrade proceduren appSchema.usp_ListAllBrands
        public IEnumerable<LabelBrands> GetWhiskyBrands()
        {
            //Skapar och initierar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser.
                    var labelBrands = new List<LabelBrands>(100);

                    //Skapar och initierar ett SqlCommand-objekt som används till att
                    //exekveras nedanstående lagrad procedur.
                    var cmd = new SqlCommand("appSchema.usp_ListAllBrands", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutning till databasen
                    conn.Open();


                    //Den lagrade proceduren innehåller en SELECT-sats som kan returnera flera poster varför
                    //ett SqlDataReader-objekt måste ta hand om alla poster. Metoden ExecuteReader skapar ett
                    //SqlDataReader-objekt och returnerar en referens till objektet.
                    using (var reader = cmd.ExecuteReader())
                    {
                        //Nedan tar reda på vilket index de olika kolumnerna har.
                        var labelBrandsIndex = reader.GetOrdinal("BrandID");
                        var labelBrandsNameIndex = reader.GetOrdinal("Brand");


                        // Så länge som det finns poster att läsa returnerar Read true. Finns det inte fler
                        // poster returnerar Read false.
                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post.
                            labelBrands.Add(new LabelBrands
                            {
                                BrandID = reader.GetInt32(labelBrandsIndex),
                                Brand = reader.GetString(labelBrandsNameIndex),
                            });
                        }
                    }

                    //TrimExcess tar bort överflödig plats från listan labelBrands, avallokerar minne
                    //som inte används.
                    labelBrands.TrimExcess();

                    return labelBrands;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Lyckades inte lista alla märken");
                }
            }
        }

        //Metoden DeleteLabelBrand tar bort ett whiskymärke ur datorbasen med hjälp av appSchema.usp_DeleteWhiskyBrandName proceduren.
        public void DeleteLabelBrand(int brandID)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteWhiskyBrandName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BrandID", SqlDbType.Int, 4).Value = brandID;

                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att plocka bort information.
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod när uppgifterna editerades i databasen.");
                }
            }
        }

        //Metoden GetWhiskyBrand hämtar ett specifikt whiskymärke ur datorbasen för att kunna editera ett existerande whiskymärke.
        public static LabelBrands GetWhiskyBrand(int brandID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_EditLabelBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(@"BrandID", SqlDbType.Int, 4).Value = brandID;

                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att INSERT information.
                    conn.Open();
                    cmd.ExecuteNonQuery();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Om det finns en post att läsa returnerar Read true. Finns ingen post returnerar
                        // Read false.
                        if (reader.Read())
                        {
                            var BrandIDIndex = reader.GetOrdinal("BrandID");

                            return new LabelBrands
                            {
                                BrandID = reader.GetInt32(BrandIDIndex)
                            };
                        }
                    }
                }
                catch (Exception)
                {
                    throw new ApplicationException("Lyckades inte uppdatera whiskymärket");
                }
            }
            //Hamnar aldrig vid returnen nedan. Eftersom catchen fångar fel.
            return null;
        }


        //Metoden InsertWhisky hämtar ett specifikt whiskymärke ur datorbasen för att kunna editera ett existerande whiskymärke.
        public void InsertWhisky(LabelBrands labelbrands)
        {
            using (SqlConnection conn = CreateConnection())

                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddWhiskyBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Brand", SqlDbType.VarChar, 50).Value = labelbrands.Brand;
                    cmd.Parameters.Add("@BrandID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att "INSERT" till databasen
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    labelbrands.BrandID = (int)cmd.Parameters["@BrandID"].Value;
                }
                catch (Exception)
                {
                    throw new ApplicationException("Error i åtkomstlagret i databasen");
                }
        }

        //UpdateWhisky uppdaterar en befintlig whiskuppgift
        public void UpdateWhisky(LabelBrands labelBrands)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_InsertLabelBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BrandID", SqlDbType.Int, 4).Value = labelBrands.BrandID;
                    cmd.Parameters.Add("@Brand", SqlDbType.VarChar, 50).Value = labelBrands.Brand;


                    //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att uppdatera
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel uppstod när uppgifterna skulle uppdateras i databasen.");
                }
            }
        }
    }
}