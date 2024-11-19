using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DataAccess.MySQL;

namespace Presentation
{
    public partial class FormGestionarEmpleadosPL : Form
    {
        private EmpleadosInyeccionDao empleadosInyeccionDao; // Declara el DAO

        public FormGestionarEmpleadosPL()
        {
            InitializeComponent();
            empleadosInyeccionDao = new EmpleadosInyeccionDao(); // Inicializa el DAO
        }

        private void FormGestionarEmpleadosPL_Load(object sender, EventArgs e)
        {
            CargarEmpleados(); // Carga los empleados al iniciar el formulario
            ConfigurarColumnas(); // Configura las columnas y el estilo del DataGridView
            PersonalizarDataGridView(); // Aplica el diseño mejorado al DataGridView
        }

        private void PersonalizarDataGridView()
        {
            // Personaliza el DataGridView
            dataGridViewEmpleados.AllowUserToAddRows = false;
            dataGridViewEmpleados.ReadOnly = true;
            dataGridViewEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Estilo de encabezados
            dataGridViewEmpleados.EnableHeadersVisualStyles = false;
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Estilo de filas
            dataGridViewEmpleados.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewEmpleados.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridViewEmpleados.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 153, 204);
            dataGridViewEmpleados.RowsDefaultCellStyle.SelectionForeColor = Color.White;

            // Estilo de filas alternas
            dataGridViewEmpleados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewEmpleados.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            // Bordes de celda
            dataGridViewEmpleados.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewEmpleados.BorderStyle = BorderStyle.Fixed3D;
        }

        private void ConfigurarColumnas()
        {
            // Personalizar el encabezado de las columnas
            dataGridViewEmpleados.Columns["EmpleadoID"].HeaderText = "ID";
            dataGridViewEmpleados.Columns["Nombres"].HeaderText = "Nombres";
            dataGridViewEmpleados.Columns["ApellidoPaterno"].HeaderText = "Apellido Paterno";
            dataGridViewEmpleados.Columns["ApellidoMaterno"].HeaderText = "Apellido Materno";
            dataGridViewEmpleados.Columns["NumeroNomina"].HeaderText = "Número de Nómina";
            dataGridViewEmpleados.Columns["Puesto"].HeaderText = "Puesto";
            dataGridViewEmpleados.Columns["Area"].HeaderText = "Área";

            // Ajustar el ancho de las columnas
            dataGridViewEmpleados.Columns["EmpleadoID"].Width = 50;
            dataGridViewEmpleados.Columns["Nombres"].Width = 100;
            dataGridViewEmpleados.Columns["ApellidoPaterno"].Width = 100;
            dataGridViewEmpleados.Columns["ApellidoMaterno"].Width = 100;
            dataGridViewEmpleados.Columns["NumeroNomina"].Width = 80;
            dataGridViewEmpleados.Columns["Puesto"].Width = 100;
            dataGridViewEmpleados.Columns["Area"].Width = 80;
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable empleados = empleadosInyeccionDao.ObtenerEmpleados();
                dataGridViewEmpleados.DataSource = empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarEmpleadoInyeccionPlastica formAgregarEmpleadoInyeccionPlastica = new FormAgregarEmpleadoInyeccionPlastica();
            formAgregarEmpleadoInyeccionPlastica.FormClosed += FormAgregarEmpleadoInyeccionPlastica_FormClosed;
            formAgregarEmpleadoInyeccionPlastica.Show();
        }

        private void FormAgregarEmpleadoInyeccionPlastica_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarEmpleados(); // Recargar empleados cuando se cierra el formulario de agregar
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                int empleadoID = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["EmpleadoID"].Value);
                string nombres = dataGridViewEmpleados.SelectedRows[0].Cells["Nombres"].Value.ToString();
                string apellidoPaterno = dataGridViewEmpleados.SelectedRows[0].Cells["ApellidoPaterno"].Value.ToString();
                string apellidoMaterno = dataGridViewEmpleados.SelectedRows[0].Cells["ApellidoMaterno"].Value.ToString();
                string numeroNomina = dataGridViewEmpleados.SelectedRows[0].Cells["NumeroNomina"].Value.ToString();
                string puesto = dataGridViewEmpleados.SelectedRows[0].Cells["Puesto"].Value.ToString();
                string area = dataGridViewEmpleados.SelectedRows[0].Cells["Area"].Value.ToString();

                // Usamos el constructor adecuado
                FormEditarEmpleadosPL formEditar = new FormEditarEmpleadosPL(empleadoID);
                formEditar.FormClosed += (s, args) => CargarEmpleados(); // Recargar empleados después de la edición
                formEditar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmpleados.SelectedRows.Count > 0)
            {
                int empleadoID = Convert.ToInt32(dataGridViewEmpleados.SelectedRows[0].Cells["EmpleadoID"].Value);

                DialogResult dialogResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        empleadosInyeccionDao.EliminarEmpleado(empleadoID);
                        CargarEmpleados();
                        MessageBox.Show("Empleado eliminado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar empleado: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para eliminar.");
            }
        }

        // Este método se llamará desde el formulario de edición para actualizar el DataGridView
        public void ActualizarDataGrid()
        {
            CargarEmpleados(); // Llama a CargarEmpleados para refrescar la lista
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
