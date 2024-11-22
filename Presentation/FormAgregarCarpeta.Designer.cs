namespace Presentation
{
    partial class FormAgregarCarpeta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarCarpeta));
            label1 = new Label();
            label2 = new Label();
            txtNombreCarpeta = new TextBox();
            cmbCarpetaPadre = new ComboBox();
            label3 = new Label();
            btnCrearCarpeta = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGray;
            label1.Location = new Point(309, 20);
            label1.Name = "label1";
            label1.Size = new Size(189, 24);
            label1.TabIndex = 0;
            label1.Text = "CREAR CARPETA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(180, 138);
            label2.Name = "label2";
            label2.Size = new Size(154, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre Carpeta";
            // 
            // txtNombreCarpeta
            // 
            txtNombreCarpeta.Location = new Point(370, 140);
            txtNombreCarpeta.Name = "txtNombreCarpeta";
            txtNombreCarpeta.Size = new Size(218, 23);
            txtNombreCarpeta.TabIndex = 2;
            // 
            // cmbCarpetaPadre
            // 
            cmbCarpetaPadre.FormattingEnabled = true;
            cmbCarpetaPadre.Location = new Point(370, 211);
            cmbCarpetaPadre.Name = "cmbCarpetaPadre";
            cmbCarpetaPadre.Size = new Size(218, 23);
            cmbCarpetaPadre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 209);
            label3.Name = "label3";
            label3.Size = new Size(224, 20);
            label3.TabIndex = 4;
            label3.Text = "Direccion De La Carpeta";
            // 
            // btnCrearCarpeta
            // 
            btnCrearCarpeta.BackColor = Color.Green;
            btnCrearCarpeta.FlatAppearance.BorderSize = 0;
            btnCrearCarpeta.FlatStyle = FlatStyle.Flat;
            btnCrearCarpeta.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearCarpeta.Location = new Point(210, 351);
            btnCrearCarpeta.Name = "btnCrearCarpeta";
            btnCrearCarpeta.Size = new Size(124, 38);
            btnCrearCarpeta.TabIndex = 5;
            btnCrearCarpeta.Text = "CREAR";
            btnCrearCarpeta.UseVisualStyleBackColor = false;
            btnCrearCarpeta.Click += btnCrearCarpeta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Maroon;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(425, 351);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 38);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FormAgregarCarpeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(btnCrearCarpeta);
            Controls.Add(label3);
            Controls.Add(cmbCarpetaPadre);
            Controls.Add(txtNombreCarpeta);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAgregarCarpeta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAgregarCarpeta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNombreCarpeta;
        private ComboBox cmbCarpetaPadre;
        private Label label3;
        private Button btnCrearCarpeta;
        private Button btnCancelar;
    }
}