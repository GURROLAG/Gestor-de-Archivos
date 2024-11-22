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
    public partial class AreasInyeccionPlastica : Form
    {
        public AreasInyeccionPlastica()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdministrativo_Click(object sender, EventArgs e)
        {
            FormAdministrativo formAdministrativo = new FormAdministrativo();
            formAdministrativo.Show();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            FormAlmacenPL formAlmacenPL = new FormAlmacenPL();
            formAlmacenPL.Show();
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            FormChoferes formChoferes = new FormChoferes();
            formChoferes.Show();
        }

        private void btnEnsamble_Click(object sender, EventArgs e)
        {
            FormEnsamble formEnsamble = new FormEnsamble();
            formEnsamble.Show();
        }

        private void btnInyeccionAutomatica_Click(object sender, EventArgs e)
        {
            FormInyeccionAutomatica formInyeccionAutomatica = new FormInyeccionAutomatica();
            formInyeccionAutomatica.Show();
        }

        private void InyeccionManual_Click(object sender, EventArgs e)
        {
            FormInyeccionManual formInyeccionManual = new FormInyeccionManual();
            formInyeccionManual.Show();
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            FormMantenimiento formMantenimiento = new FormMantenimiento();
            formMantenimiento.Show();
        }

        private void btnRebabeo_Click(object sender, EventArgs e)
        {
            FormRebabeo formRebabeo = new FormRebabeo();
            formRebabeo.Show();
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {
            FormGestionarEmpleadosPL formGestionarEmpleadosPL = new FormGestionarEmpleadosPL();
            formGestionarEmpleadosPL.Show();
        }

        private void AreasInyeccionPlastica_Load(object sender, EventArgs e)
        {

        }
    }
}
