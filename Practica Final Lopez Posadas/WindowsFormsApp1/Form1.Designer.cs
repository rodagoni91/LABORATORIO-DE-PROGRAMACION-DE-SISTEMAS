namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapaDeMemoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.compilarToolStripMenuItem,
            this.mapaDeMemoriaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.document_file_icon1;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.add_file_512;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.open_folder_512;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.descarga;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.descarga;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.close_circle_512;
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cerrarToolStripMenuItem.Text = "Salir";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.Image = global::WindowsFormsApp1.Properties.Resources.compile_build_rebuild_make_512;
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.compilarToolStripMenuItem.Text = "Analizar";
            this.compilarToolStripMenuItem.Click += new System.EventHandler(this.compilarToolStripMenuItem_Click);
            // 
            // mapaDeMemoriaToolStripMenuItem
            // 
            this.mapaDeMemoriaToolStripMenuItem.Name = "mapaDeMemoriaToolStripMenuItem";
            this.mapaDeMemoriaToolStripMenuItem.Size = new System.Drawing.Size(144, 24);
            this.mapaDeMemoriaToolStripMenuItem.Text = "Mapa de memoria";
            this.mapaDeMemoriaToolStripMenuItem.Click += new System.EventHandler(this.mapaDeMemoriaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Ensamblador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapaDeMemoriaToolStripMenuItem;
    }
}

