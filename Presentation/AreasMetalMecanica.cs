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
            VerificarAccesoAdministrador(); // Llamar al método para verificar acceso
        }

        private void VerificarAccesoAdministrador()
        {
            // Verificar si el usuario actual está configurado
            if (UserCache.CurrentUser != null)
            {
                // Habilitar o deshabilitar el botón según el rol
                if (UserCache.CurrentUser.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
                {
                    btnVerEmpleados.Visible = true;  // Mostrar el botón si es administrador
                    btnVerEmpleados.Enabled = true;   // Habilitar el botón
                }
                else
                {
                    btnVerEmpleados.Visible = false;  // Ocultar el botón si no es administrador
                    btnVerEmpleados.Enabled = false;   // También puedes deshabilitarlo si es necesario
                }
            }
            else
            {
                btnVerEmpleados.Visible = false; // Ocultar el botón si no hay usuario
            }
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
