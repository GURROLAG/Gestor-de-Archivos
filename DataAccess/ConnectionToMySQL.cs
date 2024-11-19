using MySql.Data.MySqlClient;

namespace DataAccess.MySQL
{
    public class ConnectionToMySQL
    {
        private readonly string connectionString;

        public ConnectionToMySQL()
        {
            // Cadena de conexión a la base de datos MySQL
            connectionString = "Server=127.0.0.1;Database=sistema;User ID=root;Password=;SslMode=none;";
        }

        // Método público para obtener la conexión a MySQL
        public MySqlConnection GetMySqlConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
