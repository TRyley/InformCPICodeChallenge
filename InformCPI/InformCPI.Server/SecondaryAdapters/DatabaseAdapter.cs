using InformCPI.Server.Models;
using InformCPI.Server.OutgoingPorts;
using System.Data.SqlClient;

namespace InformCPI.Server.SecondaryAdapters
{
    public class DatabaseAdapter : IDatabaseReader, IDatabaseWriter
    {
        private readonly ILogger<DatabaseAdapter> _logger;
        private readonly SqlConnectionStringBuilder sqlStringBuilder;
        public DatabaseAdapter(ILogger<DatabaseAdapter> logger)
        {
            _logger = logger;
            sqlStringBuilder = new SqlConnectionStringBuilder();

            sqlStringBuilder.DataSource = "(localdb)\\ProjectModels";
            sqlStringBuilder.InitialCatalog = "InformCPI.Database";
}
        public void AddNewContactToDatabase(Contact newContact)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlStringBuilder.ConnectionString))
                {
                    connection.Open();

                    String sql = "INSERT INTO dbo.Contacts (Name, Email, Address, Phone) " + 
                                    $"VALUES ('{newContact.Name}', '{newContact.Email}', '{newContact.Address}', '{newContact.PhoneNum}')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Let's ask the db to execute the query
                        int rowsAdded = command.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            _logger.LogInformation("Successfully added rows to DB");
                        else
                            _logger.LogWarning("Rows were not added");
                    }

                    _logger.LogInformation($"Successfully connected to the database!");
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Failure while trying to connect to database: {ex.Message}");
                throw ex;
            }
        }
        public void UpdateExistingContact(Contact updatedContact)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlStringBuilder.ConnectionString))
                {
                    connection.Open();

                    String sql = $"UPDATE dbo.Contacts SET Name = '{updatedContact.Name}'," +
                                    $" Email = '{updatedContact.Email}'," +
                                    $" Address = '{updatedContact.Address}'," +
                                    $" Phone = '{updatedContact.PhoneNum}' WHERE Id = {updatedContact.Id}";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Let's ask the db to execute the query
                        int rowsAdded = command.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            _logger.LogInformation("Successfully updated DB entry");
                        else
                            _logger.LogWarning("Contact not updated");
                    }

                    _logger.LogInformation($"Successfully connected to the database!");
                }
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Failure while trying to connect to database: {ex.Message}");
            }
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> readList = new List<Contact>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlStringBuilder.ConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT *  FROM dbo.Contacts ORDER BY Name ASC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                readList.Add(new Contact(
                                        int.Parse(reader["Id"].ToString()),
                                        reader["Name"].ToString(),
                                        reader["Address"].ToString(),
                                        reader["Email"].ToString(),
                                        reader["Phone"].ToString()
                                    ));
                            }
                        }
                    }

                    _logger.LogInformation($"Successfully connected to the database!");
                }
                return readList;
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Failure while trying to connect to database: {ex.Message}");
                throw ex;
            }
        }

        public Contact GetContact(int id)
        {
            try
            {
                Contact foundContact = null;

                using (SqlConnection connection = new SqlConnection(sqlStringBuilder.ConnectionString))
                {
                    connection.Open();

                    String sql = $"SELECT *  FROM dbo.Contacts WHERE id = {id}";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                foundContact = new Contact(
                                        int.Parse(reader["Id"].ToString()),
                                        reader["Name"].ToString(),
                                        reader["Address"].ToString(),
                                        reader["Email"].ToString(),
                                        reader["PhoneNum"].ToString()
                                    );
                            }
                        }
                    }

                    _logger.LogInformation($"Successfully connected to the database!");
                }
                return foundContact;
            }
            catch (SqlException ex)
            {
                _logger.LogError($"Failure while trying to connect to database: {ex.Message}");
                throw ex;
            }
        }
    }
}
