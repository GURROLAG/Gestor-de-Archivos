namespace Presentation
{
    partial class FormActualizarDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormActualizarDocumento));
            btnCancelar = new Button();
            btnGuardar = new Button();
            label2 = new Label();
            txtNombreDocumento = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(388, 287);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(139, 38);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Green;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(212, 287);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(139, 38);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 151);
            label2.Name = "label2";
            label2.Size = new Size(245, 22);
            label2.TabIndex = 8;
            label2.Text = "Cambiar Nombre de Archivo";
            // 
            // txtNombreDocumento
            // 
            txtNombreDocumento.Location = new Point(340, 150);
            txtNombreDocumento.Name = "txtNombreDocumento";
            txtNombreDocumento.Size = new Size(247, 23);
            txtNombreDocumento.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(259, 20);
            label1.Name = "label1";
            label1.Size = new Size(212, 22);
            label1.TabIndex = 6;
            label1.Text = "EDITAR DOCUMENTO";
            // 
            // FormActualizarDocumento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Olive;
            ClientSize = new Size(715, 345);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(label2);
            Controls.Add(txtNombreDocumento);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormActualizarDocumento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormActualizarDocumento";
            Load += FormActualizarDocumento_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGuardar;
        private Label label2;
        private TextBox txtNombreDocumento;
        private Label label1;
    }
}