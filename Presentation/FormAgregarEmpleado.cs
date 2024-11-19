using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Common.Cache;
using DataAccess;
using DataAccess.MySQL;

namespace Presentation
{
    public partial class FormAgregarEmpleado : Form
    {
        private EmpleadosDao empleadosDao;  // Instancia de EmpleadosDao
        private RegistroActividadesDao registroActividadesDao; // Instancia de RegistroActividadesDao

        public FormAgregarEmpleado()
        {
            InitializeComponent();
            empleadosDao = new EmpleadosDao();  // Inicializar empleadosDao
            registroActividadesDao = new RegistroActividadesDao(); // Inicializa la instancia
            CargarComboBoxArea();              // Cargar las áreas en el ComboBox
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormAgregarEmpleado_Load(object sender, EventArgs e)
        {
            // Cargar las áreas al abrir el formulario
            CargarComboBoxArea();
        }

        private void CargarComboBoxArea()
        {
            // Cargar las áreas en el ComboBox
            comboBoxArea.Items.AddRange(new string[] {
                "Gasket", "Taller", "Sistemas", "Almacén", "Calidad", "CNC", "Logística"
            });

            // Seleccionar el primer área por defecto
            comboBoxArea.SelectedIndex = 0;
        }

        private void GuardarEmpleado()
        {
            try
            {
                string nombreEmpleado = txtNombreEmpleado.Text;   // Obtener el nombre del empleado
                string apellidoPaterno = txtApellidoPaterno.Text; // Obtener apellido paterno
                string apellidoMaterno = txtApellidoMaterno.Text; // Obtener apellido materno
                string numeroNomina = txtNumeroNomina.Text;       // Obtener número de nómina
                string puesto = txtPuesto.Text;                   // Obtener puesto
                string areaSeleccionada = comboBoxArea.SelectedItem.ToString();  // Obtener área seleccionada

                // Llamar al método para guardar el empleado en la base de datos
                int empleadoId = empleadosDao.AgregarEmpleado(nombreEmpleado, apellidoPaterno, apellidoMaterno, numeroNomina, puesto, areaSeleccionada);

                // Verificar y crear carpetas para el nuevo empleado
                empleadosDao.VerificarYCrearCarpetasParaEmpleado(empleadoId, $"{nombreEmpleado} {apellidoPaterno}");

                // Registro de la actividad
                var actividad = new RegistroActividad
                {
                    UsuarioID = registroActividadesDao.ObtenerUsuarioActualId(), // Obtiene el ID del usuario actual
                    DocumentoID = null, // Puedes asignar un ID de documento si es relevante
                    Actividad = "Registro de empleado",
                    FechaHora = DateTime.Now,
                    DetallesActividad = $"Empleado ID: {empleadoId} creado. Nombres: {nombreEmpleado}, Apellido Paterno: {apellidoPaterno}, Apellido Materno: {apellidoMaterno}, Puesto: {puesto}, Área: {areaSeleccionada}"
                };
                registroActividadesDao.AddActividad(actividad); // Agrega la actividad al registro

                MessageBox.Show("Empleado guardado correctamente y carpetas creadas.");

                // Cerrar el formulario después de registrar el empleado
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar empleado: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cerrar el formulario si se cancela la operación
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            GuardarEmpleado();  // Registrar el empleado y cerrar el formulario
        }

        private void FormAgregarEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
