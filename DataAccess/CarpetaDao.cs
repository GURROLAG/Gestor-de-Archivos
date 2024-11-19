using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using DataAccess.MySQL;

public class CarpetaDao
{
    // Método para crear una carpeta en la base de datos
    public bool CrearCarpeta(int empleadoId, string nombreCarpeta, string tipoCarpeta)
    {
        using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
        {
            conn.Open();
            string query = "INSERT INTO carpetas_empleado (EmpleadoID, NombreCarpeta, TipoCarpeta, FechaCreacion) VALUES (@EmpleadoID, @NombreCarpeta, @TipoCarpeta, NOW())";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                command.Parameters.AddWithValue("@NombreCarpeta", nombreCarpeta);
                command.Parameters.AddWithValue("@TipoCarpeta", tipoCarpeta);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
   
    // Método para eliminar una carpeta específica
    public bool EliminarCarpeta(int carpetaId)
    {
        using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
        {
            conn.Open();
            string query = "DELETE FROM carpetas_empleado WHERE CarpetaID = @CarpetaID";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@CarpetaID", carpetaId);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

    // Método para editar el nombre de una carpeta
    public bool EditarCarpeta(int carpetaId, string nuevoNombre)
    {
        using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
        {
            conn.Open();
            string query = "UPDATE carpetas_empleado SET NombreCarpeta = @NuevoNombre WHERE CarpetaID = @CarpetaID";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@CarpetaID", carpetaId);
                command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

    // Método para obtener todas las carpetas de un empleado
    public DataTable ObtenerCarpetasPorEmpleado(int empleadoId)
    {
        using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM carpetas_empleado WHERE EmpleadoID = @EmpleadoID";
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }

    // Método para obtener el ID de una carpeta específica por nombre y empleado
    public int ObtenerCarpetaIdPorNombre(int empleadoId, string nombreCarpeta)
    {
        using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT CarpetaID FROM carpetas_empleado WHERE EmpleadoID = @EmpleadoID AND NombreCarpeta = @NombreCarpeta";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                command.Parameters.AddWithValue("@NombreCarpeta", nombreCarpeta);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }

    // Método para subir un documento a una carpeta específica
    public bool SubirDocumento(int carpetaId, string nombreDocumento, DateTime fechaSubida, byte[] contenido, string tipoDocumento)
    {
        using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
        {
            conn.Open();
            string query = @"
                INSERT INTO documentos_empleado (CarpetaID, NombreDocumento, FechaSubida, Documento, TipoDocumento, ExtensionDocumento, Contenido) 
                VALUES (@CarpetaID, @NombreDocumento, @FechaSubida, @Documento, @TipoDocumento, @ExtensionDocumento, @Contenido)";
            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@CarpetaID", carpetaId);
                command.Parameters.AddWithValue("@NombreDocumento", nombreDocumento);
                command.Parameters.AddWithValue("@FechaSubida", fechaSubida);
                command.Parameters.AddWithValue("@Documento", contenido);
                command.Parameters.AddWithValue("@TipoDocumento", tipoDocumento);
                command.Parameters.AddWithValue("@ExtensionDocumento", Path.GetExtension(nombreDocumento).TrimStart('.'));
                command.Parameters.AddWithValue("@Contenido", contenido);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }

    // Método para obtener las carpetas de un empleado para visualización (ID y nombre)
   public DataTable ObtenerCarpetas(int empleadoId)
{
    using (MySqlConnection conn = new ConnectionToMySQL().GetMySqlConnection())
    {
        conn.Open();
        string query = "SELECT CarpetaID, NombreCarpeta FROM carpetas_empleado WHERE EmpleadoID = @EmpleadoID";
        using (var adapter = new MySqlDataAdapter(query, conn))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@EmpleadoID", empleadoId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            // Agregar depuración para verificar filas
            Console.WriteLine($"Número de carpetas encontradas: {dt.Rows.Count}");
            
            return dt;
        }
    }
}
}
