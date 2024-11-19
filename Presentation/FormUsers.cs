using DataAccess.MySQL;
using Common.Cache;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private UserDao userDao; // Declarar userDao

        public Form1()
        {
            InitializeComponent();
            userDao = new UserDao(); // Inicializar userDao
            CargarUsuarios(); // Cargar los usuarios en el DataGridView cuando se inicializa el formulario
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarUsuarios()
        {
            List<User> usuarios = userDao.GetAllUsers(); // Obtener la lista de usuarios desde la base de datos
            dgvUsers.DataSource = null;  // Limpiar el DataSource anterior
            dgvUsers.DataSource = usuarios;  // Asignar la lista al DataGridView

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            User usuarioSeleccionado = ObtenerUsuarioSeleccionado(); // M�todo para obtener el usuario seleccionado
            if (usuarioSeleccionado != null)
            {
                FormActualizarUsuario formActualizar = new FormActualizarUsuario(usuarioSeleccionado);
                formActualizar.ShowDialog(); // Muestra el formulario como un di�logo

                CargarUsuarios(); // Actualizar la lista de usuarios despu�s de editar
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para editar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarUsuario formAgregarUsuario = new FormAgregarUsuario();
            formAgregarUsuario.ShowDialog(); // Abre el formulario para agregar usuarios
            CargarUsuarios(); // Actualiza la lista de usuarios despu�s de agregar
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado alg�n usuario en el DataGridView
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Obtener el ID del usuario seleccionado
                int usuarioID = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UsuarioID"].Value);

                // Confirmar la eliminaci�n
                var confirmResult = MessageBox.Show("�Est�s seguro de eliminar este usuario?",
                                                    "Confirmar eliminaci�n",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Llamar al m�todo de UserDao para eliminar el usuario
                    userDao.DeleteUser(usuarioID);

                    // Actualizar el DataGridView para reflejar los cambios
                    CargarUsuarios(); // Refrescar la lista de usuarios
                    MessageBox.Show("Usuario eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.");
            }
        }

        private User ObtenerUsuarioSeleccionado()
        {
            // Verifica si hay una fila seleccionada en el DataGridView
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Obtener el objeto User desde la fila seleccionada
                return (User)dgvUsers.SelectedRows[0].DataBoundItem; // Ajusta seg�n tu implementaci�n
            }
            return null;
        }
        private void PersonalizarDataGridView()
        {
            // Cambiar el color del encabezado
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font(dgvUsers.Font, FontStyle.Bold);

            // Cambiar el color de fondo de las filas alternas
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Cambiar el color de las celdas
            dgvUsers.DefaultCellStyle.BackColor = Color.Beige;
            dgvUsers.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.White;

            // Borde de las celdas
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Bordes del DataGridView
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.GridColor = Color.LightGray;

            // Alinear el texto al centro en las celdas
            dgvUsers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar autom�ticamente el tama�o de las columnas
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Quitar el modo de multiselecci�n
            dgvUsers.MultiSelect = false;

            // Evitar que el usuario agregue filas nuevas
            dgvUsers.AllowUserToAddRows = false;

            // Evitar que el usuario elimine filas
            dgvUsers.AllowUserToDeleteRows = false;

            // Cambiar el cursor al pasar sobre las celdas
            dgvUsers.Cursor = Cursors.Hand;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PersonalizarDataGridView();
        }
    }
}
