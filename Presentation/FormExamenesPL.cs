using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormExamenesPL : Form
    {
        private List<EmpleadoExamen> empleados = new List<EmpleadoExamen>();

        // Diccionario de exámenes por área
        private Dictionary<string, List<string>> examenesPorArea = new Dictionary<string, List<string>>()
        {
            { "Administrativo", new List<string> { "Agudeza Visual", "AP lateral de columna" } },
            { "Calidad", new List<string> { "Colorimetría" } },
            { "Almacén", new List<string> { "AP lateral de columna" } }
        };

        public FormExamenesPL()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewEmpleados.Columns.Clear();
            dataGridViewEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Configuración de columnas
            dataGridViewEmpleados.Columns.Add("EmpleadoID", "EmpleadoID");
            dataGridViewEmpleados.Columns["EmpleadoID"].Visible = false; // Ocultar ID
            dataGridViewEmpleados.Columns.Add("NumeroNomina", "Número Nómina");
            dataGridViewEmpleados.Columns.Add("NombreCompleto", "Nombre Completo");
            dataGridViewEmpleados.Columns.Add("Area", "Área");

            // Checkbox para estado del examen
            dataGridViewEmpleados.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "No pasó", Name = "NoPaso" });
            dataGridViewEmpleados.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Pasó", Name = "Paso" });
            dataGridViewEmpleados.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Aprobado", Name = "Aprobado" });
        }

        private void FormExamenesPL_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con los exámenes únicos desde la relación examenesPorArea
            comboBoxExamenes.Items.Clear();
            foreach (var examenList in examenesPorArea.Values.SelectMany(x => x).Distinct())
            {
                comboBoxExamenes.Items.Add(examenList);
            }

            // Cargar todos los empleados desde la base de datos
            empleados = ObtenerEmpleadosDesdeBaseDeDatos();
        }

        private MySqlConnection GetMySqlConnection()
        {
            string connectionString = "Server=127.0.0.1;Database=sistema;User ID=root;Password=;SslMode=none;";
            return new MySqlConnection(connectionString);
        }

        private List<EmpleadoExamen> ObtenerEmpleadosDesdeBaseDeDatos()
        {
            var listaEmpleados = new List<EmpleadoExamen>();

            try
            {
                using (var conn = GetMySqlConnection())
                {
                    conn.Open();

                    string query = "SELECT EmpleadoID, Nombres, ApellidoPaterno, ApellidoMaterno, NumeroNomina, Area FROM empleados_inyeccion";

                    using (var command = new MySqlCommand(query, conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaEmpleados.Add(new EmpleadoExamen
                            {
                                EmpleadoID = reader.GetInt32("EmpleadoID"),
                                Nombre = reader.GetString("Nombres"),
                                ApellidoPaterno = reader.GetString("ApellidoPaterno"),
                                ApellidoMaterno = reader.GetString("ApellidoMaterno"),
                                NumeroNomina = reader.GetString("NumeroNomina"),
                                Area = reader.GetString("Area") // Ahora usamos área
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al recuperar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaEmpleados;
        }

        private void comboBoxExamenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxExamenes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un examen antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string examenSeleccionado = comboBoxExamenes.SelectedItem.ToString();

            // Filtrar empleados por área que necesitan este examen
            var empleadosFiltrados = empleados
                .Where(emp => examenesPorArea.ContainsKey(emp.Area) && examenesPorArea[emp.Area].Contains(examenSeleccionado))
                .ToList();

            dataGridViewEmpleados.Rows.Clear();

            if (!empleadosFiltrados.Any())
            {
                MessageBox.Show($"No se encontraron empleados que requieran el examen '{examenSeleccionado}'.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var emp in empleadosFiltrados)
            {
                dataGridViewEmpleados.Rows.Add(
                    emp.EmpleadoID,
                    emp.NumeroNomina,
                    $"{emp.Nombre} {emp.ApellidoPaterno} {emp.ApellidoMaterno}",
                    emp.Area
                );
            }

            // Cargar y aplicar los estados de los exámenes
            CargarEstadosExamen(examenSeleccionado);
        }

        private void AplicarColores()
        {
            foreach (DataGridViewRow fila in dataGridViewEmpleados.Rows)
            {
                if (fila.IsNewRow) continue;

                bool noPaso = Convert.ToBoolean(fila.Cells["NoPaso"].Value ?? false);
                bool paso = Convert.ToBoolean(fila.Cells["Paso"].Value ?? false);
                bool aprobado = Convert.ToBoolean(fila.Cells["Aprobado"].Value ?? false);

                if (noPaso)
                {
                    fila.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (paso)
                {
                    fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (aprobado)
                {
                    fila.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridViewEmpleados.Rows)
            {
                if (fila.IsNewRow) continue; // Ignorar la fila nueva

                // Verificar EmpleadoID
                var empleadoIDCell = fila.Cells["EmpleadoID"];
                if (empleadoIDCell.Value == null || !(empleadoIDCell.Value is int empleadoID))
                {
                    MessageBox.Show("No se puede guardar porque el empleado no existe o el ID es inválido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                // Obtener el examen seleccionado
                string examen = comboBoxExamenes.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(examen))
                {
                    MessageBox.Show("Seleccione un examen antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificación del estado
                string estado = "";
                if ((bool)(fila.Cells["NoPaso"].Value ?? false))
                    estado = "No pasó";
                else if ((bool)(fila.Cells["Paso"].Value ?? false))
                    estado = "Pasó";
                else if ((bool)(fila.Cells["Aprobado"].Value ?? false))
                    estado = "Aprobado";

                // Guardar el estado solo si es válido
                if (!string.IsNullOrEmpty(estado))
                {
                    GuardarEstadoExamen(empleadoID, examen, estado);
                }
            }

            MessageBox.Show("Estados guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GuardarEstadoExamen(int empleadoID, string examen, string estado)
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "INSERT INTO estadoexamen_pl (EmpleadoID, Examen, Estado) VALUES (@EmpleadoID, @Examen, @Estado) " +
                               "ON DUPLICATE KEY UPDATE Estado = @Estado"; // Actualiza si ya existe

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    command.Parameters.AddWithValue("@Examen", examen);
                    command.Parameters.AddWithValue("@Estado", estado);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CargarEstadosExamen(string examenSeleccionado)
        {
            foreach (DataGridViewRow fila in dataGridViewEmpleados.Rows)
            {
                if (fila.IsNewRow) continue;

                var empleadoID = Convert.ToInt32(fila.Cells["EmpleadoID"].Value);
                string estado = ObtenerEstadoExamen(empleadoID, examenSeleccionado);

                if (estado == "No pasó")
                {
                    fila.Cells["NoPaso"].Value = true;
                }
                else if (estado == "Pasó")
                {
                    fila.Cells["Paso"].Value = true;
                }
                else if (estado == "Aprobado")
                {
                    fila.Cells["Aprobado"].Value = true;
                }
            }

            AplicarColores();
        }

        private string ObtenerEstadoExamen(int empleadoID, string examen)
        {
            string estado = "";

            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "SELECT Estado FROM estadoexamen_pl WHERE EmpleadoID = @EmpleadoID AND Examen = @Examen";

                using (var command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                    command.Parameters.AddWithValue("@Examen", examen);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            estado = reader.GetString("Estado");
                        }
                    }
                }
            }

            return estado;
        }

        private void dataGridViewEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hace clic en una celda de checkbox
            if (e.RowIndex >= 0 && (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6))
            {
                // Validar que el valor de EmpleadoID no sea nulo
                var empleadoIDCell = dataGridViewEmpleados.Rows[e.RowIndex].Cells["EmpleadoID"];
                if (empleadoIDCell.Value == null || !(empleadoIDCell.Value is int))
                {
                    MessageBox.Show("El empleado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int empleadoID = (int)empleadoIDCell.Value;

                // Validar que un examen esté seleccionado en el ComboBox
                if (comboBoxExamenes.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un examen antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string examen = comboBoxExamenes.SelectedItem.ToString();

                // Desmarcar otros CheckBox en la fila
                for (int i = 4; i <= 6; i++)
                {
                    dataGridViewEmpleados.Rows[e.RowIndex].Cells[i].Value = false; // Desmarcar todos
                }
                dataGridViewEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true; // Marcar el checkbox seleccionado

                // Determinar el estado seleccionado
                string estadoSeleccionado = "";
                switch (e.ColumnIndex)
                {
                    case 4: // No pasó
                        estadoSeleccionado = "No pasó";
                        break;
                    case 5: // Pasó
                        estadoSeleccionado = "Pasó";
                        break;
                    case 6: // Aprobado
                        estadoSeleccionado = "Aprobado";
                        break;
                }

                // Cambiar el color de la fila según el estado
                var fila = dataGridViewEmpleados.Rows[e.RowIndex];
                ActualizarEstadoFila(fila, estadoSeleccionado);
            }
        }

        private void ActualizarEstadoFila(DataGridViewRow fila, string estadoSeleccionado)
        {
            fila.Cells["NoPaso"].Value = estadoSeleccionado == "No pasó";
            fila.Cells["Paso"].Value = estadoSeleccionado == "Pasó";
            fila.Cells["Aprobado"].Value = estadoSeleccionado == "Aprobado";

            // Aplicar color basado en el estado
            AplicarColores();
        }
    }

    // Clase que representa un empleado y su examen
    public class EmpleadoExamen
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroNomina { get; set; }
        public string Area { get; set; }
    }
}
