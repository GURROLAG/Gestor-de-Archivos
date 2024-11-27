namespace Presentation
{
    partial class FormExamenesPL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExamenesPL));
            pictureBox1 = new PictureBox();
            btnGuardar = new Button();
            label1 = new Label();
            comboBoxExamenes = new ComboBox();
            dataGridViewEmpleados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(869, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Maroon;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(405, 441);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(119, 33);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(406, 16);
            label1.Name = "label1";
            label1.Size = new Size(118, 22);
            label1.TabIndex = 7;
            label1.Text = "EXAMENES";
            // 
            // comboBoxExamenes
            // 
            comboBoxExamenes.FormattingEnabled = true;
            comboBoxExamenes.Location = new Point(50, 441);
            comboBoxExamenes.Name = "comboBoxExamenes";
            comboBoxExamenes.Size = new Size(222, 23);
            comboBoxExamenes.TabIndex = 6;
            comboBoxExamenes.SelectedIndexChanged += comboBoxExamenes_SelectedIndexChanged;
            // 
            // dataGridViewEmpleados
            // 
            dataGridViewEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpleados.Location = new Point(50, 57);
            dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            dataGridViewEmpleados.Size = new Size(835, 359);
            dataGridViewEmpleados.TabIndex = 5;
            dataGridViewEmpleados.CellContentClick += dataGridViewEmpleados_CellContentClick;
            // 
            // FormExamenesPL
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(935, 497);
            Controls.Add(pictureBox1);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(comboBoxExamenes);
            Controls.Add(dataGridViewEmpleados);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormExamenesPL";
            Text = "FormExamenesPL";
            Load += FormExamenesPL_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button btnGuardar;
        private Label label1;
        private ComboBox comboBoxExamenes;
        private DataGridView dataGridViewEmpleados;
    }
}