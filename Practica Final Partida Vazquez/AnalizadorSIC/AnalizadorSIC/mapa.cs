using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorSIC
{
    public partial class mapa : Form
    {

        string CC = "";
        string direccionInicio="";
        string tamProg;
        string archivoObj;
        private string ruta;
        string dirActual = "";
        public string PATH { get; private set; }
        int NUMFINAL;
        public mapa( string dirIni, string tam, string nameFile)
        {
            InitializeComponent();
            dirInicio.Text= direccionInicio = dirIni;
            label6.Text= tamProg = tam;
            archivoObj = nameFile;
        }

        public mapa()
        {
            InitializeComponent();
          
        }

        private void mapa_Load(object sender, EventArgs e)
        {
            tablaRegistros.Rows.Add("PC", "FFFFFF");
            tablaRegistros.Rows.Add("A", "FFFFFF");
            tablaRegistros.Rows.Add("X", "FFFFFF");
            tablaRegistros.Rows.Add("L", "FFFFFF");
            tablaRegistros.Rows.Add("SW", "FFFFFF");

            if (direccionInicio != "")
            {
                CrearTabla();
                cargaPrograma();
            }
          
        }
        /// <summary>
        /// Este metodo crea la tabla llenandola de dos F cada celda
        /// </summary>
        private void CrearTabla()
        {
            string inicio = calcularInicio();
            string fin = calcularFin();
            string aux = inicio;
            int cont = 0;
            int numInicio = Convert.ToInt32(inicio, 16);
            int numFinal = Convert.ToInt32(fin, 16);
            mapaMem.Rows.Clear();
            while (numInicio < numFinal)
            {
                mapaMem.Rows.Add("FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF");
                String INTER = (cont * 16).ToString("X");
                aux = (Convert.ToInt32(inicio, 16) + Convert.ToInt32(INTER, 16)).ToString("X");
                numInicio = Convert.ToInt32(aux, 16);
                mapaMem.Rows[cont].HeaderCell.Value = aux;
                cont++;
            }

            NUMFINAL = Convert.ToInt32(aux,16)+16;
        }
        /// <summary>
        /// Este metodo calcula la direccion final del ultimo renglon
        /// </summary>
        /// <returns></returns>
        private string calcularFin()
        {
            string res = "";
            string cad = (Convert.ToInt32(direccionInicio, 16) + Convert.ToInt32(tamProg, 16)).ToString("X"); ;
            String unidad = cad[cad.Length - 1].ToString();
            int numF = Convert.ToInt32(unidad, 16);

            res = (Convert.ToInt32(cad, 16) - Convert.ToInt32(numF.ToString(), 16)).ToString("X");

            return res;
        }
        /// <summary>
        /// Este metodo calcula la direccion para el primer renglon
        /// </summary>
        /// <returns></returns>
        private string calcularInicio()
        {
            string res = "";
            string cad = direccionInicio.ToString();
            string unidad = cad[cad.Length - 1].ToString();
            int NUM1 = Convert.ToInt32(direccionInicio, 16);
            int NUM2 = Convert.ToInt32(unidad, 16);
            res = (NUM1 - NUM2).ToString("X");

            return res;
        }

        /// <summary>
        /// Este metodo lee el archivo y analiza renglon por renglon obteniendo solo el codigo objeto
        /// </summary>
        private void cargaPrograma()
        {
            StreamReader reader = new StreamReader(archivoObj);
            string line = "";
            string dirT = "";
            string tamReg = "";
            string regT = "";
            int iterator = 1;
            string dirInt = "";
            while(line!=null||line!="")
            {
                line = reader.ReadLine();
                if(line[0]=='T')
                {
                    dirT = TomaCaracteres(6, line,ref iterator);
                    dirInt = dirT;
                    tamReg = TomaCaracteres(2, line, ref iterator);
                    for(int i=0; i<mapaMem.RowCount;)
                    {
                        string num = (Convert.ToInt32(dirT, 16) - Convert.ToInt32(dirT[dirT.Length - 1].ToString(), 16)).ToString("X").PadLeft(6,'0');
                        if (mapaMem.Rows[i].HeaderCell.Value.ToString().PadLeft(6,'0')==num)
                        {
                            regT = TomaCaracteres(2, line, ref iterator);
                            if (regT=="")
                            {
                                iterator = 1;
                                break;
                            }
                            string colIndex = dirInt[dirInt.Length - 1].ToString();
                            for(int j= 0; j<mapaMem.ColumnCount;j++)
                            {
                                if(mapaMem.Columns[j].HeaderText==colIndex)
                                {
                                    mapaMem[j, i].Value = regT;
                                    break;
                                }
                            }
                            if(colIndex=="F")
                            {
                                dirT= (Convert.ToInt32(dirInt, 16) + 1).ToString("X").PadLeft(6,'0');
                                dirInt=dirT;
                                i++; 
                            }
                            else
                            {
                                dirInt = (Convert.ToInt32(dirInt, 16) + 1).ToString("X");
                            }
                            
                        }
                        else {
                            i++;
                        }
                    }
                    
                }
                else
                {
                    if(line[0]=='E')
                    {
                        iterator = 1;
                        string dirStart = TomaCaracteres(6, line, ref iterator);
                        tablaRegistros[1, 0].Value = dirStart;
                        break;
                    }
                }
            }

        }

        private string TomaCaracteres(int v, string line, ref int i)
        {
            string cars = "";
            int val = i;
            for (; i < line.Length; i++)
            {
                if(i==v+val)
                {
                    return cars;
                }
                else
                {
                    cars += line[i];

                }
            }
            if(cars!="")
            {
                return cars;
            }
            return "";
        }

        private void abirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iterator=1;
            PATH = System.Environment.CurrentDirectory;
            PATH += @"\Ejemplos";

            try
            {
                openFileDialog1.InitialDirectory = PATH;
                openFileDialog1.ShowDialog();

                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                string archivo;
                archivo = sr.ReadLine();

                if(archivo[0]=='H')
                {
                    string nombre = TomaCaracteres(6,archivo,ref iterator);
                    string dirIni = TomaCaracteres(6, archivo, ref iterator);
                    string tam = TomaCaracteres(6, archivo, ref iterator);

                    archivoObj = openFileDialog1.FileName;
                    dirInicio.Text=direccionInicio = dirIni;
                    label6.Text= tamProg = tam;

                    CrearTabla();
                    cargaPrograma();

                }
                else
                {
                    MessageBox.Show("El archivo no tiene el formato adecuado.");
                }

                ruta = openFileDialog1.FileName.ToString();
                sr.Close();
            }
            catch { }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            bool CONTINUAR = true;
            int numInstrucciones = (int)numInstr.Value; //toma el numero de instrucciones del numeric box

            for(int i=0;i<numInstrucciones; i++)
            { 
                salida.Text += "CP: " + tablaRegistros[1, 0].Value.ToString() + '\n';
                string cp = tablaRegistros[1, 0].Value.ToString();
                string colIndex = cp[cp.Length-1].ToString();
                string numren = (Convert.ToInt32(cp, 16) - Convert.ToInt32(colIndex, 16)).ToString("X");
                string instruccion = "";
                instruccion = ObtenerContenido(cp).ToString("X").PadLeft(6,'0');
                dirActual = (Convert.ToInt32(cp, 16) + 3).ToString("X");
                tablaRegistros[1, 0].Value = dirActual.PadLeft(6, '0');

                CONTINUAR = ejecutaInstrccion(instruccion);
                salida.SelectionStart = salida.Text.Length;
                salida.ScrollToCaret();
                

                if (!CONTINUAR)
                {
                    break;
                }
            }
        }

        private bool ejecutaInstrccion(string instruccion)
        {
            bool band = true;
            int iterator = 0;
            string codOp = TomaCaracteres(2, instruccion,ref iterator);
            string valorCodOP = TomaCaracteres(4, instruccion, ref iterator);
            string dirm = indexado(valorCodOP);
            bool end = false;
            if(valorCodOP!=dirm)
            {
                valorCodOP = dirm;
                valorCodOP = (Convert.ToInt32(valorCodOP, 16) + 
                    Convert.ToInt32(tablaRegistros[1, 2].Value.ToString(), 16)).ToString("X");
            }

            salida.Text += "m: " + valorCodOP + '\n';
            switch (codOp)
            {
                case "18":
                    salida.Text += "A<--(A)+(m..m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + "+" +
                        ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';
                    tablaRegistros[1, 1].Value = (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) +
                        ObtenerContenido(valorCodOP)).ToString();
                    break;
                case "40":
                    salida.Text += "A<--(A)&(m..m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + "&" + 
                        ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';

                    tablaRegistros[1, 1].Value = (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) & 
                        ObtenerContenido(valorCodOP)).ToString("X");
                    break;
                case "28":
                    salida.Text += "A<--(A):(m..m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + ":" + ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';

                    if (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) == ObtenerContenido(valorCodOP))
                    {
                        CC = "=";
                    }
                    else
                    {
                        if (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) > ObtenerContenido(valorCodOP))
                        {
                            CC = ">";
                        }
                        else
                        {
                            CC = "<";
                        }
                    }
                    CCtxt.Text = CC;
                    break;
                case "24":
                    salida.Text += "A<--(A)/(m..m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + "/" + ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';

                    tablaRegistros[1, 1].Value = (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) / ObtenerContenido(valorCodOP)).ToString("X");
                    break;
                case "3C":
                    salida.Text += "CP<--m" + '\n';
                    salida.Text += "CP<--" + valorCodOP.PadLeft(6, '0') + '\n';

                    tablaRegistros[1, 0].Value = valorCodOP.ToString().PadLeft(6, '0');
                    break;
                case "30":
                    if (CC == "=")
                    {
                        salida.Text += "CP<--m si CC:=" + '\n';
                        salida.Text += "CP<--" + valorCodOP.PadLeft(6, '0') + '\n';
                        tablaRegistros[1, 0].Value = valorCodOP.ToString().PadLeft(6, '0');
                    }
                    break;
                case "34":
                    if (CC == ">")
                    {
                        salida.Text += "CP<--m si CC:>" + '\n';
                        salida.Text += "CP<--" + valorCodOP.PadLeft(6, '0') + '\n';
                        tablaRegistros[1, 0].Value = valorCodOP.ToString().PadLeft(6, '0');
                    }
                    break;
                case "38":
                    if (CC == "<")
                    {
                        salida.Text += "CP<--m si CC:<" + '\n';
                        salida.Text += "CP<--" + valorCodOP.PadLeft(6, '0') + '\n';
                        tablaRegistros[1, 0].Value = valorCodOP.ToString().PadLeft(6, '0');
                    }
                    break;
                case "48":
                    salida.Text += "L<--(CP);" + '\n' + "CP<--m";
                    salida.Text += "L<--" + ObtenerContenido(tablaRegistros[1, 0].Value.ToString()).ToString("X").PadLeft(6, '0') + ";\n" + "Cp<--" + valorCodOP.ToString().PadLeft(6, '0') + '\n';
                    tablaRegistros[1, 3].Value = ObtenerContenido(tablaRegistros[1, 0].Value.ToString()).ToString("X").PadLeft(6, '0');
                    tablaRegistros[1, 0].Value = valorCodOP.ToString().PadLeft(6, '0');
                    break;
                case "00":
                    salida.Text += "A<--(m..m+2)" + '\n';
                    salida.Text += "A<--" + ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';

                    tablaRegistros[1, 1].Value = ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0');
                    break;
                case "50":
                    int xp = 4;
                    String aux = TomaCaracteres(4, tablaRegistros[1, 1].Value.ToString(), ref xp);
                    salida.Text += "A[byte+derecha]<--(m)" + '\n';
                    salida.Text += "[" + aux + "]<--" + SingleByte_Obtener(valorCodOP).ToString() + '\n';

                    tablaRegistros[1, 1].Value = SingleByte_Obtener(valorCodOP).PadLeft(6,'F');
                    break;
                case "08":
                    salida.Text += "L<--(m...m+2)" + '\n';
                    salida.Text += "L<--" + ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';
                    tablaRegistros[1, 3].Value = ObtenerContenido(valorCodOP).ToString("X");
                    break;
                case "04":
                    salida.Text += "X<--(m...m+2)" + '\n';
                    salida.Text += "X<--" + ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';
                    string sux = ObtenerContenido(valorCodOP).ToString("X");
                    tablaRegistros[1, 2].Value = sux.PadLeft(6, '0');
                    break;
                case "20":
                    salida.Text += "A<--(A)*(m...m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + "*" + ObtenerContenido(instruccion).ToString("X").PadLeft(6, '0') + '\n';
                    tablaRegistros[1, 1].Value = (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) * ObtenerContenido(valorCodOP)).ToString("X");
                    break;
                case "44":
                    salida.Text += "A<--(A)|(m...m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + "|" + ObtenerContenido(instruccion).ToString("X").PadLeft(6, '0') + '\n';
                    tablaRegistros[1, 1].Value = (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) | ObtenerContenido(valorCodOP)).ToString("X");
                    break;
                case "D8":

                    break;
                case "4C":
                    salida.Text += "PC<--(L)" + '\n';
                    salida.Text += "PC<--" + ObtenerContenido(tablaRegistros[1, 3].Value.ToString()).ToString("X") + '\n';
                    tablaRegistros[1, 0].Value = ObtenerContenido(tablaRegistros[1, 3].Value.ToString()).ToString("X");
                    end = true;
                    break;
                case "0C":
                    salida.Text += "m...m+2<--(A)" + '\n';
                    salida.Text += "m...m+2<--" + ObtenerContenido(tablaRegistros[1, 1].Value.ToString()).ToString("X") + '\n';
                    ColocarContenido(ObtenerContenido(tablaRegistros[1, 1].Value.ToString()).ToString("X"), valorCodOP);
                    break;
                case "54":
                    int numcar = 4;
                    salida.Text += "m<--(A)[byte+derecha]" + '\n';
                    string bytederecah = TomaCaracteres(2, tablaRegistros[1, 1].Value.ToString(), ref numcar);
                    salida.Text += valorCodOP+"<--" + bytederecah + '\n';
                    ColocarContenido_UnByte(bytederecah, valorCodOP);
                    break;
                case "14":
                    salida.Text += "m...m+2<--(L)" + '\n';
                    salida.Text += "m...m+2<--" + ObtenerContenido(tablaRegistros[1, 3].Value.ToString()).ToString("X") + '\n';
                    ColocarContenido(ObtenerContenido(tablaRegistros[1, 3].Value.ToString()).ToString("X"), valorCodOP);
                    break;
                case "E8":
                    salida.Text += "m...m+2<--(SW)" + '\n';
                    salida.Text += "m...m+2<--" + ObtenerContenido(tablaRegistros[1, 4].Value.ToString()).ToString("X") + '\n';
                    ColocarContenido(ObtenerContenido(tablaRegistros[1, 4].Value.ToString()).ToString("X"), valorCodOP);
                    break;
                case "10":
                    salida.Text += "m...m+2<--(X)" + '\n';
                    salida.Text += "m...m+2<--" + ObtenerContenido(tablaRegistros[1, 2].Value.ToString()).ToString("X") + '\n';
                    ColocarContenido(ObtenerContenido(tablaRegistros[1, 2].Value.ToString()).ToString("X"), valorCodOP);
                    break;
                case "1C":
                    salida.Text += "A<--(A)-(m...m+2)" + '\n';
                    salida.Text += "A<--" + tablaRegistros[1, 1].Value.ToString() + "-" + ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0') + '\n';
                    tablaRegistros[1, 1].Value = (Convert.ToInt32(tablaRegistros[1, 1].Value.ToString(), 16) - ObtenerContenido(valorCodOP)).ToString("X");
                    break;
                case "E0":

                    break;
                case "2C":
                    string cont = ObtenerContenido(valorCodOP).ToString("X").PadLeft(6, '0');
                    salida.Text += "X<--(X)+1; (X):(m...m+2)" + '\n';
                    salida.Text += "X<--" + tablaRegistros[1, 2].Value.ToString() + "+1" + ";";
                    tablaRegistros[1, 2].Value = (Convert.ToInt32(tablaRegistros[1, 2].Value.ToString(), 16) +1).ToString("X");
                    salida.Text+= tablaRegistros[1, 2].Value.ToString() + ":" + cont + '\n';
                    if (Convert.ToInt32(tablaRegistros[1, 2].Value.ToString(), 16) == Convert.ToInt32(cont,16))
                    {
                        CC = "=";
                    }
                    else
                    {
                        if (Convert.ToInt32(tablaRegistros[1, 2].Value.ToString(), 16) > Convert.ToInt32(cont, 16))
                        {
                            CC = ">";
                        }
                        else
                        {
                            CC = "<";
                        }
                    }
                    CCtxt.Text = CC;
                    break;
                case "DC":
                    break;
                default:
                    if(end)
                        salida.Text += "END" + '\n';
                    else
                        salida.Text += "Error" + '\n';
                    band = false;
                    break;
            }
            return band;
        }

        private string indexado(string valorCodOP)
        {
            string indexval = "8000";
            int Num = Convert.ToInt32(valorCodOP.PadLeft(6, '0'), 16);
            string cad = NUMFINAL.ToString("X");
            if ( Num > NUMFINAL)
            {
                return (Convert.ToInt32(valorCodOP.PadLeft(6, '0'), 16) - Convert.ToInt32(indexval.PadLeft(6, '0'), 16)).ToString("X");
            }
            return valorCodOP;
        }

        private void ColocarContenido_UnByte(string contenido, string direccion)
        {
            string colIndex = direccion[direccion.Length-1].ToString();
            string rowindex = (Convert.ToInt32(direccion, 16) - Convert.ToInt32(colIndex, 16)).ToString("X");

            for (int i = 0; i < mapaMem.RowCount; i++)
            {
                if (mapaMem.Rows[i].HeaderCell.Value.ToString().PadLeft(6, '0') == rowindex.PadLeft(6, '0'))
                {
                    for (int j = 0; j < mapaMem.ColumnCount; j++)
                    {
                        if (mapaMem.Columns[j].HeaderText == colIndex)
                        {
                            mapaMem[j, i].Value = contenido;
                            if (mapaMem[j, i].Style.BackColor != Color.GreenYellow)
                                mapaMem[j, i].Style.BackColor = Color.GreenYellow;
                            else
                                mapaMem[j, i].Style.BackColor = Color.Green;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void ColocarContenido(string contenido, string direccion)
        {
           string colIndex = direccion[direccion.Length-1].ToString();
            string rowindex = (Convert.ToInt32(direccion, 16) - Convert.ToInt32(colIndex, 16)).ToString();

            for (int i = 0; i < mapaMem.RowCount; i++)
            {
                if (mapaMem.Rows[i].HeaderCell.Value.ToString().PadLeft(6, '0') == rowindex.PadLeft(6, '0'))
                {
                    for (int j = 0; j < mapaMem.ColumnCount; j++)
                    {
                        if (mapaMem.Columns[j].HeaderText == colIndex)
                        {
                            int iterator = 0;
                            mapaMem[j, i].Value = TomaCaracteres(2, contenido, ref iterator);
                            mapaMem[j+1, i].Value = TomaCaracteres(2, contenido, ref iterator);
                            mapaMem[j+2, i].Value = TomaCaracteres(2, contenido, ref iterator);
                            break;
                        }
                    }
                    break;
                }
            }

        }

        private string SingleByte_Obtener(string valorCodOP)
        {
            string colIndex = valorCodOP[valorCodOP.Length-1].ToString();
            string rowindex = (Convert.ToInt32(valorCodOP, 16) - Convert.ToInt32(colIndex, 16)).ToString("X");

            for (int i = 0; i < mapaMem.RowCount; i++)
            {
                if (mapaMem.Rows[i].HeaderCell.Value.ToString().PadLeft(6, '0') == rowindex.PadLeft(6, '0'))
                {
                    for (int j = 0; j < mapaMem.ColumnCount; j++)
                    {
                        if (mapaMem.Columns[j].HeaderText == colIndex)
                        {
                            return mapaMem[j, i].Value.ToString();
                        }
                    }
                }

            }

            return "0";
        }

        private int ObtenerContenido(string valorCodOP)
        {
            string colIndex = valorCodOP[valorCodOP.Length-1].ToString();
            string rowindex = (Convert.ToInt32(valorCodOP, 16) - Convert.ToInt32(colIndex, 16)).ToString("X");
            string mem = "";
            int numbytes=0;
            string col1 = "";
            for (int i=0; i< mapaMem.RowCount;i++)
            {
                if (mapaMem.Rows[i].HeaderCell.Value.ToString().PadLeft(6, '0') == rowindex.PadLeft(6, '0'))
                {
                    for (int j = 0; j < mapaMem.ColumnCount; j++)
                    {
                        if(col1=="F"&&mem.Length>=2)
                        {
                            col1 = colIndex;
                            numbytes++;
                        }
                        else
                        {
                            if(numbytes>0)
                            {
                                col1 = (Convert.ToInt32(colIndex, 16) + numbytes).ToString("X");
                            }
                            else
                            {
                                col1 = (Convert.ToInt32(colIndex, 16) + (mem.Length / 2)).ToString("X");
                            }
                        }
                        
                        if(mapaMem.Columns[j].HeaderText == col1)
                        {
                           
                            mem += mapaMem[j, i].Value.ToString();
                            if (mem.Length == 6)
                            {
                                return Convert.ToInt32(mem, 16);
                            }
                            if (col1 == "F")
                            {
                                rowindex = (Convert.ToInt32(rowindex, 16) + 16).ToString("X");
                                colIndex = "0";
                                numbytes = 0;
                                break;
                            }
                            
                           
                        }
                    }
                }

            }

            return 0;
        }

        private void btnEjecutar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.F4)
            {
                this.btnEjecutar_Click(this, null);
            }
        }
    }

}
