using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorSIC
{
    public partial class Form1 : Form
    {
        string contenidoArchivo;
        string ruta;
        String PATH = "";
        string nombrearchivo;
        AtraparErrores error;
        String longProg;
        String direccionIni;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contenidoArchivo = "";
            ruta = "";
            RegistrosXe.Visible = false;
            RegistrosXe.Rows.Add("A", "FFFFFF");
            RegistrosXe.Rows.Add("X", "FFFFFF");
            RegistrosXe.Rows.Add("PC", "FFFFFF");
            RegistrosXe.Rows.Add("L", "FFFFFF");
            RegistrosXe.Rows.Add("SW", "FFFFFF");
            RegistrosXe.Rows.Add("B", "FFFFFF");
            RegistrosXe.Rows.Add("S", "FFFFFF");
            RegistrosXe.Rows.Add("T", "FFFFFF");
            RegistrosXe.Rows.Add("F", "FFFFFF");
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            PATH = System.Environment.CurrentDirectory;
            PATH += @"\Ejemplos";

            try
            {
                openFileDialog1.InitialDirectory = PATH;
                if(openFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    tablaPaso2.Columns[tablaPaso2.Columns.Count - 1].Visible = true;
                    nuevoToolStripMenuItem_Click(this, null);
                }

                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string archivo;
                archivo = sr.ReadToEnd();
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                if (richTextBox1.Text != "")
                {
                    richTextBox1.Text = archivo;
                }
                nombrearchivo = openFileDialog1.FileName;
                ruta = openFileDialog1.FileName.ToString();
                sr.Close();
                richTextBox1.Text = archivo;
                contenidoArchivo = archivo;
            }
            catch { }
        }

        private void Analizar_Click(object sender, EventArgs e)
        {
            bool band = File.Exists(PATH + @"\errores.txt");
            if (band )
            {
                File.Delete(PATH + @"\errores.txt");
            }
            richTextBox2.Clear();
            error = new AtraparErrores(ruta,richTextBox2);
            contenidoArchivo = richTextBox1.Text;
            string myString = contenidoArchivo;
            gramticSicEstandarLexer lex = 
                new gramticSicEstandarLexer(new AntlrInputStream(myString + Environment.NewLine));
            CommonTokenStream tokens = new CommonTokenStream(lex);
            gramticSicEstandarParser parser = new gramticSicEstandarParser(tokens);
            parser.RemoveErrorListeners();
            lex.RemoveErrorListeners();
            parser.AddErrorListener(error);
            lex.AddErrorListener(error);
            parser.programa();
            /*Aqui se depliega un mensaje si hay o no errores*/
            if(!error.TieneErrores())
            {
                
                richTextBox2.Text = "Todo bien, todo correcto y yo que me alegro!!!";
            }
            else
            {
                StreamReader sr = new StreamReader(PATH + @"\errores.txt");
                richTextBox2.Text = sr.ReadToEnd();
                sr.Close();
            }
           TablaSimbolos();

        }

        private void TablaSimbolos()
        {
            AntlrInputStream input;
            gramticSicEstandarLexer lexer;
            CommonTokenStream tokens;
            gramticSicEstandarParser parser;
            Paso1 contador = new Paso1();
            int contadorLineas = 0;
            List<string> cp = new List<string>();
            string[] lineasTexto = contenidoArchivo.Split('\n');
            foreach (string linea in lineasTexto)
            {
                input = new AntlrInputStream(linea);
                lexer = new gramticSicEstandarLexer(input);
                tokens = new CommonTokenStream(lexer);
                parser = new gramticSicEstandarParser(tokens);
                try
                {
                    if (contadorLineas == 0)
                        contador.Visit(parser.inicio());
                    else if (linea != "END" && !string.IsNullOrEmpty(linea))
                    {
                        if(linea=="\tRSUB")
                        {
                            contador.CP += 3;
                        }
                        contador.Visit(parser.proposicion());
                    }
                    else
                        parser.fin();
                }
                catch (Exception ex)
                {
                    //File.AppendAllText(nombrearchivo+ ".err", ex.Message + '\t' + contadorLineas.ToString() + "\n");
                    richTextBox2.Text += "";
                }

                cp.Add(contador.CP.ToString("X"));
                contadorLineas++;
            }
            Paso2 p2 = new Paso2(contador.TABSIM, Convert.ToInt32(cp[cp.Count - 1], 16) - Convert.ToInt32(cp[0], 16));
            cp.Insert(0, cp[0]);
            contadorLineas = 0;
            int longitudRegistroT = 0;
            tablaPaso2.Rows.Clear();
            List<string> codigoFuente = new List<string>(5);
            char[] delimiters = {' ', '\t' };
            foreach (string linea in lineasTexto)
            {
                input = new AntlrInputStream(linea);
                lexer = new gramticSicEstandarLexer(input);
                tokens = new CommonTokenStream(lexer);
                parser = new gramticSicEstandarParser(tokens);
                //parser.RemoveErrorListeners();
               
                try
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        codigoFuente.Insert(0, cp[contadorLineas]);
                        codigoFuente.InsertRange(1, linea.Split(delimiters));

                        if (contadorLineas == 0)
                        {
                            codigoFuente.Insert(4, p2.Visit(parser.inicio()));
                            archivoObjeto.Text = p2.registroH + "\n";
                        }
                        else
                        {
                            codigoFuente.Insert(4, p2.Visit(parser.proposicion()));
                        }

                        tablaPaso2.Rows.Add(codigoFuente.ToArray());
                        codigoFuente = new List<string> { "" };
                    }
                }
                catch (Exception ex)
                {
                    tablaPaso2.Rows.Add(codigoFuente.ToArray());
                }
                contadorLineas++;
            }
            LlenaTablaTabSim(contador.TABSIM);
            CreaArchivos(p2.longitudPrograma);
            longProg = p2.longitudPrograma.ToString("X");
            direccionIni = p2.dirInicio;
            tamProg.Text = p2.longitudPrograma.ToString("X");
            foreach (DataGridViewRow row in tablaPaso2.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
               foreach(int i in error.ListaErrores)
                {
                    if(row.Index==i)
                    {
                        tablaPaso2[tablaPaso2.ColumnCount - 1, i-1].Value = "error";
                    }
                }
            }
            if (!contador.formato4)
            {
                RegistrosXe.Visible = false;
                GeneraRegistroT();
                GeneraRegistroE();
                CrearArchivoRegistro();
            }
            else
            {
                tablaPaso2.Columns[tablaPaso2.Columns.Count - 1].Visible = false;
                RegistrosXe.Visible = true;
            }
        }

        private void CrearArchivoRegistro()
        {
            char[] delimiter = { '.' };
            string dir = ruta.Split(delimiter)[0] + "_archivoRegistro.txt";
            if (File.Exists(dir))
            {
                File.Delete(dir);
            }
            StreamWriter writer = new StreamWriter(dir);
            char[] delimiter2 = { '\n' };
            string [] ren = archivoObjeto.Text.Split(delimiter2);
            foreach(string s in ren)
            {
                writer.WriteLine(s);
            }
            writer.Close();
        }

        private void LlenaTablaTabSim(Dictionary<string, int> dicTabsim)
        {
            tablasim.Rows.Clear();
            foreach (string key in dicTabsim.Keys)
                tablasim.Rows.Add(key, dicTabsim[key].ToString("X"));

            foreach (DataGridViewRow row in tablasim.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        public void CreaArchivos(int longitudP)
        {
            char[] delimiter = { '.' };
            string dir = ruta.Split(delimiter)[0] + "_tabSim.txt";
            if(File.Exists(dir))
            {
                File.Delete(dir);
            }
            StreamWriter writer = new StreamWriter(dir);

            for(int i =0; i<tablasim.Rows.Count;i++)
            {
                writer.WriteLine(tablasim[0,i].Value.ToString() + '\t' + tablasim[1,i].Value.ToString());
            }
            writer.WriteLine("Longitud del Programa: "+longitudP.ToString("X"));
            writer.Close();

            string dir2 = ruta.Split(delimiter)[0] + "_inter.txt";
            if (File.Exists(dir2))
            {
                File.Delete(dir2);
            }
            StreamWriter writer2 = new StreamWriter(dir2);
            for (int i = 0; i < tablaPaso2.Rows.Count; i++)
            {
                string cad = " ";
                for(int j=0; j<tablaPaso2.Columns.Count; j++)
                {
                    if(tablaPaso2[j,i].Value!=null)
                    {
                        if (j == 4)
                        {
                            cad += tablaPaso2[j, i].Value.ToString() + '\t'+'\t';
                        }
                        else
                        {
                            cad += tablaPaso2[j, i].Value.ToString()+'\t';
                        }
                        
                    }
                    else
                    {
                        cad += "-------" + '\t'+'\t';
                    }
                }
                writer2.WriteLine(cad);
            }
            writer2.Close();
        }

        private void GeneraRegistroT()
        {
            string regT="T"+tablaPaso2[0,1].Value.ToString().PadLeft(6,'0');
            string aux="";
            string aux2="";
            char[] delemiter = { ',' };

            for(int i=0; i<tablaPaso2.RowCount;i++)
            {
                if (tablaPaso2[tablaPaso2.ColumnCount - 1, i].Value != null)
                {
                    aux = tablaPaso2[tablaPaso2.ColumnCount - 1, i].Value.ToString().Split(delemiter,StringSplitOptions.RemoveEmptyEntries)[0];
                    string aux3 = tablaPaso2[2, i].Value.ToString();
                    if (i!=0 && aux!="error")
                    {
                        if (!ChecaResW_ResB_Rsub(tablaPaso2[2, i].Value.ToString()))
                        {
                            if ((aux.Length + aux2.Length) <= 60)
                            {
                                aux2 += aux;
                            }
                            else
                            {
                                if (aux2 != "")
                                {
                                    regT += (aux2.Length/2).ToString("X").PadLeft(2, '0') + aux2;
                                    regT += (aux2.Length/2).ToString("X").PadLeft(2, '0') + aux2;
                                    archivoObjeto.Text += regT +'\n';
                                    aux2 = "";
                                    regT = "T" + tablaPaso2[0, i].Value.ToString().PadLeft(6, '0');
                                }
                                else
                                {
                                    regT = "T" + tablaPaso2[0, i].Value.ToString().PadLeft(6, '0');
                                    aux2 = "";
                                }
                            }
                        }
                        else
                        {
                            if (aux2 != "")
                            {
                                regT += (aux2.Length/2).ToString("X").PadLeft(2, '0') + aux2;
                                archivoObjeto.Text +=  regT+'\n' ;

                                if (!ChecaResW_ResB_Rsub(tablaPaso2[2, i].Value.ToString()))
                                {
                                    regT = "T" + tablaPaso2[0, i].Value.ToString().PadLeft(6, '0');
                                    aux2 = "";
                                }
                                else
                                {
                                    regT = "T" + tablaPaso2[0, i + 1].Value.ToString().PadLeft(6, '0');
                                    aux2 = "";
                                }
                            }
                            else
                            {
                                if(!ChecaResW_ResB_Rsub(tablaPaso2[2, i].Value.ToString()))
                                {
                                    regT = "T" + tablaPaso2[0, i].Value.ToString().PadLeft(6, '0');
                                    aux2 = "";
                                }
                                else
                                {
                                    regT = "T" + tablaPaso2[0, i+1].Value.ToString().PadLeft(6, '0');
                                    aux2 = "";
                                }
                            }
                        }
                        
                    }
                }
            }
            if (aux2!="")
            {
                regT += (aux2.Length/2).ToString("X").PadLeft(2, '0') + aux2;
                archivoObjeto.Text += regT+'\n';
            }
        }

        private bool ChecaResW_ResB_Rsub(string v)
        {
            if (v == "RESB" || v == "RESW")
                return true;
            return false;
        }

        public void GeneraRegistroE()
        {
            string RegE = "E";

            if (tablaPaso2[3, tablaPaso2.RowCount - 1].Value != null&& tablaPaso2[3, tablaPaso2.RowCount - 1].Value.ToString() !="")
            {
                string val = "";
                if (ChecaTablaSim(tablaPaso2[3, tablaPaso2.RowCount - 1].Value.ToString(),ref val))
                {
                    RegE += val.PadLeft(6, '0');
                }
                else
                {
                    RegE += "FFFFFF";
                }
            }
            else
            {
                RegE += BuscaPrimeraInstruccion().PadLeft(6,'0');
            }
            archivoObjeto.Text += RegE;
        }

        private string BuscaPrimeraInstruccion()
        {
            string[] instrucciones = {"ADD","AND","COMP","DIV","J",
                    "JEQ","JGT","JLT","JSUB","LDA",
                    "LDCH","LDL","LDX","MUL","OR",
                    "RD","STA","STCH","STL",
                    "STSW","STX","SUB","TD","TIX","WD" };
            for(int i=0; i<tablaPaso2.RowCount;i++)
            {
                Char[] delimiters = { ' ','\t','\n' };
                string[] cads = tablaPaso2[2, i].Value.ToString().Split(delimiters);
                if (instrucciones.Contains(cads[0]))
                {
                    return tablaPaso2[0, i].Value.ToString();
                }
            }

            return "";
        }

        private bool ChecaTablaSim(string v, ref string val)
        {
            for(int i=0; i<tablasim.RowCount;i++)
            {
                if(v==tablasim[0,i].Value.ToString())
                {
                    val = tablasim[1, i].Value.ToString();
                    return true;
                }
            }
            return false;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoObjeto.Clear();
            tablaPaso2.Rows.Clear();
            tablasim.Rows.Clear();
            tamProg.Text = "";
            richTextBox1.Clear();
            richTextBox2.Clear();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory= @System.Environment.CurrentDirectory+"\\Ejemplos";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(saveFileDialog1.FileName);
                char[] delimiter = { '\n' };
                string[] ren = richTextBox1.Text.Split(delimiter);
                foreach(string s in ren)
                {
                    stream.WriteLine(s);
                }
                stream.Close();
                ruta = saveFileDialog1.FileName;
            }
        }

        private void mapaDeMemoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] delimiter = { '.' };
            string dir = ruta.Split(delimiter)[0] + "_archivoRegistro.txt";

            mapa m;

            if (archivoObjeto.Text != "")
                m = new mapa(direccionIni, longProg, dir);
            else
                m = new mapa();

            m.ShowDialog();
        }
    }
}
