namespace Presentation
{
    partial class FormDetalleEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalleEmpleado));
            label1 = new Label();
            pictureBox1 = new PictureBox();
            dataGridViewDocumentos = new DataGridView();
            treeViewCarpetas = new TreeView();
            btnCrearCarpeta = new Button();
            btnEditarCarpeta = new Button();
            btnEliminarCarpeta = new Button();
            btnAgregarDocumento = new Button();
            btnEditarDocumento = new Button();
            btnEliminarDocumento = new Button();
            btnVerDocumento = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDocumentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(415, 15);
            label1.Name = "label1";
            label1.Size = new Size(181, 22);
            label1.TabIndex = 0;
            label1.Text = "DOCUMENTACION";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(945, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dataGridViewDocumentos
            // 
            dataGridViewDocumentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDocumentos.Location = new Point(358, 102);
            dataGridViewDocumentos.Name = "dataGridViewDocumentos";
            dataGridViewDocumentos.Size = new Size(638, 298);
            dataGridViewDocumentos.TabIndex = 2;
            dataGridViewDocumentos.CellContentDoubleClick += dataGridViewDocumentos_CellContentDoubleClick;
            dataGridViewDocumentos.SelectionChanged += dataGridViewDocumentos_SelectionChanged;
            // 
            // treeViewCarpetas
            // 
            treeViewCarpetas.Location = new Point(12, 102);
            treeViewCarpetas.Name = "treeViewCarpetas";
            treeViewCarpetas.Size = new Size(311, 298);
            treeViewCarpetas.TabIndex = 3;
            treeViewCarpetas.AfterSelect += treeViewCarpetas_AfterSelect_1;
            // 
            // btnCrearCarpeta
            // 
            btnCrearCarpeta.BackColor = Color.Green;
            btnCrearCarpeta.FlatAppearance.BorderSize = 0;
            btnCrearCarpeta.FlatStyle = FlatStyle.Flat;
            btnCrearCarpeta.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCrearCarpeta.ForeColor = Color.Black;
            btnCrearCarpeta.Location = new Point(12, 422);
            btnCrearCarpeta.Name = "btnCrearCarpeta";
            btnCrearCarpeta.Size = new Size(123, 44);
            btnCrearCarpeta.TabIndex = 4;
            btnCrearCarpeta.Text = "CREAR CARPETA";
            btnCrearCarpeta.UseVisualStyleBackColor = false;
            btnCrearCarpeta.Click += btnCrearCarpeta_Click;
            // 
            // btnEditarCarpeta
            // 
            btnEditarCarpeta.BackColor = Color.Olive;
            btnEditarCarpeta.FlatAppearance.BorderSize = 0;
            btnEditarCarpeta.FlatStyle = FlatStyle.Flat;
            btnEditarCarpeta.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarCarpeta.ForeColor = Color.Black;
            btnEditarCarpeta.Location = new Point(106, 479);
            btnEditarCarpeta.Name = "btnEditarCarpeta";
            btnEditarCarpeta.Size = new Size(123, 44);
            btnEditarCarpeta.TabIndex = 5;
            btnEditarCarpeta.Text = "EDITAR CARPETA";
            btnEditarCarpeta.UseVisualStyleBackColor = false;
            btnEditarCarpeta.Click += btnEditarCarpeta_Click;
            // 
            // btnEliminarCarpeta
            // 
            btnEliminarCarpeta.BackColor = Color.Maroon;
            btnEliminarCarpeta.FlatAppearance.BorderSize = 0;
            btnEliminarCarpeta.FlatStyle = FlatStyle.Flat;
            btnEliminarCarpeta.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarCarpeta.ForeColor = Color.Black;
            btnEliminarCarpeta.Location = new Point(200, 422);
            btnEliminarCarpeta.Name = "btnEliminarCarpeta";
            btnEliminarCarpeta.Size = new Size(123, 44);
            btnEliminarCarpeta.TabIndex = 6;
            btnEliminarCarpeta.Text = "ELIMINAR CARPETA";
            btnEliminarCarpeta.UseVisualStyleBackColor = false;
            btnEliminarCarpeta.Click += btnEliminarCarpeta_Click;
            // 
            // btnAgregarDocumento
            // 
            btnAgregarDocumento.BackColor = Color.Green;
            btnAgregarDocumento.FlatAppearance.BorderSize = 0;
            btnAgregarDocumento.FlatStyle = FlatStyle.Flat;
            btnAgregarDocumento.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarDocumento.ForeColor = Color.Black;
            btnAgregarDocumento.Location = new Point(375, 422);
            btnAgregarDocumento.Name = "btnAgregarDocumento";
            btnAgregarDocumento.Size = new Size(123, 44);
            btnAgregarDocumento.TabIndex = 7;
            btnAgregarDocumento.Text = "AGREGAR DOCUMENTO";
            btnAgregarDocumento.UseVisualStyleBackColor = false;
            btnAgregarDocumento.Click += btnAgregarDocumento_Click;
            // 
            // btnEditarDocumento
            // 
            btnEditarDocumento.BackColor = Color.Olive;
            btnEditarDocumento.FlatAppearance.BorderSize = 0;
            btnEditarDocumento.FlatStyle = FlatStyle.Flat;
            btnEditarDocumento.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarDocumento.ForeColor = Color.Black;
            btnEditarDocumento.Location = new Point(701, 422);
            btnEditarDocumento.Name = "btnEditarDocumento";
            btnEditarDocumento.Size = new Size(123, 44);
            btnEditarDocumento.TabIndex = 8;
            btnEditarDocumento.Text = "EDITAR DOCUMENTO";
            btnEditarDocumento.UseVisualStyleBackColor = false;
            btnEditarDocumento.Click += btnEditarDocumento_Click;
            // 
            // btnEliminarDocumento
            // 
            btnEliminarDocumento.BackColor = Color.Maroon;
            btnEliminarDocumento.FlatAppearance.BorderSize = 0;
            btnEliminarDocumento.FlatStyle = FlatStyle.Flat;
            btnEliminarDocumento.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarDocumento.ForeColor = Color.Black;
            btnEliminarDocumento.Location = new Point(535, 422);
            btnEliminarDocumento.Name = "btnEliminarDocumento";
            btnEliminarDocumento.Size = new Size(123, 44);
            btnEliminarDocumento.TabIndex = 9;
            btnEliminarDocumento.Text = "ELIMINAR DOCUMENTO";
            btnEliminarDocumento.UseVisualStyleBackColor = false;
            btnEliminarDocumento.Click += btnEliminarDocumento_Click;
            // 
            // btnVerDocumento
            // 
            btnVerDocumento.BackColor = Color.Orange;
            btnVerDocumento.FlatAppearance.BorderSize = 0;
            btnVerDocumento.FlatStyle = FlatStyle.Flat;
            btnVerDocumento.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerDocumento.ForeColor = Color.Black;
            btnVerDocumento.Location = new Point(857, 422);
            btnVerDocumento.Name = "btnVerDocumento";
            btnVerDocumento.Size = new Size(123, 44);
            btnVerDocumento.TabIndex = 11;
            btnVerDocumento.Text = "VER DOCUMENTO";
            btnVerDocumento.UseVisualStyleBackColor = false;
            btnVerDocumento.Click += btnVerDocumento_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(923, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(16, 16);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // FormDetalleEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(1008, 535);
            Controls.Add(pictureBox2);
            Controls.Add(btnVerDocumento);
            Controls.Add(btnEliminarDocumento);
            Controls.Add(btnEditarDocumento);
            Controls.Add(btnAgregarDocumento);
            Controls.Add(btnEliminarCarpeta);
            Controls.Add(btnEditarCarpeta);
            Controls.Add(btnCrearCarpeta);
            Controls.Add(treeViewCarpetas);
            Controls.Add(dataGridViewDocumentos);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDetalleEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDetalleEmpleado";
            MouseDown += FormDetalleEmpleado_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDocumentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView dataGridViewDocumentos;
        private TreeView treeViewCarpetas;
        private Button btnCrearCarpeta;
        private Button btnEditarCarpeta;
        private Button btnEliminarCarpeta;
        private Button btnAgregarDocumento;
        private Button btnEditarDocumento;
        private Button btnEliminarDocumento;
        private Button btnVerDocumento;
        private PictureBox pictureBox2;
    }
}