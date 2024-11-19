using DataAccess.MySQL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common.Cache;
using System.Runtime.InteropServices;

namespace Presentation
{
    public partial class FormAgregarUsuario : Form
    {
        private UserDao userDao; // Declara una instancia de UserDao
        public FormAgregarUsuario()
        {
            InitializeComponent();
            userDao = new UserDao(); // Inicializa userDao

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void FormAgregarUsuario_Load(object sender, EventArgs e)
        {
            CargarRoles(); // Carga los roles
            CargarPlantas(); // Carga las plantas
        }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                NombreUsuario = txtNombreUsuario.Text,
                Password = txtPassword.Text,
                Rol = cmbRol.SelectedItem.ToString(),
                Planta = cmbPlanta.SelectedItem.ToString() // Asigna el nombre de la planta
            };

            // Aquí llamamos a la función para agregar el usuario
            userDao.AddUser(newUser);

            // Vuelve a cargar los usuarios en el DataGridView
            CargarUsuarios(); // Asegúrate de que este método esté presente y cargue los usuarios

            // También puedes recargar los ComboBox si es necesario
            CargarRoles();
            CargarPlantas();

            this.Close(); // Cierra el formulario después de agregar
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarUsuarios()
        {
            // Esta lógica debe ser adecuada para tu implementación.
            List<User> usuarios = userDao.GetAllUsers(); // Obtiene la lista de usuarios desde la base de datos
            // Por ejemplo: dgvUsers.DataSource = usuarios;
        }

        private void FormAgregarUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
