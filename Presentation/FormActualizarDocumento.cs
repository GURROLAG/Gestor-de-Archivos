using System;
using System.Windows.Forms;
using DataAccess;

namespace Presentation
{
    public partial class FormActualizarDocumento : Form
    {
        private readonly int documentoId;  // ID del documento
        private readonly string nombreDocumentoActual;  // Nombre actual del documento
        private readonly Action actualizarDataGridView;  // Delegado para actualizar el DataGridView

        // Constructor que recibe la acción para actualizar el DataGridView
        public FormActualizarDocumento(int documentoId, string nombreDocumento, Action actualizarDataGridView)
        {
            InitializeComponent();
            this.documentoId = documentoId;
            this.nombreDocumentoActual = nombreDocumento;
            this.actualizarDataGridView = actualizarDataGridView;  // Asignar el delegado
        }

        private void FormActualizarDocumento_Load(object sender, EventArgs e)
        {
            txtNombreDocumento.Text = nombreDocumentoActual; // El TextBox donde editar el nombre
        }

        // Al hacer clic en el botón "Guardar"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNombreDocumento.Text.Trim();

            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("El nombre del documento no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Llamar al método de actualización en el DAO para actualizar solo el nombre
                DocumentosInyeccionDao documentosDao = new DocumentosInyeccionDao();
                bool exito = documentosDao.ActualizarDocumento(documentoId, nuevoNombre, null, null, null); // No se pasa ruta ni extensión

                if (exito)
                {
                    MessageBox.Show("Documento actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario después de actualizar

                    // Actualizar el DataGridView en el formulario principal
                    actualizarDataGridView(); // Llamar al delegado
                }
                else
                {
                    MessageBox.Show("Error al actualizar el documento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar actualizar el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
