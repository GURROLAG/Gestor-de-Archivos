using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DataAccess;

namespace Presentation
{
    public partial class FormCarpetasEmpleado : Form
    {
        private readonly int empleadoId;
        private int documentoSeleccionadoId;
        private DocumentosInyeccionDao documentosInyeccionDao;
        private EmpleadosInyeccionDao empleadosInyeccionDao;

        public FormCarpetasEmpleado(int empleadoId)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;
            this.Load += FormCarpetasEmpleado_Load;
        }

        private void FormCarpetasEmpleado_Load(object sender, EventArgs e)
        {
            CargarCarpetasEmpleado();
        }

        private void CargarCarpetasEmpleado()
        {
            try
            {
                var carpetasDao = new CarpetasInyeccionDao();
                DataTable carpetas = carpetasDao.ObtenerCarpetasPorEmpleado(empleadoId);

                treeViewCarpetas.Nodes.Clear();

                if (carpetas.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron carpetas para este empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in carpetas.Rows)
                {
                    var node = new TreeNode(row["NombreCarpeta"].ToString())
                    {
                        Tag = row["CarpetaId"]
                    };
                    treeViewCarpetas.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las carpetas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeViewCarpetas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is int carpetaId)
            {
                CargarArchivosDeCarpeta(carpetaId);
            }
        }

        private void CargarArchivosDeCarpeta(int carpetaId)
        {
            try
            {
                documentosInyeccionDao = new DocumentosInyeccionDao();
                DataTable archivos = documentosInyeccionDao.ObtenerArchivosPorCarpeta(carpetaId);

                dataGridViewArchivos.DataSource = archivos;

                dataGridViewArchivos.Columns["ID_Documento"].HeaderText = "ID Documento";
                dataGridViewArchivos.Columns["CarpetaID"].HeaderText = "ID Carpeta";
                dataGridViewArchivos.Columns["EmpleadoID"].HeaderText = "ID Empleado";
                dataGridViewArchivos.Columns["NombreDocumento"].HeaderText = "Nombre del Documento";
                dataGridViewArchivos.Columns["ExtensionDocumento"].HeaderText = "Extensión";
                dataGridViewArchivos.Columns["FechaCreacion"].HeaderText = "Fecha de Carga";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los archivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearCarpeta_Click(object sender, EventArgs e)
        {
            using (var formCrearCarpeta = new FormCrearCarpeta(empleadoId))
            {
                formCrearCarpeta.ShowDialog();
            }
            CargarCarpetasEmpleado();
        }

        private int ObtenerCarpetaIdSeleccionada() =>
            treeViewCarpetas.SelectedNode?.Tag is int carpetaId ? carpetaId : 0;

        private string ObtenerNombreCarpetaSeleccionada() =>
            treeViewCarpetas.SelectedNode?.Text ?? string.Empty;

        private void btnEditarCarpeta_Click(object sender, EventArgs e)
        {
            int carpetaId = ObtenerCarpetaIdSeleccionada();
            if (carpetaId == 0)
            {
                MessageBox.Show("Seleccione una carpeta para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formActualizar = new FormActualizarCarpeta(carpetaId, ObtenerNombreCarpetaSeleccionada()))
            {
                formActualizar.ShowDialog();
            }
            CargarCarpetasEmpleado();
        }

        private void btnEliminarCarpeta_Click(object sender, EventArgs e)
        {
            int carpetaId = ObtenerCarpetaIdSeleccionada();
            if (carpetaId == 0)
            {
                MessageBox.Show("Seleccione una carpeta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show($"¿Está seguro que desea eliminar la carpeta '{ObtenerNombreCarpetaSeleccionada()}'?",
                                                     "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var carpetasDao = new CarpetasInyeccionDao();
                    carpetasDao.EliminarCarpeta(carpetaId);
                    MessageBox.Show("Carpeta eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCarpetasEmpleado();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la carpeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAgregarDocumento_Click(object sender, EventArgs e)
        {
            int carpetaId = ObtenerCarpetaIdSeleccionada();
            if (carpetaId == 0)
            {
                MessageBox.Show("Seleccione una carpeta para agregar un documento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formAgregarDocumento = new FormAgregarDocumento(empleadoId, carpetaId))
            {
                formAgregarDocumento.ShowDialog();
            }
            CargarArchivosDeCarpeta(carpetaId);
        }

        private void btnVerDocumento_Click(object sender, EventArgs e)
        {
            if (dataGridViewArchivos.SelectedRows.Count > 0)
            {
                int documentoId = Convert.ToInt32(dataGridViewArchivos.SelectedRows[0].Cells["ID_Documento"].Value);
                VerDocumentoDesdeBaseDeDatos(documentoId);
            }
            else
            {
                MessageBox.Show("Seleccione un documento para ver.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void VerDocumentoDesdeBaseDeDatos(int documentoId)
        {
            try
            {
                var documentosDao = new DocumentosInyeccionDao();
                var (contenidoDocumento, extension) = documentosDao.ObtenerContenidoDocumentoPL(documentoId);

                if (contenidoDocumento != null && contenidoDocumento.Length > 0 && !string.IsNullOrEmpty(extension))
                {
                    string rutaTemporal = Path.Combine(Path.GetTempPath(), $"documento_temporal_{documentoId}.{extension}");

                    File.WriteAllBytes(rutaTemporal, contenidoDocumento);
                    Process.Start(new ProcessStartInfo(rutaTemporal) { UseShellExecute = true });
                }
                else
                {
                    MessageBox.Show("No se pudo cargar el documento o el archivo no tiene contenido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar abrir el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarDocumento_Click(object sender, EventArgs e)
        {
            if (dataGridViewArchivos.SelectedRows.Count > 0)
            {
                int documentoId = Convert.ToInt32(dataGridViewArchivos.SelectedRows[0].Cells["ID_Documento"].Value);
                int carpetaId = ObtenerCarpetaIdSeleccionada();

                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este documento?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        documentosInyeccionDao.EliminarDocumento(documentoId);
                        MessageBox.Show("Documento eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarArchivosDeCarpeta(carpetaId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el documento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un documento para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarDocumento_Click(object sender, EventArgs e)
        {
            if (dataGridViewArchivos.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtener los datos necesarios del documento seleccionado
                    int documentoId = Convert.ToInt32(dataGridViewArchivos.SelectedRows[0].Cells["ID_Documento"].Value);
                    string nombreDocumento = dataGridViewArchivos.SelectedRows[0].Cells["NombreDocumento"].Value.ToString();
                    string extensionDocumento = dataGridViewArchivos.SelectedRows[0].Cells["ExtensionDocumento"].Value.ToString();

                    // Crear una nueva acción para actualizar el DataGridView
                    Action actualizarDataGridView = () => CargarArchivosDeCarpeta(ObtenerCarpetaIdSeleccionada());

                    // Crear una nueva instancia del formulario de actualización con los parámetros necesarios
                    FormActualizarDocumento formActualizar = new FormActualizarDocumento(documentoId, nombreDocumento, actualizarDataGridView);

                    // Mostrar el formulario de actualización
                    formActualizar.ShowDialog();

                    // Actualizar el DataGridView después de cerrar el formulario
                    actualizarDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al editar el documento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un documento para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewArchivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se ha hecho clic fuera de las filas (es decir, en un espacio vacío)
            if (e.RowIndex == -1)
            {
                MessageBox.Show("Seleccione un archivo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // Minimizar la ventana
        }
    }
}
