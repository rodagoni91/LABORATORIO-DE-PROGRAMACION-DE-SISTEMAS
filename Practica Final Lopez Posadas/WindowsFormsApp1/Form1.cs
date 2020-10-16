using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Errores f2;
        CodigoObjeto f3;
        TablaSimbolos f4;
        ArchivoIntermedio f5;
        ArchivoFuente f6;
        List<string> direcciones = new List<string>();
        List<string> etiquetas = new List<string>();
        string basePath;

        public Form1()
        {
            InitializeComponent();
            f2 = new Errores();
            f2.MdiParent = this;
            f2.Show();

            f3 = new CodigoObjeto();
            f3.MdiParent = this;
            f3.Show();

            f4 = new TablaSimbolos();
            f4.MdiParent = this;
            f4.Show();

            f5 = new ArchivoIntermedio();
            f5.MdiParent = this;
            f5.Show();

            f6 = new ArchivoFuente();
            f6.MdiParent = this;
            f6.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);

            string path1 = "WindowsFormsApp1.exe";
            //string fileName = "myfile.ext";
            //string path1 = @"Debug";
            //string path1 = @"\Debug";
            string fullPath;
            basePath = Environment.CurrentDirectory;

            fullPath = Path.GetFullPath(path1);
            //MessageBox.Show(fullPath);
            MessageBox.Show(basePath);


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6.abrir();
            f2.limpia();
            f4.limpia();
            f5.limpia();
            f3.limpia();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6.guardar();
            f2.limpia();
            f4.limpia();
            f5.limpia();
            f3.limpia();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6.nuevo();
            f2.limpia();
            f4.limpia();
            f5.limpia();
            f3.limpia();
            
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6.guardarComo();
            f2.limpia();
            f4.limpia();
            f5.limpia();
            f3.limpia();
        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string directorio = f6.regresaDirec();
            bool band = f6.regresaBand();
            if (directorio != "algo" && band == false)
            {
                compila(directorio);
            }
            else
            {
                f6.guardar();
                directorio = f6.regresaDirec();
                compila(directorio);
            }
            
        }

        private void compila(string directorio)
        {

            bool XE;
            f5.limpiaErrores();
            f2.compila(directorio);
            f5.leeErrores(f2.regresaDirErro());
            XE = f5.checaXE(f6.regresaText());
            direcciones = f5.regresaDir();
            etiquetas = f5.regresaSim();
            f4.llena(etiquetas, direcciones, f5.regresaTam());
            if (XE == false)
            {
                f5.paso2();
                f3.llenarich(f5.regresaRuta());
            }
        }

        private void mapaDeMemoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MapaMemoria mdm = new MapaMemoria(f3.regresa_cadena());
            mdm.MdiParent = this;
            mdm.Show();
        }
    }
}
