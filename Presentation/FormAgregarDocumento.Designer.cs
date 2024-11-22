namespace Presentation
{
    partial class FormAgregarDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarDocumento));
            btnCancelar = new Button();
            btnSubir = new Button();
            txtNombreDocumento = new TextBox();
            btnSeleccionarArchivo = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(447, 242);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(136, 40);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSubir
            // 
            btnSubir.BackColor = Color.Lime;
            btnSubir.FlatAppearance.BorderSize = 0;
            btnSubir.FlatStyle = FlatStyle.Flat;
            btnSubir.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSubir.Location = new Point(252, 242);
            btnSubir.Name = "btnSubir";
            btnSubir.Size = new Size(136, 40);
            btnSubir.TabIndex = 9;
            btnSubir.Text = "SUBIR";
            btnSubir.UseVisualStyleBackColor = false;
            btnSubir.Click += btnSubir_Click;
            // 
            // txtNombreDocumento
            // 
            txtNombreDocumento.Location = new Point(235, 110);
            txtNombreDocumento.Name = "txtNombreDocumento";
            txtNombreDocumento.Size = new Size(309, 23);
            txtNombreDocumento.TabIndex = 8;
            // 
            // btnSeleccionarArchivo
            // 
            btnSeleccionarArchivo.BackColor = Color.Silver;
            btnSeleccionarArchivo.FlatAppearance.BorderSize = 0;
            btnSeleccionarArchivo.FlatStyle = FlatStyle.Flat;
            btnSeleccionarArchivo.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSeleccionarArchivo.Location = new Point(563, 109);
            btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            btnSeleccionarArchivo.Size = new Size(108, 23);
            btnSeleccionarArchivo.TabIndex = 7;
            btnSeleccionarArchivo.Text = "SELECCIONAR";
            btnSeleccionarArchivo.UseVisualStyleBackColor = false;
            btnSeleccionarArchivo.Click += btnSeleccionarArchivo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(292, 24);
            label1.Name = "label1";
            label1.Size = new Size(200, 22);
            label1.TabIndex = 6;
            label1.Text = "SUBIR DOCUMENTO";
            // 
            // FormAgregarDocumento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            ClientSize = new Size(832, 309);
            Controls.Add(btnCancelar);
            Controls.Add(btnSubir);
            Controls.Add(txtNombreDocumento);
            Controls.Add(btnSeleccionarArchivo);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAgregarDocumento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAgregarDocumento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnSubir;
        private TextBox txtNombreDocumento;
        private Button btnSeleccionarArchivo;
        private Label label1;
    }
}