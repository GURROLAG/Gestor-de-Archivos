using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Diagnostics;
using DataAccess.MySQL;

namespace DataAccess
{
    public class DocumentosInyeccionDao : ConnectionToMySQL
    {
        // Método para obtener archivos por CarpetaId
        public DataTable ObtenerArchivosPorCarpeta(int carpetaId)
        {
            using (var conn = GetMySqlConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM documentos_empleado_inyeccion WHERE CarpetaID = @CarpetaID";

                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@CarpetaID", carpetaId);

                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable archivosTable = new DataTable();
                            adapter.Fill(archivosTable);
                            return archivosTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener archivos por Carpeta: " + ex.Message);
                    return null;
                }
            }
        }




        // Método para actualizar un documento
        // Método para actualizar un documento
        public bool ActualizarDocumento(int documentoId, string nuevoNombreDocumento, byte[] nuevoDocumento, string nuevaRuta, string nuevaExtension)
        {
            string query = @"
    UPDATE documentos_empleado_inyeccion 
    SET NombreDocumento = @NuevoNombreDocumento 
    WHERE ID_Documento = @DocumentoId";

            using (var conn = GetMySqlConnection())
            {
                try
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DocumentoId", documentoId);
                        command.Parameters.AddWithValue("@NuevoNombreDocumento", nuevoNombreDocumento);

                        // Solo se actualiza el nombre, no la ruta ni la extensión
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar el documento: " + ex.Message);
                    return false;
                }
            }
        }


        // Método para eliminar un documento
        public bool EliminarDocumento(int documentoId)
        {
            string query = "DELETE FROM documentos_empleado_inyeccion WHERE ID_Documento = @DocumentoId";

            using (var conn = GetMySqlConnection())
            {
                try
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DocumentoId", documentoId);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el documento: " + ex.Message);
                    return false;
                }
            }
        }

        // Método para agregar un documento
        public int AgregarDocumento(int carpetaId, int empleadoId, string nombreDocumento, byte[] documento, string extension)
        {
            string query = @"
            INSERT INTO documentos_empleado_inyeccion (CarpetaID, EmpleadoID, NombreDocumento, Documento, ExtensionDocumento) 
            VALUES (@CarpetaID, @EmpleadoID, @NombreDocumento, @Documento, @ExtensionDocumento); 
            SELECT LAST_INSERT_ID();";

            using (var conn = GetMySqlConnection())
            {
                try
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@CarpetaID", carpetaId);
                        command.Parameters.AddWithValue("@EmpleadoID", empleadoId);
                        command.Parameters.AddWithValue("@NombreDocumento", nombreDocumento);
                        command.Parameters.AddWithValue("@Documento", documento);
                        command.Parameters.AddWithValue("@ExtensionDocumento", extension);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al agregar documento: " + ex.Message);
                    return -1;
                }
            }
        }
        // Método para obtener el contenido y extensión de un documento por su ID
        public (byte[] contenidoDocumento, string extension) ObtenerContenidoDocumentoPL(int documentoId)
        {
            string query = "SELECT Documento, ExtensionDocumento FROM documentos_empleado_inyeccion WHERE ID_Documento = @DocumentoId";

            using (var conn = GetMySqlConnection())
            {
                try
                {
                    conn.Open();
                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DocumentoId", documentoId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] contenidoDocumento = (byte[])reader["Documento"];
                                string extension = reader["ExtensionDocumento"].ToString();
                                return (contenidoDocumento, extension);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el contenido del documento: " + ex.Message);
                }
            }

            // En caso de error o si no se encuentra el documento, retornar valores nulos
            return (null, null);
        }
        public byte[] ObtenerDocumentoPorId(int documentoId)
        {
            using (var conn = GetMySqlConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Documento FROM documentos_empleado_inyeccion WHERE ID_Documento = @DocumentoId";

                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@DocumentoId", documentoId);

                        var resultado = command.ExecuteScalar();
                        return resultado != DBNull.Value ? (byte[])resultado : null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener el contenido del documento: " + ex.Message);
                    return null;
                }
            }
        }


    }

}
