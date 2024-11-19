using DataAccess.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

public class EmpleadosInyeccionDao : ConnectionToMySQL
{
    // Método para obtener todos los empleados de Inyección Plásticos
    public DataTable ObtenerEmpleados()
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM empleados_inyeccion ORDER BY Nombres ASC";

            using (var command = new MySqlCommand(query, conn))
            using (var adapter = new MySqlDataAdapter(command))
            {
                DataTable empleadosTable = new DataTable();
                adapter.Fill(empleadosTable);
                return empleadosTable;
            }
        }
    }
    public string ObtenerRutaDocumento(int documentoId)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT Ruta FROM documentos_empleado_inyeccion WHERE ID_Documento = @DocumentoID";  // Filtrar por DocumentoID

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@DocumentoID", documentoId);
                return command.ExecuteScalar()?.ToString();  // Devolver la ruta si existe
            }
        }
    }

    // Método para agregar un nuevo empleado
    public int AgregarEmpleado(string nombres, string apellidoPaterno, string apellidoMaterno, string numeroNomina, string puesto, string area)
    {
        int empleadoId;
        string query = "INSERT INTO empleados_inyeccion (Nombres, ApellidoPaterno, ApellidoMaterno, NumeroNomina, Puesto, Area) " +
                       "VALUES (@nombres, @apellidoPaterno, @apellidoMaterno, @numeroNomina, @puesto, @area); SELECT LAST_INSERT_ID();";

        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@nombres", nombres);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@numeroNomina", numeroNomina);
                command.Parameters.AddWithValue("@puesto", puesto);
                command.Parameters.AddWithValue("@area", area);

                empleadoId = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        return empleadoId;
    }

    // Método para obtener empleados por área
    public DataTable ObtenerEmpleadosPorArea(string area)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM empleados_inyeccion WHERE Area = @area ORDER BY Nombres ASC";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@area", area);

                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable empleadosTable = new DataTable();
                    adapter.Fill(empleadosTable);
                    return empleadosTable;
                }
            }
        }
    }

    // Método para actualizar la información de un empleado
    public bool ActualizarEmpleado(int empleadoId, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroNomina, string puesto, string area)
    {
        string query = "UPDATE empleados_inyeccion SET Nombres = @nombres, ApellidoPaterno = @apellidoPaterno, ApellidoMaterno = @apellidoMaterno, " +
                       "NumeroNomina = @numeroNomina, Puesto = @puesto, Area = @area WHERE EmpleadoId = @empleadoId";

        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@nombres", nombres);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@numeroNomina", numeroNomina);
                command.Parameters.AddWithValue("@puesto", puesto);
                command.Parameters.AddWithValue("@area", area);
                command.Parameters.AddWithValue("@empleadoId", empleadoId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Método para eliminar un empleado
    public bool EliminarEmpleado(int empleadoId)
    {
        string query = "DELETE FROM empleados_inyeccion WHERE EmpleadoId = @empleadoId";

        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@empleadoId", empleadoId);
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Método para buscar un empleado por su ID
    public DataTable ObtenerEmpleadoPorId(int empleadoId)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM empleados_inyeccion WHERE EmpleadoId = @empleadoId";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@empleadoId", empleadoId);

                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable empleadoTable = new DataTable();
                    adapter.Fill(empleadoTable);
                    return empleadoTable;
                }
            }
        }
    }

}
