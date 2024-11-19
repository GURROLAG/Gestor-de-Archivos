using DataAccess.MySQL;
using System;
using System.Data;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormRebabeo : Form
    {
        private FormCarpetasEmpleado formCarpetasEmpleado; // Variable para la instancia de FormCarpetasEmpleado

        public FormRebabeo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimizar la ventana
        }

        private void FormRebabeo_Load(object sender, EventArgs e)
        {
            // Llamar al método para cargar empleados del área "Rebabeo"
            CargarEmpleadosRebabeo();
            ConfigurarDataGridView();
            this.dataGridViewEmpleados.CellContentClick += dataGridViewEmpleados_CellContentClick;
        }

        // Método para cargar los empleados del área "Rebabeo"
        private void CargarEmpleadosRebabeo()
        {
            try
            {
                // Crear una instancia del DAO
                EmpleadosInyeccionDao dao = new EmpleadosInyeccionDao();

                // Llamar al método para obtener empleados del área "Rebabeo"
                DataTable empleados = dao.ObtenerEmpleadosPorArea("Rebabeo");

                // Asignar el resultado al DataGridView
                dataGridViewEmpleados.DataSource = empleados;
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si ocurre algún error
                MessageBox.Show("Error al cargar empleados de Rebabeo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Configurar el DataGridView para incluir la columna de botón
        private void ConfigurarDataGridView()
        {
            DataGridViewButtonColumn detallesButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Detalles",
                HeaderText = "Ver Más Detalles",
                Text = "Ver Detalles",
                UseColumnTextForButtonValue = true
            };

            // Agregar la columna al DataGridView solo si no está ya agregada
            if (dataGridViewEmpleados.Columns["Detalles"] == null)
            {
                dataGridViewEmpleados.Columns.Add(detallesButtonColumn);
            }
        }

        // Evento para manejar el clic en el botón "Ver Más Detalles"
        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la columna es la de botones
            if (e.ColumnIndex == dataGridViewEmpleados.Columns["Detalles"].Index && e.RowIndex >= 0)
            {
                // Verifica si la celda que contiene el ID del empleado está vacía o es inválida
                if (dataGridViewEmpleados.Rows[e.RowIndex].Cells["EmpleadoID"].Value == null ||
                    dataGridViewEmpleados.Rows[e.RowIndex].Cells["EmpleadoID"].Value.ToString() == string.Empty)
                {
                    // Mostrar un mensaje si no se ha seleccionado un empleado válido
                    MessageBox.Show("Por favor, seleccione un empleado válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Terminar la ejecución sin abrir el formulario de detalles
                }

                // Obtén el ID del empleado desde la fila seleccionada
                int empleadoId = Convert.ToInt32(dataGridViewEmpleados.Rows[e.RowIndex].Cells["EmpleadoID"].Value);

                // Verificar si el formulario ya está abierto
                if (formCarpetasEmpleado == null || formCarpetasEmpleado.IsDisposed)
                {
                    formCarpetasEmpleado = new FormCarpetasEmpleado(empleadoId);
                    formCarpetasEmpleado.Show();
                }
                else
                {
                    // Traer al frente la instancia existente
                    formCarpetasEmpleado.BringToFront();
                }
            }
        }
    }
}
