namespace Presentation
{
    partial class FormRegistrarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarUsuario));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            chkInyeccion = new CheckBox();
            chkMetalMecanica = new CheckBox();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(185, 26);
            label1.Name = "label1";
            label1.Size = new Size(172, 22);
            label1.TabIndex = 0;
            label1.Text = "Registrar Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(82, 102);
            label2.Name = "label2";
            label2.Size = new Size(145, 22);
            label2.TabIndex = 1;
            label2.Text = "Nombre Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(82, 182);
            label3.Name = "label3";
            label3.Size = new Size(105, 22);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(82, 238);
            label5.Name = "label5";
            label5.Size = new Size(63, 22);
            label5.TabIndex = 4;
            label5.Text = "Planta";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(233, 101);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(284, 23);
            txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(233, 181);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(284, 23);
            txtPassword.TabIndex = 6;
            // 
            // chkInyeccion
            // 
            chkInyeccion.AutoSize = true;
            chkInyeccion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkInyeccion.ForeColor = Color.White;
            chkInyeccion.Location = new Point(233, 238);
            chkInyeccion.Name = "chkInyeccion";
            chkInyeccion.Size = new Size(150, 25);
            chkInyeccion.TabIndex = 7;
            chkInyeccion.Text = "Inyeccion Plastica";
            chkInyeccion.UseVisualStyleBackColor = true;
            chkInyeccion.CheckedChanged += chkInyeccion_CheckedChanged;
            // 
            // chkMetalMecanica
            // 
            chkMetalMecanica.AutoSize = true;
            chkMetalMecanica.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMetalMecanica.ForeColor = Color.White;
            chkMetalMecanica.Location = new Point(389, 238);
            chkMetalMecanica.Name = "chkMetalMecanica";
            chkMetalMecanica.Size = new Size(137, 25);
            chkMetalMecanica.TabIndex = 8;
            chkMetalMecanica.Text = "Metal Mecanica";
            chkMetalMecanica.UseVisualStyleBackColor = true;
            chkMetalMecanica.CheckedChanged += chkMetalMecanica_CheckedChanged;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Maroon;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(90, 329);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(137, 26);
            btnRegistrar.TabIndex = 9;
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(128, 64, 0);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(325, 329);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 26);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormRegistrarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(548, 381);
            Controls.Add(btnCancelar);
            Controls.Add(btnRegistrar);
            Controls.Add(chkMetalMecanica);
            Controls.Add(chkInyeccion);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormRegistrarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistrarUsuario";
            MouseDown += FormRegistrarUsuario_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private CheckBox chkInyeccion;
        private CheckBox chkMetalMecanica;
        private Button btnRegistrar;
        private Button btnCancelar;
    }
}