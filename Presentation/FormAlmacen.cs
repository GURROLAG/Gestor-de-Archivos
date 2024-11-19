using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataAccess; // Asegúrate de tener la referencia correcta a tu DAO

namespace Presentation
{
    public partial class FormAlmacen : Form
    {
        private EmpleadosDao empleadosDao; // Declarar empleadosDao

        public FormAlmacen()
        {
            InitializeComponent();
            empleadosDao = new EmpleadosDao(); // Inicializar empleadosDao
            CargarEmpleadosEnDataGrid("Almacen"); // Cargar empleados del área "Almacén"
            ConfigurarDataGridView();
        }

        // Importar funciones de Windows API para mover el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        // Evento para cerrar el formulario al hacer clic en el icono
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método para cargar empleados en el DataGridView por área
        private void CargarEmpleadosEnDataGrid(string area)
        {
            try
            {
                DataTable empleados = empleadosDao.ObtenerEmpleadosPorArea(area); // Obtener empleados por área
                dataGridViewEmpleados.DataSource = empleados; // Asignar al DataGridView

                // Verificar si la columna de "Ver más detalles" ya existe para evitar duplicados
                if (!dataGridViewEmpleados.Columns.Contains("VerDetalles"))
                {
                    DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn
                    {
                        Name = "VerDetalles",
                        Text = "Ver más detalles",
                        UseColumnTextForButtonValue = true // Mostrar el texto en los botones
                    };
                    dataGridViewEmpleados.Columns.Add(btnDetalles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Configuración del DataGridView
        private void ConfigurarDataGridView()
        {
            // Establecer propiedades del DataGridView
            dataGridViewEmpleados.BackgroundColor = Color.Black;
            dataGridViewEmpleados.BorderStyle = BorderStyle.None;
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 0, 0);
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridViewEmpleados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 0, 0);
            dataGridViewEmpleados.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewEmpleados.DefaultCellStyle.BackColor = Color.FromArgb(40, 0, 0);
            dataGridViewEmpleados.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewEmpleados.EnableHeadersVisualStyles = false;
            dataGridViewEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEmpleados.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Borde simple para las celdas
        }

        // Permitir mover el formulario haciendo clic y arrastrando
        private void FormAlmacen_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Evento para minimizar el formulario
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Evento para manejar clics en el DataGridView
        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se ha hecho clic en la columna de "VerDetalles"
            if (dataGridViewEmpleados.Columns[e.ColumnIndex].Name == "VerDetalles" && e.RowIndex >= 0)
            {
                // Obtener el valor de la celda "EmpleadoID"
                var empleadoIdCellValue = dataGridViewEmpleados.Rows[e.RowIndex].Cells["EmpleadoID"].Value;

                // Verificar si el valor es DBNull o null
                if (empleadoIdCellValue != DBNull.Value && empleadoIdCellValue != null)
                {
                    int empleadoId = Convert.ToInt32(empleadoIdCellValue);
                    AbrirDetalleEmpleado(empleadoId); // Llamar al método para abrir el formulario de detalles
                }
                else
                {
                    MessageBox.Show("Seleccione un empleado válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Método para abrir el formulario de detalles del empleado
        private void AbrirDetalleEmpleado(int empleadoId)
        {
            // Abrir el formulario de detalles del empleado
            FormDetalleEmpleado formDetalle = new FormDetalleEmpleado(empleadoId);
            formDetalle.Show();
        }
    }
}
