namespace Presentation
{
    partial class FormActualizarCarpeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActualizarCarpeta));
            button1 = new Button();
            btnGuardar = new Button();
            label3 = new Label();
            txtNombreCarpeta = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(423, 279);
            button1.Name = "button1";
            button1.Size = new Size(129, 44);
            button1.TabIndex = 14;
            button1.Text = "CANCELAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Green;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(249, 279);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 44);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(198, 171);
            label3.Name = "label3";
            label3.Size = new Size(189, 22);
            label3.TabIndex = 12;
            label3.Text = "CAMBIAR NOMBRE";
            // 
            // txtNombreCarpeta
            // 
            txtNombreCarpeta.Location = new Point(393, 171);
            txtNombreCarpeta.Name = "txtNombreCarpeta";
            txtNombreCarpeta.Size = new Size(218, 23);
            txtNombreCarpeta.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(316, 37);
            label1.Name = "label1";
            label1.Size = new Size(176, 22);
            label1.TabIndex = 8;
            label1.Text = "EDITAR CARPETA";
            // 
            // FormActualizarCarpeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Olive;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(txtNombreCarpeta);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormActualizarCarpeta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormActualizarCarpeta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button btnGuardar;
        private Label label3;
        private TextBox txtNombreCarpeta;
        private Label label1;
    }
}