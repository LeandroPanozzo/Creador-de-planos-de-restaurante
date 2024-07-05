namespace ProyectoFinalRestaurante
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            guardarEnElMismoArchivoToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolToolStripMenuItem = new ToolStripMenuItem();
            mesasToolStripMenuItem = new ToolStripMenuItem();
            mesaRedondaToolStripMenuItem = new ToolStripMenuItem();
            mesaCuadradaToolStripMenuItem = new ToolStripMenuItem();
            sillasToolStripMenuItem = new ToolStripMenuItem();
            sillasDeGrupoToolStripMenuItem = new ToolStripMenuItem();
            sillasIndividualesToolStripMenuItem = new ToolStripMenuItem();
            divisoresToolStripMenuItem = new ToolStripMenuItem();
            divisoresToolStripMenuItem1 = new ToolStripMenuItem();
            paredesToolStripMenuItem = new ToolStripMenuItem();
            puertasToolStripMenuItem = new ToolStripMenuItem();
            bañoToolStripMenuItem = new ToolStripMenuItem();
            indoroToolStripMenuItem = new ToolStripMenuItem();
            urinarioToolStripMenuItem = new ToolStripMenuItem();
            lavaboToolStripMenuItem = new ToolStripMenuItem();
            cocinaToolStripMenuItem = new ToolStripMenuItem();
            cocinaToolStripMenuItem1 = new ToolStripMenuItem();
            heladeraToolStripMenuItem = new ToolStripMenuItem();
            lavaderoGrandeToolStripMenuItem = new ToolStripMenuItem();
            lavaderoChicoToolStripMenuItem = new ToolStripMenuItem();
            pasarAPrevisualizacionToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolToolStripMenuItem, pasarAPrevisualizacionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, guardarEnElMismoArchivoToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Image = Properties.Resources.file_logo;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(53, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = Properties.Resources.New_logo;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "Nuevo";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = Properties.Resources.Open_logo;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Abrir";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // guardarEnElMismoArchivoToolStripMenuItem
            // 
            guardarEnElMismoArchivoToolStripMenuItem.Image = Properties.Resources.guardar_en_el_mismo_archivo_logo;
            guardarEnElMismoArchivoToolStripMenuItem.Name = "guardarEnElMismoArchivoToolStripMenuItem";
            guardarEnElMismoArchivoToolStripMenuItem.Size = new Size(180, 22);
            guardarEnElMismoArchivoToolStripMenuItem.Text = "Guardar ";
            guardarEnElMismoArchivoToolStripMenuItem.Click += guardarEnElMismoArchivoToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = Properties.Resources.Save_logo;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Guardar como";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mesasToolStripMenuItem, sillasToolStripMenuItem, divisoresToolStripMenuItem, bañoToolStripMenuItem, cocinaToolStripMenuItem });
            toolToolStripMenuItem.Image = Properties.Resources.Tool_logo;
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.Size = new Size(106, 20);
            toolToolStripMenuItem.Text = "Herramientas";
            // 
            // mesasToolStripMenuItem
            // 
            mesasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mesaRedondaToolStripMenuItem, mesaCuadradaToolStripMenuItem });
            mesasToolStripMenuItem.Image = Properties.Resources.Mesa;
            mesasToolStripMenuItem.Name = "mesasToolStripMenuItem";
            mesasToolStripMenuItem.Size = new Size(121, 22);
            mesasToolStripMenuItem.Text = "Mesas";
            mesasToolStripMenuItem.Click += mesasToolStripMenuItem_Click;
            // 
            // mesaRedondaToolStripMenuItem
            // 
            mesaRedondaToolStripMenuItem.Image = Properties.Resources.Mesa_redonda1;
            mesaRedondaToolStripMenuItem.Name = "mesaRedondaToolStripMenuItem";
            mesaRedondaToolStripMenuItem.Size = new Size(156, 22);
            mesaRedondaToolStripMenuItem.Text = "Mesa Redonda";
            mesaRedondaToolStripMenuItem.Click += mesaRedondaToolStripMenuItem_Click;
            // 
            // mesaCuadradaToolStripMenuItem
            // 
            mesaCuadradaToolStripMenuItem.Image = Properties.Resources.Mesa1;
            mesaCuadradaToolStripMenuItem.Name = "mesaCuadradaToolStripMenuItem";
            mesaCuadradaToolStripMenuItem.Size = new Size(156, 22);
            mesaCuadradaToolStripMenuItem.Text = "Mesa Cuadrada";
            mesaCuadradaToolStripMenuItem.Click += mesaCuadradaToolStripMenuItem_Click;
            // 
            // sillasToolStripMenuItem
            // 
            sillasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sillasDeGrupoToolStripMenuItem, sillasIndividualesToolStripMenuItem });
            sillasToolStripMenuItem.Image = Properties.Resources.Silla_grande_logo;
            sillasToolStripMenuItem.Name = "sillasToolStripMenuItem";
            sillasToolStripMenuItem.Size = new Size(121, 22);
            sillasToolStripMenuItem.Text = "Sillas";
            sillasToolStripMenuItem.Click += sillasToolStripMenuItem_Click;
            // 
            // sillasDeGrupoToolStripMenuItem
            // 
            sillasDeGrupoToolStripMenuItem.Image = Properties.Resources.Silla_grande_logo;
            sillasDeGrupoToolStripMenuItem.Name = "sillasDeGrupoToolStripMenuItem";
            sillasDeGrupoToolStripMenuItem.Size = new Size(166, 22);
            sillasDeGrupoToolStripMenuItem.Text = "Sillas de grupo";
            sillasDeGrupoToolStripMenuItem.Click += sillasDeGrupoToolStripMenuItem_Click;
            // 
            // sillasIndividualesToolStripMenuItem
            // 
            sillasIndividualesToolStripMenuItem.Image = Properties.Resources.silla_chica_logo;
            sillasIndividualesToolStripMenuItem.Name = "sillasIndividualesToolStripMenuItem";
            sillasIndividualesToolStripMenuItem.Size = new Size(166, 22);
            sillasIndividualesToolStripMenuItem.Text = "Sillas individuales";
            sillasIndividualesToolStripMenuItem.Click += sillasIndividualesToolStripMenuItem_Click;
            // 
            // divisoresToolStripMenuItem
            // 
            divisoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { divisoresToolStripMenuItem1, paredesToolStripMenuItem, puertasToolStripMenuItem });
            divisoresToolStripMenuItem.Image = Properties.Resources.divisor_Logo;
            divisoresToolStripMenuItem.Name = "divisoresToolStripMenuItem";
            divisoresToolStripMenuItem.Size = new Size(121, 22);
            divisoresToolStripMenuItem.Text = "Divisores";
            divisoresToolStripMenuItem.Click += divisoresToolStripMenuItem_Click;
            // 
            // divisoresToolStripMenuItem1
            // 
            divisoresToolStripMenuItem1.Image = Properties.Resources.divisor_Logo1;
            divisoresToolStripMenuItem1.Name = "divisoresToolStripMenuItem1";
            divisoresToolStripMenuItem1.Size = new Size(121, 22);
            divisoresToolStripMenuItem1.Text = "Divisores";
            divisoresToolStripMenuItem1.Click += divisoresToolStripMenuItem1_Click;
            // 
            // paredesToolStripMenuItem
            // 
            paredesToolStripMenuItem.Image = Properties.Resources.pared_logo;
            paredesToolStripMenuItem.Name = "paredesToolStripMenuItem";
            paredesToolStripMenuItem.Size = new Size(121, 22);
            paredesToolStripMenuItem.Text = "Paredes";
            paredesToolStripMenuItem.Click += paredesToolStripMenuItem_Click;
            // 
            // puertasToolStripMenuItem
            // 
            puertasToolStripMenuItem.Image = Properties.Resources.puerta_logo;
            puertasToolStripMenuItem.Name = "puertasToolStripMenuItem";
            puertasToolStripMenuItem.Size = new Size(121, 22);
            puertasToolStripMenuItem.Text = "Puertas";
            puertasToolStripMenuItem.Click += puertasToolStripMenuItem_Click;
            // 
            // bañoToolStripMenuItem
            // 
            bañoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { indoroToolStripMenuItem, urinarioToolStripMenuItem, lavaboToolStripMenuItem });
            bañoToolStripMenuItem.Image = Properties.Resources.baño_logo;
            bañoToolStripMenuItem.Name = "bañoToolStripMenuItem";
            bañoToolStripMenuItem.Size = new Size(121, 22);
            bañoToolStripMenuItem.Text = "Baño";
            // 
            // indoroToolStripMenuItem
            // 
            indoroToolStripMenuItem.Image = Properties.Resources.inodoro_logo;
            indoroToolStripMenuItem.Name = "indoroToolStripMenuItem";
            indoroToolStripMenuItem.Size = new Size(116, 22);
            indoroToolStripMenuItem.Text = "Indoro";
            indoroToolStripMenuItem.Click += indoroToolStripMenuItem_Click;
            // 
            // urinarioToolStripMenuItem
            // 
            urinarioToolStripMenuItem.Image = Properties.Resources.utinario_logo;
            urinarioToolStripMenuItem.Name = "urinarioToolStripMenuItem";
            urinarioToolStripMenuItem.Size = new Size(116, 22);
            urinarioToolStripMenuItem.Text = "Urinario";
            urinarioToolStripMenuItem.Click += urinarioToolStripMenuItem_Click;
            // 
            // lavaboToolStripMenuItem
            // 
            lavaboToolStripMenuItem.Image = Properties.Resources.lavabo_logo;
            lavaboToolStripMenuItem.Name = "lavaboToolStripMenuItem";
            lavaboToolStripMenuItem.Size = new Size(116, 22);
            lavaboToolStripMenuItem.Text = "lavabo";
            lavaboToolStripMenuItem.Click += lavaboToolStripMenuItem_Click;
            // 
            // cocinaToolStripMenuItem
            // 
            cocinaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cocinaToolStripMenuItem1, heladeraToolStripMenuItem, lavaderoGrandeToolStripMenuItem, lavaderoChicoToolStripMenuItem });
            cocinaToolStripMenuItem.Image = Properties.Resources.cocina_logo;
            cocinaToolStripMenuItem.Name = "cocinaToolStripMenuItem";
            cocinaToolStripMenuItem.Size = new Size(121, 22);
            cocinaToolStripMenuItem.Text = "Cocina";
            // 
            // cocinaToolStripMenuItem1
            // 
            cocinaToolStripMenuItem1.Image = Properties.Resources.horno_logo;
            cocinaToolStripMenuItem1.Name = "cocinaToolStripMenuItem1";
            cocinaToolStripMenuItem1.Size = new Size(162, 22);
            cocinaToolStripMenuItem1.Text = "Cocina";
            cocinaToolStripMenuItem1.Click += cocinaToolStripMenuItem1_Click;
            // 
            // heladeraToolStripMenuItem
            // 
            heladeraToolStripMenuItem.Image = Properties.Resources.heladera_logo;
            heladeraToolStripMenuItem.Name = "heladeraToolStripMenuItem";
            heladeraToolStripMenuItem.Size = new Size(162, 22);
            heladeraToolStripMenuItem.Text = "Heladera";
            heladeraToolStripMenuItem.Click += heladeraToolStripMenuItem_Click;
            // 
            // lavaderoGrandeToolStripMenuItem
            // 
            lavaderoGrandeToolStripMenuItem.Image = Properties.Resources.lavadero_grande_logo;
            lavaderoGrandeToolStripMenuItem.Name = "lavaderoGrandeToolStripMenuItem";
            lavaderoGrandeToolStripMenuItem.Size = new Size(162, 22);
            lavaderoGrandeToolStripMenuItem.Text = "Lavadero grande";
            lavaderoGrandeToolStripMenuItem.Click += lavaderoGrandeToolStripMenuItem_Click;
            // 
            // lavaderoChicoToolStripMenuItem
            // 
            lavaderoChicoToolStripMenuItem.Image = Properties.Resources.lvadero_chico_logo1;
            lavaderoChicoToolStripMenuItem.Name = "lavaderoChicoToolStripMenuItem";
            lavaderoChicoToolStripMenuItem.Size = new Size(162, 22);
            lavaderoChicoToolStripMenuItem.Text = "Lavadero chico";
            lavaderoChicoToolStripMenuItem.Click += lavaderoChicoToolStripMenuItem_Click;
            // 
            // pasarAPrevisualizacionToolStripMenuItem
            // 
            pasarAPrevisualizacionToolStripMenuItem.Image = Properties.Resources.Previsualizacion_logo;
            pasarAPrevisualizacionToolStripMenuItem.Name = "pasarAPrevisualizacionToolStripMenuItem";
            pasarAPrevisualizacionToolStripMenuItem.Size = new Size(159, 20);
            pasarAPrevisualizacionToolStripMenuItem.Text = "Pasar a previsualización";
            pasarAPrevisualizacionToolStripMenuItem.Click += pasarAPrevisualizacionToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.RenderMode = ToolStripRenderMode.System;
            contextMenuStrip1.Size = new Size(61, 4);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 317);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(816, 356);
            Name = "Form1";
            Text = "Modo Edicion";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem mesasToolStripMenuItem;
        private ToolStripMenuItem mesaRedondaToolStripMenuItem;
        private ToolStripMenuItem mesaCuadradaToolStripMenuItem;
        private ToolStripMenuItem sillasToolStripMenuItem;
        private ToolStripMenuItem sillasDeGrupoToolStripMenuItem;
        private ToolStripMenuItem sillasIndividualesToolStripMenuItem;
        private ToolStripMenuItem divisoresToolStripMenuItem;
        private ToolStripMenuItem divisoresToolStripMenuItem1;
        private ToolStripMenuItem paredesToolStripMenuItem;
        private ToolStripMenuItem puertasToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem bañoToolStripMenuItem;
        private ToolStripMenuItem indoroToolStripMenuItem;
        private ToolStripMenuItem urinarioToolStripMenuItem;
        private ToolStripMenuItem lavaboToolStripMenuItem;
        private ToolStripMenuItem cocinaToolStripMenuItem;
        private ToolStripMenuItem cocinaToolStripMenuItem1;
        private ToolStripMenuItem heladeraToolStripMenuItem;
        private ToolStripMenuItem lavaderoGrandeToolStripMenuItem;
        private ToolStripMenuItem lavaderoChicoToolStripMenuItem;
        private ToolStripMenuItem pasarAPrevisualizacionToolStripMenuItem;
        private ToolStripMenuItem guardarEnElMismoArchivoToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}
