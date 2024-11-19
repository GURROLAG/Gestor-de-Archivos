namespace Presentation
{
    partial class FormCrearCarpeta
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
            txtNombreCarpeta = new TextBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnCrearCarpeta = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(291, 31);
            label1.Name = "label1";
            label1.Size = new Size(189, 24);
            label1.TabIndex = 1;
            label1.Text = "CREAR CARPETA";
            // 
            // txtNombreCarpeta
            // 
            txtNombreCarpeta.Location = new Point(365, 155);
            txtNombreCarpeta.Name = "txtNombreCarpeta";
            txtNombreCarpeta.Size = new Size(218, 23);
            txtNombreCarpeta.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Sans Unicode", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(175, 153);
            label2.Name = "label2";
            label2.Size = new Size(154, 20);
            label2.TabIndex = 3;
            label2.Text = "Nombre Carpeta";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Maroon;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(447, 291);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 38);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnCrearCarpeta
            // 
            btnCrearCarpeta.BackColor = Color.Green;
            btnCrearCarpeta.FlatAppearance.BorderSize = 0;
            btnCrearCarpeta.FlatStyle = FlatStyle.Flat;
            btnCrearCarpeta.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearCarpeta.Location = new Point(218, 291);
            btnCrearCarpeta.Name = "btnCrearCarpeta";
            btnCrearCarpeta.Size = new Size(124, 38);
            btnCrearCarpeta.TabIndex = 7;
            btnCrearCarpeta.Text = "CREAR";
            btnCrearCarpeta.UseVisualStyleBackColor = false;
            btnCrearCarpeta.Click += btnCrearCarpeta_Click;
            // 
            // FormCrearCarpeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(791, 382);
            Controls.Add(btnCancelar);
            Controls.Add(btnCrearCarpeta);
            Controls.Add(txtNombreCarpeta);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCrearCarpeta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCrearCarpeta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreCarpeta;
        private Label label2;
        private Button btnCancelar;
        private Button btnCrearCarpeta;
    }
}