namespace Presentation
{
    partial class FormAgregarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarUsuario));
            label1 = new Label();
            txtNombreUsuario = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAgregar = new Button();
            button1 = new Button();
            cmbRol = new ComboBox();
            cmbPlanta = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(309, 23);
            label1.Name = "label1";
            label1.Size = new Size(174, 24);
            label1.TabIndex = 0;
            label1.Text = "Agregar Usuario";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(383, 108);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(286, 23);
            txtNombreUsuario.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(383, 173);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(286, 23);
            txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(180, 108);
            label2.Name = "label2";
            label2.Size = new Size(160, 22);
            label2.TabIndex = 6;
            label2.Text = "Nombre Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(222, 173);
            label3.Name = "label3";
            label3.Size = new Size(118, 22);
            label3.TabIndex = 7;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(300, 245);
            label4.Name = "label4";
            label4.Size = new Size(40, 22);
            label4.TabIndex = 8;
            label4.Text = "Rol";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(272, 315);
            label5.Name = "label5";
            label5.Size = new Size(68, 22);
            label5.TabIndex = 9;
            label5.Text = "Planta";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.SpringGreen;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(222, 390);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(133, 35);
            btnAgregar.TabIndex = 11;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(468, 390);
            button1.Name = "button1";
            button1.Size = new Size(133, 35);
            button1.TabIndex = 12;
            button1.Text = "CANCELAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(383, 245);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(158, 23);
            cmbRol.TabIndex = 13;
            // 
            // cmbPlanta
            // 
            cmbPlanta.FormattingEnabled = true;
            cmbPlanta.Location = new Point(383, 318);
            cmbPlanta.Name = "cmbPlanta";
            cmbPlanta.Size = new Size(158, 23);
            cmbPlanta.TabIndex = 14;
            // 
            // FormAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbPlanta);
            Controls.Add(cmbRol);
            Controls.Add(button1);
            Controls.Add(btnAgregar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAgregarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAgregarUsuario";
            Load += FormAgregarUsuario_Load;
            MouseDown += FormAgregarUsuario_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreUsuario;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAgregar;
        private Button button1;
        private ComboBox cmbRol;
        private ComboBox cmbPlanta;
    }
}