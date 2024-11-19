using DataAccess.MySQL;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FormRegistrarUsuario : Form
    {
        public FormRegistrarUsuario()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validar que todos los campos estén llenos
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos.");
                return;
            }

            // Validar que al menos una planta esté seleccionada
            string plantaSeleccionada = ObtenerPlantaSeleccionada();
            if (string.IsNullOrEmpty(plantaSeleccionada))
            {
                MessageBox.Show("Por favor, seleccione una planta.");
                return;
            }

            UserDao userDao = new UserDao();
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Asignar rol basado en la planta seleccionada
            string rol = plantaSeleccionada == "InyecciónPlásticos" ? "UsuarioPlástico" : "UsuarioMetal";

            try
            {
                // Registrar el usuario con la planta seleccionada y el rol correspondiente
                userDao.CreateUser(username, password, plantaSeleccionada, rol);
                MessageBox.Show("Usuario registrado correctamente.");
                this.Close(); // Cierra el formulario después de registrar el usuario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}");
            }
        }

        // Obtener la planta seleccionada
        private string ObtenerPlantaSeleccionada()
        {
            if (chkInyeccion.Checked)
            {
                return "InyecciónPlásticos"; // Si seleccionan Inyección Plástica
            }
            else if (chkMetalMecanica.Checked)
            {
                return "MetalMecanica"; // Si seleccionan Metal-Mecánica
            }

            return null; // Si no se selecciona ninguna planta
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkInyeccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInyeccion.Checked)
            {
                chkMetalMecanica.Checked = false; // Desmarca "Metal-Mecánica" si se selecciona "Inyección Plástica"
            }
        }

        private void chkMetalMecanica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMetalMecanica.Checked)
            {
                chkInyeccion.Checked = false; // Desmarca "Inyección Plástica" si se selecciona "Metal-Mecánica"
            }
        }

        private void FormRegistrarUsuario_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
