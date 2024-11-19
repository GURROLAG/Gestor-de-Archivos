using DataAccess.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DataAccess
{
    public class CarpetasInyeccionDao : ConnectionToMySQL
    {
        // Método para crear una carpeta específica para un empleado
        public void CrearCarpeta(int empleadoId, string nombreCarpeta)
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "INSERT INTO carpetas_empleado_inyeccion (EmpleadoID, NombreCarpeta, FechaCreacion) " +
                               "VALUES (@empleadoId, @nombreCarpeta, @fechaCreacion)";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@empleadoId", empleadoId);
                    command.Parameters.AddWithValue("@nombreCarpeta", nombreCarpeta);
                    command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para verificar si una carpeta existe
        public bool CarpetaExiste(int empleadoId, string nombreCarpeta)
        {
            string query = "SELECT COUNT(*) FROM carpetas_empleado_inyeccion WHERE EmpleadoID = @empleadoId AND NombreCarpeta = @nombreCarpeta";

            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@empleadoId", empleadoId);
                    command.Parameters.AddWithValue("@nombreCarpeta", nombreCarpeta);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;  // Si el valor es mayor a 0, la carpeta ya existe
                }
            }
        }

        // Método para verificar y crear carpetas predeterminadas para un empleado
        public void VerificarYCrearCarpetasParaEmpleado(int empleadoId, string nombreCompletoEmpleado)
        {
            // Lista de nombres de las carpetas predeterminadas
            var carpetasPredeterminadas = new[]
            {
                new { Nombre = "Documentos del Empleado" },
                new { Nombre = "Exámenes" },
                new { Nombre = "Capacitaciones" },
                new { Nombre = "Certificaciones" },
                new { Nombre = "Documentos Personales" }
            };

            // Verificar y crear cada carpeta si no existe
            foreach (var carpeta in carpetasPredeterminadas)
            {
                if (!CarpetaExiste(empleadoId, carpeta.Nombre))
                {
                    CrearCarpeta(empleadoId, carpeta.Nombre);
                }
            }
        }

        // Método para obtener las carpetas de un empleado
        public DataTable ObtenerCarpetasPorEmpleado(int empleadoId)
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "SELECT * FROM carpetas_empleado_inyeccion WHERE EmpleadoID = @empleadoId";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@empleadoId", empleadoId);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        DataTable carpetasTable = new DataTable();
                        adapter.Fill(carpetasTable);
                        return carpetasTable;
                    }
                }
            }
        }

        // Método para crear carpetas para empleados existentes
        public void CrearCarpetasParaEmpleadosExistentes()
        {
            string query = "SELECT EmpleadoId, CONCAT(Nombres, ' ', ApellidoPaterno, ' ', ApellidoMaterno) AS NombreCompleto FROM empleados_inyeccion";

            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                using (var command = new MySqlCommand(query, conn))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int empleadoId = reader.GetInt32("EmpleadoId");
                        string nombreCompleto = reader.GetString("NombreCompleto");

                        VerificarYCrearCarpetasParaEmpleado(empleadoId, nombreCompleto);
                    }
                }
            }
        }

        // Método para eliminar una carpeta por su ID
        public void EliminarCarpeta(int carpetaId)
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "DELETE FROM carpetas_empleado_inyeccion WHERE CarpetaID = @carpetaId";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@carpetaId", carpetaId);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Método para editar el nombre de una carpeta
        public void EditarCarpeta(int carpetaId, string nuevoNombreCarpeta)
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "UPDATE carpetas_empleado_inyeccion SET NombreCarpeta = @nuevoNombreCarpeta " +
                               "WHERE CarpetaID = @carpetaId";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@nuevoNombreCarpeta", nuevoNombreCarpeta);
                    command.Parameters.AddWithValue("@carpetaId", carpetaId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
