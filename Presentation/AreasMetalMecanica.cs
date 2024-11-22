using Common.Cache;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class AreasMetalMecanica : Form
    {
        public AreasMetalMecanica()
        {
            InitializeComponent();
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGasket_Click(object sender, EventArgs e)
        {
            FormGasket formGasket = new FormGasket();
            formGasket.Show();
        }

        private void btnTaller_Click(object sender, EventArgs e)
        {
            FormTaller formTaller = new FormTaller();
            formTaller.Show();
        }

        private void btnLogistica_Click(object sender, EventArgs e)
        {
            FormLogistica formLogistica = new FormLogistica();
            formLogistica.Show();
        }

        private void btnSistemas_Click(object sender, EventArgs e)
        {
            FormSistemas formSistemas = new FormSistemas();
            formSistemas.Show();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            FormAlmacen formAlmacen = new FormAlmacen();
            formAlmacen.Show();
        }

        private void btnCalidad_Click(object sender, EventArgs e)
        {
            FormCalidad formCalidad = new FormCalidad();
            formCalidad.Show();
        }

        private void btnCNC_Click(object sender, EventArgs e)
        {
            FormCNC formCNC = new FormCNC();
            formCNC.Show();
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            FormGestionarEmpleados formGestionarEmpleados = new FormGestionarEmpleados();
            formGestionarEmpleados.Show();
        }
    }
}
