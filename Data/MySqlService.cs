using MySqlConnector;
using System.Data;

namespace Inscription.Data
{
    public class MySqlService
    {
        private readonly string _connectionString;

        public MySqlService()
        {
            _connectionString = "server=localhost;database=Inscription;user=chris;password=Chriskely@123;";
        }

        public async Task<DataTable> GetDataAsync()
        {
            await using var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();

            var command = new MySqlCommand("SELECT * FROM votre_table", connection);
            var reader = await command.ExecuteReaderAsync();

            var table = new DataTable();
            table.Load(reader);
            return table;
        }
    }
}
