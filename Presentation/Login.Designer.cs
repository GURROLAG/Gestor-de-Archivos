namespace Presentation
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            txtuser = new TextBox();
            txtpass = new TextBox();
            label1 = new Label();
            btnlogin = new Button();
            btnsalir = new PictureBox();
            btnminimizar = new PictureBox();
            lblErrorMessage = new Label();
            btnRegistrarUsuario = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnsalir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 330);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(34, 81);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(169, 169);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // txtuser
            // 
            txtuser.BackColor = Color.FromArgb(15, 15, 15);
            txtuser.BorderStyle = BorderStyle.None;
            txtuser.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtuser.ForeColor = Color.DimGray;
            txtuser.Location = new Point(316, 92);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(400, 19);
            txtuser.TabIndex = 2;
            txtuser.Text = "USUARIO";
            txtuser.Enter += txtuser_Enter;
            txtuser.Leave += txtuser_Leave;
            // 
            // txtpass
            // 
            txtpass.BackColor = Color.FromArgb(15, 15, 15);
            txtpass.BorderStyle = BorderStyle.None;
            txtpass.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpass.ForeColor = Color.DimGray;
            txtpass.Location = new Point(316, 145);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(400, 19);
            txtpass.TabIndex = 3;
            txtpass.Text = "CONTRASEÑA";
            txtpass.Enter += txtpass_Enter;
            txtpass.Leave += txtpass_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(456, 9);
            label1.Name = "label1";
            label1.Size = new Size(94, 34);
            label1.TabIndex = 3;
            label1.Text = "LOGIN";
            // 
            // btnlogin
            // 
            btnlogin.BackColor = Color.FromArgb(40, 40, 40);
            btnlogin.FlatAppearance.BorderSize = 0;
            btnlogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btnlogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btnlogin.FlatStyle = FlatStyle.Flat;
            btnlogin.ForeColor = Color.LightGray;
            btnlogin.Location = new Point(316, 227);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(400, 40);
            btnlogin.TabIndex = 3;
            btnlogin.Text = "ACCEDER";
            btnlogin.UseVisualStyleBackColor = false;
            btnlogin.Click += btnlogin_Click;
            // 
            // btnsalir
            // 
            btnsalir.Image = (Image)resources.GetObject("btnsalir.Image");
            btnsalir.Location = new Point(763, 0);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(17, 18);
            btnsalir.SizeMode = PictureBoxSizeMode.Zoom;
            btnsalir.TabIndex = 6;
            btnsalir.TabStop = false;
            btnsalir.Click += btnsalir_Click;
            // 
            // btnminimizar
            // 
            btnminimizar.Image = (Image)resources.GetObject("btnminimizar.Image");
            btnminimizar.Location = new Point(742, 0);
            btnminimizar.Name = "btnminimizar";
            btnminimizar.Size = new Size(19, 19);
            btnminimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnminimizar.TabIndex = 7;
            btnminimizar.TabStop = false;
            btnminimizar.Click += btnminimizar_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Image = (Image)resources.GetObject("lblErrorMessage.Image");
            lblErrorMessage.ImageAlign = ContentAlignment.TopLeft;
            lblErrorMessage.Location = new Point(316, 185);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(95, 17);
            lblErrorMessage.TabIndex = 9;
            lblErrorMessage.Text = "Error Message";
            lblErrorMessage.Visible = false;
            // 
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.BackColor = Color.Black;
            btnRegistrarUsuario.FlatAppearance.BorderSize = 0;
            btnRegistrarUsuario.FlatStyle = FlatStyle.Flat;
            btnRegistrarUsuario.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegistrarUsuario.ForeColor = Color.Gainsboro;
            btnRegistrarUsuario.Location = new Point(447, 295);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(140, 35);
            btnRegistrarUsuario.TabIndex = 10;
            btnRegistrarUsuario.Text = "Registrar Usuario";
            btnRegistrarUsuario.UseVisualStyleBackColor = false;
            btnRegistrarUsuario.Click += btnRegistrarUsuario_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(508, 275);
            label2.Name = "label2";
            label2.Size = new Size(19, 19);
            label2.TabIndex = 11;
            label2.Text = "o";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(label2);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(lblErrorMessage);
            Controls.Add(btnminimizar);
            Controls.Add(btnsalir);
            Controls.Add(btnlogin);
            Controls.Add(label1);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += Form1_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnsalir).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnminimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtuser;
        private TextBox txtpass;
        private Label label1;
        private Button btnlogin;
        private PictureBox btnsalir;
        private PictureBox pictureBox3;
        private PictureBox btnminimizar;
        private Label lblErrorMessage;
        private Button btnRegistrarUsuario;
        private Label label2;
    }
}
