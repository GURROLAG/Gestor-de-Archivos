namespace Presentation
{
    partial class FormActualizarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActualizarUsuario));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombreUsuario = new TextBox();
            txtPassword = new TextBox();
            cmbRol = new ComboBox();
            cmbPlanta = new ComboBox();
            btnActualizar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(336, 20);
            label1.Name = "label1";
            label1.Size = new Size(205, 24);
            label1.TabIndex = 0;
            label1.Text = "Actualizar Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Constantia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(182, 118);
            label2.Name = "label2";
            label2.Size = new Size(177, 26);
            label2.TabIndex = 1;
            label2.Text = "Nombre Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Constantia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(234, 181);
            label3.Name = "label3";
            label3.Size = new Size(125, 26);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Constantia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(312, 244);
            label4.Name = "label4";
            label4.Size = new Size(47, 26);
            label4.TabIndex = 3;
            label4.Text = "Rol";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Constantia", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(284, 294);
            label5.Name = "label5";
            label5.Size = new Size(75, 26);
            label5.TabIndex = 4;
            label5.Text = "Planta";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(427, 121);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(300, 23);
            txtNombreUsuario.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(427, 186);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 23);
            txtPassword.TabIndex = 6;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(427, 247);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(168, 23);
            cmbRol.TabIndex = 7;
            // 
            // cmbPlanta
            // 
            cmbPlanta.FormattingEnabled = true;
            cmbPlanta.Location = new Point(427, 297);
            cmbPlanta.Name = "cmbPlanta";
            cmbPlanta.Size = new Size(168, 23);
            cmbPlanta.TabIndex = 8;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Maroon;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(260, 415);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(130, 32);
            btnActualizar.TabIndex = 9;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Green;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(474, 415);
            button1.Name = "button1";
            button1.Size = new Size(130, 32);
            button1.TabIndex = 10;
            button1.Text = "CANCELAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormActualizarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(896, 490);
            Controls.Add(button1);
            Controls.Add(btnActualizar);
            Controls.Add(cmbPlanta);
            Controls.Add(cmbRol);
            Controls.Add(txtPassword);
            Controls.Add(txtNombreUsuario);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormActualizarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormActualizarUsuario";
            Load += FormActualizarUsuario_Load_1;
            MouseDown += FormActualizarUsuario_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombreUsuario;
        private TextBox txtPassword;
        private ComboBox cmbRol;
        private ComboBox cmbPlanta;
        private Button btnActualizar;
        private Button button1;
    }
}