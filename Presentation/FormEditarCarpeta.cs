using System;
using System.Data;
using System.Windows.Forms;
using Common.Cache;
using DataAccess;
using DataAccess.MySQL; // Asegúrate de incluir el espacio de nombres adecuado para RegistroActividadesDao

namespace Presentation
{
    public partial class FormEditarCarpeta : Form
    {
        private int empleadoId;
        private FormDetalleEmpleado detalleEmpleadoForm;
        private CarpetaDao carpetaDao;
        private RegistroActividadesDao registroActividadesDao; // Para registrar la actividad

        public FormEditarCarpeta(int empleadoId, FormDetalleEmpleado detalleEmpleadoForm)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;
            this.detalleEmpleadoForm = detalleEmpleadoForm;
            carpetaDao = new CarpetaDao();
            registroActividadesDao = new RegistroActividadesDao(); // Inicializa la instancia
            CargarCarpetas();
        }

        private void CargarCarpetas()
        {
            DataTable carpetas = carpetaDao.ObtenerCarpetasPorEmpleado(empleadoId);

            // Configuración del ComboBox para mostrar las carpetas con sus IDs
            cmbCarpetas.DisplayMember = "NombreCarpeta"; // Campo para mostrar
            cmbCarpetas.ValueMember = "CarpetaID"; // Campo del ID de la carpeta
            cmbCarpetas.DataSource = carpetas; // Establecer como origen de datos
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbCarpetas.SelectedItem == null || string.IsNullOrWhiteSpace(txtNuevoNombre.Text))
            {
                MessageBox.Show("Por favor, selecciona una carpeta y proporciona un nuevo nombre.");
                return;
            }

            int carpetaId = (int)cmbCarpetas.SelectedValue; // Obtener el ID de la carpeta seleccionada
            string nuevoNombre = txtNuevoNombre.Text;

            // Llamar al método EditarCarpeta en CarpetaDao
            bool success = carpetaDao.EditarCarpeta(carpetaId, nuevoNombre);

            if (success)
            {
                // Registrar la actividad
                RegistroActividad actividad = new RegistroActividad
                {
                    UsuarioID = registroActividadesDao.ObtenerUsuarioActualId(), // Obtén el ID del usuario actual
                    CarpetaID = carpetaId,
                    Actividad = "Edición de Carpeta",
                    FechaHora = DateTime.Now,
                    DetallesActividad = $"Se cambió el nombre de la carpeta a {nuevoNombre}."
                };
                registroActividadesDao.AddActividad(actividad); // Registra la actividad

                MessageBox.Show("Carpeta editada con éxito.");

                // Actualizar los datos en el formulario principal
                detalleEmpleadoForm.ActualizarDatos();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al editar la carpeta.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
