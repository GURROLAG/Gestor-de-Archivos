using System;
using System.Data;
using System.Drawing; // Asegúrate de incluir este espacio de nombres
using System.Windows.Forms;
using DataAccess;

namespace Presentation
{
    public partial class FormGestionarEmpleados : Form
    {
        private EmpleadosDao empleadosDao;

        public FormGestionarEmpleados()
        {
            InitializeComponent();
            empleadosDao = new EmpleadosDao();
            ConfigurarDataGridView(); // Configurar el diseño del DataGridView
            CargarEmpleados();  // Cargar empleados al inicio
        }

        // Método para cargar los empleados en el DataGridView
        private void CargarEmpleados()
        {
            try
            {
                DataTable empleados = empleadosDao.ObtenerEmpleados();
                dataGridViewEmpleados.DataSource = empleados;

                // Verifica si se cargaron datos
                if (empleados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron empleados.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        // Método para configurar el diseño del DataGridView
        private void ConfigurarDataGridView()
        {
            // Propiedades del DataGridView
            dataGridViewEmpleados.BackgroundColor = Color.White; // Fondo blanco
            dataGridViewEmpleados.BorderStyle = BorderStyle.None; // Sin borde
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy; // Color de fondo de los encabezados
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Color de texto de los encabezados
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente de encabezados

            dataGridViewEmpleados.DefaultCellStyle.SelectionBackColor = Color.LightBlue; // Color de selección de fila
            dataGridViewEmpleados.DefaultCellStyle.SelectionForeColor = Color.Black; // Color de texto al seleccionar
            dataGridViewEmpleados.DefaultCellStyle.BackColor = Color.White; // Color de fondo de las celdas
            dataGridViewEmpleados.DefaultCellStyle.ForeColor = Color.Black; // Color de texto de las celdas

            dataGridViewEmpleados.EnableHeadersVisualStyles = false; // Deshabilitar estilos visuales predeterminados de encabezados

            // Establecer ancho de columnas y ajuste automático
            dataGridViewEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Evento para agregar un nuevo empleado
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario para agregar empleados
            FormAgregarEmpleado formAgregarEmpleado = new FormAgregarEmpleado();

            // Mostrar el formulario como un diálogo modal (el formulario principal se deshabilitará hasta que se cierre este)
            formAgregarEmpleado.ShowDialog();

            // Después de cerrar el formulario de agregar, recargar los empleados en el DataGridView
            CargarEmpleados();  // Recargar empleados después de agregar uno nuevo
        }

        // Evento para editar un empleado seleccionado
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                // Obtener los datos del empleado seleccionado
                int empleadoID = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["EmpleadoID"].Value);
                string nombres = dataGridViewEmpleados.SelectedRows[0].Cells["Nombres"].Value.ToString();
                string apellidoPaterno = dataGridViewEmpleados.SelectedRows[0].Cells["ApellidoPaterno"].Value.ToString();
                string apellidoMaterno = dataGridViewEmpleados.SelectedRows[0].Cells["ApellidoMaterno"].Value.ToString();
                string numeroNomina = dataGridViewEmpleados.SelectedRows[0].Cells["NumeroNomina"].Value.ToString();
                string puesto = dataGridViewEmpleados.SelectedRows[0].Cells["Puesto"].Value.ToString();
                string area = dataGridViewEmpleados.SelectedRows[0].Cells["Area"].Value.ToString();

                // Crear una instancia del formulario para editar empleados con los datos seleccionados
                FormEditarEmpleado formEditarEmpleado = new FormEditarEmpleado(empleadoID, nombres, apellidoPaterno, apellidoMaterno, numeroNomina, puesto, area);

                // Mostrar el formulario como un diálogo modal (el formulario principal se deshabilitará hasta que se cierre este)
                formEditarEmpleado.ShowDialog();

                // Después de cerrar el formulario de editar, recargar los empleados en el DataGridView
                CargarEmpleados();  // Recargar empleados después de editar
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para actualizar.");
            }
        }

        // Evento para eliminar el empleado seleccionado
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                int empleadoID = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["EmpleadoID"].Value);
                empleadosDao.EliminarEmpleado(empleadoID);
                MessageBox.Show("Empleado eliminado.");
                CargarEmpleados();  // Recargar empleados después de eliminar uno
            }
        }

        // Evento para cerrar el formulario al hacer clic en la imagen
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
