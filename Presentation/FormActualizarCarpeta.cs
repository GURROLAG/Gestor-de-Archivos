using System;
using System.Windows.Forms;
using DataAccess;

namespace Presentation
{
    public partial class FormActualizarCarpeta : Form
    {
        private int carpetaId;

        // Constructor que recibe el ID de la carpeta y su nombre actual
        public FormActualizarCarpeta(int carpetaId, string nombreActual)
        {
            InitializeComponent();
            this.carpetaId = carpetaId;

            // Mostrar el nombre actual en el TextBox al abrir el formulario
            txtNombreCarpeta.Text = nombreActual;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que el campo de texto no esté vacío
            string nuevoNombreCarpeta = txtNombreCarpeta.Text.Trim();
            if (string.IsNullOrEmpty(nuevoNombreCarpeta))
            {
                MessageBox.Show("Ingrese un nuevo nombre para la carpeta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CarpetasInyeccionDao carpetasDao = new CarpetasInyeccionDao();
                carpetasDao.EditarCarpeta(carpetaId, nuevoNombreCarpeta);

                MessageBox.Show("Carpeta actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la carpeta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
