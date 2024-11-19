using System;
using System.IO;
using System.Windows.Forms;
using Common.Cache;
using DataAccess;
using DataAccess.MySQL;

namespace Presentation
{
    public partial class FormSubirDocumento : Form
    {
        private int carpetaId; // ID de la carpeta a la que se subirá el documento
        private CarpetaDao carpetaDao; // Instancia de CarpetaDao para manejar operaciones
        private RegistroActividadesDao registroActividadesDao; // Instancia de RegistroActividadesDao

        public FormSubirDocumento(int carpetaId)
        {
            InitializeComponent();
            this.carpetaId = carpetaId;
            carpetaDao = new CarpetaDao(); // Asegúrate de que esta clase esté correctamente implementada
            registroActividadesDao = new RegistroActividadesDao(); // Inicializa la instancia
        }

        // Evento para seleccionar archivo
        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar Documento",
                Filter = "Archivos PDF|*.pdf|Archivos de Imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = openFileDialog.FileName; // Muestra la ruta del archivo en el TextBox
            }
        }

        // Evento para subir archivo
        private void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = txtRutaArchivo.Text;

                // Validación del archivo seleccionado
                if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                {
                    MessageBox.Show("Por favor, selecciona un archivo válido.");
                    return;
                }

                string nombreDocumento = Path.GetFileName(filePath); // Obtener solo el nombre del archivo
                byte[] contenido;

                try
                {
                    contenido = File.ReadAllBytes(filePath); // Leer el contenido del archivo
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tipoDocumento = Path.GetExtension(filePath).TrimStart('.'); // Obtener tipo sin el punto
                DateTime fechaSubida = DateTime.Now; // Fecha actual

                // Subir el documento
                bool success = carpetaDao.SubirDocumento(carpetaId, nombreDocumento, fechaSubida, contenido, tipoDocumento);

                if (success)
                {
                    // Registro de la actividad
                    var actividad = new RegistroActividad
                    {
                        UsuarioID = registroActividadesDao.ObtenerUsuarioActualId(), // Obtiene el ID del usuario actual
                        DocumentoID = null, // Asigna el ID del documento si está disponible
                        Actividad = "Subida de documento",
                        FechaHora = DateTime.Now,
                        DetallesActividad = $"Documento '{nombreDocumento}' subido a la carpeta ID: {carpetaId}"
                    };
                    registroActividadesDao.AddActividad(actividad); // Agrega la actividad al registro

                    MessageBox.Show("Archivo subido exitosamente.");
                    this.Close(); // Cierra el formulario después de la subida exitosa
                }
                else
                {
                    MessageBox.Show("Error al subir el archivo. Intenta nuevamente.");
                }
            }
            catch (Exception ex)
            {
                // Mostrar error si ocurre alguna excepción inesperada
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para cancelar la operación
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario sin realizar cambios
        }
    }
}
