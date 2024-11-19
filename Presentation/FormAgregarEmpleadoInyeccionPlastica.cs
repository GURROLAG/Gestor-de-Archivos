using System;
using System.Data;
using System.Windows.Forms;
using DataAccess;
using DataAccess.MySQL; // Asegúrate de que esta referencia esté incluida

namespace Presentation
{
    public partial class FormAgregarEmpleadoInyeccionPlastica : Form
    {
        public FormAgregarEmpleadoInyeccionPlastica()
        {
            InitializeComponent();
        }

        // Método para manejar el clic del botón Agregar
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario desde los campos de texto
                string nombres = txtNombres.Text.Trim();
                string apellidoPaterno = txtApellidoPaterno.Text.Trim();
                string apellidoMaterno = txtApellidoMaterno.Text.Trim();
                string numeroNomina = txtNumeroNomina.Text.Trim();
                string puesto = txtPuesto.Text.Trim();
                string area = cboArea.SelectedItem.ToString(); // Si usas un ComboBox para el área

                // Validación de campos
                if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(apellidoPaterno) || string.IsNullOrEmpty(numeroNomina) ||
                    string.IsNullOrEmpty(puesto) || string.IsNullOrEmpty(area))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear una instancia de la clase EmpleadosInyeccionDao
                EmpleadosInyeccionDao dao = new EmpleadosInyeccionDao();

                // Llamar al método AgregarEmpleado de la clase Dao
                int empleadoId = dao.AgregarEmpleado(nombres, apellidoPaterno, apellidoMaterno, numeroNomina, puesto, area);

                // Verificar si el empleado fue agregado correctamente
                if (empleadoId > 0)
                {
                    // Llamar al método para crear las carpetas del empleado
                    CarpetasInyeccionDao carpetasDao = new CarpetasInyeccionDao();
                    carpetasDao.VerificarYCrearCarpetasParaEmpleado(empleadoId, $"{nombres} {apellidoPaterno} {apellidoMaterno}");

                    MessageBox.Show("Empleado agregado con éxito. ID: " + empleadoId, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); // Limpiar los campos después de agregar el empleado
                    this.Close(); // Cerrar el formulario después de agregar el empleado
                }
                else
                {
                    MessageBox.Show("Hubo un error al agregar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos después de agregar un empleado
        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtNumeroNomina.Clear();
            txtPuesto.Clear();
            cboArea.SelectedIndex = -1; // Si usas un ComboBox para seleccionar el área
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario si el usuario decide cancelar
        }

        private void FormAgregarEmpleadoInyeccionPlastica_Load(object sender, EventArgs e)
        {
            CargarAreas(); // Cargar las áreas al iniciar el formulario
        }

        // Método para cargar las áreas en el ComboBox
        private void CargarAreas()
        {
            try
            {
                // Crear una lista de áreas locales
                var areas = new[] { "Administrativo", "Almacen", "Choferes", "Ensamble", "Inyeccion Automatica", "Inyeccion Manual", "Mantenimiento" };

                // Limpiar cualquier ítem previo en el ComboBox
                cboArea.Items.Clear();

                // Agregar las áreas locales al ComboBox
                cboArea.Items.AddRange(areas);

                // Seleccionar el primer ítem por defecto (si es necesario)
                cboArea.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las áreas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
