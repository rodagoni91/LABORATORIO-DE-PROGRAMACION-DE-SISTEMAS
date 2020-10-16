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

namespace WindowsFormsApp1
{
    public partial class MapaMemoria : Form
    {
        private string CP;
        private string Nombre;
        private string Tam;
        private string DirInicio;
        private string RutaProgObjeto;
        private string dirTA = "";
        private string codOperacion = "";
        private string ContProg = "";
        private string ContProgAnt = "";
        private string instruccionObtenida = "";
        private string direccionamiento;
        private string efecto;
        private string m1;
        private string m2;
        private string m3;
        private string m123;
        private int tamanoProg;
        private string DIRINI;
        private int contadorins=0;
        private string basePath;


        private static string ff = "FF";
        private int inicio = 0;//Direccion de inicio del programa en decimal
        private int tam = 0; //Tamaño del programa en decimal
        private int ix = 0; //Contador de renglones que se ocupan para la tabla
        private string cadena = "";//Cadena donde se guardan los archivos H, Ts y E
        private string directorio; //Directorio donde se guardan los archivos 
        private bool esOBJ = false; // Bandera que se activa cuando los datos son obtenidos de un archivo OBJ
        private string registro_h = "";//String donde se guarda el archio H
        private List<string> l_registro_t = new List<string>();//lista de strings donde se guardan los archivos T
        private string registro_e = "";//String donde se guarda el archio E
        private int cp = 0;//Contador de programa
        private int a, x, l, sw;
        private char rcc;

        public MapaMemoria(string cadena)
        {
            InitializeComponent();

            if (cadena == "")
            {
                esOBJ = true;
                RutaProgObjeto = "";
                buttonEjecutar.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                numericUpDownInstrucciones.Enabled = false;
            }
            else
            {
                esOBJ = false;
                this.cadena = cadena; //Cadena donde se guardan los archivos H, Ts y E

                esOBJ = false;
                llena_archivos();
                llena_valores();
                completa_tabla();
                llena_ff();
                vacia_registros_en_tabla();
            }
        }

       

        public MapaMemoria(string RutaProgObjeto, string dirIni, string tam, string dirInicialEjec)
        {
            InitializeComponent();
            basePath = Environment.CurrentDirectory;
            this.RutaProgObjeto = @basePath + RutaProgObjeto + ".obj";
            tb_regA.Text = "FFFFFF";
            tb_regL.Text = "FFFFFF";
            tb_regX.Text = "FFFFFF";
            tb_regSW.Text = "FFFFFF";
            tb_CC.Text = "";
            DIRINI = dirInicialEjec;
            tb_regCP.Text = dirInicialEjec.PadLeft(6, '0');
            tb_inicio.Text = dirIni + " H";
            tb_tam.Text = tam + " H";
            buttonEjecutar.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            numericUpDownInstrucciones.Enabled = false;
            ContProg = dirInicialEjec;
            tamanoProg = int.Parse(dirIni, System.Globalization.NumberStyles.HexNumber) + int.Parse(tam, System.Globalization.NumberStyles.HexNumber);
        }

        /*private void FormSimulacion_Load(object sender, EventArgs e)
		{
			toolStripStatusLabel1.BackColor = SystemColors.Control;
			if (RutaProgObjeto != null)
			{
				if (CragaAMemoria(RutaProgObjeto))
				{
					toolStripStatusLabel1.BackColor = Color.PaleGreen;
					toolStripStatusLabel1.Text = "El Archivo se Cargo Correctamente en la Memoria";
				}
			}
		}*/

        //Llena la tabla con filas desde el inicio del programa hasta el final segun su tamaño
        private void completa_tabla()
        {
            //Redondea el inicio de programa y tamaño
            int inicio = 0;
            int tam = 0;
            if ((float)this.inicio % 16 == 0.0000)
            {
                inicio = ((int)Math.Ceiling(this.inicio / 16d) * 16);
                tam = ((int)Math.Ceiling(this.tam / 16d) * 16);
            }
            else
            {
                inicio = ((int)Math.Ceiling(this.inicio / 16d) * 16) - 16;
                tam = ((int)Math.Ceiling(this.tam / 16d) * 16) + 16;

            }
            int cont = 0;
            int i = 0;
            //Crea los elementos en DataGrid
            while (inicio + cont < inicio + tam)
            {
                dg_mapamemoria.Rows.Add();
                dg_mapamemoria.Rows[i].Cells[0].Value = (inicio + cont).ToString("X");
                cont += 16;
                i++;
            }
            this.ix = i;
        }

        //Llena todos los espacios del proframa con 'FF'
        private void llena_ff()
        {
            int iniF = inicio - ((int)Math.Ceiling(inicio / 16d) * 16) - 16;
            int tamF = this.tam - ((int)Math.Ceiling(this.tam / 16d) * 16) + iniF;
            bool primero = true;
            for (int i = 0; i < ix; i++)
            {
                for (int j = 1; j < 17; j++)
                {
                    dg_mapamemoria.Rows[i].Cells[j].Value = ff;
                }
            }
        }

        /*
         * En este metodo se usan dos casos: cuando se obtiene las cadenas de un archivo OBJ
         * o cuando vienen como parametro en el constructor. Cuado viene de un archivo OBJ
         * debemos de quitar el ultimo caracter de la cadena, si viene en el constructo no es necesario
         * quitarle nada.
        */
        private void llena_archivos()
        {
            MessageBox.Show(cadena);
            string[] cadenas = cadena.Split('\n');
            int cont = 0;
            foreach (var s in cadenas)
            {
                if (cont == 0)//Archivo H
                {
                    if (esOBJ)
                        registro_h = s.Substring(0, s.Length - 1);
                    else
                        registro_h = s;
                }
                else if (cont == cadenas.Length - 2)//Archivo E
                {
                    if (esOBJ)
                        registro_e = s.Substring(0, s.Length - 1);
                    else
                        registro_e = s;
                    break;
                }
                else //Archivo T
                {
                    if (esOBJ)
                        l_registro_t.Add(s.Substring(0, s.Length - 1));
                    else
                        l_registro_t.Add(s);
                }
                cont++;
            }
        }

        //Llenamos los valores obtenidos de los registros
        private void llena_valores()
        {
            //Quitamos el pedazo que nos sirve del registro y lo convertimos de string a decimal
            this.inicio = Convert.ToInt32(registro_h.Substring(7, 6), 16); //Nos indica el inicio del programa
            this.tam = Convert.ToInt32(registro_h.Substring(13, 6), 16);// nos dice el tamaño del programa
            tb_inicio.Text = this.inicio.ToString("X");
            tb_tam.Text = this.tam.ToString("X");
            registro_e = registro_e.Remove(0, 1);
            cp = Convert.ToInt32(registro_e, 16);
            tb_regCP.Text = cp.ToString("X");
        }

        // Sacamos el numero de renglon (indice de datagrid)
        private int get_renglon(int x)
        {
            int n = 0;
            for (int i = 0; i < dg_mapamemoria.Rows.Count; i++)
            {
                n = Convert.ToInt32(dg_mapamemoria.Rows[i].Cells[0].Value.ToString(), 16);//Convertimos la direccion de hexadecimal a decimal
                if (n == x)
                    return i;//Regresamos el indice
            }
            return -1;
        }

        //Sacamos el nombre del programa y lo colocamos en el textbox destino
        private void nombre_programa()
        {
            tb_nombrep.Text = registro_h.Substring(1, 6);
        }

        private void vacia_registros_en_tabla()
        {
            nombre_programa();
            //Lista donde se guardan las direcciones de inicio de los registros t
            List<string> l_inicio_cod = new List<string>();
            //Lista donde se guarda el codigo de los registros t
            List<string> l_cod = new List<string>();
            //Lista donde se guarda el tamaño de los registros t
            List<string> l_tam = new List<string>();

            foreach (var t in l_registro_t)
            {
                // inicio de código
                l_inicio_cod.Add(t.Substring(1, 6));
                //Tamaño de codigo
                l_tam.Add(t.Substring(7, 2));
                //codigo
                l_cod.Add(t.Substring(9));
            }

            int tam, ini, inix, inij;
            for (int i = 0; i < l_registro_t.Count; i++)//Recorremos todos los registros T >> i
            {
                if (l_cod[i].Length % 2 != 0)
                    l_cod[i] += " "; //Si el codigo no tiene un tamaño par le agregamos un espacio

                tam = Convert.ToInt32(l_tam[i], 16);                //Convertimos el tamaño a decimal
                ini = Convert.ToInt32(l_inicio_cod[i], 16);         //Convertimos el inicio a decimal
                //Renglon
                if ((float)ini % 16 == 0.0000)                      //Si el inicio comienza en 0s...
                    inij = ((int)Math.Ceiling(ini / 16d) * 16);     // esto no es necesario...
                else
                    inij = ((int)Math.Ceiling(ini / 16d) * 16) - 16;// Reducimos en 16 el redondeo que nos da.
                //Columna
                inix = ini - inij;                                  // Indicamos en que columna va a iniciar.
                //MessageBox.Show(inij.ToString("X") +" + "+ inix.ToString("X") + " = " + ini.ToString("X"));
                int ren = get_renglon(inij); // Sacamos el numero de renglon (indice de datagrid)
                int col = inix + 1; // Sacamos el numero de columna (indice de daragrid)
                for (int j = 0; j < (l_cod[i].Length / 2); j++) //Recorremos el código de dos en dos
                {
                    dg_mapamemoria.
                            Rows[ren].//Renglon
                            Cells[col].//Columna
                            Value = l_cod[i].Substring(j * 2, 2); ;// "";//Valor

                    col++;
                    if (col == 17) // Si esta en la ultima columna se reinicia y aumentamos un renglon.
                    {
                        ren++;
                        col = 1;
                    }
                }
            }
        }

        /*public FormSimulacion(int dirIni, int dirFin)
        {
            InitializeComponent();
            InicializaDatagrid(dirIni, dirFin);
            label2.Text = "Direccion de Carga: "+dirIni.ToString("X") + " H";
            label1.Text = "Tamaño del Programa: " + (dirFin - dirIni).ToString("X")+ " H";
        }*/

        private void MapaMemoria_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.BackColor = SystemColors.Control;
            if (RutaProgObjeto.Length != 0)
            {
                if (CragaAMemoria(RutaProgObjeto))
                {
                    toolStripStatusLabel1.BackColor = Color.PaleGreen;
                    toolStripStatusLabel1.Text = "El Archivo se Cargo Correctamente en la Memoria";
                }
            }
        }

        private void InicializaDatagrid(int DireccionInicial, int DireccionFinal)
        {
            int tamañoPrograma = DireccionFinal - DireccionInicial;
            dg_mapamemoria.ColumnCount = 16;
            dg_mapamemoria.ColumnHeadersVisible = true;
            dg_mapamemoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int col = 0; col < dg_mapamemoria.Columns.Count; col++)
            {
                dg_mapamemoria.Columns[col].HeaderText = col.ToString("X");
                dg_mapamemoria.Columns[col].Name = col.ToString("X");
                dg_mapamemoria.Columns[col].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            dg_mapamemoria.RowHeadersWidth = 70;

            for (int i = DireccionInicial; i < DireccionFinal; i += 16)
            {
                dg_mapamemoria.Rows.Add("FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF", "FF");
                dg_mapamemoria.Rows[dg_mapamemoria.Rows.Count - 1].HeaderCell.Value = i.ToString("X").PadLeft(6, '0');
            }

            /*Obtener o establecer el valor de una direccion de memoria en el datagrid*/
            //this.dataGridView1.Rows[BuscaIndiceDireccion("4000")].Cells["A"].Value = "new value";
            //this.dataGridView1["A", BuscaIndiceDireccion("4000")].Value = "new value";
        }

        private int BuscaIndiceDireccion(string DireccinABuscar)
        {
            for (int i = 0; i < dg_mapamemoria.RowCount-1; i++)
            {
                if(int.Parse(dg_mapamemoria[0, i].Value.ToString(), System.Globalization.NumberStyles.HexNumber) ==
                    int.Parse(DireccinABuscar, System.Globalization.NumberStyles.HexNumber))
                    return i;
            }
            return -1;
        }

        private bool CragaAMemoria(string ProgramaACargar)
        {
            string line;
            char[] ArrayLine;
            bool TieneCabecera = false;
            CP = "";
            int pos;

            dg_mapamemoria.Rows.Clear();
            dg_mapamemoria.Columns.Clear();
            //label3.Text = "Nombre del Programa:";
            //label1.Text = "Tamaño Programa:";
            //label2.Text = "Direccion de Carga:";

            StreamReader sr = new StreamReader(ProgramaACargar.Replace(".s", ".obj"));
            while ((line = sr.ReadLine()) != null)
            {
                ArrayLine = line.ToCharArray();
                switch (ArrayLine[0])
                {
                    case 'H':
                        if (!TieneCabecera)
                        {
                            TieneCabecera = true;
                            pos = 1;
                            //Obtener Nombre
                            char[] ArrayName = new char[6];
                            Array.Copy(ArrayLine, pos, ArrayName, 0, 6);
                            Nombre = String.Join("", ArrayName);
                            pos += 6;
                            //Obtener Direccion de carga
                            char[] ArrayInicio = new char[6];
                            Array.Copy(ArrayLine, pos, ArrayInicio, 0, 6);
                            DirInicio = String.Join("", ArrayInicio);
                            pos += 6;
                            //Obtener Tamaño de programa
                            char[] ArrayTam = new char[6];
                            Array.Copy(ArrayLine, pos, ArrayTam, 0, 6);
                            Tam = String.Join("", ArrayTam);

                            //label1.Text = label1.Text + " " + Tam + " Bytes";
                            //label2.Text = label2.Text + " " + DirInicio;
                            //label3.Text = label3.Text + " " + Nombre.Trim('_');

                            int i = int.Parse(DirInicio, System.Globalization.NumberStyles.HexNumber);
                            int t = int.Parse(Tam, System.Globalization.NumberStyles.HexNumber);
                            tb_inicio.Text = DirInicio;
                            tb_tam.Text = Tam;
                            tamanoProg = int.Parse(DirInicio, System.Globalization.NumberStyles.HexNumber) + int.Parse(Tam, System.Globalization.NumberStyles.HexNumber);
                            DIRINI = DirInicio;

                            InicializaDatagrid(i, i + t);
                        }
                        else
                        {
                            toolStripStatusLabel1.BackColor = Color.IndianRed;
                            toolStripStatusLabel1.Text = "Error: El Archivo Contiene mas de una Cabecera";
                            sr.Close();
                            return false;
                        }
                        break;
                    case 'T':

                        pos = 1;
                        //Obtener direccion de carga del registro
                        char[] ArrayCarga = new char[6];
                        Array.Copy(ArrayLine, pos, ArrayCarga, 0, 6);
                        pos += 6;
                        //Obtener longitud en bytes dek registro
                        char[] ArrayTamLine = new char[2];
                        Array.Copy(ArrayLine, pos, ArrayTamLine, 0, 2);
                        int tamLine = int.Parse(string.Join("", ArrayTamLine), System.Globalization.NumberStyles.HexNumber);
                        if ((ArrayLine.Length - pos - 1) / 2 == tamLine)
                        {
                            pos += 2;
                            int columna = int.Parse(ArrayCarga[5].ToString(), System.Globalization.NumberStyles.HexNumber);
                            ArrayCarga[5] = '0';
                            int DirCarga = int.Parse(string.Join("", ArrayCarga), System.Globalization.NumberStyles.HexNumber);
                            int i = int.Parse(DirInicio, System.Globalization.NumberStyles.HexNumber);
                            int t = int.Parse(Tam, System.Globalization.NumberStyles.HexNumber);
                            if (DirCarga < i + t)
                            {
                                while (pos < ArrayLine.Length - 1)
                                {
                                    char[] ArrayCelda = new char[2];
                                    Array.Copy(ArrayLine, pos, ArrayCelda, 0, 2);

                                    if (columna < 16)
                                    {
                                        this.dg_mapamemoria[columna.ToString("X"), BuscaIndiceDireccion(DirCarga.ToString("X").PadLeft(6, '0'))].Value = String.Join("", ArrayCelda);
                                        columna++;
                                    }
                                    else
                                    {
                                        DirCarga += 16;
                                        columna = 0;
                                        this.dg_mapamemoria[columna.ToString("X"), BuscaIndiceDireccion(DirCarga.ToString("X").PadLeft(6, '0'))].Value = String.Join("", ArrayCelda);
                                        columna++;
                                    }
                                    pos += 2;
                                }
                            }
                            else
                            {
                                toolStripStatusLabel1.BackColor = Color.IndianRed;
                                toolStripStatusLabel1.Text = "Error: Se intento modificar una area de memoria no Asignada (" + DirCarga.ToString("X").PadLeft(6, '0') + "H)";
                                sr.Close();
                                return false;
                            }

                        }
                        else
                        {
                            toolStripStatusLabel1.BackColor = Color.IndianRed;
                            toolStripStatusLabel1.Text = "Error: Registro errorneo, la longitud no corresponde al numero de bytes";
                            sr.Close();
                            return false;
                        }

                        break;
                    case 'E':
                        //Obtener direccion de inicio del programa
                        char[] ArrayCP = new char[6];
                        Array.Copy(ArrayLine, 1, ArrayCP, 0, 6);
                        CP = String.Join("", ArrayCP);
                        sr.Close();
                        listViewEjecucion.Items.Clear();
                        tb_regCP.Text = ContProg = CP;
                        tb_regA.Text = "FFFFFF";
                        tb_regL.Text = "FFFFFF";
                        tb_regX.Text = "FFFFFF";
                        tb_regSW.Text = "FFFFFF";
                        tb_CC.Text = "";
                        return true;
                }
            }
            sr.Close();
            return true;
        }

        /*private void archivoToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			switch (e.ClickedItem.Name)
			{
				case "abrirToolStripMenuItem":
					OpenFileDialog open = new OpenFileDialog();
					open.Title = "Abrir";
					open.Filter = "SIC files (*.obj)|*.obj|All files (*.*)|*.*";
					open.InitialDirectory = Application.StartupPath + "\\Programas_SIC";

					if (open.ShowDialog() == DialogResult.OK)
					{
						if (CragaAMemoria(open.FileName))
						{
							toolStripStatusLabel1.BackColor = Color.PaleGreen;
							toolStripStatusLabel1.Text = "El Archivo se Cargo Correctamente en la Memoria";
						}
					}
					break;
				case "salirToolStripMenuItem":
					this.Close();
					break;
			}
		}*/

        private void archivoToolStripMenuItem_DropDownItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "abrirToolStripMenuItem":
                    OpenFileDialog open = new OpenFileDialog();
                    open.Title = "Abrir";
                    open.Filter = "SIC files (*.obj)|*.obj|All files (*.*)|*.*";
                    open.InitialDirectory = Application.StartupPath + "\\Programas_SIC";

                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        if (CragaAMemoria(open.FileName))
                        {
                            toolStripStatusLabel1.BackColor = Color.PaleGreen;
                            toolStripStatusLabel1.Text = "El Archivo se Cargo Correctamente en la Memoria";
                            buttonEjecutar.Enabled = true;
                            button1.Enabled = true;
                            button2.Enabled = true;
                            numericUpDownInstrucciones.Enabled = true;
                        }
                    }
                    break;
                case "salirToolStripMenuItem":
                    this.Close();
                    break;
            }
        }

        private void obtenInstruccion()
        {
            if (int.Parse(ContProg, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
            {
                string rowAux = ContProg.Remove(ContProg.Length - 1) + "0";
                int indexCol = int.Parse(ContProg[ContProg.Length - 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                int indexRow = BuscaIndiceDireccion(rowAux);
                int bitDir;

                ContProgAnt = ContProg;
                ContProg = (int.Parse(ContProg, System.Globalization.NumberStyles.HexNumber) + 3).ToString("X").PadLeft(6, '0');

                switch (indexCol)
                {
                    case 14:
                        instruccionObtenida = dg_mapamemoria[indexCol+1, indexRow].Value.ToString() + dg_mapamemoria[indexCol + 2, indexRow].Value.ToString() + dg_mapamemoria[1, indexRow + 1].Value.ToString();
                        dirTA = (dg_mapamemoria[indexCol + 2, indexRow].Value.ToString() + dg_mapamemoria[1, indexRow + 1].Value.ToString()).PadLeft(6, '0');
                        break;
                    case 15:
                        instruccionObtenida = dg_mapamemoria[indexCol+1, indexRow].Value.ToString() + dg_mapamemoria[1, indexRow + 1].Value.ToString() + dg_mapamemoria[2, indexRow + 2].Value.ToString();
                        dirTA = (dg_mapamemoria[1, indexRow + 1].Value.ToString() + dg_mapamemoria[2, indexRow + 1].Value.ToString()).PadLeft(6, '0');
                        break;
                    default:
                        instruccionObtenida = dg_mapamemoria[indexCol+1, indexRow].Value.ToString() + dg_mapamemoria[indexCol + 2, indexRow].Value.ToString() + dg_mapamemoria[indexCol + 3, indexRow].Value.ToString();
                        dirTA = (dg_mapamemoria[indexCol + 2, indexRow].Value.ToString() + dg_mapamemoria[indexCol + 3, indexRow].Value.ToString()).PadLeft(6, '0');
                        break;
                }
                codOperacion = dg_mapamemoria[indexCol + 1, indexRow].Value.ToString();

                direccionamiento = "Directo";

                if ((int.Parse(dirTA[2].ToString(), System.Globalization.NumberStyles.HexNumber)) >= 8)
                {
                    bitDir = int.Parse(dirTA[2].ToString(), System.Globalization.NumberStyles.HexNumber) - 8;
                    dirTA = dirTA.Remove(0, 3);
                    dirTA = (bitDir).ToString("X") + dirTA;
                    dirTA = (int.Parse(dirTA, System.Globalization.NumberStyles.HexNumber) + int.Parse(tb_regX.Text, System.Globalization.NumberStyles.HexNumber)).ToString("X").PadLeft(6, '0');
                    direccionamiento = "Indexado";
                }
            }
        }

        private void generaEfecto()
        {
            switch (codOperacion.ToUpper())
            {
                case "18":
                    ADD();
                    efecto = "A←(A)+(m..m+2)";
                    break;

                case "40":
                    AND();
                    efecto = "A←(A)&(m..m+2)";
                    break;

                case "28":
                    COMP();
                    efecto = "(A):(m..m+2)";
                    break;

                case "24":
                    DIV();
                    efecto = "A←(A)/(m..m+2)";
                    break;

                case "3C":
                    J();
                    efecto = "CP←m";
                    break;

                case "30":
                    JEQ();
                    efecto = "CP←m si CC está en =";
                    break;

                case "34":
                    JGT();
                    efecto = "CP←m si CC está en >";
                    break;

                case "38":
                    JLT();
                    efecto = "CP←m si CC está en <";
                    break;

                case "48":
                    JSUB();
                    efecto = "L←(CP);CP←m";
                    break;

                case "00":
                    LDA();
                    efecto = "A←(m..m+2)";
                    break;

                case "50":
                    LDCH();
                    efecto = "A[el byte de más a la derecha]←(m)";
                    break;

                case "08":
                    LDL();
                    efecto = "L←(m..m+2)";
                    break;

                case "04":
                    LDX();
                    efecto = "X←(m..m+2)";
                    break;

                case "20":
                    MUL();
                    efecto = "A←(A)*(m..m+2)";
                    break;

                case "44":
                    OR();
                    efecto = "A←(A)|(m..m+2)";
                    break;

                case "4C":
                    RSUB();
                    efecto = "PC←(L) ";
                    break;

                case "0C":
                    STA();
                    efecto = "m..m+2←(A)";
                    break;

                case "54":
                    STCH();
                    efecto = "m←(A)[el byte más a la derecha]";
                    break;

                case "14":
                    STL();
                    efecto = "m..m+2←(L)";
                    break;

                case "E8":
                    STSW();
                    efecto = "m..m+2←(SW)";
                    break;

                case "10":
                    STX();
                    efecto = "m..m+2←(X)";
                    break;

                case "1C":
                    SUB();
                    efecto = "A←(A)–(m..m+2)";
                    break;

                case "2C":
                    TIX();
                    efecto = "X←(X)+1;(X):(m..m+2)";
                    break;
            }
        }

        private void obtenM1M2M3()
        {
            string rowAux = dirTA.Remove(dirTA.Length - 1) + "0";
            int indexCol = int.Parse(dirTA[dirTA.Length - 1].ToString(), System.Globalization.NumberStyles.HexNumber);
            int indexRow = BuscaIndiceDireccion(rowAux);

            switch (indexCol)
            {
                case 14:
                    m1 = dg_mapamemoria[indexCol+1, indexRow].Value.ToString();
                    m2 = dg_mapamemoria[indexCol + 2, indexRow].Value.ToString();
                    m3 = dg_mapamemoria[1, indexRow + 1].Value.ToString();
                    m123 = m1 + m2 + m3;
                    break;

                case 15:
                    m1 = dg_mapamemoria[indexCol+1, indexRow].Value.ToString();
                    m2 = dg_mapamemoria[1, indexRow + 1].Value.ToString();
                    m3 = dg_mapamemoria[2, indexRow + 1].Value.ToString();
                    m123 = m1 + m2 + m3;
                    break;

                default:
                    m1 = dg_mapamemoria[indexCol+1, indexRow].Value.ToString();
                    m2 = dg_mapamemoria[indexCol + 2, indexRow].Value.ToString();
                    m3 = dg_mapamemoria[indexCol + 3, indexRow].Value.ToString();
                    m123 = m1 + m2 + m3;
                    break;
            }
        }

        private void escribeM1M2M3(string m1, string m2, string m3)
        {
            string rowAux = dirTA.Remove(dirTA.Length - 1) + "0";
            int indexCol = int.Parse(dirTA[dirTA.Length - 1].ToString(), System.Globalization.NumberStyles.HexNumber);
            int indexRow = BuscaIndiceDireccion(rowAux);


            dg_mapamemoria[indexCol, indexRow].Value = m1;
            dg_mapamemoria[indexCol + 1, indexRow].Value = m2;
            dg_mapamemoria[indexCol + 2, indexRow].Value = m3;
        }

        private void escribeM1(string m1)
        {
            string rowAux = dirTA.Remove(dirTA.Length - 1) + "0";
            int indexCol = int.Parse(dirTA[dirTA.Length - 1].ToString(), System.Globalization.NumberStyles.HexNumber);
            int indexRow = BuscaIndiceDireccion(rowAux);


            dg_mapamemoria[indexCol, indexRow].Value = m1;
        }

        private void ADD()//A←(A)+(m..m+2)
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            tb_regA.Text = (auxA + auxM).ToString("X").PadLeft(6, '0');
        }

        private void AND()// A←(A)&(m..m+2)
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            tb_regA.Text = (auxA & auxM).ToString("X").PadLeft(6, '0');

        }

        private void COMP()// (A):(m..m+2)
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            if (auxA > auxM)
            {
                tb_CC.Text = ">";
            }
            else
            {
                if (auxA < auxM)
                {
                    tb_CC.Text = "<";
                }
                else
                {
                    if (auxA == auxM)
                    {
                        tb_CC.Text = "=";
                    }
                }
            }
        }

        private void DIV()
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            tb_regA.Text = (auxA / auxM).ToString("X").PadLeft(6, '0');
        }

        private void J()
        {
            ContProg = dirTA;
        }

        private void JEQ()
        {
            if (tb_CC.Text == "=")
                ContProg = dirTA;
        }

        private void JGT()
        {
            if (tb_CC.Text == ">")
                ContProg = dirTA;
        }

        private void JLT()
        {
            if (tb_CC.Text == "<")
                ContProg = dirTA;
        }

        private void JSUB()
        {
            tb_regL.Text = ContProg;
            ContProg = dirTA;
        }

        private void LDA()
        {
            obtenM1M2M3();
            tb_regA.Text = m123;
        }

        private void LDCH()
        {
            obtenM1M2M3();
            tb_regA.Text = tb_regA.Text.Remove(4) + m1;
        }

        private void LDL()
        {
            obtenM1M2M3();
            tb_regL.Text = m123;
        }

        private void LDX()
        {
            obtenM1M2M3();
            tb_regX.Text = m123;
        }

        private void MUL()
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            tb_regA.Text = (auxA * auxM).ToString("X").PadLeft(6, '0');
        }

        private void OR()
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            tb_regA.Text = (auxA | auxM).ToString("X").PadLeft(6, '0');
        }

        private void RSUB()
        {
            ContProg = tb_regL.Text;
        }

        private void STA()
        {
            string m1 = tb_regA.Text.Remove(2);
            string m2 = (tb_regA.Text.Remove(0, 2)).Remove(2);
            string m3 = tb_regA.Text.Remove(0, 4);
            escribeM1M2M3(m1, m2, m3);
        }

        private void STCH()
        {
            string m1 = tb_regA.Text.Remove(0,4);
            escribeM1(m1);
        }

        private void STL()
        {
            string m1 = tb_regL.Text.Remove(2);
            string m2 = (tb_regL.Text.Remove(0, 2)).Remove(2);
            string m3 = tb_regL.Text.Remove(0, 4);
            escribeM1M2M3(m1, m2, m3);
        }

        private void STSW()
        {

        }

        private void STX()
        {
            string m1 = tb_regX.Text.Remove(2);
            string m2 = (tb_regX.Text.Remove(0, 2)).Remove(2);
            string m3 = tb_regX.Text.Remove(0, 4);
            escribeM1M2M3(m1, m2, m3);
        }

        private void SUB()
        {
            int auxA = int.Parse(tb_regA.Text, System.Globalization.NumberStyles.HexNumber);
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            tb_regA.Text = (auxA - auxM).ToString("X").PadLeft(6, '0');
        }

        private void TIX()
        {
            int auxX = int.Parse(tb_regX.Text, System.Globalization.NumberStyles.HexNumber) + 1;
            tb_regX.Text = auxX.ToString("X").PadLeft(6, '0');
            obtenM1M2M3();
            int auxM = int.Parse(m123, System.Globalization.NumberStyles.HexNumber);
            if (auxX > auxM)
            {
                tb_CC.Text = ">";
            }
            else
            {
                if (auxX < auxM)
                {
                    tb_CC.Text = "<";
                }
                else
                {
                    if (auxX == auxM)
                    {
                        tb_CC.Text = "=";
                    }
                }
            }
        }

        private void numericUpDownInstrucciones_ValueChanged(object sender, EventArgs e)
        {
            listViewEjecucion.Items.Clear();
            tb_regA.Text = "FFFFFF";
            tb_regL.Text = "FFFFFF";
            tb_regX.Text = "FFFFFF";
            tb_regSW.Text = "FFFFFF";
            tb_CC.Text = "";
            tb_regCP.Text = DIRINI.PadLeft(6, '0');
            ContProg = DIRINI.PadLeft(6, '0');


            for (int i = 0; i < numericUpDownInstrucciones.Value; i++)
            {
                tb_regCP.Text = ContProg;
                obtenInstruccion();
                if (int.Parse(dirTA, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
                {
                    generaEfecto();
                    ListViewItem elementos = new ListViewItem(ContProgAnt);
                    elementos.SubItems.Add(instruccionObtenida);
                    elementos.SubItems.Add(codOperacion);
                    elementos.SubItems.Add(direccionamiento);
                    elementos.SubItems.Add(dirTA);
                    elementos.SubItems.Add(efecto);
                    listViewEjecucion.Items.Add(elementos);
                }
                else
                {
                    MessageBox.Show("Direccion Fuera De Rango");
                }
            }
        }


        private void boton_abrir_Click_1(object sender, EventArgs e)
        {
            limpia();
            abrir();
            esOBJ = true;
            llena_archivos();
            llena_valores();
            completa_tabla();
            llena_ff();
            vacia_registros_en_tabla();
            buttonEjecutar.Enabled = numericUpDownInstrucciones.Enabled = true ;
            button1.Enabled = button2.Enabled = true;
            //OpenFileDialog open = new OpenFileDialog();
            //open.Title = "Abrir";
            //open.Filter = "SIC files (*.obj)|*.obj|All files (*.*)|*.*";
            //open.InitialDirectory = Application.StartupPath + "\\Programas_SIC";

            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    if (CragaAMemoria(open.FileName))
            //    {
            //        toolStripStatusLabel1.BackColor = Color.PaleGreen;
            //        toolStripStatusLabel1.Text = "El Archivo se Cargo Correctamente en la Memoria";
            //        buttonEjecutar.Enabled = true;
            //        numericUpDownInstrucciones.Enabled = true;
            //    }
            //}
        }

        // Reinicia los valores.
        private void limpia()
        {
            this.inicio = 0;
            this.tam = 0;
            tb_inicio.Text = this.inicio.ToString("X");
            tb_tam.Text = this.tam.ToString("X");
            tb_nombrep.Text = "";
            dg_mapamemoria.Rows.Clear();
            registro_h = "";
            l_registro_t.Clear();
            registro_e = "";
            esOBJ = false;
        }

        /*private void numericUpDownInstrucciones_ValueChanged_1(object sender, EventArgs e)
        {

            listViewEjecucion.Items.Clear();
            tb_regA.Text = "FFFFFF";
            tb_regL.Text = "FFFFFF";
            tb_regX.Text = "FFFFFF";
            tb_regSW.Text = "FFFFFF";
            tb_CC.Text = "";
            tb_regCP.Text = ContProg = dir_primera_inst().PadLeft(6, '0');
            tamanoProg = tam + int.Parse(dir_primera_inst(), System.Globalization.NumberStyles.HexNumber);
            int cont = 0;
            for (int i = 0; i < numericUpDownInstrucciones.Value; i++)
            {
                tb_regCP.Text = ContProg;
                obtenInstruccion();
                if (int.Parse(dirTA, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
                {
                    generaEfecto();
                    ListViewItem elementos = new ListViewItem(ContProgAnt);
                    elementos.SubItems.Add(instruccionObtenida);
                    elementos.SubItems.Add(codOperacion);
                    elementos.SubItems.Add(direccionamiento);
                    elementos.SubItems.Add(dirTA);
                    elementos.SubItems.Add(efecto);
                    listViewEjecucion.Items.Add(elementos);
                }
                else
                {
                    MessageBox.Show("Direccion Fuera De Rango");
                }
            }
        }*/

        private void ejecuta1en1(int valor)
        {
            listViewEjecucion.Items.Clear();
            tb_regA.Text = "FFFFFF";
            tb_regL.Text = "FFFFFF";
            tb_regX.Text = "FFFFFF";
            tb_regSW.Text = "FFFFFF";
            tb_CC.Text = "";
            tb_regCP.Text = ContProg = dir_primera_inst().PadLeft(6, '0');
            tamanoProg = tam + int.Parse(dir_primera_inst(), System.Globalization.NumberStyles.HexNumber);
            int cont = 0;
            for (int i = 0; i < valor; i++)
            {
                tb_regCP.Text = ContProg;
                obtenInstruccion();
                if (int.Parse(dirTA, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
                {
                    generaEfecto();
                    ListViewItem elementos = new ListViewItem(ContProgAnt);
                    elementos.SubItems.Add(instruccionObtenida);
                    elementos.SubItems.Add(codOperacion);
                    elementos.SubItems.Add(direccionamiento);
                    elementos.SubItems.Add(dirTA);
                    elementos.SubItems.Add(efecto);
                    listViewEjecucion.Items.Add(elementos);
                }
                else
                {
                    MessageBox.Show("Direccion Fuera De Rango");
                }
            }
            listViewEjecucion.Items[listViewEjecucion.Items.Count - 1].EnsureVisible();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listViewEjecucion.Items.Clear();
            limpia();
            contadorins = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contadorins++;
            ejecuta1en1(contadorins);
        }

        //Abre un archivo OBJ donde se cargan los archivos
        public void abrir()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Archivo OBJ (*.obj)|*.obj";
            openfile.Title = "Abrir archivo OBJ";

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    cadena = sr.ReadToEnd();
                    sr.Close();
                }
            }
            directorio = openfile.FileName;
        }

        private void MapaMemoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.S )
            {
                contadorins++;
                ejecuta1en1(contadorins);
            }
            if (e.KeyData == Keys.A)
            {
                ejecutaTodo();
            }
        }

        private string dir_primera_inst()
        {
            return l_registro_t[0].Substring(1, 6);
           // return "-1";
        }

        private void buttonEjecutar_Click_1(object sender, EventArgs e)
        {
            ejecutaTodo();
            /*contadorins = 0;
            listViewEjecucion.Items.Clear();
            tb_regA.Text = "FFFFFF";
            tb_regL.Text = "FFFFFF";
            tb_regX.Text = "FFFFFF";
            tb_regSW.Text = "FFFFFF";
            tb_CC.Text = "";
            tb_regCP.Text = ContProg = dir_primera_inst().PadLeft(6, '0'); //dir_primera_inst();//inicio.ToString();//"000000";// DIRINI.PadLeft(6, '0');

            tamanoProg = tam + int.Parse(dir_primera_inst(), System.Globalization.NumberStyles.HexNumber);
            int cont = 0;
            while (int.Parse(ContProg, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
            {
                tb_regCP.Text = ContProg;
                obtenInstruccion();
                if (int.Parse(dirTA, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
                {
                    generaEfecto();
                    ListViewItem elementos = new ListViewItem(ContProgAnt);
                    elementos.SubItems.Add(instruccionObtenida);
                    elementos.SubItems.Add(codOperacion);
                    elementos.SubItems.Add(direccionamiento);
                    elementos.SubItems.Add(dirTA);
                    elementos.SubItems.Add(efecto);
                    listViewEjecucion.Items.Add(elementos);
                }
                else
                {
                    MessageBox.Show("Direccion Fuera De Rango");
                    break;
                }
                cont++;
                if (cont > 1000)
                    break;
            }
            listViewEjecucion.Items[listViewEjecucion.Items.Count - 1].EnsureVisible();*/
        }

        private void ejecutaTodo()
        {
            contadorins = 0;
            listViewEjecucion.Items.Clear();
            tb_regA.Text = "FFFFFF";
            tb_regL.Text = "FFFFFF";
            tb_regX.Text = "FFFFFF";
            tb_regSW.Text = "FFFFFF";
            tb_CC.Text = "";
            tb_regCP.Text = ContProg = dir_primera_inst().PadLeft(6, '0'); //dir_primera_inst();//inicio.ToString();//"000000";// DIRINI.PadLeft(6, '0');

            tamanoProg = tam + int.Parse(dir_primera_inst(), System.Globalization.NumberStyles.HexNumber);
            int cont = 0;
            while (int.Parse(ContProg, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
            {
                tb_regCP.Text = ContProg;
                obtenInstruccion();
                if (int.Parse(dirTA, System.Globalization.NumberStyles.HexNumber) < tamanoProg)
                {
                    generaEfecto();
                    ListViewItem elementos = new ListViewItem(ContProgAnt);
                    elementos.SubItems.Add(instruccionObtenida);
                    elementos.SubItems.Add(codOperacion);
                    elementos.SubItems.Add(direccionamiento);
                    elementos.SubItems.Add(dirTA);
                    elementos.SubItems.Add(efecto);
                    listViewEjecucion.Items.Add(elementos);
                }
                else
                {
                    MessageBox.Show("Direccion Fuera De Rango");
                    break;
                }
                cont++;
                if (cont > 1000)
                    break;
            }
            listViewEjecucion.Items[listViewEjecucion.Items.Count - 1].EnsureVisible();
        }
    }
}
