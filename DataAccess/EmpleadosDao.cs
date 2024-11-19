using DataAccess.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Data;

public class EmpleadosDao : ConnectionToMySQL
{
    // Método existente para obtener todos los empleados
    public DataTable ObtenerEmpleados()
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Empleados ORDER BY Nombres ASC";  // Ordenar por nombre

            using (var command = new MySqlCommand(query, conn))
            {
                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable empleadosTable = new DataTable();
                    adapter.Fill(empleadosTable);  // Llenar el DataTable con los datos obtenidos
                    return empleadosTable;         // Devolver la tabla de empleados
                }
            }
        }
    }

    // Método para obtener empleados por área
    public DataTable ObtenerEmpleadosPorArea(string area)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Empleados WHERE Area = @Area ORDER BY Nombres ASC"; // Filtrar por área y ordenar por nombre

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@Area", area); // Agregar parámetro para el área
                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable empleadosTable = new DataTable();
                    adapter.Fill(empleadosTable);  // Llenar el DataTable con los datos obtenidos
                    return empleadosTable;         // Devolver la tabla de empleados
                }
            }
        }
    }

    public int AgregarEmpleado(string nombreEmpleado, string apellidoPaterno, string apellidoMaterno, string numeroNomina, string puesto, string area)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "INSERT INTO Empleados (Nombres, ApellidoPaterno, ApellidoMaterno, NumeroNomina, Puesto, Area) " +
                           "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @numeroNomina, @puesto, @area); SELECT LAST_INSERT_ID();";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@nombre", nombreEmpleado);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@numeroNomina", numeroNomina);
                command.Parameters.AddWithValue("@puesto", puesto);
                command.Parameters.AddWithValue("@area", area);

                // Ejecutar el comando y devolver el ID del nuevo empleado
                int empleadoId = Convert.ToInt32(command.ExecuteScalar());

                // Puedes crear las subcarpetas para el nuevo empleado si lo deseas
                VerificarYCrearCarpetasParaEmpleado(empleadoId, $"{nombreEmpleado} {apellidoPaterno} {apellidoMaterno}");

                return empleadoId;
            }
        }
    }

    // Método para crear una carpeta
    private void CrearCarpeta(int empleadoId, string nombreCarpeta, string tipoCarpeta)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "INSERT INTO carpetas_empleado (EmpleadoID, NombreCarpeta, TipoCarpeta, FechaCreacion) VALUES (@empleadoId, @nombreCarpeta, @tipoCarpeta, @fechaCreacion)";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@empleadoId", empleadoId);
                command.Parameters.AddWithValue("@nombreCarpeta", nombreCarpeta);
                command.Parameters.AddWithValue("@tipoCarpeta", tipoCarpeta);
                command.Parameters.AddWithValue("@fechaCreacion", DateTime.Now); // Establecer la fecha de creación

                // Asegúrate de que se ejecute correctamente
                int result = command.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new Exception("No se pudo crear la carpeta en la base de datos.");
                }
            }
        }
    }

    // Método para verificar y crear carpetas para un empleado existente
    public void VerificarYCrearCarpetasParaEmpleado(int empleadoId, string nombreCompletoEmpleado)
    {
        // Verificar y crear las subcarpetas
        if (!CarpetaExiste(empleadoId, "Exámenes"))
        {
            CrearCarpeta(empleadoId, "Exámenes", "Exámenes");
        }
        if (!CarpetaExiste(empleadoId, "Capacitaciones"))
        {
            CrearCarpeta(empleadoId, "Capacitaciones", "Capacitaciones");
        }
        if (!CarpetaExiste(empleadoId, "Certificaciones"))
        {
            CrearCarpeta(empleadoId, "Certificaciones", "Certificaciones");
        }
        if (!CarpetaExiste(empleadoId, "Documentos Personales"))
        {
            CrearCarpeta(empleadoId, "Documentos Personales", "Documentos Personales");
        }
    }

    // Método para verificar si una carpeta ya existe
    private bool CarpetaExiste(int empleadoId, string nombreCarpeta)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT COUNT(*) FROM carpetas_empleado WHERE EmpleadoID = @EmpleadoID AND NombreCarpeta = @NombreCarpeta";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                command.Parameters.AddWithValue("@NombreCarpeta", nombreCarpeta);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0; // Retorna verdadero si la carpeta ya existe
            }
        }
    }

    // Método para actualizar un empleado existente
    public void ActualizarEmpleado(int empleadoID, string nombreEmpleado, string apellidoPaterno, string apellidoMaterno, string numeroNomina, string puesto, string area)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "UPDATE Empleados SET Nombres = @nombre, ApellidoPaterno = @apellidoPaterno, ApellidoMaterno = @apellidoMaterno, NumeroNomina = @numeroNomina, Puesto = @puesto, Area = @area " +
                           "WHERE EmpleadoID = @empleadoID";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@nombre", nombreEmpleado);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                command.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                command.Parameters.AddWithValue("@numeroNomina", numeroNomina);
                command.Parameters.AddWithValue("@puesto", puesto);
                command.Parameters.AddWithValue("@area", area);
                command.Parameters.AddWithValue("@empleadoID", empleadoID);

                command.ExecuteNonQuery();  // Ejecutar la consulta de actualización
            }
        }
    }

    // Método para eliminar un empleado por su ID
    public void EliminarEmpleado(int empleadoID)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "DELETE FROM Empleados WHERE EmpleadoID = @empleadoID";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@empleadoID", empleadoID); // Parámetro para el ID del empleado

                command.ExecuteNonQuery();  // Ejecutar el comando
            }
        }
    }



    // Método para obtener documentos por CarpetaID
    public DataTable ObtenerDocumentosPorCarpeta(int carpetaId)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT * FROM documentos_empleado WHERE CarpetaID = @CarpetaID"; // Filtrar por carpeta

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@CarpetaID", carpetaId);

                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable documentosTable = new DataTable();
                    adapter.Fill(documentosTable);  // Llenar el DataTable con los datos obtenidos
                    return documentosTable;         // Devolver la tabla de documentos
                }
            }
        }
    }


    // Método para obtener la ruta de un documento
    public string ObtenerRutaDocumento(int documentoId)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT Ruta FROM documentos_empleado WHERE ID_Documento = @DocumentoID";  // Filtrar por DocumentoID

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@DocumentoID", documentoId);
                return command.ExecuteScalar()?.ToString();  // Devolver la ruta si existe
            }
        }
    }

    public bool EditarNombreDocumento(int documentoId, string nuevoNombre)
    {
        try
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "UPDATE documentos_empleado SET NombreDocumento = @NuevoNombre WHERE ID_Documento = @DocumentoID";
                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                    command.Parameters.AddWithValue("@DocumentoID", documentoId);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }



  
    // Método para eliminar un documento por su ID
    public void EliminarDocumento(int documentoId)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    // Primero, eliminar registros de registroactividades que referencian este documento
                    string deleteRegistroActividadesQuery = "DELETE FROM registroactividades WHERE DocumentoID = @DocumentoID";
                    using (var command = new MySqlCommand(deleteRegistroActividadesQuery, conn, transaction))
                    {
                        command.Parameters.AddWithValue("@DocumentoID", documentoId);
                        command.ExecuteNonQuery();
                    }

                    // Luego, eliminar el documento
                    string deleteDocumentoQuery = "DELETE FROM documentos_empleado WHERE ID_Documento = @DocumentoID";
                    using (var command = new MySqlCommand(deleteDocumentoQuery, conn, transaction))
                    {
                        command.Parameters.AddWithValue("@DocumentoID", documentoId);
                        command.ExecuteNonQuery();
                    }

                    // Confirmar la transacción
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaction.Rollback();
                    throw new Exception($"Error al eliminar el documento: {ex.Message}");
                }
            }
        }
    }


    public (byte[] contenido, string extension) ObtenerContenidoDocumento(int documentoId)
    {
        using (var conn = GetMySqlConnection())
        {
            conn.Open();
            string query = "SELECT Documento, ExtensionDocumento FROM documentos_empleado WHERE ID_Documento = @DocumentoID";

            using (var command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@DocumentoID", documentoId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] contenido = (byte[])reader["Documento"];
                        string extension = reader["ExtensionDocumento"].ToString();
                        return (contenido, extension);
                    }
                }
            }
        }
        return (null, null);
    }
   
}


