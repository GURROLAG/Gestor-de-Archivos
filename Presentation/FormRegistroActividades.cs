using DataAccess.MySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormRegistroActividades : Form
    {
        private RegistroActividadesDao actividadesDao; // Declarar la instancia
        public FormRegistroActividades()
        {
            InitializeComponent();
            CargarActividades();
            actividadesDao = new RegistroActividadesDao(); // Inicializar la instancia
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarActividades()
        {
            RegistroActividadesDao actividadesDao = new RegistroActividadesDao(); // Crea una instancia de la clase DAO
            var actividades = actividadesDao.ObtenerActividades(); // Llama al método para obtener actividades
            dataGridViewActividades.DataSource = actividades; // Asigna la lista de actividades al DataGridView
            dataGridViewActividades.DataSource = actividades;
            EstiloDataGridView(dataGridViewActividades);
        }
        private void EstiloDataGridView(DataGridView dgv)
        {
            // Establecer el estilo del DataGridView
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta las columnas al ancho del DataGridView
            dgv.RowHeadersVisible = false; // Oculta la columna de encabezados de filas

            // Estilos de encabezados
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80); // Color de fondo
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Color de texto
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Fuente

            // Estilos de las celdas
            dgv.DefaultCellStyle.BackColor = Color.White; // Color de fondo de las celdas
            dgv.DefaultCellStyle.ForeColor = Color.Black; // Color de texto de las celdas
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9); // Fuente

            // Alternar colores de fila
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230); // Color de fondo de filas alternas

            // Configurar el borde del DataGridView
            dgv.BorderStyle = BorderStyle.None; // Sin borde
            dgv.EnableHeadersVisualStyles = false; // Permite usar estilos personalizados

            // Estilo de selección
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); // Color de fondo al seleccionar
            dgv.DefaultCellStyle.SelectionForeColor = Color.White; // Color de texto al seleccionar

            // Ajustar el tamaño de las filas
            dgv.RowTemplate.Height = 30; // Altura de las filas

            // Permitir el ajuste de texto en las celdas
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Permitir el ajuste de texto
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Ajustar el tamaño de la columna
            }

            // Ajustar la altura de las filas para que se ajuste al texto
            dgv.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    var cellValue = dgv[e.ColumnIndex, e.RowIndex].Value?.ToString();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        // Estimar la altura de la fila basado en el contenido de la celda
                        Size textSize = TextRenderer.MeasureText(cellValue, dgv.DefaultCellStyle.Font);
                        int desiredHeight = textSize.Height + dgv.RowTemplate.Height - 4; // Ajustar según sea necesario
                        dgv.Rows[e.RowIndex].Height = desiredHeight;
                    }
                }
            };
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DateTime desde = dateTimePickerDesde.Value;
            DateTime hasta = dateTimePickerHasta.Value;

            // Asegúrate de que la fecha de inicio sea menor que la fecha de fin
            if (desde > hasta)
            {
                MessageBox.Show("La fecha de inicio debe ser anterior a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Filtrar las actividades
            var actividadesFiltradas = actividadesDao.ObtenerActividadesPorFecha(desde, hasta);

            // Actualiza el DataGridView con las actividades filtradas
            dataGridViewActividades.DataSource = actividadesFiltradas;
        }

        private void cmbFiltroActividades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
