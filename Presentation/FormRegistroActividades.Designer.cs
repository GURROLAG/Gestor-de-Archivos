namespace Presentation
{
    partial class FormRegistroActividades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroActividades));
            label1 = new Label();
            dataGridViewActividades = new DataGridView();
            pictureBox1 = new PictureBox();
            dateTimePickerHasta = new DateTimePicker();
            dateTimePickerDesde = new DateTimePicker();
            btnFiltrar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewActividades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(328, 9);
            label1.Name = "label1";
            label1.Size = new Size(246, 24);
            label1.TabIndex = 0;
            label1.Text = "Historial de Actividades";
            // 
            // dataGridViewActividades
            // 
            dataGridViewActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActividades.Location = new Point(38, 49);
            dataGridViewActividades.Name = "dataGridViewActividades";
            dataGridViewActividades.Size = new Size(821, 347);
            dataGridViewActividades.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(843, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 16);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dateTimePickerHasta
            // 
            dateTimePickerHasta.Location = new Point(38, 501);
            dateTimePickerHasta.Name = "dateTimePickerHasta";
            dateTimePickerHasta.Size = new Size(232, 23);
            dateTimePickerHasta.TabIndex = 3;
            // 
            // dateTimePickerDesde
            // 
            dateTimePickerDesde.Location = new Point(38, 435);
            dateTimePickerDesde.Name = "dateTimePickerDesde";
            dateTimePickerDesde.Size = new Size(232, 23);
            dateTimePickerDesde.TabIndex = 4;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.Teal;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = Color.Gainsboro;
            btnFiltrar.Location = new Point(413, 470);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(90, 36);
            btnFiltrar.TabIndex = 5;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(375, 422);
            label2.Name = "label2";
            label2.Size = new Size(171, 18);
            label2.TabIndex = 6;
            label2.Text = "FILTRAR ACTIVIDADES";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(127, 414);
            label3.Name = "label3";
            label3.Size = new Size(60, 18);
            label3.TabIndex = 7;
            label3.Text = "DESDE";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(127, 480);
            label4.Name = "label4";
            label4.Size = new Size(56, 18);
            label4.TabIndex = 8;
            label4.Text = "HASTA";
            // 
            // FormRegistroActividades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 64, 64);
            ClientSize = new Size(896, 536);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnFiltrar);
            Controls.Add(dateTimePickerDesde);
            Controls.Add(dateTimePickerHasta);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridViewActividades);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormRegistroActividades";
            Text = "FormRegistroActividades";
            ((System.ComponentModel.ISupportInitialize)dataGridViewActividades).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewActividades;
        private PictureBox pictureBox1;
        private DateTimePicker dateTimePickerHasta;
        private DateTimePicker dateTimePickerDesde;
        private Button btnFiltrar;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}