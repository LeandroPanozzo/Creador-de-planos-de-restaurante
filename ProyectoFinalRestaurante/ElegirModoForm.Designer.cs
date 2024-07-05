namespace ProyectoFinalRestaurante
{
    partial class ElegirModoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElegirModoForm));
            label1 = new Label();
            label2 = new Label();
            EditarBtn = new Button();
            PrevisualizacionBtn = new Button();
            label3 = new Label();
            SalirBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(120, 23);
            label1.TabIndex = 0;
            label1.Text = "Modo edicion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(162, 81);
            label2.Name = "label2";
            label2.Size = new Size(189, 23);
            label2.TabIndex = 1;
            label2.Text = "Modo previsualizacion";
            // 
            // EditarBtn
            // 
            EditarBtn.BackColor = Color.Transparent;
            EditarBtn.FlatAppearance.BorderSize = 0;
            EditarBtn.FlatStyle = FlatStyle.Flat;
            EditarBtn.ForeColor = Color.Transparent;
            EditarBtn.Image = (Image)resources.GetObject("EditarBtn.Image");
            EditarBtn.Location = new Point(27, 107);
            EditarBtn.Name = "EditarBtn";
            EditarBtn.Size = new Size(105, 23);
            EditarBtn.TabIndex = 2;
            EditarBtn.UseVisualStyleBackColor = false;
            EditarBtn.Click += EditarBtn_Click;
            // 
            // PrevisualizacionBtn
            // 
            PrevisualizacionBtn.BackColor = Color.Transparent;
            PrevisualizacionBtn.FlatAppearance.BorderSize = 0;
            PrevisualizacionBtn.FlatStyle = FlatStyle.Flat;
            PrevisualizacionBtn.ForeColor = Color.Transparent;
            PrevisualizacionBtn.Image = (Image)resources.GetObject("PrevisualizacionBtn.Image");
            PrevisualizacionBtn.Location = new Point(216, 107);
            PrevisualizacionBtn.Name = "PrevisualizacionBtn";
            PrevisualizacionBtn.Size = new Size(105, 23);
            PrevisualizacionBtn.TabIndex = 3;
            PrevisualizacionBtn.UseVisualStyleBackColor = false;
            PrevisualizacionBtn.Click += PrevisualizacionBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(253, 255, 244);
            label3.Location = new Point(89, 9);
            label3.Name = "label3";
            label3.Size = new Size(183, 40);
            label3.TabIndex = 4;
            label3.Text = "Elegir modo";
            // 
            // SalirBtn
            // 
            SalirBtn.BackColor = Color.Transparent;
            SalirBtn.FlatAppearance.BorderSize = 0;
            SalirBtn.FlatStyle = FlatStyle.Flat;
            SalirBtn.ForeColor = Color.Transparent;
            SalirBtn.Image = Properties.Resources.button_salir;
            SalirBtn.Location = new Point(276, 207);
            SalirBtn.Name = "SalirBtn";
            SalirBtn.Size = new Size(75, 23);
            SalirBtn.TabIndex = 5;
            SalirBtn.UseVisualStyleBackColor = false;
            SalirBtn.Click += SalirBtn_Click;
            // 
            // ElegirModoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.restaurantebakground;
            ClientSize = new Size(363, 242);
            Controls.Add(SalirBtn);
            Controls.Add(label3);
            Controls.Add(PrevisualizacionBtn);
            Controls.Add(EditarBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(379, 281);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(379, 281);
            Name = "ElegirModoForm";
            Text = "Restó.Net";
            Load += ElegirModoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button EditarBtn;
        private Button PrevisualizacionBtn;
        private Label label3;
        private Button SalirBtn;
    }
}