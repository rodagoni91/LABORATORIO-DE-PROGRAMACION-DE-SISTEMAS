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
    public partial class ArchivoFuente : Form
    {
        string directorio="algo";
        bool textoCambiado = false;
        public ArchivoFuente()
        {
            InitializeComponent();
        }

        public void nuevo()
        {
            richTextBox1.Clear();
            directorio = "algo";
            textoCambiado = false;
        }

        public void abrir()
        {
            
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Archivo Fuente (*.s)|*.s";
            openfile.Title = "Abrir archivo";

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            directorio=openfile.FileName;
            textoCambiado = false;
        }

        public void guardarComo()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Archivo Fuente (*.s)|*.s";
            savefile.Title = "Guarda como..";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                txtoutput.Write(richTextBox1.Text);
                txtoutput.Close();
            }
            textoCambiado = false;
            directorio = savefile.FileName;
        }

        public void guardar()
        {
            if (directorio!="algo")
            {
                File.WriteAllText(directorio, richTextBox1.Text);
            }
            else
            {
                guardarComo();
            }
            textoCambiado = false;
        }

        public string regresaDirec()
        {
            return directorio;
        }

        public string regresaText()
        {
            return richTextBox1.Text;
        }

        public bool regresaBand()
        {
            return textoCambiado;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textoCambiado = true;
        }
    }
}
