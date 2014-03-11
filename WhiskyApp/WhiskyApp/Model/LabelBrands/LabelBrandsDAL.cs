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
        //GetContacts används för att hämta alla kontaktuppgifter samt kontakatuppgifter
        public IEnumerable<LabelBrands> GetWhiskyBrands()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt som initialt har plats för 100 referenser till Customer-objekt.
                    var labelBrands = new List<LabelBrands>(100);
                    var cmd = new SqlCommand("appSchema.usp_ListAllBrands", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppnar anslutning till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Tar reda på vilket index de olika kolumnerna har. Genom att använda GetOrdinal behöver du inte känna till
                        var labelBrandsIndex = reader.GetOrdinal("BrandID");
                        var labelBrandsNameIndex = reader.GetOrdinal("Brand");

                        while (reader.Read())
                        {
                            // Hämtar ut datat för en post. Använder GetXxx-metoder - vilken beror av typen av data.
                            labelBrands.Add(new LabelBrands
                            {
                                BrandID = reader.GetInt32(labelBrandsIndex),
                                Brand = reader.GetString(labelBrandsNameIndex),
                            });
                        }
                    }
                    labelBrands.TrimExcess();
                    return labelBrands;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }











        //Metoden DeleteContact tar bort en kontaktuppgift
        public void DeleteLabelBrand(int brandID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteWhisky", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BrandID", SqlDbType.Int, 4).Value = brandID;

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




        public static LabelBrands GetWhiskyBrand(int brandID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_EditLabelBrand", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(@"BrandID", SqlDbType.Int, 4).Value = brandID;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
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
                    throw new ApplicationException("Lyckades inte uppdatera whiksymärket");
                }
            }
            //Hamnar aldrig vid returnen nedan. Eftersom catchen fångar fel.
            return null;
        }







        public void InsertWhisky(LabelBrands labelbrands)
        {
            using (SqlConnection conn = CreateConnection())

                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddWhisky", conn);
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





        //UpdateContact uppdaterar en befintlig whiskuppgift
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