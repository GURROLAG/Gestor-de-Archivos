using DataAccess;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormCrearCarpeta : Form
    {
        private readonly int empleadoId;
        private readonly CarpetasInyeccionDao carpetasDao;

        public FormCrearCarpeta(int empleadoId)
        {
            InitializeComponent();
            this.empleadoId = empleadoId;
            carpetasDao = new CarpetasInyeccionDao();
        }

        private void btnCrearCarpeta_Click(object sender, EventArgs e)
        {
            string nombreCarpeta = txtNombreCarpeta.Text;  // Solo se necesita el nombre de la carpeta

            if (!string.IsNullOrWhiteSpace(nombreCarpeta))
            {
                carpetasDao.CrearCarpeta(empleadoId, nombreCarpeta);  // Solo pasamos el nombre
                MessageBox.Show("Carpeta creada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
