namespace Presentation
{
    partial class Interfaz
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interfaz));
            PanelContenedor = new Panel();
            PanelFormularios = new Panel();
            pictureBox1 = new PictureBox();
            PanelMenu = new Panel();
            btnExamenesPL = new Button();
            btnMetal = new Button();
            btnActividades = new Button();
            btnExamenesMM = new Button();
            btnUsuarios = new Button();
            pictureBox2 = new PictureBox();
            btnLogOut = new Button();
            btnPL = new Button();
            PanelBarraTitulo = new Panel();
            label5 = new Label();
            panel1 = new Panel();
            btnRestaurar = new PictureBox();
            btnMinimizar = new PictureBox();
            btnMaximizar = new PictureBox();
            btnCerrar = new PictureBox();
            label1 = new Label();
            PanelContenedor.SuspendLayout();
            PanelFormularios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            PanelBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = SystemColors.ActiveCaption;
            PanelContenedor.Controls.Add(PanelFormularios);
            PanelContenedor.Controls.Add(PanelMenu);
            PanelContenedor.Controls.Add(PanelBarraTitulo);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(0, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1200, 600);
            PanelContenedor.TabIndex = 0;
            // 
            // PanelFormularios
            // 
            PanelFormularios.BackColor = SystemColors.Control;
            PanelFormularios.Controls.Add(pictureBox1);
            PanelFormularios.Dock = DockStyle.Fill;
            PanelFormularios.Location = new Point(257, 40);
            PanelFormularios.Name = "PanelFormularios";
            PanelFormularios.Size = new Size(943, 560);
            PanelFormularios.TabIndex = 2;
            PanelFormularios.Paint += PanelFormularios_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(335, 115);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 303);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = Color.FromArgb(4, 41, 68);
            PanelMenu.Controls.Add(label1);
            PanelMenu.Controls.Add(btnExamenesPL);
            PanelMenu.Controls.Add(btnMetal);
            PanelMenu.Controls.Add(btnActividades);
            PanelMenu.Controls.Add(btnExamenesMM);
            PanelMenu.Controls.Add(btnUsuarios);
            PanelMenu.Controls.Add(pictureBox2);
            PanelMenu.Controls.Add(btnLogOut);
            PanelMenu.Controls.Add(btnPL);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 40);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(257, 560);
            PanelMenu.TabIndex = 1;
            // 
            // btnExamenesPL
            // 
            btnExamenesPL.FlatAppearance.BorderSize = 0;
            btnExamenesPL.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnExamenesPL.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnExamenesPL.FlatStyle = FlatStyle.Flat;
            btnExamenesPL.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExamenesPL.ForeColor = Color.Gainsboro;
            btnExamenesPL.Image = (Image)resources.GetObject("btnExamenesPL.Image");
            btnExamenesPL.ImageAlign = ContentAlignment.MiddleLeft;
            btnExamenesPL.Location = new Point(3, 167);
            btnExamenesPL.Name = "btnExamenesPL";
            btnExamenesPL.Size = new Size(254, 58);
            btnExamenesPL.TabIndex = 13;
            btnExamenesPL.Text = "EXAMENES INYECCION PLASTICA";
            btnExamenesPL.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExamenesPL.UseVisualStyleBackColor = true;
            btnExamenesPL.Click += button1_Click;
            // 
            // btnMetal
            // 
            btnMetal.FlatAppearance.BorderSize = 0;
            btnMetal.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnMetal.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnMetal.FlatStyle = FlatStyle.Flat;
            btnMetal.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMetal.ForeColor = Color.Gainsboro;
            btnMetal.Image = (Image)resources.GetObject("btnMetal.Image");
            btnMetal.ImageAlign = ContentAlignment.MiddleLeft;
            btnMetal.Location = new Point(3, 245);
            btnMetal.Name = "btnMetal";
            btnMetal.Size = new Size(254, 45);
            btnMetal.TabIndex = 2;
            btnMetal.Text = "ARCHIVOS METAL";
            btnMetal.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMetal.UseVisualStyleBackColor = true;
            btnMetal.Click += btnPL_Click;
            // 
            // btnActividades
            // 
            btnActividades.FlatAppearance.BorderSize = 0;
            btnActividades.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnActividades.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnActividades.FlatStyle = FlatStyle.Flat;
            btnActividades.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActividades.ForeColor = Color.Gainsboro;
            btnActividades.Image = (Image)resources.GetObject("btnActividades.Image");
            btnActividades.ImageAlign = ContentAlignment.MiddleLeft;
            btnActividades.Location = new Point(1, 450);
            btnActividades.Name = "btnActividades";
            btnActividades.Size = new Size(254, 45);
            btnActividades.TabIndex = 12;
            btnActividades.Text = "REGISTRO ACTIVIDADES";
            btnActividades.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnActividades.UseVisualStyleBackColor = true;
            btnActividades.Click += btnActividades_Click;
            // 
            // btnExamenesMM
            // 
            btnExamenesMM.FlatAppearance.BorderSize = 0;
            btnExamenesMM.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnExamenesMM.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnExamenesMM.FlatStyle = FlatStyle.Flat;
            btnExamenesMM.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExamenesMM.ForeColor = Color.Gainsboro;
            btnExamenesMM.Image = (Image)resources.GetObject("btnExamenesMM.Image");
            btnExamenesMM.ImageAlign = ContentAlignment.MiddleLeft;
            btnExamenesMM.Location = new Point(1, 299);
            btnExamenesMM.Name = "btnExamenesMM";
            btnExamenesMM.Size = new Size(254, 59);
            btnExamenesMM.TabIndex = 11;
            btnExamenesMM.Text = "EXAMENES METAL MECANICA";
            btnExamenesMM.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnExamenesMM.UseVisualStyleBackColor = true;
            btnExamenesMM.Click += btnInicio_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.ForeColor = Color.Gainsboro;
            btnUsuarios.Image = (Image)resources.GetObject("btnUsuarios.Image");
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(3, 379);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(254, 52);
            btnUsuarios.TabIndex = 9;
            btnUsuarios.Text = "USUARIOS";
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = (Image)resources.GetObject("pictureBox2.ErrorImage");
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(3, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // btnLogOut
            // 
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnLogOut.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.ForeColor = Color.Gainsboro;
            btnLogOut.Image = (Image)resources.GetObject("btnLogOut.Image");
            btnLogOut.Location = new Point(3, 514);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(254, 45);
            btnLogOut.TabIndex = 6;
            btnLogOut.Text = "Log Out";
            btnLogOut.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnPL
            // 
            btnPL.FlatAppearance.BorderSize = 0;
            btnPL.FlatAppearance.MouseDownBackColor = Color.FromArgb(33, 50, 70);
            btnPL.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 61, 92);
            btnPL.FlatStyle = FlatStyle.Flat;
            btnPL.Font = new Font("Microsoft JhengHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPL.ForeColor = Color.Gainsboro;
            btnPL.Image = (Image)resources.GetObject("btnPL.Image");
            btnPL.ImageAlign = ContentAlignment.MiddleLeft;
            btnPL.Location = new Point(3, 106);
            btnPL.Name = "btnPL";
            btnPL.Size = new Size(254, 52);
            btnPL.TabIndex = 1;
            btnPL.Text = "ARCHIVOS PL";
            btnPL.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPL.UseVisualStyleBackColor = true;
            btnPL.Click += btnMetal_Click;
            // 
            // PanelBarraTitulo
            // 
            PanelBarraTitulo.BackColor = Color.FromArgb(13, 93, 142);
            PanelBarraTitulo.Controls.Add(label5);
            PanelBarraTitulo.Controls.Add(panel1);
            PanelBarraTitulo.Controls.Add(btnRestaurar);
            PanelBarraTitulo.Controls.Add(btnMinimizar);
            PanelBarraTitulo.Controls.Add(btnMaximizar);
            PanelBarraTitulo.Controls.Add(btnCerrar);
            PanelBarraTitulo.Dock = DockStyle.Top;
            PanelBarraTitulo.Location = new Point(0, 0);
            PanelBarraTitulo.Name = "PanelBarraTitulo";
            PanelBarraTitulo.Size = new Size(1200, 40);
            PanelBarraTitulo.TabIndex = 0;
            PanelBarraTitulo.MouseDown += PanelBarraTitulo_MouseDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(114, 21);
            label5.TabIndex = 4;
            label5.Text = "Menu Principal";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 100);
            panel1.TabIndex = 3;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRestaurar.Image = (Image)resources.GetObject("btnRestaurar.Image");
            btnRestaurar.Location = new Point(1141, 12);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(16, 16);
            btnRestaurar.SizeMode = PictureBoxSizeMode.AutoSize;
            btnRestaurar.TabIndex = 3;
            btnRestaurar.TabStop = false;
            btnRestaurar.Visible = false;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimizar.Image = (Image)resources.GetObject("btnMinimizar.Image");
            btnMinimizar.Location = new Point(1110, 12);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(16, 16);
            btnMinimizar.SizeMode = PictureBoxSizeMode.AutoSize;
            btnMinimizar.TabIndex = 2;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnMaximizar
            // 
            btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMaximizar.Image = (Image)resources.GetObject("btnMaximizar.Image");
            btnMaximizar.Location = new Point(1141, 12);
            btnMaximizar.Name = "btnMaximizar";
            btnMaximizar.Size = new Size(16, 16);
            btnMaximizar.SizeMode = PictureBoxSizeMode.AutoSize;
            btnMaximizar.TabIndex = 1;
            btnMaximizar.TabStop = false;
            btnMaximizar.Click += btnMaximizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(1172, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(16, 16);
            btnCerrar.SizeMode = PictureBoxSizeMode.AutoSize;
            btnCerrar.TabIndex = 0;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(95, 41);
            label1.Name = "label1";
            label1.Size = new Size(126, 26);
            label1.TabIndex = 5;
            label1.Text = "Bienvenido";
            // 
            // Interfaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 600);
            Controls.Add(PanelContenedor);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(680, 500);
            Name = "Interfaz";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Interfaz_Load_1;
            PanelContenedor.ResumeLayout(false);
            PanelFormularios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelMenu.ResumeLayout(false);
            PanelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            PanelBarraTitulo.ResumeLayout(false);
            PanelBarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnRestaurar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMaximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelBarraTitulo;
        private Panel PanelFormularios;
        private Panel PanelMenu;
        private PictureBox btnMaximizar;
        private PictureBox btnCerrar;
        private PictureBox btnRestaurar;
        private PictureBox btnMinimizar;
        private Button btnMetal;
        private Button btnPL;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Button btnLogOut;
        private Label label5;
        private Button btnUsuarios;
        private Button btnExamenesMM;
        private Button btnActividades;
        private Button btnExamenesPL;
        private Label label1;
    }
}
