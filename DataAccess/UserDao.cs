using Common.Cache;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DataAccess.MySQL
{
    public class UserDao : ConnectionToMySQL
    {
        public void CreateUser(string username, string password, string planta, string rol)
        {
            using (var conn = new ConnectionToMySQL().GetMySqlConnection())
            {
                conn.Open();
                string query = "INSERT INTO Usuarios (NombreUsuario, Password, Rol, Planta) VALUES (@username, @password, @rol, @planta)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@rol", rol); // Asignar rol directamente
                    command.Parameters.AddWithValue("@planta", planta);

                    command.ExecuteNonQuery(); // Ejecutar la inserción
                }
            }
        }



        // Obtener todos los usuarios
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string query = "SELECT UsuarioID, NombreUsuario, Password, Rol, Planta FROM usuarios";

            using (var connection = new ConnectionToMySQL().GetMySqlConnection())
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            UsuarioID = reader.GetInt32("UsuarioID"),
                            NombreUsuario = reader.GetString("NombreUsuario"),
                            Password = reader.GetString("Password"),
                            Rol = reader.GetString("Rol"),
                            Planta = reader.GetString("Planta") // Asegúrate de que este campo esté presente
                        });
                    }
                }
            }
            return users;
        }

        // Agregar un nuevo usuario
        public void AddUser(User user)
        {
            string query = "INSERT INTO usuarios (NombreUsuario, Password, Rol, Planta) VALUES (@NombreUsuario, @Password, @Rol, @Planta)";

            using (var connection = new ConnectionToMySQL().GetMySqlConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", user.NombreUsuario);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Rol", user.Rol);
                    command.Parameters.AddWithValue("@Planta", user.Planta); // Usa el campo Planta
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User user)
        {
            string query = "UPDATE usuarios SET NombreUsuario = @NombreUsuario, Password = @Password, Rol = @Rol, Planta = @Planta WHERE UsuarioID = @UsuarioID";

            using (var connection = new ConnectionToMySQL().GetMySqlConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", user.UsuarioID); // Asegúrate de incluir el UsuarioID
                    command.Parameters.AddWithValue("@NombreUsuario", user.NombreUsuario);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Rol", user.Rol);
                    command.Parameters.AddWithValue("@Planta", user.Planta);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Eliminar usuario
        public void DeleteUser(int usuarioID)
        {
            string query = "DELETE FROM usuarios WHERE UsuarioID = @UsuarioID";

            using (var connection = new ConnectionToMySQL().GetMySqlConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", usuarioID);
                    command.ExecuteNonQuery();
                }
            }
        }
        // Obtener lista de roles de la tabla de usuarios
        public List<string> GetAllRoles()
        {
            List<string> roles = new List<string>();
            string query = "SELECT DISTINCT Rol FROM usuarios"; // Obtener roles únicos

            using (var connection = new ConnectionToMySQL().GetMySqlConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader.GetString("Rol"));
                        }
                    }
                }
            }

            return roles;
        }
        public List<string> GetAllPlantas()
        {
            List<string> plantas = new List<string>();
            string query = "SELECT DISTINCT Planta FROM usuarios"; // Obtener plantas únicas

            using (var connection = new ConnectionToMySQL().GetMySqlConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plantas.Add(reader.GetString("Planta"));
                        }
                    }
                }
            }

            return plantas;
        }
    }
}
