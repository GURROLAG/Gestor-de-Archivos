namespace Presentation
{
    partial class FormSubirDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubirDocumento));
            label1 = new Label();
            btnSeleccionarArchivo = new Button();
            txtRutaArchivo = new TextBox();
            btnSubir = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(298, 20);
            label1.Name = "label1";
            label1.Size = new Size(200, 22);
            label1.TabIndex = 1;
            label1.Text = "SUBIR DOCUMENTO";
            // 
            // btnSeleccionarArchivo
            // 
            btnSeleccionarArchivo.BackColor = Color.Silver;
            btnSeleccionarArchivo.FlatAppearance.BorderSize = 0;
            btnSeleccionarArchivo.FlatStyle = FlatStyle.Flat;
            btnSeleccionarArchivo.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSeleccionarArchivo.Location = new Point(569, 105);
            btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            btnSeleccionarArchivo.Size = new Size(108, 23);
            btnSeleccionarArchivo.TabIndex = 2;
            btnSeleccionarArchivo.Text = "SELECCIONAR";
            btnSeleccionarArchivo.UseVisualStyleBackColor = false;
            btnSeleccionarArchivo.Click += btnSeleccionarArchivo_Click;
            // 
            // txtRutaArchivo
            // 
            txtRutaArchivo.Location = new Point(241, 106);
            txtRutaArchivo.Name = "txtRutaArchivo";
            txtRutaArchivo.Size = new Size(309, 23);
            txtRutaArchivo.TabIndex = 3;
            // 
            // btnSubir
            // 
            btnSubir.BackColor = Color.Lime;
            btnSubir.FlatAppearance.BorderSize = 0;
            btnSubir.FlatStyle = FlatStyle.Flat;
            btnSubir.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubir.Location = new Point(271, 238);
            btnSubir.Name = "btnSubir";
            btnSubir.Size = new Size(136, 40);
            btnSubir.TabIndex = 4;
            btnSubir.Text = "SUBIR";
            btnSubir.UseVisualStyleBackColor = false;
            btnSubir.Click += btnSubir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(453, 238);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(136, 40);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormSubirDocumento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(832, 309);
            Controls.Add(btnCancelar);
            Controls.Add(btnSubir);
            Controls.Add(txtRutaArchivo);
            Controls.Add(btnSeleccionarArchivo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormSubirDocumento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSubirDocumento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSeleccionarArchivo;
        private TextBox txtRutaArchivo;
        private Button btnSubir;
        private Button btnCancelar;
    }
}