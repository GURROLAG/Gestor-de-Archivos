using System;
using System.Data;
using System.Windows.Forms;
using Common.Cache;
using DataAccess;
using DataAccess.MySQL;

namespace Presentation
{
    public partial class FormAgregarCarpeta : Form
    {
        private int empleadoId; // ID del empleado actual
        private CarpetaDao carpetaDao; // Instancia para interactuar con la base de datos
        private TreeView treeView; // Referencia al TreeView
        private RegistroActividadesDao registroActividadesDao; // Instancia de RegistroActividadesDao

        public FormAgregarCarpeta(int empleadoId, TreeView treeView)
        {
            InitializeComponent();
            this.empleadoId = empleadoId; // Recibimos el ID del empleado desde el otro formulario
            this.treeView = treeView; // Inicializamos la referencia del TreeView
            carpetaDao = new CarpetaDao(); // Instanciamos CarpetaDao
            registroActividadesDao = new RegistroActividadesDao(); // Inicializa la instancia
            CargarCarpetas(); // Método para cargar las carpetas existentes en el ComboBox
        }

        private void CargarCarpetas()
        {
            DataTable carpetas = carpetaDao.ObtenerCarpetasPorEmpleado(empleadoId);

            // Añadir opción "Ninguna" para la carpeta principal
            cmbCarpetaPadre.Items.Add("Ninguna");
            cmbCarpetaPadre.SelectedIndex = 0; // Seleccionar por defecto "Ninguna"

            // Añadir las carpetas existentes al ComboBox
            foreach (DataRow row in carpetas.Rows)
            {
                cmbCarpetaPadre.Items.Add(row["NombreCarpeta"].ToString());
            }
        }

        private void btnCrearCarpeta_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = txtNombreCarpeta.Text;
            string carpetaPadre = cmbCarpetaPadre.SelectedItem.ToString();
            string tipoCarpeta = (carpetaPadre == "Ninguna") ? "Principal" : "Sub-Carpeta";

            if (string.IsNullOrWhiteSpace(nombreCarpeta))
            {
                MessageBox.Show("Por favor, ingrese un nombre para la carpeta.");
                return;
            }

            // Llamar al método CrearCarpeta del CarpetaDao
            bool success = carpetaDao.CrearCarpeta(empleadoId, nombreCarpeta, tipoCarpeta);

            if (success)
            {
                // Registro de la actividad
                var actividad = new RegistroActividad
                {
                    UsuarioID = registroActividadesDao.ObtenerUsuarioActualId(), // Obtiene el ID del usuario actual
                    DocumentoID = null, // Puedes asignar un ID de documento si es relevante
                    Actividad = "Creación de carpeta",
                    FechaHora = DateTime.Now,
                    DetallesActividad = $"Carpeta '{nombreCarpeta}' creada. Tipo: {tipoCarpeta}. Para el empleado ID: {empleadoId}."
                };
                registroActividadesDao.AddActividad(actividad); // Agrega la actividad al registro

                MessageBox.Show("Carpeta creada con éxito.");
                ActualizarTreeView(); // Actualizar el TreeView después de crear la carpeta
                this.Close(); // Cerrar el formulario después de crear la carpeta
            }
            else
            {
                MessageBox.Show("Error al crear la carpeta.");
            }
        }

        // Método para actualizar el TreeView
        private void ActualizarTreeView()
        {
            treeView.Nodes.Clear(); // Limpiar los nodos existentes
            DataTable carpetas = carpetaDao.ObtenerCarpetasPorEmpleado(empleadoId);

            // Agregar carpetas al TreeView
            foreach (DataRow row in carpetas.Rows)
            {
                treeView.Nodes.Add(row["NombreCarpeta"].ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
