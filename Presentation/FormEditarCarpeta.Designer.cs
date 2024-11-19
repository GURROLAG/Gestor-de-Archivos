namespace Presentation
{
    partial class FormEditarCarpeta
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
            label1 = new Label();
            cmbCarpetas = new ComboBox();
            txtNuevoNombre = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(317, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 22);
            label1.TabIndex = 1;
            label1.Text = "EDITAR CARPETA";
            label1.Click += label1_Click;
            // 
            // cmbCarpetas
            // 
            cmbCarpetas.FormattingEnabled = true;
            cmbCarpetas.Location = new Point(411, 117);
            cmbCarpetas.Name = "cmbCarpetas";
            cmbCarpetas.Size = new Size(218, 23);
            cmbCarpetas.TabIndex = 2;
          
            // 
            // txtNuevoNombre
            // 
            txtNuevoNombre.Location = new Point(411, 207);
            txtNuevoNombre.Name = "txtNuevoNombre";
            txtNuevoNombre.Size = new Size(218, 23);
            txtNuevoNombre.TabIndex = 3;
       
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(174, 117);
            label2.Name = "label2";
            label2.Size = new Size(231, 22);
            label2.TabIndex = 4;
            label2.Text = "ESCOGA UNA CARPETA";
            
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(216, 207);
            label3.Name = "label3";
            label3.Size = new Size(189, 22);
            label3.TabIndex = 5;
            label3.Text = "CAMBIAR NOMBRE";
         
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Green;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(254, 341);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 44);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(428, 341);
            button1.Name = "button1";
            button1.Size = new Size(129, 44);
            button1.TabIndex = 7;
            button1.Text = "CANCELAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormEditarCarpeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Olive;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtNuevoNombre);
            Controls.Add(cmbCarpetas);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEditarCarpeta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEditarCarpeta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbCarpetas;
        private TextBox txtNuevoNombre;
        private Label label2;
        private Label label3;
        private Button btnGuardar;
        private Button button1;
    }
}