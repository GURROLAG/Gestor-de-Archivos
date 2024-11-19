using Common.Cache;
using DataAccess.MySQL;
using Domain;
using System.Runtime.InteropServices;

namespace Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASE�A")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASE�A";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "USUARIO")
            {
                if (txtpass.Text != "CONTRASE�A")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);
                    if (validLogin)
                    {
                        this.Hide();

                        // Obt�n el ID del usuario para registrar la actividad
                        int usuarioId = user.GetUsuarioID(txtuser.Text);

                        // Registrar actividad de inicio de sesi�n
                        RegistroActividad registro = new RegistroActividad
                        {
                            UsuarioID = usuarioId,
                            DocumentoID = null, // No aplica al inicio de sesi�n
                            Actividad = "Inicio de sesi�n",
                            DetallesActividad = "El usuario ha iniciado sesi�n correctamente.",
                            FechaHora = DateTime.Now // Hora actual
                        };

                        RegistroActividadesDao actividadesDao = new RegistroActividadesDao();
                        actividadesDao.AddActividad(registro); // A�adir actividad a la base de datos

                        // Obt�n el rol y la planta del usuario
                        string rolUsuario = user.GetRolPorUsuario(txtuser.Text);
                        string plantaUsuario = user.GetPlantaPorUsuario(txtuser.Text);

                        // Asigna el usuario actual al cach�
                        UserCache.CurrentUser = new User
                        {
                            UsuarioID = usuarioId,
                            NombreUsuario = txtuser.Text,
                            Password = txtpass.Text, // Otras propiedades que necesites
                            Rol = rolUsuario,
                            Planta = plantaUsuario
                        };

                        // Crea una instancia de Interfaz con rol y planta
                        Interfaz mainMenu = new Interfaz(rolUsuario, plantaUsuario);
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                    }
                    else
                    {
                        msgError("Usuario o Contrase�a incorrectos. \n Por favor intente otra vez.");
                        txtpass.Text = "CONTRASE�A";
                        txtuser.Focus();
                    }
                }
                else msgError("Por favor Ingrese su Contrase�a.");
            }
            else msgError("Por favor Ingrese su Usuario.");
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "      " + msg;
            lblErrorMessage.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "CONTRASE�A";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "USUARIO";
            lblErrorMessage.Visible = false;
            this.Show();
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            FormRegistrarUsuario formRegistrar = new FormRegistrarUsuario();
            formRegistrar.Show();
        }
    }
}
