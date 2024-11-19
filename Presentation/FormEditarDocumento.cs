using System;
using System.Windows.Forms;
using DataAccess;
using DataAccess.MySQL; // Asegúrate de importar el espacio de nombres correcto
using Common.Cache; // Para acceder al cache del usuario

namespace Presentation
{
    public partial class FormEditarDocumento : Form
    {
        private int documentoId;
        private EmpleadosDao empleadosDao;
        private RegistroActividadesDao registroActividadesDao; // Para registrar la actividad

        public FormEditarDocumento(int idDocumento)
        {
            InitializeComponent();
            documentoId = idDocumento;
            empleadosDao = new EmpleadosDao();
            registroActividadesDao = new RegistroActividadesDao(); // Inicializa la instancia
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtNuevoNombre.Text;

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                bool actualizado = empleadosDao.EditarNombreDocumento(documentoId, nuevoNombre);
                if (actualizado)
                {
                    // Registrar la actividad
                    RegistroActividad actividad = new RegistroActividad
                    {
                        UsuarioID = registroActividadesDao.ObtenerUsuarioActualId(), // Obtén el ID del usuario actual
                        DocumentoID = documentoId,
                        Actividad = "Edición de Documento",
                        FechaHora = DateTime.Now,
                        DetallesActividad = $"Se cambió el nombre del documento a {nuevoNombre}."
                    };
                    registroActividadesDao.AddActividad(actividad); // Registra la actividad

                    MessageBox.Show("Nombre del documento actualizado con éxito.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el nombre del documento.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre válido.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
