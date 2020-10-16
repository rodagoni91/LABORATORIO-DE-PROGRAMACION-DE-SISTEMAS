using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class TablaSimbolos : Form
    {
        List<string> direcciones = new List<string>();
        List<string> etiquetas = new List<string>();
        public TablaSimbolos()
        {
            InitializeComponent();
        }

        public void llena(List<string> etiq, List<string> dir, int tam)
        {
            limpia();
            etiquetas = etiq;
            direcciones = dir;
            for (int j = 0; j < direcciones.Count; j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = etiquetas[j];
                dataGridView1.Rows[j].Cells[1].Value = direcciones[j];
            }
            dataGridView1.Rows[0].Cells[2].Value = tam.ToString("X");
        }

        public void limpia()
        {
            dataGridView1.Rows.Clear();
        }
    }
}
