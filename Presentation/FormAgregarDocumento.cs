using System;
using System.IO;
using System.Windows.Forms;
using DataAccess;

namespace Presentation
{
    public partial class FormAgregarDocumento : Form
    {
        private int empleadoId;
        private int carpetaId;
        private string archivoSeleccionado;  // Variable para almacenar el archivo seleccionado

        // Constructor que recibe el ID del empleado y el ID de la carpeta
        public FormAgregarDocumento(int empleadoId, int carpetaId)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;
            this.carpetaId = carpetaId;
        }

        // Evento para seleccionar el archivo
        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos|*.pdf;*.jpg;*.png;*.docx;*.txt"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                archivoSeleccionado = openFileDialog.FileName;  // Guardar la ruta del archivo
                txtNombreDocumento.Text = Path.GetFileName(archivoSeleccionado);  // Mostrar solo el nombre
            }
        }

        // Evento para subir el archivo
        private void btnSubir_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un archivo y que el nombre no esté vacío
            if (string.IsNullOrEmpty(txtNombreDocumento.Text) || string.IsNullOrEmpty(archivoSeleccionado))
            {
                MessageBox.Show("Por favor, seleccione un archivo antes de subirlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Leer el archivo seleccionado como un array de bytes
                byte[] documento = File.ReadAllBytes(archivoSeleccionado);
                string extension = Path.GetExtension(archivoSeleccionado);

                // Crear una instancia de la clase que maneja los documentos
                DocumentosInyeccionDao documentosDao = new DocumentosInyeccionDao();

                // Almacenar el documento en la base de datos como BLOB
                int documentoId = documentosDao.AgregarDocumento(carpetaId, empleadoId, txtNombreDocumento.Text, documento, extension);

                if (documentoId > 0)
                {
                    MessageBox.Show("Documento subido exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al subir el documento. Por favor, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al subir el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para cancelar la acción y cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
