using System;
using System.Data;
using System.Windows.Forms;
using DataAccess;

namespace Presentation
{
    public partial class FormCNC : Form
    {
        private EmpleadosDao empleadosDao;  // Declarar empleadosDao

        public FormCNC()
        {
            InitializeComponent();
            empleadosDao = new EmpleadosDao();  // Inicializar empleadosDao
            CargarEmpleadosEnDataGrid("CNC");  // Cargar empleados de la área "CNC"
            ConfigurarDataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarEmpleadosEnDataGrid(string area)
        {
            try
            {
                DataTable empleados = empleadosDao.ObtenerEmpleadosPorArea(area);  // Obtener empleados por área
                dataGridViewEmpleados.DataSource = empleados;  // Asignar al DataGridView

                // Verificar si la columna de "Ver más detalles" ya existe para evitar duplicados
                if (!dataGridViewEmpleados.Columns.Contains("VerDetalles"))
                {
                    DataGridViewButtonColumn btnDetalles = new DataGridViewButtonColumn();
                    btnDetalles.Name = "VerDetalles";
                    btnDetalles.Text = "Ver más detalles";
                    btnDetalles.UseColumnTextForButtonValue = true; // Mostrar el texto en los botones
                    dataGridViewEmpleados.Columns.Add(btnDetalles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }
        private void ConfigurarDataGridView()
        {
            // Propiedades del DataGridView
            dataGridViewEmpleados.BackgroundColor = Color.Black; // Fondo negro
            dataGridViewEmpleados.BorderStyle = BorderStyle.None; // Sin borde
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(80, 0, 0); // Rojo oscuro
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Color de texto blanco
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Fuente de encabezados

            dataGridViewEmpleados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 0, 0); // Rojo al seleccionar fila
            dataGridViewEmpleados.DefaultCellStyle.SelectionForeColor = Color.White; // Color de texto al seleccionar
            dataGridViewEmpleados.DefaultCellStyle.BackColor = Color.FromArgb(40, 0, 0); // Fondo rojo apagado para celdas
            dataGridViewEmpleados.DefaultCellStyle.ForeColor = Color.White; // Color de texto blanco para celdas

            dataGridViewEmpleados.EnableHeadersVisualStyles = false; // Deshabilitar estilos visuales predeterminados de encabezados

            // Establecer ancho de columnas y ajuste automático
            dataGridViewEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Agregar bordes a las celdas
            dataGridViewEmpleados.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Borde simple para las celdas
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se ha hecho clic en la columna de "VerDetalles"
            if (dataGridViewEmpleados.Columns[e.ColumnIndex].Name == "VerDetalles")
            {
                // Obtener el valor de la celda "EmpleadoID"
                var empleadoIdCellValue = dataGridViewEmpleados.Rows[e.RowIndex].Cells["EmpleadoID"].Value;

                // Verificar si el valor es DBNull o null
                if (empleadoIdCellValue != DBNull.Value && empleadoIdCellValue != null)
                {
                    int empleadoId = Convert.ToInt32(empleadoIdCellValue); // Convertir a int solo si no es DBNull
                    AbrirDetalleEmpleado(empleadoId);  // Llamar al método para abrir el formulario de detalles
                }
                else
                {
                    // Manejar el caso donde el ID del empleado no es válido
                    MessageBox.Show("Seleccione un empleado valido");
                }
            }
        }
        private void AbrirDetalleEmpleado(int empleadoId)
        {
            // Abrir el formulario de detalles del empleado
            FormDetalleEmpleado formDetalle = new FormDetalleEmpleado(empleadoId); // Cambiar a ID de empleado
            formDetalle.Show();
        }
    }
}
