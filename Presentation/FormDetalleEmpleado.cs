using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Presentation
{
    public partial class FormDetalleEmpleado : Form
    {
        private int empleadoId;
        private int carpetaId; // Definido a nivel de clase
        private EmpleadosDao empleadosDao;
        private CarpetaDao carpetaDao;
        private int documentoSeleccionadoId;

        public FormDetalleEmpleado(int idEmpleado)
        {
            InitializeComponent();
            empleadoId = idEmpleado;
            empleadosDao = new EmpleadosDao();
            carpetaDao = new CarpetaDao();
            CargarTreeView(); // Cargar las carpetas al iniciar el formulario
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void CargarTreeView()
        {
            try
            {
                treeViewCarpetas.Nodes.Clear();
                TreeNode rootNode = new TreeNode("Documentos de Empleado");
                treeViewCarpetas.Nodes.Add(rootNode);

                DataTable carpetas = ObtenerCarpetasPorEmpleado(empleadoId);
                foreach (DataRow row in carpetas.Rows)
                {
                    string nombreCarpeta = row["NombreCarpeta"].ToString();
                    TreeNode nodoCarpeta = new TreeNode(nombreCarpeta);
                    rootNode.Nodes.Add(nodoCarpeta);
                }

                treeViewCarpetas.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las carpetas: {ex.Message}");
            }
        }

        private DataTable ObtenerCarpetasPorEmpleado(int empleadoId)
        {
            return carpetaDao.ObtenerCarpetasPorEmpleado(empleadoId);
        }

        private void CargarDocumentos(string nombreCarpeta)
        {
            try
            {
                int carpetaId = ObtenerCarpetaIdPorNombre(nombreCarpeta);
                DataTable documentos = empleadosDao.ObtenerDocumentosPorCarpeta(carpetaId);
                dataGridViewDocumentos.DataSource = documentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los documentos: {ex.Message}");
            }
        }

        private void dataGridViewDocumentos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirDocumento(Convert.ToInt32(dataGridViewDocumentos.Rows[e.RowIndex].Cells["DocumentoID"].Value));
            }
        }

        private void AbrirDocumento(int documentoId)
        {
            try
            {
                string rutaDocumento = ObtenerRutaDocumentoDesdeBaseDeDatos(documentoId);
                if (!string.IsNullOrEmpty(rutaDocumento))
                {
                    System.Diagnostics.Process.Start(rutaDocumento);
                }
                else
                {
                    MessageBox.Show("La ruta del documento no es válida o no se encontró.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el documento: {ex.Message}");
            }
        }

        private string ObtenerRutaDocumentoDesdeBaseDeDatos(int documentoId)
        {
            return empleadosDao.ObtenerRutaDocumento(documentoId);
        }

        private void pictureBox1_Click(object sender, EventArgs e) => this.Close();

        private void FormDetalleEmpleado_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCrearCarpeta_Click(object sender, EventArgs e)
        {
            using (var formAgregarCarpeta = new FormAgregarCarpeta(empleadoId, treeViewCarpetas))
            {
                formAgregarCarpeta.ShowDialog();
            }
            CargarTreeView();
        }

        private void btnEliminarCarpeta_Click(object sender, EventArgs e)
        {
            if (treeViewCarpetas.SelectedNode != null)
            {
                string nombreCarpeta = treeViewCarpetas.SelectedNode.Text;
                int carpetaId = ObtenerCarpetaIdPorNombre(nombreCarpeta);

                if (MessageBox.Show($"¿Estás seguro de que quieres eliminar la carpeta '{nombreCarpeta}'?",
                                    "Confirmar Eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (carpetaDao.EliminarCarpeta(carpetaId))
                    {
                        MessageBox.Show("Carpeta eliminada con éxito.");
                        CargarTreeView();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar la carpeta.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una carpeta para eliminar.");
            }
        }

        private int ObtenerCarpetaIdPorNombre(string nombreCarpeta)
        {
            return carpetaDao.ObtenerCarpetaIdPorNombre(empleadoId, nombreCarpeta);
        }

        private void btnEditarCarpeta_Click(object sender, EventArgs e)
        {
            using (var formEditarCarpeta = new FormEditarCarpeta(empleadoId, this))
            {
                formEditarCarpeta.ShowDialog();
            }
        }

        public void ActualizarDatos()
        {
            CargarTreeView();
            if (treeViewCarpetas.SelectedNode != null)
            {
                CargarDocumentos(treeViewCarpetas.SelectedNode.Text);
            }
        }

        private void btnAgregarDocumento_Click(object sender, EventArgs e)
        {
            if (treeViewCarpetas.SelectedNode != null)
            {
                int carpetaId = ObtenerCarpetaIdPorNombre(treeViewCarpetas.SelectedNode.Text);
                using (var formSubirDocumento = new FormSubirDocumento(carpetaId))
                {
                    formSubirDocumento.FormClosed += (s, args) => ActualizarDocumentos();
                    formSubirDocumento.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una carpeta para subir el documento.");
            }
        }

        private void ActualizarDocumentos()
        {
            if (treeViewCarpetas.SelectedNode != null)
            {
                CargarDocumentos(treeViewCarpetas.SelectedNode.Text);
            }
        }


        private void btnEditarDocumento_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocumentos.SelectedRows.Count > 0)
            {
                int documentoId = Convert.ToInt32(dataGridViewDocumentos.SelectedRows[0].Cells["ID_Documento"].Value);
                using (var formEditarDocumento = new FormEditarDocumento(documentoId))
                {
                    formEditarDocumento.ShowDialog();
                }
                ActualizarDocumentos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un documento para editar.");
            }
        }

        private void treeViewCarpetas_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                CargarDocumentos(e.Node.Text);
            }
        }

        private void btnEliminarDocumento_Click(object sender, EventArgs e)
        {
            if (dataGridViewDocumentos.SelectedRows.Count > 0)
            {
                // Cambia "DocumentoID" por el nombre correcto de la columna
                int documentoId = Convert.ToInt32(dataGridViewDocumentos.SelectedRows[0].Cells["ID_Documento"].Value);

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este documento?", "Confirmar Eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        empleadosDao.EliminarDocumento(documentoId); // Eliminar el documento

                        MessageBox.Show("Documento eliminado con éxito.");

                        // Cargar documentos de la carpeta seleccionada después de eliminar
                        if (treeViewCarpetas.SelectedNode != null)
                        {
                            CargarDocumentos(treeViewCarpetas.SelectedNode.Text); // Asegúrate de pasar el nombre de la carpeta, no el ID
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el documento: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un documento para eliminar.");
            }
        }

        private void dataGridViewDocumentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDocumentos.SelectedRows.Count > 0)
            {
                documentoSeleccionadoId = Convert.ToInt32(dataGridViewDocumentos.SelectedRows[0].Cells["ID_Documento"].Value);
            }
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            if (documentoSeleccionadoId != 0)
            {
                var empleadosDao = new EmpleadosDao();

                var (contenidoDocumento, extension) = empleadosDao.ObtenerContenidoDocumento(documentoSeleccionadoId);

                if (contenidoDocumento != null && !string.IsNullOrEmpty(extension))
                {
                    string rutaTemporal = Path.Combine(Path.GetTempPath(), $"documento_temporal.{extension}"); // Usa la extensión correcta

                    File.WriteAllBytes(rutaTemporal, contenidoDocumento);
                    Process.Start(new ProcessStartInfo(rutaTemporal) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el documento.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un documento de la lista.");
            }
        }
    }
}
