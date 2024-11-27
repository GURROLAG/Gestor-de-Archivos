using System.Drawing.Text;
using System.Numerics;
using System.Runtime.InteropServices;
using Common.Cache;
using DataAccess.MySQL;

namespace Presentation
{
    public partial class Interfaz : Form
    {
        private string rolActual; // Almacena el rol del usuario actual
        private string plantaActual;  // Almacena la planta del usuario actual

        // Modificado para recibir tanto el rol como la planta
        public Interfaz(string rol, string planta)
        {
            InitializeComponent();
            rolActual = rol; // Se asigna el rol del usuario actual
            plantaActual = planta; // Se asigna la planta del usuario actual
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // M�todo para redimensionar/cambiar tama�o del formulario en tiempo de ejecuci�n
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        // Dibujar rect�ngulo para el tama�o
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.PanelContenedor.Region = region;
            this.Invalidate();
        }

        // Color y grip de rect�ngulo inferior
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�Est�s seguro de cerrar la aplicaci�n?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        int lx, ly;
        int sw, sh;

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PanelFormularios.Controls.OfType<MiForm>().FirstOrDefault(); // Busca en la colecci�n el formulario
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelFormularios.Controls.Add(formulario);
                PanelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, EventArgs e)
        {
            if (Application.OpenForms["Form1"] == null)
                btnExamenesMM.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Form2"] == null)
                btnPL.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Form3"] == null)
                btnMetal.BackColor = Color.FromArgb(4, 41, 68);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�Est�s seguro de cerrar tu sesi�n?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Crear una lista temporal para almacenar los formularios a cerrar
                List<Form> formsToClose = new List<Form>();

                // Recorrer los formularios abiertos y a�adir a la lista los que no son el de Login
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name != "Login") // Aseg�rate de que el nombre coincide con el formulario de Login
                    {
                        formsToClose.Add(form);
                    }
                }

                // Cerrar los formularios almacenados en la lista
                foreach (Form form in formsToClose)
                {
                    form.Close();
                }


                // Verificar si ya hay una instancia del formulario de Login abierta
                Form loginForm = Application.OpenForms["Login"];
                if (loginForm == null)
                {
                    // Solo crea y muestra una nueva instancia del formulario de Login si no est� abierta
                    Login newLoginForm = new Login(); // Aseg�rate de que el nombre sea el correcto
                    newLoginForm.Show();
                }

                // Cerrar el formulario actual
                this.Close();
            }
        }

        private void PanelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Interfaz_Load_1(object sender, EventArgs e)
        {
            ConfigurarPermisosBotones();
        }


        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form1>();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormExamenes>();
        }

        private void btnMetal_Click(object sender, EventArgs e)
        {
            AbrirFormulario<AreasInyeccionPlastica>();
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            AbrirFormulario<AreasMetalMecanica>();
        }
        // Configuraci�n de permisos seg�n el rol espec�fico
        private void ConfigurarPermisosBotones()
        {
            // Verifica el rol actual
            //MessageBox.Show("Rol Actual: " + rolActual);

            // Restablecer botones por defecto
            btnExamenesMM.Enabled = false;
            btnPL.Enabled = false;
            btnMetal.Enabled = false;
            btnUsuarios.Enabled = false;
            btnActividades.Enabled = false;

            // Asignar permisos seg�n el rol espec�fico
            switch (rolActual)
            {
                case "UsuarioPl�stico":
                    btnPL.Enabled = true;     // Puede acceder a Inyecci�n Pl�stica
                    break;

                case "UsuarioMetal":
                    btnExamenesMM.Enabled = true; // Puede ver el inicio
                    btnMetal.Enabled = true;  // Puede acceder a Metal-Mec�nica
                    break;

                case "Licenciado":
                    btnExamenesMM.Enabled = true; // Puede ver el inicio
                    btnPL.Enabled = true;     // Puede acceder a Inyecci�n Pl�stica
                    btnMetal.Enabled = true;   // Puede acceder a Metal-Mec�nica
                    btnUsuarios.Enabled = true; // Puede gestionar usuarios
                    btnActividades.Enabled = true;
                    break;

                case "Administrador":
                    btnExamenesMM.Enabled = true;  // Siempre habilitado
                    btnPL.Enabled = true;      // Puede acceder a Inyecci�n Pl�stica
                    btnMetal.Enabled = true;   // Puede acceder a Metal-Mec�nica
                    btnUsuarios.Enabled = true; // Puede gestionar usuarios
                    btnActividades.Enabled = true;
                    break;

                case "GerenciaPl�sticos":
                    
                    btnPL.Enabled = true;      // Puede acceder a Inyecci�n Pl�stica
                                               // btnMetal y btnUsuarios ya est�n en false
                    break;

                case "GerenciaMetal":
                    btnExamenesMM.Enabled = true;  // Siempre habilitado
                    btnMetal.Enabled = true;   // Puede acceder a Metal-Mec�nica
                                               // btnPL y btnUsuarios ya est�n en false
                    break;
            }
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormRegistroActividades>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormExamenesPL>();
        }

        

    }
}
