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




















        ////Metoden DeleteContact tar bort en kontaktuppgift
        //public void DeleteContact(int contactId)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("ContactID", SqlDbType.Int, 4).Value = contactId;

        //            //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att plocka bort information.
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            throw new ApplicationException("Ett fel uppstod när uppgifterna plockades bort från databasen.");
        //        }
        //    }
        //}

        ////UpdateContact uppdaterar en befintlig kontaktuppgift
        //public void UpdateContact(LabelBrands contact)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactId;
        //            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
        //            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
        //            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

        //            //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att uppdatera
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            throw new ApplicationException("Ett fel uppstod när uppgifterna skulle uppdateras i databasen.");
        //        }
        //    }
        //}

        //public LabelBrands GetContact(int contactId)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("Person.uspGetContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add(@"ContactId", SqlDbType.Int, 4).Value = contactId;
        //            conn.Open();
        //            cmd.ExecuteNonQuery();

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    var ContactIdIndex = reader.GetOrdinal("ContactId");
        //                    var FirstNameIndex = reader.GetOrdinal("FirstName");
        //                    var LastNameIndex = reader.GetOrdinal("LastName");
        //                    var EmailIndex = reader.GetOrdinal("EmailAddress");

        //                    return new LabelBrands
        //                    {
        //                        ContactId = reader.GetInt32(ContactIdIndex),
        //                        FirstName = reader.GetString(FirstNameIndex),
        //                        LastName = reader.GetString(LastNameIndex),
        //                        EmailAddress = reader.GetString(EmailIndex),
        //                    };
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw new ApplicationException("Lyckades inte uppdatera kund");
        //        }
        //    }
        //    //Hamnar aldrig vid returnen nedan. Eftersom catchen fångar fel.
        //    return null;
        //}

        //public IEnumerable<LabelBrands> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            var contacts = new List<Contact>(100);
        //            SqlCommand cmd = new SqlCommand("Person.uspGetContactsPageWise", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            //+1 är för att den ska starta på rätt "sida". Annars blir den första 0
        //            cmd.Parameters.Add(@"PageIndex", SqlDbType.Int, 4).Value = (startRowIndex / maximumRows) + 1;
        //            cmd.Parameters.Add(@"PageSize", SqlDbType.Int, 4).Value = maximumRows;
        //            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //            conn.Open();
        //            cmd.ExecuteNonQuery();


        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                var ContactIdIndex = reader.GetOrdinal("ContactID");
        //                var FirstNameIndex = reader.GetOrdinal("FirstName");
        //                var LastNameIndex = reader.GetOrdinal("LastName");
        //                var EmailIndex = reader.GetOrdinal("EmailAddress");

        //                while (reader.Read())
        //                {
        //                    contacts.Add(new LabelBrands
        //                    {
        //                        ContactId = reader.GetInt32(ContactIdIndex),
        //                        FirstName = reader.GetString(FirstNameIndex),
        //                        LastName = reader.GetString(LastNameIndex),
        //                        EmailAddress = reader.GetString(EmailIndex),
        //                    });
        //                }
        //            }
        //            totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
        //            contacts.TrimExcess();
        //            return contacts;
        //        }
        //        catch (Exception)
        //        {
        //            throw new ApplicationException("Lyckades inte uppdatera kund");
        //        }
        //    }
        //}

        //public void InsertContact(LabelBrands contact)
        //{
        //    using (SqlConnection conn = CreateConnection())

        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
        //            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
        //            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;

        //            cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //            //Öppnar anslutning till databasen samt "ExecuteNonQuery" kommandot för att "INSERT" till databasen
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            contact.ContactId = (int)cmd.Parameters["@ContactID"].Value;
        //        }
        //        catch (Exception)
        //        {
        //            throw new ApplicationException("Error i åtkomstlagret i databasen");
        //        }
        }
    }