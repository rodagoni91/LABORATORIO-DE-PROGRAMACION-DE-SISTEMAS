namespace WindowsFormsApp1
{
    partial class ArchivoIntermedio
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Lin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContadorPrograma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Etiq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instruccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CódigoObjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lin,
            this.ContadorPrograma,
            this.Etiq,
            this.Instruccion,
            this.Dire,
            this.CódigoObjeto});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // Lin
            // 
            this.Lin.HeaderText = "Linea";
            this.Lin.Name = "Lin";
            // 
            // ContadorPrograma
            // 
            this.ContadorPrograma.HeaderText = "CP";
            this.ContadorPrograma.Name = "ContadorPrograma";
            // 
            // Etiq
            // 
            this.Etiq.HeaderText = "Etiqueta";
            this.Etiq.Name = "Etiq";
            // 
            // Instruccion
            // 
            this.Instruccion.HeaderText = "Instrucción";
            this.Instruccion.Name = "Instruccion";
            // 
            // Dire
            // 
            this.Dire.HeaderText = "Dirección";
            this.Dire.Name = "Dire";
            // 
            // CódigoObjeto
            // 
            this.CódigoObjeto.HeaderText = "Código Objeto";
            this.CódigoObjeto.Name = "CódigoObjeto";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form5";
            this.Text = "Archivo intermedio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContadorPrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etiq;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instruccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dire;
        private System.Windows.Forms.DataGridViewTextBoxColumn CódigoObjeto;
    }
}