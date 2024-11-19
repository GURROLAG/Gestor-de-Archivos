using DataAccess.MySQL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common.Cache;
using System.Runtime.InteropServices;

namespace Presentation
{
    public partial class FormActualizarUsuario : Form
    {
        private UserDao userDao;

        private User usuarioAEditar;

        public FormActualizarUsuario(User usuario)
        {
            InitializeComponent();
            userDao = new UserDao();

            usuarioAEditar = usuario;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void CargarRoles()
        {
            cmbRol.Items.Clear(); // Limpia los items actuales

            // Agregar roles manualmente
            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Gerencia");
            cmbRol.Items.Add("Licenciado");
            cmbRol.Items.Add("UsuarioPlástico");
            cmbRol.Items.Add("UsuarioMetal");


            if (cmbRol.Items.Count > 0)
            {
                cmbRol.SelectedIndex = 0; // Selecciona el primer elemento
            }
        }

        private void CargarPlantas()
        {
            cmbPlanta.Items.Clear(); // Limpia los items actuales

            // Agregar plantas manualmente
            cmbPlanta.Items.Add("InyeccionPlasticos");
            cmbPlanta.Items.Add("MetalMecanica");
            cmbPlanta.Items.Add("Ambas");

            if (cmbPlanta.Items.Count > 0)
            {
                cmbPlanta.SelectedIndex = 0; // Selecciona el primer elemento
            }
        }

        private void CargarDatosUsuario()
        {
            if (usuarioAEditar != null)
            {
                txtNombreUsuario.Text = usuarioAEditar.NombreUsuario;
                txtPassword.Text = usuarioAEditar.Password;
                // Los roles y plantas se seleccionan en CargarRoles() y CargarPlantas()
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cmbRol.SelectedItem == null ||
                cmbPlanta.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear un objeto User actualizado
            User updatedUser = new User
            {
                UsuarioID = usuarioAEditar.UsuarioID, // Asegúrate de incluir el UsuarioID
                NombreUsuario = txtNombreUsuario.Text,
                Password = txtPassword.Text,
                Rol = cmbRol.SelectedItem.ToString(),
                Planta = cmbPlanta.SelectedItem.ToString()
            };

            // Llamar a la función para actualizar el usuario
            userDao.UpdateUser(updatedUser);

            MessageBox.Show("Usuario actualizado correctamente.");

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormActualizarUsuario_Load_1(object sender, EventArgs e)
        {
            CargarRoles(); // Carga los roles al iniciar el formulario
            CargarPlantas(); // Carga las plantas al iniciar el formulario
        }

        private void FormActualizarUsuario_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
