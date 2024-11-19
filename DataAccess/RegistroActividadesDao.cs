using Common.Cache;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess.MySQL
{
    public class RegistroActividadesDao : ConnectionToMySQL
    {
        public void AddActividad(RegistroActividad actividad)
        {
            if (actividad.UsuarioID <= 0)
            {
                Console.WriteLine("No hay usuario autenticado, no se puede registrar la actividad.");
                return;
            }
            if (actividad.FechaHora == DateTime.MinValue) actividad.FechaHora = DateTime.Now;

            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string checkUserQuery = "SELECT COUNT(*) FROM usuarios WHERE UsuarioID = @UsuarioID";
                using (var checkUserCommand = new MySqlCommand(checkUserQuery, conn))
                {
                    checkUserCommand.Parameters.AddWithValue("@UsuarioID", actividad.UsuarioID);
                    int userCount = Convert.ToInt32(checkUserCommand.ExecuteScalar());
                    if (userCount == 0) return;
                }
                string query = "INSERT INTO RegistroActividades (UsuarioID, DocumentoID, Actividad, FechaHora, DetallesActividad) VALUES (@UsuarioID, @DocumentoID, @Actividad, @FechaHora, @DetallesActividad)";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UsuarioID", actividad.UsuarioID);
                    command.Parameters.AddWithValue("@DocumentoID", actividad.DocumentoID);
                    command.Parameters.AddWithValue("@Actividad", actividad.Actividad);
                    command.Parameters.AddWithValue("@FechaHora", actividad.FechaHora);
                    command.Parameters.AddWithValue("@DetallesActividad", actividad.DetallesActividad);
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<RegistroActividad> ObtenerActividades()
        {
            List<RegistroActividad> actividades = new List<RegistroActividad>();
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = @"
                SELECT ra.*, u.NombreUsuario 
                FROM RegistroActividades ra 
                JOIN usuarios u ON ra.UsuarioID = u.UsuarioID"; // Unir las tablas

                using (var command = new MySqlCommand(query, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RegistroActividad actividad = new RegistroActividad
                            {
                                ActividadID = reader.GetInt32("ActividadID"),
                                UsuarioID = reader.GetInt32("UsuarioID"),
                                DocumentoID = reader.IsDBNull("DocumentoID") ? (int?)null : reader.GetInt32("DocumentoID"),
                                Actividad = reader.GetString("Actividad"),
                                FechaHora = reader.GetDateTime("FechaHora"),
                                DetallesActividad = reader.GetString("DetallesActividad"),
                                NombreUsuario = reader.GetString("NombreUsuario") // Asegúrate de que esta propiedad exista en RegistroActividad
                            };
                            actividades.Add(actividad);
                        }
                    }
                }
            }
            return actividades;
        }

        public List<RegistroActividad> ObtenerActividadesPorFecha(DateTime desde, DateTime hasta)
        {
            List<RegistroActividad> actividades = new List<RegistroActividad>();
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = @"
            SELECT ra.*, u.NombreUsuario 
            FROM RegistroActividades ra 
            JOIN usuarios u ON ra.UsuarioID = u.UsuarioID 
            WHERE ra.FechaHora BETWEEN @Desde AND @Hasta
            ORDER BY ra.FechaHora DESC"; // Filtra por fecha

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Desde", desde);
                    command.Parameters.AddWithValue("@Hasta", hasta);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RegistroActividad actividad = new RegistroActividad
                            {
                                ActividadID = reader.GetInt32("ActividadID"),
                                UsuarioID = reader.GetInt32("UsuarioID"),
                                DocumentoID = reader.IsDBNull("DocumentoID") ? (int?)null : reader.GetInt32("DocumentoID"),
                                Actividad = reader.GetString("Actividad"),
                                FechaHora = reader.GetDateTime("FechaHora"),
                                DetallesActividad = reader.GetString("DetallesActividad"),
                                NombreUsuario = reader.GetString("NombreUsuario")
                            };
                            actividades.Add(actividad);
                        }
                    }
                }
            }
            return actividades;
        }


        // Método para obtener el ID del usuario actual
        public int ObtenerUsuarioActualId()
        {
            if (UserCache.CurrentUser != null)
            {
                return UserCache.CurrentUser.UsuarioID; // Devuelve el ID del usuario actual
            }
            else
            {
                Console.WriteLine("No hay un usuario autenticado."); // Debug
                return -1; // O algún valor que indique que no se pudo obtener el ID
            }
        }
    }
}
