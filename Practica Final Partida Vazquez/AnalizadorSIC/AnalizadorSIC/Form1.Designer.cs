namespace AnalizadorSIC
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
            this.btnAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapaDeMemoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tablasim = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.tablaPaso2 = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.archivoObjeto = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tamProg = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.RegistrosXe = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablasim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPaso2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistrosXe)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.analizarToolStripMenuItem,
            this.mapaDeMemoriaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1162, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrir,
            this.toolStripSeparator3,
            this.nuevoToolStripMenuItem,
            this.toolStripSeparator1,
            this.guardarToolStripMenuItem,
            this.toolStripSeparator2,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // btnAbrir
            // 
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(116, 22);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(113, 6);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            // 
            // analizarToolStripMenuItem
            // 
            this.analizarToolStripMenuItem.Name = "analizarToolStripMenuItem";
            this.analizarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.analizarToolStripMenuItem.Text = "Analizar";
            this.analizarToolStripMenuItem.Click += new System.EventHandler(this.Analizar_Click);
            // 
            // mapaDeMemoriaToolStripMenuItem
            // 
            this.mapaDeMemoriaToolStripMenuItem.Name = "mapaDeMemoriaToolStripMenuItem";
            this.mapaDeMemoriaToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.mapaDeMemoriaToolStripMenuItem.Text = "Mapa de Memoria";
            this.mapaDeMemoriaToolStripMenuItem.Click += new System.EventHandler(this.mapaDeMemoriaToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Location = new System.Drawing.Point(23, 67);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(261, 352);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(302, 246);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(252, 123);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Programa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Errores";
            // 
            // tablasim
            // 
            this.tablasim.AllowUserToAddRows = false;
            this.tablasim.AllowUserToDeleteRows = false;
            this.tablasim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.tablasim.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablasim.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.tablasim.Location = new System.Drawing.Point(302, 67);
            this.tablasim.Name = "tablasim";
            this.tablasim.ReadOnly = true;
            this.tablasim.RowHeadersWidth = 80;
            this.tablasim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablasim.Size = new System.Drawing.Size(252, 150);
            this.tablasim.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Simbolo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 69;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Direccion";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "TabSim";
            // 
            // tablaPaso2
            // 
            this.tablaPaso2.AllowUserToAddRows = false;
            this.tablaPaso2.AllowUserToDeleteRows = false;
            this.tablaPaso2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.tablaPaso2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.tablaPaso2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.tablaPaso2.Location = new System.Drawing.Point(561, 67);
            this.tablaPaso2.Name = "tablaPaso2";
            this.tablaPaso2.ReadOnly = true;
            this.tablaPaso2.RowHeadersWidth = 80;
            this.tablaPaso2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tablaPaso2.Size = new System.Drawing.Size(589, 302);
            this.tablaPaso2.TabIndex = 8;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CP";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 46;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Etiqueta";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 71;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Expresion";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 78;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Direccion";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 77;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Cod. Objeto";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 88;
            // 
            // archivoObjeto
            // 
            this.archivoObjeto.AcceptsTab = true;
            this.archivoObjeto.Location = new System.Drawing.Point(302, 403);
            this.archivoObjeto.Name = "archivoObjeto";
            this.archivoObjeto.Size = new System.Drawing.Size(848, 223);
            this.archivoObjeto.TabIndex = 9;
            this.archivoObjeto.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Archivo objeto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 436);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tamaño del Programa";
            // 
            // tamProg
            // 
            this.tamProg.AutoSize = true;
            this.tamProg.Location = new System.Drawing.Point(20, 461);
            this.tamProg.Name = "tamProg";
            this.tamProg.Size = new System.Drawing.Size(0, 13);
            this.tamProg.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(558, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Archivo Intermedio";
            // 
            // RegistrosXe
            // 
            this.RegistrosXe.AllowUserToAddRows = false;
            this.RegistrosXe.AllowUserToDeleteRows = false;
            this.RegistrosXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegistrosXe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.RegistrosXe.Location = new System.Drawing.Point(26, 493);
            this.RegistrosXe.Name = "RegistrosXe";
            this.RegistrosXe.ReadOnly = true;
            this.RegistrosXe.Size = new System.Drawing.Size(240, 150);
            this.RegistrosXe.TabIndex = 14;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Nombre Registro";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Valor";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 661);
            this.Controls.Add(this.RegistrosXe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tamProg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.archivoObjeto);
            this.Controls.Add(this.tablaPaso2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tablasim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablasim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaPaso2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistrosXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnAbrir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem analizarToolStripMenuItem;
        private System.Windows.Forms.DataGridView tablasim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tablaPaso2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.RichTextBox archivoObjeto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tamProg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem mapaDeMemoriaToolStripMenuItem;
        private System.Windows.Forms.DataGridView RegistrosXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}

