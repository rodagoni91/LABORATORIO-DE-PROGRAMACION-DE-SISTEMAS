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
    public partial class CodigoObjeto : Form
    {
        public CodigoObjeto()
        {
            InitializeComponent();
        }

        public void llenarich(string ruta)
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        public void limpia()
        {
            richTextBox1.Text = "";
        }
        
        public string regresa_cadena()
        {
            return richTextBox1.Text;
        }
    }
}
