namespace Presentation
{
    partial class FormEditarEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditarEmpleado));
            label2 = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            comboBoxArea = new ComboBox();
            label7 = new Label();
            txtPuesto = new TextBox();
            txtNumeroNomina = new TextBox();
            label6 = new Label();
            txtApellidoMaterno = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtApellidoPaterno = new TextBox();
            label3 = new Label();
            txtNombreEmpleado = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(328, 9);
            label2.Name = "label2";
            label2.Size = new Size(217, 24);
            label2.TabIndex = 2;
            label2.Text = "Actualizar Empleado";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Maroon;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(481, 337);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(116, 35);
            btnCancelar.TabIndex = 30;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Green;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(293, 337);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(116, 35);
            btnGuardar.TabIndex = 29;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // comboBoxArea
            // 
            comboBoxArea.FormattingEnabled = true;
            comboBoxArea.Location = new Point(513, 222);
            comboBoxArea.Name = "comboBoxArea";
            comboBoxArea.Size = new Size(292, 23);
            comboBoxArea.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(513, 202);
            label7.Name = "label7";
            label7.Size = new Size(40, 17);
            label7.TabIndex = 27;
            label7.Text = "Area";
            // 
            // txtPuesto
            // 
            txtPuesto.BackColor = Color.White;
            txtPuesto.BorderStyle = BorderStyle.None;
            txtPuesto.Location = new Point(73, 222);
            txtPuesto.Name = "txtPuesto";
            txtPuesto.Size = new Size(294, 16);
            txtPuesto.TabIndex = 26;
            // 
            // txtNumeroNomina
            // 
            txtNumeroNomina.BackColor = Color.White;
            txtNumeroNomina.BorderStyle = BorderStyle.None;
            txtNumeroNomina.Location = new Point(513, 166);
            txtNumeroNomina.Name = "txtNumeroNomina";
            txtNumeroNomina.Size = new Size(294, 16);
            txtNumeroNomina.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(73, 202);
            label6.Name = "label6";
            label6.Size = new Size(53, 17);
            label6.TabIndex = 24;
            label6.Text = "Puesto";
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.BackColor = Color.White;
            txtApellidoMaterno.BorderStyle = BorderStyle.None;
            txtApellidoMaterno.Location = new Point(73, 166);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(294, 16);
            txtApellidoMaterno.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(513, 146);
            label5.Name = "label5";
            label5.Size = new Size(135, 17);
            label5.TabIndex = 22;
            label5.Text = "Numero de Nomina";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(73, 146);
            label4.Name = "label4";
            label4.Size = new Size(124, 17);
            label4.TabIndex = 21;
            label4.Text = "Apellido Materno";
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.BackColor = Color.White;
            txtApellidoPaterno.BorderStyle = BorderStyle.None;
            txtApellidoPaterno.Location = new Point(513, 98);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(294, 16);
            txtApellidoPaterno.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(513, 78);
            label3.Name = "label3";
            label3.Size = new Size(118, 17);
            label3.TabIndex = 19;
            label3.Text = "Apellido Paterno";
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.BackColor = Color.White;
            txtNombreEmpleado.BorderStyle = BorderStyle.None;
            txtNombreEmpleado.Location = new Point(73, 98);
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.Size = new Size(294, 16);
            txtNombreEmpleado.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(73, 78);
            label1.Name = "label1";
            label1.Size = new Size(78, 17);
            label1.TabIndex = 17;
            label1.Text = "Nombre(s)";
            // 
            // FormEditarEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 0);
            ClientSize = new Size(880, 451);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(comboBoxArea);
            Controls.Add(label7);
            Controls.Add(txtPuesto);
            Controls.Add(txtNumeroNomina);
            Controls.Add(label6);
            Controls.Add(txtApellidoMaterno);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtApellidoPaterno);
            Controls.Add(label3);
            Controls.Add(txtNombreEmpleado);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormEditarEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEditarEmpleados";
            MouseDown += FormEditarEmpleado_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox comboBoxArea;
        private Label label7;
        private TextBox txtPuesto;
        private TextBox txtNumeroNomina;
        private Label label6;
        private TextBox txtApellidoMaterno;
        private Label label5;
        private Label label4;
        private TextBox txtApellidoPaterno;
        private Label label3;
        private TextBox txtNombreEmpleado;
        private Label label1;
    }
}