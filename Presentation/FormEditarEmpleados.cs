using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DataAccess;
using Common.Cache; // Asegúrate de importar el espacio de nombres para acceder al usuario actual
using DataAccess.MySQL;

namespace Presentation
{
    public partial class FormEditarEmpleado : Form
    {
        private EmpleadosDao empleadosDao;
        private RegistroActividadesDao registroActividadesDao; // Instancia de RegistroActividadesDao
        private int empleadoID;

        public FormEditarEmpleado(int idEmpleado, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroNomina, string puesto, string area)
        {
            InitializeComponent();
            empleadosDao = new EmpleadosDao();
            registroActividadesDao = new RegistroActividadesDao(); // Inicializa la instancia
            empleadoID = idEmpleado;

            // Precargar los campos con la información del empleado seleccionado
            txtNombreEmpleado.Text = nombres;
            txtApellidoPaterno.Text = apellidoPaterno;
            txtApellidoMaterno.Text = apellidoMaterno;
            txtNumeroNomina.Text = numeroNomina;
            txtPuesto.Text = puesto;
            comboBoxArea.SelectedItem = area;

            // Cargar las áreas en el ComboBox
            CargarComboBoxArea();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void CargarComboBoxArea()
        {
            comboBoxArea.Items.AddRange(new string[] {
                "Gasket", "Taller", "Sistemas", "Almacén", "Calidad", "CNC", "Logística"
            });
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos necesarios estén llenos
                string nombreEmpleado = txtNombreEmpleado.Text;
                string apellidoPaterno = txtApellidoPaterno.Text;
                string apellidoMaterno = txtApellidoMaterno.Text;
                string numeroNomina = txtNumeroNomina.Text;
                string puesto = txtPuesto.Text;

                // Comprobar si el área está seleccionada
                if (comboBoxArea.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un área.");
                    return;
                }

                string areaSeleccionada = comboBoxArea.SelectedItem.ToString();

                // Actualizar el empleado en la base de datos
                empleadosDao.ActualizarEmpleado(empleadoID, nombreEmpleado, apellidoPaterno, apellidoMaterno, numeroNomina, puesto, areaSeleccionada);

                // Registro de la actividad
                var actividad = new RegistroActividad
                {
                    UsuarioID = registroActividadesDao.ObtenerUsuarioActualId(), // Obtiene el ID del usuario actual
                    DocumentoID = null, // Puedes asignar un ID de documento si es relevante
                    Actividad = "Edición de empleado",
                    FechaHora = DateTime.Now,
                    DetallesActividad = $"Empleado ID: {empleadoID} actualizado. Nombres: {nombreEmpleado}, Apellido Paterno: {apellidoPaterno}, Apellido Materno: {apellidoMaterno}, Puesto: {puesto}, Área: {areaSeleccionada}"
                };

                // Agregar la actividad al registro
                registroActividadesDao.AddActividad(actividad);

                MessageBox.Show("Empleado actualizado correctamente.");
                this.Close();  // Cerrar el formulario después de guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar empleado: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormEditarEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
