using KDBKinderboekenDBConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KDBKinderboekenDBConsoleApp.Services
{
    public class BoekenDAO : IBoekDataService
    {
        string connectionString = @"Server=DESKTOP-R82UNLU\MSSQLSERVER_1;Database=KDBKinderboeken;Trusted_Connection=True";
        public int Delete(Boek boek)
        {
            throw new NotImplementedException();
        }

        public List<Boek> GetAllBooks()
        {
            List<Boek> gevondenBoeken = new List<Boek>();

            string sqlStatement = "SELECT * FROM dbo.Boeken";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gevondenBoeken.Add(new Boek { Id = (int)reader[0], Titel = (string)reader[1], Samenvatting = (string)reader[2], Cijfer = (int)reader[3] });
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return gevondenBoeken;
        }

        public Boek GetBookByTitle(string Titel)
        {
            throw new NotImplementedException();
        }

        public int Insert(Boek boek)
        {
            throw new NotImplementedException();
        }

        public List<Boek> SearchBooks(string searchTerm)
        {
            List<Boek> gevondenBoeken = new List<Boek>();

            string sqlStatement = "SELECT * FROM dbo.Boeken WHERE Titel LIKE @Titel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Titel", '%' + searchTerm + '%');

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gevondenBoeken.Add(new Boek { Id = (int)reader[0], Titel = (string)reader[1], Samenvatting = (string)reader[2], Cijfer = (int)reader[3] });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return gevondenBoeken;
        }

        public int Update(Boek boek)
        {
            throw new NotImplementedException();
        }
    }
}