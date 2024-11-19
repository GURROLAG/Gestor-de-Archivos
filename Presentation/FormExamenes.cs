using Common.Cache;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormExamenes : Form
    {
        private List<Empleado> empleados = new List<Empleado>();
        private Dictionary<string, List<string>> examenesPorPuesto = new Dictionary<string, List<string>>()
        {
            { "Oficinista", new List<string> { "Agudeza Visual", "AP lateral de columna" } },
            { "Metodología y Calidad", new List<string> { "Colorimetría" } },
            { "Operario", new List<string> { "Campimetría" } },
            { "Almacén", new List<string> { "AP lateral de columna" } },
            { "Torno", new List<string> { "Química Sanguínea" } },
            { "CNC", new List<string> { "Química Sanguínea" } }
        };

        public FormExamenes()
        {
            InitializeComponent();
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewEmpleados.Columns.Clear();

    // Ajustar el tamaño de las columnas para llenar el ancho total del DataGridView
    dataGridViewEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

    // Ajustar la altura de las filas automáticamente según el contenido
    dataGridViewEmpleados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

    // Configuración de columnas
    dataGridViewEmpleados.Columns.Add("EmpleadoID", "EmpleadoID");
    dataGridViewEmpleados.Columns["EmpleadoID"].Visible = false; // Puede mantenerse oculto si es un dato de referencia
    dataGridViewEmpleados.Columns.Add("NumeroNomina", "Número Nómina");
    dataGridViewEmpleados.Columns.Add("NombreCompleto", "Nombre Completo");
    dataGridViewEmpleados.Columns.Add("Puesto", "Puesto");

    // Checkbox para estado del examen
    dataGridViewEmpleados.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "No pasó", Name = "NoPaso" });
    dataGridViewEmpleados.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Pasó", Name = "Paso" });
    dataGridViewEmpleados.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "Aprobado", Name = "Aprobado" });
        }

        private void FormExamenes_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con los exámenes
            foreach (var examenList in examenesPorPuesto.Values)
            {
                foreach (var examen in examenList)
                {
                    if (!comboBoxExamenes.Items.Contains(examen)) // Evitar duplicados
                    {
                        comboBoxExamenes.Items.Add(examen);
                    }
                }
            }

            // Obtener empleados desde la base de datos
            empleados = ObtenerEmpleadosDesdeBaseDeDatos();
        }

        private MySqlConnection GetMySqlConnection()
        {
            // String de conexión
            string connectionString = "Server=127.0.0.1;Database=sistema;User ID=root;Password=;SslMode=none;";
            return new MySqlConnection(connectionString);
        }

        private List<Empleado> ObtenerEmpleadosDesdeBaseDeDatos()
        {
            var listaEmpleados = new List<Empleado>();

            try
            {
                using (var conn = GetMySqlConnection())
                {
                    conn.Open();
                    string query = "SELECT EmpleadoID, Nombres, ApellidoPaterno, ApellidoMaterno, NumeroNomina, Puesto FROM Empleados";

                    using (var command = new MySqlCommand(query, conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaEmpleados.Add(new Empleado
                            {
                                EmpleadoID = reader.GetInt32("EmpleadoID"),
                                Nombre = reader.GetString("Nombres"),
                                ApellidoPaterno = reader.GetString("ApellidoPaterno"),
                                ApellidoMaterno = reader.GetString("ApellidoMaterno"),
                                NumeroNomina = reader.GetString("NumeroNomina"),
                                Puesto = reader.GetString("Puesto")
                            });
                        }
                    }
                }
                Console.WriteLine("Número de empleados recuperados: " + listaEmpleados.Count);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message);
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
            var empleadosFiltrados = empleados
                .Where(emp => examenesPorPuesto.ContainsKey(emp.Puesto) && examenesPorPuesto[emp.Puesto].Contains(examenSeleccionado))
                .ToList();

            dataGridViewEmpleados.Rows.Clear();

            if (empleadosFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontraron empleados que requieran este examen.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var emp in empleadosFiltrados)
            {
                var fila = new DataGridViewRow();
                fila.CreateCells(dataGridViewEmpleados, emp.EmpleadoID, emp.NumeroNomina, $"{emp.Nombre} {emp.ApellidoPaterno}", emp.Puesto);

                // Establecer el estado inicial
                string estado = ObtenerEstadoExamen(emp.EmpleadoID, examenSeleccionado);
                ActualizarEstadoFila(fila, estado);

                // Agregar la fila al DataGridView
                dataGridViewEmpleados.Rows.Add(fila);
            }
        }

        private string ObtenerEstadoExamen(int empleadoID, string examen)
        {
            string estado = ""; // Sin calificación por defecto

            try
            {
                using (var conn = GetMySqlConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT Estado FROM EstadoExamen 
                WHERE EmpleadoID = @EmpleadoID AND Examen = @Examen 
                ORDER BY FechaExamen DESC 
                LIMIT 1"; // Selecciona el estado más reciente según la fecha

                    using (var command = new MySqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                        command.Parameters.AddWithValue("@Examen", examen);

                        var resultado = command.ExecuteScalar();
                        if (resultado != null)
                            estado = resultado.ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener estado del examen: " + ex.Message);
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

        private void ActualizarEstadoFila(DataGridViewRow fila, string estado)
        {
            // Limpiar color de fondo
            fila.DefaultCellStyle.BackColor = Color.White;

            switch (estado)
            {
                case "No pasó":
                    fila.DefaultCellStyle.BackColor = Color.Red; // Color rojo
                    break;
                case "Pasó":
                    fila.DefaultCellStyle.BackColor = Color.Yellow; // Color amarillo
                    break;
                case "Aprobado":
                    fila.DefaultCellStyle.BackColor = Color.Green; // Color verde
                    break;
                default:
                    break;
            }
        }

        private void GuardarEstadoExamen(int empleadoID, string examen, string estado)
        {
            using (var conn = GetMySqlConnection())
            {
                conn.Open();
                string query = "INSERT INTO EstadoExamen (EmpleadoID, Examen, Estado) VALUES (@EmpleadoID, @Examen, @Estado) " +
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

        private void button1_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroNomina { get; set; }
        public string Puesto { get; set; }
    }
}