using System;
using System.Data;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormEditarEmpleadosPL : Form
    {
        private int empleadoId;

        // Constructor que recibe el EmpleadoId
        public FormEditarEmpleadosPL(int empleadoId)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;  // Guardamos el EmpleadoId en la variable
            CargarEmpleado(empleadoId);    // Cargamos los datos del empleado
        }

        // Método para cargar los datos del empleado
        public void CargarEmpleado(int empleadoId)
        {
            try
            {
                // Crear una instancia del DAO
                EmpleadosInyeccionDao dao = new EmpleadosInyeccionDao();

                // Obtener los datos del empleado desde la base de datos
                DataTable empleadoData = dao.ObtenerEmpleadoPorId(empleadoId);

                if (empleadoData.Rows.Count > 0)
                {
                    // Suponiendo que los nombres de las columnas coinciden con los nombres de los controles
                    DataRow row = empleadoData.Rows[0];

                    // Asignar los datos a los controles del formulario
                    txtNombres.Text = row["Nombres"].ToString();
                    txtApellidoPaterno.Text = row["ApellidoPaterno"].ToString();
                    txtApellidoMaterno.Text = row["ApellidoMaterno"].ToString();
                    txtNumeroNomina.Text = row["NumeroNomina"].ToString();
                    txtPuesto.Text = row["Puesto"].ToString();

                    // Obtener el valor del área desde la base de datos
                    string area = row["Area"].ToString();

                    // Cargar el ComboBox con las áreas locales
                    CargarAreas();

                    // Seleccionar el área correcto en el ComboBox
                    if (cboArea.Items.Contains(area))
                    {
                        cboArea.SelectedItem = area; // Establecer el área del empleado
                    }
                    else
                    {
                        MessageBox.Show("El área del empleado no es válida o no se encuentra en la lista de áreas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarCambios_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores ingresados por el usuario
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

                // Llamamos al método ActualizarEmpleado de la clase Dao
                EmpleadosInyeccionDao dao = new EmpleadosInyeccionDao();
                bool exito = dao.ActualizarEmpleado(empleadoId, nombres, apellidoPaterno, apellidoMaterno, numeroNomina, puesto, area);

                // Verificar si la actualización fue exitosa
                if (exito)
                {
                    MessageBox.Show("Empleado actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar el formulario después de guardar los cambios
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura de excepciones
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
