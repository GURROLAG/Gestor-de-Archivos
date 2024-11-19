using DataAccess.MySQL;
using MySql.Data.MySqlClient;

namespace Domain
{
    public class UserModel
    {
        private readonly ConnectionToMySQL connection;

        public UserModel()
        {
            connection = new ConnectionToMySQL();
        }

        // Método para logear al usuario
        public bool LoginUser(string username, string password)
        {
            using (var conn = connection.GetMySqlConnection())
            {
                conn.Open();
                string query = "SELECT Password FROM Usuarios WHERE NombreUsuario = @username";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string storedPassword = result.ToString();
                        return password == storedPassword;
                    }
                }
            }
            return false;
        }

        // Método para obtener el rol del usuario
        public string GetRolPorUsuario(string username)
        {
            using (var conn = connection.GetMySqlConnection())
            {
                conn.Open();
                string query = "SELECT Rol FROM Usuarios WHERE NombreUsuario = @username";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var result = command.ExecuteScalar();

                    return result?.ToString(); // Retorna el rol o null si no se encuentra
                }
            }
        }

        // Método para obtener la planta del usuario
        public string GetPlantaPorUsuario(string username)
        {
            using (var conn = connection.GetMySqlConnection())
            {
                conn.Open();
                string query = "SELECT Planta FROM Usuarios WHERE NombreUsuario = @username";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var result = command.ExecuteScalar();

                    return result?.ToString(); // Retorna la planta o null si no se encuentra
                }
            }
        }

        // Método para obtener el ID del usuario
        public int GetUsuarioID(string username)
        {
            using (var conn = connection.GetMySqlConnection())
            {
                conn.Open();
                string query = "SELECT UsuarioID FROM Usuarios WHERE NombreUsuario = @username";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    var result = command.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0; // Retorna el ID o 0 si no se encuentra
                }
            }
        }
    }
}
