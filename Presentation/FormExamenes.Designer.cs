namespace Presentation
{
    partial class FormExamenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExamenes));
            dataGridViewEmpleados = new DataGridView();
            comboBoxExamenes = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewEmpleados
            // 
            dataGridViewEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpleados.Location = new Point(45, 50);
            dataGridViewEmpleados.Name = "dataGridViewEmpleados";
            dataGridViewEmpleados.Size = new Size(835, 359);
            dataGridViewEmpleados.TabIndex = 0;
            dataGridViewEmpleados.CellContentClick += dataGridViewEmpleados_CellContentClick;
            // 
            // comboBoxExamenes
            // 
            comboBoxExamenes.FormattingEnabled = true;
            comboBoxExamenes.Location = new Point(78, 448);
            comboBoxExamenes.Name = "comboBoxExamenes";
            comboBoxExamenes.Size = new Size(222, 23);
            comboBoxExamenes.TabIndex = 1;
            comboBoxExamenes.SelectedIndexChanged += comboBoxExamenes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(401, 9);
            label1.Name = "label1";
            label1.Size = new Size(118, 22);
            label1.TabIndex = 2;
            label1.Text = "EXAMENES";
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(401, 441);
            button1.Name = "button1";
            button1.Size = new Size(119, 33);
            button1.TabIndex = 3;
            button1.Text = "GUARDAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(864, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FormExamenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(935, 497);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(comboBoxExamenes);
            Controls.Add(dataGridViewEmpleados);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormExamenes";
            Text = "FormExamenes";
            Load += FormExamenes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewEmpleados;
        private ComboBox comboBoxExamenes;
        private Label label1;
        private Button button1;
        private PictureBox pictureBox1;
    }
}