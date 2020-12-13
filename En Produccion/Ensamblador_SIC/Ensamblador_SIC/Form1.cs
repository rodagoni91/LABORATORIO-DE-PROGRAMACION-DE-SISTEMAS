using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Ensamblador_SIC
{
    public partial class Form1 : Form
    {
        #region variables
        public Form2 ejecucion;
        private string sTamaProgrma;
        private string sTamaInicial;
        private string sTamaFinal;
        private string sPrograma;

        private string sRegistroB;
        private string sRegistroS;
        private string sRegistroT;
        private string sRegistroF;
        private string sRegistroA;
        private string sRegistroX;
        private string sRegistroL;

        private Programa ensamblador;
        private List<Etiqueta> etiquetas;
        private List<Instruccion> instrucciones;
        private List<Direccion> lDirecciones;
        private List<string> errores;
        private List<TabSim> tablaSimbolos;
        private List<string> lRegistros;
        Dictionary<string, List<string>> dMapaMemoria = new Dictionary<string, List<string>>();
        private Dictionary<string, string> codOp = new Dictionary<string, string>()
        {   { "ADD", "18" }, {"AND", "40" }, {"COMP", "28" }, {"DIV", "24" }, {"J", "3C"}, {"JEQ", "30"}, {"JGT", "34"}, {"JLT", "38"},
            {"JSUB", "48"}, {"LDA", "00"}, {"3z", "50"}, {"LDL", "08"}, {"LDX", "04"}, {"MUL", "20"}, {"OR", "44"}, {"RD", "D8"},
            { "STA", "0C"}, {"STCH", "54"}, {"STL", "14"}, {"STSW", "E8"}, {"STX", "10"}, {"SUB", "1C"}, {"TD", "E0"}, { "TIX", "2C"},
            { "WD", "DC"}
        };
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.sPrograma = "";
            this.ensamblador = new Programa();
            this.etiquetas = new List<Etiqueta>();
            this.errores = new List<string>();
            this.instrucciones = new List<Instruccion>();
            this.lDirecciones = new List<Direccion>();
            this.tablaSimbolos = new List<TabSim>();
            this.lRegistros = new List<string>();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            sPrograma = "";
            sPrograma = this.textBox1.Text;
            this.dataGridView1.Visible = true;
            this.dataGridView5.Visible = false;
            var entrada = sPrograma + Environment.NewLine;
            byte[] byteArray = Encoding.ASCII.GetBytes(entrada);
            MemoryStream stream = new MemoryStream(byteArray);
            var parametro1 = new AntlrInputStream(entrada);
            SIC_gramaticaLexer lex = new SIC_gramaticaLexer(parametro1);
            //CREAMOS UN LEXER CON LA CADENA QUE ESCRIBIO EL USUARIO
            Antlr4.Runtime.CommonTokenStream tokens = new Antlr4.Runtime.CommonTokenStream(lex);
            //CREAMOS LOS TOKENS SEGUN EL LEXER CREADO
            SIC_gramaticaParser parser = new SIC_gramaticaParser(tokens);
            //CREAMOS EL PARSER CON LOS TOKENS CREADOS
            try
            {
                parser.programa();
                this.tablaSimbolos = new List<TabSim>();
                this.limpiarDataGrids();
                this.separarPrograma();
                this.separarEtiquetas();
                this.separarInstrucciones();
                this.separDirecciones();
                this.calcularDirecciones();
                this.crearTabSim();
                this.codigoOBJ();
                this.codigoObjeto();
                this.mapaMemoria();
                this.llenarDataGrid();
                this.archivoErrores();
                this.ejecutarProgramaToolStripMenuItem.Enabled = true;
            }
            catch (Exception error)
            {
                //Console.Error.WriteLine(e.StackTrace);
                MessageBox.Show("A ocurrido un error inesperado " + error.Message);
            }
        }

        private void limpiarDataGrids()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Refresh();
            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Refresh();
            this.dataGridView4.Rows.Clear();
            this.dataGridView4.Refresh();
            this.dataGridView5.Rows.Clear();
            this.dataGridView5.Refresh();
        }

        private void separarPrograma()
        {
            if (ensamblador.programa.Count == 0)
                ensamblador = new Programa();
            else
            {
                ensamblador.programa.Clear();
            }
            string sLinea = "";
            Linea lLinea;
            foreach (var linea in sPrograma)
            {
                if (linea != '\n')
                {
                    if (linea == '\r')
                    {
                        char delimitador = '\t';
                        char[] delimitadores = { '\t', ' ', };
                        List<string> lAux = new List<string>();
                        string[] separar = sLinea.Split(delimitadores);
                        string[] instrucciones = new string[] { };

                        foreach (var i in separar)
                        {
                            if (i != "")
                            {
                                lAux.Add(i);
                            }
                        }

                        instrucciones = lAux.ToArray();
                        if (instrucciones.Length == 4)
                        {
                            //etiqueta
                            string etiqueta = instrucciones[0];
                            //instruccion
                            string operacion = instrucciones[1];
                            //direccion
                            string direccion = instrucciones[2];
                            string direccion2 = instrucciones[3];
                            if (this.existeInstruccion(operacion))
                            {
                                lLinea = new Linea(etiqueta, operacion, direccion + direccion2);
                                ensamblador.programa.Add(lLinea);
                            }
                            else
                            {
                                lLinea = new Linea(etiqueta, operacion, direccion + direccion2);
                                lLinea.sDireccionamiento = "Error de Sintaxis";
                                ensamblador.programa.Add(lLinea);
                            }
                        }
                        else if (instrucciones.Length == 3)
                        {
                            string etiqueta = instrucciones[0];
                            string operacion = instrucciones[1];
                            string direccion = instrucciones[2];
                            if (this.existeInstruccion(etiqueta))
                            {
                                lLinea = new Linea(etiqueta, operacion + direccion);
                                lLinea.sDireccionamiento = "Error de Sintaxis";
                                ensamblador.programa.Add(lLinea);
                            }
                            else if (this.existeInstruccion(operacion))
                            {
                                lLinea = new Linea(etiqueta, operacion, direccion);
                                ensamblador.programa.Add(lLinea);
                            }

                        }
                        else if (instrucciones.Length == 2)
                        {
                            string operacion = instrucciones[0];
                            string direccion = instrucciones[1];
                            lLinea = new Linea(operacion, direccion);
                            ensamblador.programa.Add(lLinea);

                        }
                        else if (instrucciones.Length == 1)
                        {
                            string operacion = instrucciones[0];
                            lLinea = new Linea(operacion);
                            ensamblador.programa.Add(lLinea);
                        }


                        sLinea = "";
                    }
                    else
                    {
                        sLinea += linea;
                    }
                }
            }

            string[] separar1 = sLinea.Split('\t', ' ');

            string[] instrucciones2 = new string[] { };

            List<string> lAux2 = new List<string>();

            foreach (var i in separar1)
            {
                if (i != "")
                {
                    lAux2.Add(i);
                }
            }

            instrucciones2 = lAux2.ToArray();

            if (instrucciones2.Length == 3)
            {
                string etiqueta = instrucciones2[0];
                string operacion = instrucciones2[1];
                string direccion = instrucciones2[2];
                lLinea = new Linea(etiqueta, operacion, direccion);
                ensamblador.programa.Add(lLinea);
            }
            else if (instrucciones2.Length == 2)
            {
                string operacion = instrucciones2[0];
                string direccion = instrucciones2[1];
                lLinea = new Linea(operacion, direccion);
                ensamblador.programa.Add(lLinea);
            }
            else if (instrucciones2.Length == 1)
            {
                string operacion = instrucciones2[0];
                lLinea = new Linea(operacion);
                ensamblador.programa.Add(lLinea);
            }

        }

        private void separarEtiquetas()
        {
            this.etiquetas = new List<Etiqueta>();
            foreach (var p in ensamblador.programa)
            {
                if (p.sEtiqueta != null)
                {
                    this.etiquetas.Add(new Etiqueta(p.sEtiqueta, ensamblador.programa.IndexOf(p) + 1));
                }
            }
        }

        private void separDirecciones()
        {
            Direccion direccion;
            char registro;
            string sAux;
            string error = "";
            string mensaje = "Errores de direcciones: \r\n";
            //errores.Add("Errores de direcciones: \r\n");
            this.lDirecciones = new List<Direccion>();

            foreach (var p in ensamblador.programa)
            {
                if (p.sDireccion != null)
                {
                    if (ensamblador.programa.IndexOf(p) != 0)
                    {
                        string[] separar = p.sDireccion.Split(',');

                        if (separar.Length == 1)
                        {
                            if (p.sDireccion[0] == 'C' && p.sDireccion[1] == 39)
                            {
                                //CADENA
                                registro = p.sDireccion[0];
                                sAux = p.sDireccion.Substring(1);
                                direccion = new Direccion(registro, sAux, ensamblador.programa.IndexOf(p));
                                lDirecciones.Add(direccion);
                            }
                            else if (p.sDireccion[0] == 'X' && p.sDireccion.Length > 1)
                            {
                                //HECADECIMAL
                                string dirHex = p.sDireccion.Substring(2, p.sDireccion.Length - 3);
                                direccion = new Direccion(dirHex, ensamblador.programa.IndexOf(p));
                                lDirecciones.Add(direccion);
                            }
                            else
                            {
                                //numero o solo registro
                                try
                                {
                                    int iDecimal = Int32.Parse(p.sDireccion);
                                    direccion = new Direccion(iDecimal, ensamblador.programa.IndexOf(p));
                                    lDirecciones.Add(direccion);
                                }
                                catch (Exception a)
                                {
                                    direccion = new Direccion(p.sDireccion, 'Z', ensamblador.programa.IndexOf(p));
                                    lDirecciones.Add(direccion);
                                }
                            }

                        }
                        else
                        {

                            string etiqueta = separar[0];
                            registro = separar[1][0];
                            direccion = new Direccion(etiqueta, registro, ensamblador.programa.IndexOf(p));
                            if (this.etiquetaExiste(etiqueta) == false && p.sDireccion.Contains(",") == false)
                            {
                                mensaje = mensaje + "La etiqueta " + p.sDireccion + " No Existe, Error en Linea: " + ensamblador.programa.IndexOf(p) + "\r\n";


                            }
                            lDirecciones.Add(direccion);
                        }

                    }
                    else
                    {
                        direccion = new Direccion(p.sDireccion);
                        lDirecciones.Add(direccion);
                    }
                }
                else
                {
                    direccion = new Direccion();
                    lDirecciones.Add(direccion);
                }
            }

            textBox2.Text = textBox2.Text + mensaje;
        }

        private void separarInstrucciones()
        {
            this.instrucciones.Clear();
            foreach (var p in ensamblador.programa)
            {
                if (p.sCodigoOp != null)
                {
                    this.instrucciones.Add(new Instruccion(p.sCodigoOp, ensamblador.programa.IndexOf(p) + 1));
                }
            }
        }

        private void buscarErrores()
        {
            this.etiquetasRepetidas();
            this.instruccionExiste();
        }

        private void etiquetasRepetidas()
        {
            Etiqueta esta;
            string error = "";
            errores.Add("Errores de etiquetas: \r\n");
            foreach (var e in etiquetas)
            {
                esta = e;

                foreach (var etiqueta in etiquetas)
                {
                    //etiquetas.Contains(etiqueta)
                    if (etiqueta.iNoLinea != esta.iNoLinea && etiqueta.nEtiqueta == esta.nEtiqueta)
                    {
                        error = "Etiqueta " + etiqueta.nEtiqueta + " duplicada en la linea " + esta.iNoLinea + "\r\n";
                        errores.Add(error);
                    }
                }
            }
            if (error == "")
            {
                textBox2.Text = textBox2.Text + "\r\nEl Programa No Contiene Errores de Etiquetas repetidas \r\n";
            }
            else
            {
                foreach (var e in errores)
                {
                    error = e + '\n';
                }

                textBox2.Text = error;
            }
        }

        private bool existeInstruccion(string instruccion)
        {
            List<string> listaInstrucciones = new List<string>() { "START", "END", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "CLEAR", "JGT", "JLT", "JSUB", "LDA", "LDCH", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };
            if (listaInstrucciones.Contains(instruccion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void instruccionExiste()
        {
            //List<string> listaInstrucciones = new List<string>() { "START", "END", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCG", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };
            List<string> listaInstrucciones = new List<string>() { "START", "END", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCH", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };
            string mensaje = "Errores de instrucciones y/o directivas \r\n";
            string[] instruccion = new string[1];

            foreach (var i in instrucciones)
            {
                instruccion = i.nInstruccion.Split(' ');
                if (listaInstrucciones.Contains(instruccion[0]) == false)
                {
                    mensaje = mensaje + "La Instruccion " + i.nInstruccion + " No Exite Error En Linea " + i.iNoLinea + "\r\n";
                }
            }

            if (mensaje == "Errores de instrucciones y/o directivas \r\n")
            {
                mensaje = mensaje + "Sin errores de instrucciones y/o directivas \r\n";
            }

            textBox2.Text = textBox2.Text + mensaje;
        }

        private bool etiquetaExiste(string etiqueta)
        {
            //Etiqueta esta;
            if (etiqueta != "START" && etiqueta != "EDN")
            {
                foreach (var e in etiquetas)
                {
                    if (e.nEtiqueta == etiqueta)
                    {
                        return true;
                    }
                }
                if (etiqueta == null)
                    return true;
                return false;
            }

            return true;
        }

        private void crearArchivo()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ERRORES.txt";


            StreamWriter fichero; //Clase que representa un fichero
            fichero = File.CreateText("error.error");
            fichero.WriteLine(textBox2.Text); // Lo mismo que cuando escribimos por consola
            //fichero.Write("fin de la cita.");
            fichero.Close(); // Al cerrar el fic
            MessageBox.Show("Archivo de errores generado en: " + path);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void calcularDirecciones()
        {
            string dirHexa = "";
            int iDirDec = 0;
            int iPos = 0;
            int iTotal = 0;
            textBox2.Text = "Errores en el Paso No. 1 \r\n";

            string errores = "";
            foreach (var linea in this.ensamblador.programa)
            {
                if (this.ensamblador.programa.IndexOf(linea) == 0)
                {
                    linea.sDireccionHEXA = lDirecciones[0].sDireccionHexadecimal.Trim('H');
                    dirHexa = lDirecciones[0].sDireccionHexadecimal;
                    dirHexa = dirHexa.Trim('H');
                    dirHexa = dirHexa.Trim('h');
                    iDirDec = Convert.ToInt32(dirHexa.ToString(), 16);
                    linea.sDireccionamiento = "----";
                }

                else
                {
                    if (linea.sCodigoOp == "BYTE")
                    {
                        int iCount = 0;
                        if (this.lDirecciones[iPos].cRegistro == 'C')
                        {
                            string palabra = "";
                            foreach (var c in this.lDirecciones[iPos].sPalabra)
                            {
                                if (c != "'"[0])
                                {
                                    palabra = palabra + c;
                                }
                                else
                                {
                                    iCount++;
                                }
                            }
                            if (iCount == 2)
                            {
                                iTotal = palabra.Length;
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + iTotal;
                                linea.sDireccionamiento = "----";
                            }
                            else
                            {
                                linea.sDireccionamiento = "Error de Sintaxis";
                                errores = errores + "Error de Sintaxis en: " + this.lDirecciones[iPos].sPalabra + "\r\n";
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                            }
                        }
                        else if (this.lDirecciones[iPos].cRegistro == 'X' && this.lDirecciones[iPos].sDireccionHexadecimal != null)
                        {
                            string palabra = "";
                            foreach (var c in linea.sDireccion)
                            {
                                if (c != "'"[0])
                                {
                                    palabra = palabra + c;
                                }
                                else
                                {
                                    iCount++;
                                }
                            }
                            if (iCount == 2)
                            {
                                iTotal = this.lDirecciones[iPos].sDireccionHexadecimal.Length;
                                if (iTotal % 2 == 0)
                                    iTotal = iTotal / 2;
                                else
                                    iTotal = (iTotal / 2) + 1;

                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + iTotal;
                                linea.sDireccionamiento = "----";
                            }
                            else
                            {
                                linea.sDireccionamiento = "Error de Sintaxis";
                                errores = errores + "Error de Sintaxis en: " + linea.sDireccion + "\r\n";
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                            }
                        }
                    }
                    else if (linea.sCodigoOp == "WORD")
                    {
                        dirHexa = $"{iDirDec:X}";
                        linea.sDireccionHEXA = dirHexa;
                        iDirDec = iDirDec + 3;
                        linea.sDireccionamiento = "----";
                    }
                    else if (linea.sCodigoOp == "RESW")
                    {
                        if (this.lDirecciones[iPos].iNumeroDecimal != 0)
                        {
                            int iNuevo = this.lDirecciones[iPos].iNumeroDecimal * 3;
                            dirHexa = $"{iDirDec:X}";
                            linea.sDireccionHEXA = dirHexa;
                            iDirDec = iDirDec + iNuevo;
                            linea.sDireccionamiento = "----";
                        }
                    }
                    else if (this.existeInstruccion(linea.sCodigoOp))
                    {
                        if (this.existeInstruccion(linea.sEtiqueta) == true)
                        {
                            linea.sDireccionamiento = "Error de Sintaxis";
                            errores = errores + "Error de Sintaxis en: " + linea.sEtiqueta + "\n";
                            dirHexa = $"{iDirDec:X}";
                            linea.sDireccionHEXA = dirHexa;
                        }
                        else
                        {
                            dirHexa = $"{iDirDec:X}";
                            linea.sDireccionHEXA = dirHexa;
                            iDirDec = iDirDec + 3;
                            if (linea.sDireccion != null && linea.sCodigoOp != "END")
                            {
                                if (linea.sDireccion.Contains(",X"))
                                {
                                    linea.sDireccionamiento = "Indexado";
                                }
                                else
                                {
                                    linea.sDireccionamiento = "Directo";
                                }
                            }
                            else if (linea.sDireccion == null && linea.sCodigoOp == "RSUB" || linea.sCodigoOp == "END")
                            {
                                linea.sDireccionamiento = "----";
                            }


                        }
                    }
                    else
                    {
                        linea.sDireccionamiento = "Error, Instruccion no Existe.\n";
                        errores = errores + "Error, Instruccion " + linea.sCodigoOp + " no Existe.\r\n";
                        dirHexa = $"{iDirDec:X}";
                        linea.sDireccionHEXA = dirHexa;

                    }
                }
                iPos++;
            }
            if (errores == "")
            {
                errores = "Sin Errores en el Paso No. 1\r\n";
                textBox2.Text = errores;
            }
            else
            {
                textBox2.Text = textBox2.Text + errores;
            }
        }

        private void crearTabSim()
        {
            string dir;
            string etq;

            foreach (var l in ensamblador.programa)
            {
                if (l.sEtiqueta != null && ensamblador.programa.IndexOf(l) != 0 && this.existeInstruccion(l.sEtiqueta) == false)
                {
                    if (this.existeSimbolo(l.sEtiqueta) == false)
                    {
                        this.tablaSimbolos.Add(new TabSim(l.sEtiqueta, l.sDireccionHEXA));
                        this.dataGridView2.Rows.Add(l.sEtiqueta, l.sDireccionHEXA);
                    }
                    else
                    {
                        textBox2.Text = textBox2.Text + "Error, Simbolo " + l.sEtiqueta + " Se Encuentra Duplicado.\r\n";
                        l.sDireccionamiento = "Error, Simbolo Duplicado";
                    }
                }
                else if (this.existeInstruccion(l.sEtiqueta) == true)
                {
                    l.sDireccionamiento = "Error de Sintaxis";
                }
            }
        }

        private bool existeSimbolo(string simbolo)
        {
            foreach (var s in this.tablaSimbolos)
            {
                if (s.sEtiqueta == simbolo)
                {
                    return true;
                }
            }

            return false;
        }

        private void codigoOBJ()
        {
            List<string> listaInstrucciones = new List<string>() { "START", "END", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCH", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };

            string sOBJ = "";
            foreach (var l in ensamblador.programa)
            {
                if (listaInstrucciones.Contains(l.sCodigoOp) && this.etiquetaExiste(l.sEtiqueta))
                {
                    if (l.sCodigoOp == "START" || l.sCodigoOp == "END" || l.sCodigoOp == "RESB" || l.sCodigoOp == "RESW")
                    {
                        l.sCodigoObjeto = "---";
                        //l.sDireccionamiento = "---";
                    }
                    else
                    {
                        if (l.sCodigoOp == "RSUB")
                        {
                            l.sCodigoObjeto = "4C0000";
                            //l.sDireccionamiento = "DIRECTO";
                        }
                        else if (l.sCodigoOp == "BYTE")
                        {
                            if (l.sDireccion.Contains("C\"") && l.sDireccion[0] == 'C')
                            {
                                l.sCodigoObjeto = this.codigoCadena(l.sDireccion);
                                //l.sDireccionamiento = "DIRECTO";
                            }
                            else if (l.sDireccion.Contains("X\"") && l.sDireccion[0] == 'X' || l.sDireccion.Contains("X\'") && l.sDireccion[0] == 'X')
                            {
                                l.sCodigoObjeto = this.obtenerCodigo(l.sDireccion);
                                //l.sDireccionamiento = "DIRECTO";
                            }
                        }
                        else if (l.sCodigoOp == "WORD")
                        {
                            int iCodigo = Int32.Parse(l.sDireccion);
                            string hexa = iCodigo.ToString("X");
                            if (hexa.Length <= 5)
                            {
                                switch (hexa.Length)
                                {
                                    case 1:
                                        hexa = "00000" + hexa;
                                        break;

                                    case 2:
                                        hexa = "0000" + hexa;
                                        break;

                                    case 3:
                                        hexa = "000" + hexa;
                                        break;

                                    case 4:
                                        hexa = "00" + hexa;
                                        break;

                                    case 5:
                                        hexa = "0" + hexa;
                                        break;
                                }
                            }

                            l.sCodigoObjeto = hexa;
                            //l.sDireccionamiento = "DIRECTO";
                        }
                        else
                        {
                            sOBJ = "";
                            if (l.sDireccion.Contains(",X") || l.sDireccionamiento == "Indexado")
                            {
                                string direccion = l.sDireccion.Substring(0, l.sDireccion.Length - 2);
                                string hexa = this.buscarTABSIB(direccion);
                                int iDecimal = Convert.ToInt32(hexa, 16);
                                string sBinario = Convert.ToString(iDecimal, 2);
                                string nBinario = "1000000000000000";
                                int iBinario = Convert.ToInt32(nBinario, 2) + iDecimal;
                                string sBinario2 = Convert.ToString(iBinario, 2);
                                if (sBinario.Length > 16)
                                {
                                    int sobra = sBinario.Length - 16;
                                    sBinario2 = sBinario2.Substring(sobra);
                                    iBinario = Convert.ToInt32(sBinario2, 2);
                                }
                                sBinario2 = Convert.ToString(iBinario, 16).ToUpper();
                                sOBJ = this.codigoOperacion(l.sCodigoOp) + sBinario2;
                                l.sCodigoObjeto = sOBJ;
                                //l.sDireccionamiento = "INDEXADO";
                            }
                            else
                            {
                                //sOBJ = this.codigoOperacion(l.sCodigoOp) + this.buscarTABSIB(l.sEtiqueta);
                                sOBJ = this.codigoOperacion(l.sCodigoOp) + this.buscarTABSIB(l.sDireccion);
                                l.sCodigoObjeto = sOBJ;
                                //l.sDireccionamiento = "DIRECTO";
                            }
                        }

                    }
                }
                else
                {
                    if (listaInstrucciones.Contains(l.sCodigoOp) == false)
                    {
                        l.sCodigoObjeto = "ERROR";
                        l.sDireccionamiento = "------";
                    }
                    if (this.etiquetaExiste(l.sEtiqueta) == false)
                    {
                        l.sCodigoObjeto = "ERROR SIMBOLO NO EXISTE";
                        l.sDireccionamiento = "------";
                    }
                }
            }
        }

        private string codigoOperacion(string operacion)
        {
            foreach (var c in this.codOp)
            {
                if (c.Key == operacion)
                {
                    return c.Value;
                }
            }

            return null;
        }

        private string buscarTABSIB(string sEtiqueta)
        {
            foreach (var t in this.tablaSimbolos)
            {
                if (t.sEtiqueta == sEtiqueta)
                {
                    return t.sDireccion;
                }
            }

            return null;
        }

        private string codigoCadena(string cadena)
        {
            string sHexadecimal = "";
            string hexValue;
            int iAux = 0;
            string sCadena = cadena.Substring(2);
            int iTamano = sCadena.Length - 1;
            sCadena = sCadena.Substring(0, iTamano);

            foreach (var c in sCadena)
            {
                iAux = (int)c;
                hexValue = iAux.ToString("X");
                sHexadecimal = sHexadecimal + hexValue;
            }


            return sHexadecimal;
        }

        private string obtenerCodigo(string hexa)
        {
            string hex = hexa.Substring(2);
            int iTamano = hex.Length - 1;
            hex = hex.Substring(0, iTamano);
            return hex;
        }

        private void llenarDataGrid()
        {
            int iPos = 1;
            foreach (var linea in this.ensamblador.programa)
            {
                this.dataGridView1.Rows.Add(linea.sDireccionHEXA, linea.sEtiqueta, linea.sCodigoOp, linea.sDireccion, linea.sDireccionamiento, linea.sCodigoObjeto);
                iPos++;
            }

            foreach (var c in this.codOp)
            {
                this.dataGridView3.Rows.Add(c.Key, c.Value);
            }
        }

        private string codigoObjeto()
        {
            int iTotalLineas = this.ensamblador.programa.Count;
            lRegistros = new List<string>();
            string sRegistroEncabezado = "H";
            string sRegistroTexto = "T";
            string sDireccionInicio = this.ensamblador.programa[0].sDireccion.Substring(0, 4);
            sTamaInicial = sDireccionInicio;
            string sDireccionFinal = this.ensamblador.programa[iTotalLineas - 1].sDireccionHEXA;
            sTamaFinal = sDireccionFinal;
            int iDireccionInicio = Convert.ToInt32(sDireccionInicio, 16);
            int iDireccionFinal = Convert.ToInt32(sDireccionFinal, 16);
            int iLongitud = iDireccionFinal - iDireccionInicio;
            string sNombrePrograma = this.ensamblador.programa[0].sEtiqueta;
            string sTamano = $"{iLongitud:X}";
            #region Registro Encabezado
            int i = sNombrePrograma.Length;
            if (i < 6)
            {
                int espBlancos = 6 - i;
                string sEspacio = "_";
                sRegistroEncabezado = sRegistroEncabezado + sNombrePrograma;
                for (int ii = 0; ii < espBlancos - 1; ii++)
                {
                    sEspacio = sEspacio + '_';
                }
                sRegistroEncabezado = sRegistroEncabezado + sEspacio;
            }
            else if (i == 6)
            {
                sRegistroEncabezado = sRegistroEncabezado + sNombrePrograma;
            }
            else
            {

                sRegistroEncabezado = sRegistroEncabezado + sNombrePrograma.Substring(0, 6);

            }
            if (sDireccionInicio.Length == 6)
            {
                sRegistroEncabezado = sRegistroEncabezado + sDireccionInicio + sTamano;
            }
            else
            {
                int faltante = 6 - sDireccionInicio.Length;

                for (int a = 0; a < faltante; a++)
                {
                    sDireccionInicio = "0" + sDireccionInicio;
                }

                sRegistroEncabezado = sRegistroEncabezado + sDireccionInicio + sTamano;
            }
            lRegistros.Add(sRegistroEncabezado);
            string sD = this.ensamblador.programa[0].sDireccionHEXA.Substring(0, this.ensamblador.programa[0].sDireccionHEXA.Length - 1);
            int falta = 6 - sD.Length;
            for (int a = 0; a < falta; a++)
            {
                sD = "0" + sD;
            }
            sRegistroTexto = sRegistroTexto + sD + "XX";
            iDireccionInicio = Convert.ToInt32(sD, 16);
            #endregion
            sRegistroTexto = "T";
            foreach (var l in this.ensamblador.programa)
            {
                /* 1 T
                 * 2 - 7 Direccion de Inicio
                 * 8 - 9 Longitud de Codigo
                 * 10 - 69 Codigo Objeto
                 * */
                if (l.sCodigoObjeto != "--------" && l.sCodigoObjeto != "---" && l.sCodigoObjeto != "ERROR SINTACTICO" && l.sCodigoObjeto != "ERROR la ins. no es relativa ni al contador ni a la base" && l.sCodigoObjeto != "ERROR simbolo no existe")
                {
                    if (sRegistroTexto.Length + l.sCodigoObjeto.Length <= 69)
                    {
                        if (sRegistroTexto == "T")
                        {
                            int iLong = 6 - l.sDireccionHEXA.Length;
                            string sDireccionHexa = l.sDireccionHEXA;
                            for (int y = 0; y < iLong; y++)
                            {
                                //l.sDireccionHEXA = "0" + l.sDireccionHEXA;
                                sDireccionHexa = "0" + sDireccionHexa;
                            }
                            sRegistroTexto = sRegistroTexto + sDireccionHexa.ToString() + "XX" + l.sCodigoObjeto;
                        }
                        else
                        {
                            sRegistroTexto = sRegistroTexto + l.sCodigoObjeto;
                        }
                    }
                    else
                    {
                        //int iLongitudRegistro = sRegistroTexto.Substring(9).Length;
                        if (sRegistroTexto.Substring(9).Length % 2 == 0)
                        {
                            int iLongitudRegistro = sRegistroTexto.Substring(9).Length / 2;
                        }
                        else
                        {
                            int iLongitudRegistro = (sRegistroTexto.Substring(9).Length / 2) + 1;
                        }
                        string sLongitudRegistro = iLongitud.ToString("X");
                        sRegistroTexto.Replace("XX", sLongitudRegistro);
                        lRegistros.Add(sRegistroTexto);
                        int iLong = 6 - l.sDireccionHEXA.Length;
                        for (int y = 0; y < iLong; y++)
                        {
                            l.sDireccionHEXA = "0" + l.sDireccionHEXA;
                        }
                        sRegistroTexto = "T" + l.sDireccionHEXA.ToString() + "XX" + l.sCodigoObjeto;
                    }

                }
                if (l.sCodigoOp == "RESB" || l.sCodigoOp == "RESW")
                {
                    int iLongitudRegistro = 0;
                    if (sRegistroTexto.Length > 9)
                    {
                        if (sRegistroTexto.Substring(9).Length % 2 == 0)
                        {
                            iLongitudRegistro = sRegistroTexto.Substring(9).Length / 2;
                        }
                        else
                        {
                            iLongitudRegistro = (sRegistroTexto.Substring(9).Length / 2) + 1;
                        }
                        string sLongitudRegistro = iLongitudRegistro.ToString("X");
                        sRegistroTexto = sRegistroTexto.Replace("XX", sLongitudRegistro);
                        lRegistros.Add(sRegistroTexto);
                    }

                    sRegistroTexto = "T";
                }
            }
            lRegistros.Add("E" + this.ensamblador.programa[1].sDireccionHEXA);

            foreach (var r in this.lRegistros)
            {
                textBox3.Text = textBox3.Text + r + "\r\n";
                //fichero.WriteLine(r + "\r\n");
            }

            //this.archivoErrores();

            return (sTamano);
        }

        private void archivoErrores()
        {
            string sNombrePrograma = this.ensamblador.programa[0].sEtiqueta;
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + sNombrePrograma + ".obj";
            StreamWriter fichero; //Clase que representa un fichero
            fichero = File.CreateText(sNombrePrograma + ".obj");
            foreach (var r in this.lRegistros)
            {
                fichero.WriteLine(r + "\r\n");
            }
            fichero.Close(); // Al cerrar el fic
            MessageBox.Show("Archivo de codigo objeto generado en: " + path);
        }

        private void mapaMemoria()
        {

            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int inicio = inicioProgrma;
            int final = this.RoundUp(finalProgrma);
            string sDirIni = $"{inicio:X}";
            string sDirFin = $"{final:X}";
            string direccion = "";
            string dirInicio = "";
            List<string> lAux = new List<string>();
            this.dMapaMemoria = new Dictionary<string, List<string>>();
            for (int i = inicio; i < final; i += 16)
            {
                direccion = $"{i:X}";
                lAux = new List<string>();
                lAux.Add(direccion);
                lAux.Add(direccion.Substring(0, 3) + "1X");//1
                lAux.Add(direccion.Substring(0, 3) + "2X");//2
                lAux.Add(direccion.Substring(0, 3) + "3X");//3
                lAux.Add(direccion.Substring(0, 3) + "4X");//4
                lAux.Add(direccion.Substring(0, 3) + "5X");//6
                lAux.Add(direccion.Substring(0, 3) + "6X");//6
                lAux.Add(direccion.Substring(0, 3) + "7X");//7
                lAux.Add(direccion.Substring(0, 3) + "8X");//8
                lAux.Add(direccion.Substring(0, 3) + "9X");//9
                lAux.Add(direccion.Substring(0, 3) + "AX");//10
                lAux.Add(direccion.Substring(0, 3) + "BX");//11
                lAux.Add(direccion.Substring(0, 3) + "CX");//12
                lAux.Add(direccion.Substring(0, 3) + "DX");//13
                lAux.Add(direccion.Substring(0, 3) + "EX");//14
                lAux.Add(direccion.Substring(0, 3) + "FX");//15
                this.dMapaMemoria.Add(direccion, lAux);
            }

            foreach (var l in lRegistros)
            {
                if (l != lRegistros[0] && l != lRegistros[lRegistros.Count - 1] && l.Length > 10)
                {
                    List<string> objs = this.separarCodigo(l);
                    string sDireccion = l.Substring(1, 6);
                    int iDireccion = Convert.ToInt32(sDireccion, 16);
                    sDireccion = $"{iDireccion:X}";
                    this.llenarMapa(sDireccion, objs);
                }
            }

            int j = 0;
            int k = 0;
            List<string> sHeader = new List<string>();
            for (int i = inicio; i < final; i += 16)
            {
                direccion = $"{i:X}";
                sHeader.Add(direccion);
            }

            foreach (var d in this.dMapaMemoria)
            {
                for (int t = 0; t < 16; t++)
                {
                    if (d.Value[t].Length >= 4)
                        d.Value[t] = "00";
                }
                this.dataGridView4.Rows.Add(d.Key, d.Value[0], d.Value[1], d.Value[2], d.Value[3], d.Value[4], d.Value[5], d.Value[6], d.Value[7], d.Value[8], d.Value[9], d.Value[10], d.Value[11], d.Value[12], d.Value[13], d.Value[14], d.Value[15]);
            }

            ejecucion = new Form2();
            ejecucion.sTamaInicial = this.sTamaInicial;
            ejecucion.sTamaFinal = this.sTamaFinal;
            ejecucion.lRegistros = this.lRegistros;
            ejecucion.dMapaMemoria = this.dMapaMemoria;

        }

        private string sDireccionInicio(string esta)
        {
            return esta.Substring(1, 6);
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string name = openFileDialog1.FileName;
                string[] lines = System.IO.File.ReadAllLines(name);
                textBox1.Text = String.Join(System.Environment.NewLine, lines);
            }
        }

        int RoundUp(int toRound)
        {
            if (toRound % 10 == 0) return toRound;
            return (10 - toRound % 10) + toRound;
        }

        int RoundDown(int toRound)
        {
            return toRound - toRound % 10;
        }

        private List<string> separarCodigo(string linea)
        {
            string n = "";
            string separado = linea.Substring(9);
            List<string> lista = new List<string>();

            foreach (var s in separado)
            {
                n += s;
                if (n.Length == 2)
                {
                    lista.Add(n);
                    n = "";
                }
            }

            if (n.Length == 1)
                lista.Add(n + "0");

            return lista;
        }

        private void llenarMapa(string direccion, List<string> codigo)
        {
            bool bandera = false;
            int iCount = 0;
            foreach (var e in dMapaMemoria)
            {
                for (int j = 0; j < e.Value.Count; j++)
                {
                    if (e.Value[j].Contains(direccion))
                    {
                        bandera = true;
                    }

                    if (bandera == true)
                    {
                        e.Value[j] = codigo[iCount];
                        iCount++;
                    }


                    if (iCount >= codigo.Count)
                    {
                        bandera = false;
                    }
                }
            }
        }

        private void ejecutarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ejecucion.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.WordWrap = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //SIC XE
            sPrograma = "";
            sPrograma = this.textBox1.Text;
            this.dataGridView1.Visible = false;
            this.dataGridView5.Visible = true;
            var entrada = sPrograma + Environment.NewLine;
            byte[] byteArray = Encoding.ASCII.GetBytes(entrada);
            MemoryStream stream = new MemoryStream(byteArray);
            var parametro1 = new AntlrInputStream(entrada);
            sicXELexer lex = new sicXELexer(parametro1);
            //SIC_gramaticaLexer lex = new SIC_gramaticaLexer(parametro1);
            //CREAMOS UN LEXER CON LA CADENA QUE ESCRIBIO EL USUARIO
            Antlr4.Runtime.CommonTokenStream tokens = new Antlr4.Runtime.CommonTokenStream(lex);
            //CREAMOS LOS TOKENS SEGUN EL LEXER CREADO
            sicXEParser parser = new sicXEParser(tokens);
            //SIC_gramaticaParser parser = new SIC_gramaticaParser(tokens);
            //CREAMOS EL PARSER CON LOS TOKENS CREADOS
            try
            {
                parser.programa();
                this.tablaSimbolos = new List<TabSim>();
                this.limpiarDataGrids();
                this.separarPrograma();
                this.separarEtiquetas();
                this.separarInstrucciones();
                this.separDirecciones();
                this.calcularDireccionesXE();
                this.crearTabSimXE();
                this.iniciarRegistros();
                this.codigoOBJXE();
                this.codigoObjeto();
                this.archivoErrores();
            }
            catch (Exception error)
            {
                //Console.Error.WriteLine(e.StackTrace);
                MessageBox.Show("A ocurrido un error inesperado " + error.Message);
            }


        }

        private string sContador(int iPos)
        {
            bool bandera = false;
            foreach (var t in this.ensamblador.programa)
            {
                if (this.ensamblador.programa.IndexOf(t) == iPos + 1)
                {
                    return t.sDireccionHEXA;
                }
            }

            return null;
        }

        private void iniciarRegistros()
        {
            this.sRegistroA = "0";
            this.sRegistroB = "3";
            this.sRegistroF = "6";
            this.sRegistroL = "2";
            this.sRegistroS = "4";
            this.sRegistroT = "5";
            this.sRegistroX = "1";

        }

        private string regresarRegistro(string registro)
        {
            if (registro == "A")
            {
                return "0";
            }
            else if (registro == "B")
            {
                return "3";
            }
            else if (registro == "F")
            {
                return "6";
            }
            else if (registro == "L")
            {
                return "2";
            }
            else if (registro == "S")
            {
                return "4";
            }
            else if (registro == "T")
            {
                return "5";
            }
            else if (registro == "X")
            {
                return "1";
            }

            return "ERROR registro no existe";
        }

        private int formatoInstruccion(string instruccion)
        {
            List<string> formato1 = new List<string> { "FIX", "FLOAT", "HIO", "NORM", "SIO", "TIO" };
            List<string> formato2 = new List<string> { "CLEAR", "ADDR", "COMPR", "DIVR", "MULR", "SHIFTL", "SHIFTR", "SUBR", "SVC", "TIXR" };
            List<string> formato3y4 = new List<string> { "ADD", "ADDF", "AND", "COMP", "COMPRF", "DIV", "DIVF", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDB", "LDCH", "LDF", "LDL", "LDS", "LDT", "LDX", "LPS", "MUL", "MULF", "OR", "RD", "RSUB", "SSK", "STA", "STB", "STCH", "STF", "STI", "STL", "STS", "STSW", "STT", "STX", "SUB", "SUBF", "TD", "TIX", "WD" };
            List<string> directivas = new List<string> { "BYTE", "WORD", "RESB", "RESW", "BASE", "USE", "EQU" };
            //'BYTE' | 'WORD' | 'RESB' | 'RESW' | 'BASE' | 'USE' | 'EQU'
            if (formato1.Contains(instruccion))
            {
                return 1;
            }
            else if (formato2.Contains(instruccion))
            {
                return 2;
            }

            if (instruccion.Contains("+"))
            {
                string ins = instruccion.Substring(1);
                if (formato3y4.Contains(ins))
                {
                    return 4;
                }
                else
                {
                    return -1;
                }
            }
            else if (formato3y4.Contains(instruccion))
            {
                return 3;
            }

            if (directivas.Contains(instruccion))
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }

        private bool existeInstruccionXE(string instruccion)
        {
            //List<string> listaInstrucciones = new List<string>() { "START", "END", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCH", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };
            List<string> formato1 = new List<string> { "FIX", "FLOAT", "HIO", "NORM", "SIO", "TIO" };
            List<string> formato2 = new List<string> { "CLEAR", "ADDR", "COMPR", "DIVR", "MULR", "SHIFTL", "SHIFTR", "SUBR", "SVC", "TIXR" };
            List<string> formato3y4 = new List<string> { "ADD", "ADDF", "AND", "COMP", "COMPRF", "DIV", "DIVF", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDB", "LDCH", "LDF", "LDL", "LDS", "LDT", "LDX", "LPS", "MUL", "MULF", "OR", "RD", "RSUB", "SSK", "STA", "STB", "STCH", "STF", "STI", "STL", "STS", "STSW", "STT", "STX", "SUB", "SUBF", "TD", "TIX", "WD" };
            if (formato1.Contains(instruccion) || formato2.Contains(instruccion) || formato3y4.Contains(instruccion) || instruccion == "START" || instruccion == "END")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void calcularDireccionesXE()
        {
            string dirHexa = "";
            int iDirDec = 0;
            int iPos = 0;
            int iTotal = 0;
            textBox2.Text = "Errores en el Paso No. 1 de la SIC-XE \r\n";

            string errores = "";
            foreach (var linea in this.ensamblador.programa)
            {
                if (this.ensamblador.programa.IndexOf(linea) == 0)
                {
                    linea.sDireccionHEXA = lDirecciones[0].sDireccionHexadecimal.Trim('H');
                    dirHexa = lDirecciones[0].sDireccionHexadecimal;
                    dirHexa = dirHexa.Trim('H');
                    dirHexa = dirHexa.Trim('h');
                    iDirDec = Convert.ToInt32(dirHexa.ToString(), 16);
                    linea.sDireccionamiento = "----";
                }

                else if (linea.sCodigoOp == "END")
                {
                    dirHexa = $"{iDirDec:X}";
                    linea.sDireccionHEXA = dirHexa;
                    linea.sDireccionamiento = "----";
                }

                else
                {

                    string lineaCodigo = "";
                    if (linea.sCodigoOp.Contains("+"))
                    {
                        lineaCodigo = linea.sCodigoOp.Substring(1);
                    }
                    else
                    {
                        lineaCodigo = linea.sCodigoOp;
                    }

                    if (linea.sCodigoOp == "BYTE")
                    {
                        int iCount = 0;
                        if (this.lDirecciones[iPos].cRegistro == 'C')
                        {
                            string palabra = "";
                            foreach (var c in this.lDirecciones[iPos].sPalabra)
                            {
                                if (c != "'"[0])
                                {
                                    palabra = palabra + c;
                                }
                                else
                                {
                                    iCount++;
                                }
                            }
                            if (iCount == 2)
                            {
                                iTotal = palabra.Length;
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + iTotal;
                                linea.sDireccionamiento = "----";
                            }
                            else
                            {
                                linea.sDireccionamiento = "Error de Sintaxis";
                                errores = errores + "Error de Sintaxis en: " + this.lDirecciones[iPos].sPalabra + "\r\n";
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                            }
                        }
                        else if (this.lDirecciones[iPos].cRegistro == 'X' && this.lDirecciones[iPos].sDireccionHexadecimal != null)
                        {
                            string palabra = "";
                            foreach (var c in linea.sDireccion)
                            {
                                if (c != "'"[0])
                                {
                                    palabra = palabra + c;
                                }
                                else
                                {
                                    iCount++;
                                }
                            }
                            if (iCount == 2)
                            {
                                iTotal = this.lDirecciones[iPos].sDireccionHexadecimal.Length;
                                if (iTotal % 2 == 0)
                                    iTotal = iTotal / 2;
                                else
                                    iTotal = (iTotal / 2) + 1;

                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + iTotal;
                                linea.sDireccionamiento = "----";
                            }
                            else
                            {
                                linea.sDireccionamiento = "Error de Sintaxis";
                                errores = errores + "Error de Sintaxis en: " + linea.sDireccion + "\r\n";
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                            }
                        }
                    }
                    else if (linea.sCodigoOp == "WORD")
                    {
                        dirHexa = $"{iDirDec:X}";
                        linea.sDireccionHEXA = dirHexa;
                        iDirDec = iDirDec + 3;
                        linea.sDireccionamiento = "----";
                    }
                    else if (linea.sCodigoOp == "RESW")
                    {
                        if (this.lDirecciones[iPos].iNumeroDecimal != 0)
                        {
                            int iValor = Convert.ToInt32(linea.sDireccion) * 3;
                            //int iValorCP = Convert.ToInt32(dirHexa, 16);
                            dirHexa = $"{iDirDec:x}";

                            linea.sDireccionHEXA = dirHexa;
                            linea.sDireccionamiento = "----";

                            iDirDec = iDirDec + iValor;
                            dirHexa = $"{iDirDec:x}";
                            //int iNuevoCP = iValor + iValorCP;
                            //dirHexa = $"{iNuevoCP:X}";
                        }
                        else
                        {
                            if (linea.sDireccion.Contains("H"))
                            {
                                int iValor = Convert.ToInt32(linea.sDireccion.Replace("H", ""), 16) * 3;
                                dirHexa = $"{iDirDec:x}";
                                int iValorCP = Convert.ToInt32(dirHexa, 16);

                                linea.sDireccionHEXA = dirHexa;
                                linea.sDireccionamiento = "----";
                                iDirDec = iValor + iValorCP;
                                dirHexa = $"{iDirDec:X}";
                            }
                            else
                            {
                                int iValor = Convert.ToInt32(linea.sDireccion) * 3;
                                int iValorCP = Convert.ToInt32(dirHexa, 16);
                                linea.sDireccionHEXA = dirHexa;
                                linea.sDireccionamiento = "----";
                                iDirDec = iValor + iValorCP;
                                dirHexa = $"{iDirDec:X}";
                            }
                        }
                    }
                    else if (this.existeInstruccionXE(lineaCodigo))
                    {
                        if (this.existeInstruccionXE(linea.sEtiqueta) == true)
                        {
                            linea.sDireccionamiento = "Error de Sintaxis";
                            errores = errores + "Error de Sintaxis en: " + linea.sEtiqueta + "\n";
                            dirHexa = $"{iDirDec:X}";
                            linea.sDireccionHEXA = dirHexa;
                        }
                        else
                        {


                            if (this.formatoInstruccion(lineaCodigo) == 1)
                            {
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + 1;
                            }
                            else if (this.formatoInstruccion(lineaCodigo) == 2)
                            {
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + 2;
                            }
                            else if (this.formatoInstruccion(linea.sCodigoOp) == 3)
                            {
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + 3;
                            }
                            else if (this.formatoInstruccion(linea.sCodigoOp) == 4)
                            {
                                dirHexa = $"{iDirDec:X}";
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = iDirDec + 4;
                            }

                            if (lineaCodigo == "ORG")
                            {
                                dirHexa = linea.sDireccion.Trim('H').ToString();
                                linea.sDireccionHEXA = dirHexa;
                                iDirDec = Convert.ToInt32(dirHexa, 16);
                            }


                            if (linea.sDireccion != null && lineaCodigo != "END")
                            {
                                if (linea.sDireccion.Contains("@"))
                                {
                                    linea.sDireccionamiento = "Indirecto";
                                }
                                else if (linea.sDireccion.Contains("#"))
                                {
                                    linea.sDireccionamiento = "Inmediato";
                                }
                                else
                                {
                                    linea.sDireccionamiento = "Simple";
                                }
                            }
                            else if (linea.sDireccion == null && lineaCodigo == "RSUB" || lineaCodigo == "END")
                            {
                                linea.sDireccionamiento = "----";
                            }
                        }
                    }
                    else if (this.existeDirectiva(lineaCodigo))
                    {
                        //DIRECTIVAS
                        // List<string> directivas = new List<string>() {"RESB","BYTE","RESB","RESW","BASE","WORD"};
                        if (lineaCodigo == "RESB")
                        {
                            dirHexa = $"{iDirDec:X}";
                            linea.sDireccionHEXA = dirHexa;
                            linea.sDireccionamiento = "----";

                            if (linea.sDireccion.Contains("H"))
                            {
                                int iV = Convert.ToInt32(linea.sDireccion.Replace("H", ""), 16);
                                iDirDec = iDirDec + iV;
                                dirHexa = $"{iDirDec:X}";
                            }
                            else
                            {
                                int iV = Convert.ToInt32(linea.sDireccion);
                                iDirDec = iDirDec + iV;
                                dirHexa = $"{iDirDec:X}";
                            }



                        }
                        else if (lineaCodigo == "RESW")
                        {
                            int iValor = Convert.ToInt32(linea.sDireccion, 16) * 2;
                            int iValorCP = Convert.ToInt32(dirHexa, 16);

                            int iNuevoCP = iValor + iValorCP;
                            dirHexa = $"{iNuevoCP:X}";
                            linea.sDireccionHEXA = dirHexa;
                            linea.sDireccionamiento = "----";
                        }
                        else if (lineaCodigo == "EQU" || lineaCodigo == "BASE" || lineaCodigo == "END")
                        {
                            linea.sDireccionHEXA = dirHexa;
                            linea.sDireccionamiento = "----";
                        }
                        else if (lineaCodigo == "BYTE")
                        {
                            int iCount = 0;
                            if (this.lDirecciones[iPos].cRegistro == 'C')
                            {
                                string palabra = "";
                                foreach (var c in this.lDirecciones[iPos].sPalabra)
                                {
                                    if (c != "'"[0])
                                    {
                                        palabra = palabra + c;
                                    }
                                    else
                                    {
                                        iCount++;
                                    }
                                }
                                if (iCount == 2)
                                {
                                    iTotal = palabra.Length;
                                    dirHexa = $"{iDirDec:X}";
                                    linea.sDireccionHEXA = dirHexa;
                                    iDirDec = iDirDec + iTotal;
                                    linea.sDireccionamiento = "----";
                                }
                                else
                                {
                                    linea.sDireccionamiento = "Error de Sintaxis";
                                    errores = errores + "Error de Sintaxis en: " + this.lDirecciones[iPos].sPalabra + "\r\n";
                                    dirHexa = $"{iDirDec:X}";
                                    linea.sDireccionHEXA = dirHexa;
                                }
                            }
                            else if (this.lDirecciones[iPos].cRegistro == 'X' && this.lDirecciones[iPos].sDireccionHexadecimal != null)
                            {
                                string palabra = "";
                                foreach (var c in linea.sDireccion)
                                {
                                    if (c != "'"[0])
                                    {
                                        palabra = palabra + c;
                                    }
                                    else
                                    {
                                        iCount++;
                                    }
                                }
                                if (iCount == 2)
                                {
                                    iTotal = this.lDirecciones[iPos].sDireccionHexadecimal.Length;
                                    if (iTotal % 2 == 0)
                                        iTotal = iTotal / 2;
                                    else
                                        iTotal = (iTotal / 2) + 1;

                                    dirHexa = $"{iDirDec:X}";
                                    linea.sDireccionHEXA = dirHexa;
                                    iDirDec = iDirDec + iTotal;
                                    linea.sDireccionamiento = "----";
                                }
                                else
                                {
                                    linea.sDireccionamiento = "Error de Sintaxis";
                                    errores = errores + "Error de Sintaxis en: " + linea.sDireccion + "\r\n";
                                    dirHexa = $"{iDirDec:X}";
                                    linea.sDireccionHEXA = dirHexa;
                                    linea.sDireccionamiento = "----";
                                }
                            }
                        }
                        else if (linea.sCodigoOp == "WORD")
                        {
                            dirHexa = $"{iDirDec:X}";
                            linea.sDireccionHEXA = dirHexa;
                            iDirDec = iDirDec + 3;
                            linea.sDireccionamiento = "----";
                        }
                    }
                    else
                    {
                        linea.sDireccionamiento = "Error, Instruccion no Existe.\n";
                        errores = errores + "Error, Instruccion " + linea.sCodigoOp + " no Existe.\r\n";
                        dirHexa = $"{iDirDec:X}";
                        linea.sDireccionHEXA = dirHexa;

                    }
                }
                iPos++;
            }
            if (errores == "")
            {
                errores = "Sin Errores en el Paso No. 1\r\n";
                textBox2.Text = errores;
            }
            else
            {
                textBox2.Text = textBox2.Text + errores;
            }


        }

        private void llenarDataGridXE()
        {
            int iPos = 1;
            foreach (var linea in this.ensamblador.programa)
            {
                string formato = "----";

                formato = this.formatoInstruccion(linea.sCodigoOp).ToString();
                if (formato == "-1" || formato == "0")
                {
                    formato = "----";
                }
                this.dataGridView5.Rows.Add(formato, linea.sDireccionHEXA, linea.sCodigoObjeto, linea.sEtiqueta, linea.sCodigoOp, linea.sDireccion, linea.sDireccionamiento);
                iPos++;
            }
        }

        private void crearTabSimXE()
        {
            string dir;
            string etq;

            foreach (var l in ensamblador.programa)
            {
                if (l.sEtiqueta != null && ensamblador.programa.IndexOf(l) != 0 && this.existeInstruccion(l.sEtiqueta) == false)
                {
                    if (this.existeSimbolo(l.sEtiqueta) == false)
                    {
                        this.tablaSimbolos.Add(new TabSim(l.sEtiqueta, l.sDireccionHEXA));
                        this.dataGridView2.Rows.Add(l.sEtiqueta, l.sDireccionHEXA);
                    }
                    else
                    {
                        textBox2.Text = textBox2.Text + "Error, Simbolo " + l.sEtiqueta + " Se Encuentra Duplicado.\r\n";
                        l.sDireccionamiento = "Error, Simbolo Duplicado";
                    }
                }
                else if (this.existeInstruccion(l.sEtiqueta) == true)
                {
                    l.sDireccionamiento = "Error de Sintaxis";
                }
            }
        }

        private bool existeDirectiva(string directiva)
        {
            List<string> directivas = new List<string>() { "BYTE", "RESB", "RESW", "BASE", "WORD", "EQU" };

            if (directivas.Contains(directiva))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string codInsXE(string instruccion)
        {
            if (instruccion == "ADD")
            {
                return ("000110");
            }
            else if (instruccion == "ADDF")
            {
                return ("010110");
            }
            else if (instruccion == "ADDR")
            {
                return ("90");
            }
            else if (instruccion == "AND")
            {
                return ("010000");
            }
            else if (instruccion == "CLEAR")
            {
                return ("B4");
            }
            else if (instruccion == "COMP")
            {
                return ("001010");
            }
            else if (instruccion == "COMPF")
            {
                return ("100010");
            }
            else if (instruccion == "COMPR")
            {
                return ("A0");
            }
            else if (instruccion == "DIV")
            {
                return ("001001");
            }
            else if (instruccion == "DIVR")
            {
                return ("9C");
            }
            else if (instruccion == "FIX")
            {
                return ("C4");
            }
            else if (instruccion == "FLOAT")
            {
                return ("C0");
            }
            else if (instruccion == "HIO")
            {
                return ("F4");
            }
            else if (instruccion == "J")
            {
                return ("001111");
            }
            else if (instruccion == "JEQ")
            {
                return ("001100");
            }
            else if (instruccion == "JGT")
            {
                return ("001101");
            }
            else if (instruccion == "JLT")
            {
                return ("001110");
            }
            else if (instruccion == "JSUB")
            {
                return ("010010");
            }
            else if (instruccion == "LDA")
            {
                return ("000000");
            }
            else if (instruccion == "LDB")
            {
                return ("011010");
            }
            else if (instruccion == "LDCH")
            {
                return ("010100");
            }
            else if (instruccion == "LDF")
            {
                return ("011100");
            }
            else if (instruccion == "LDL")
            {
                return ("000010");
            }
            else if (instruccion == "LDS")
            {
                return ("011011");
            }
            else if (instruccion == "LDT")
            {
                return ("011101");
            }
            else if (instruccion == "LDX")
            {
                return ("000001");
            }
            else if (instruccion == "LPS")
            {
                return ("110100");
            }
            else if (instruccion == "MUL")
            {
                return ("001000");
            }
            else if (instruccion == "MULF")
            {
                return ("011000");
            }
            else if (instruccion == "MULR")
            {
                return ("98");
            }
            else if (instruccion == "NORM")
            {
                return ("C8");
            }
            else if (instruccion == "OR")
            {
                return ("010001");
            }
            else if (instruccion == "RD")
            {
                return ("110110");
            }
            else if (instruccion == "RMO")
            {
                return ("AC");
            }
            else if (instruccion == "RSUB")
            {
                return ("010011");
            }
            else if (instruccion == "SHIFTL")
            {
                return ("A4");
            }
            else if (instruccion == "SHIFTR")
            {
                return ("A8");
            }
            else if (instruccion == "SIO")
            {
                return ("F0");
            }
            else if (instruccion == "SSK")
            {
                return ("111011");
            }
            else if (instruccion == "STA")
            {
                return ("000011");
            }
            else if (instruccion == "STB")
            {
                return ("011110");
            }
            else if (instruccion == "STCH")
            {
                return ("010101");
            }
            else if (instruccion == "STF")
            {
                return ("100000");
            }
            else if (instruccion == "STI")
            {
                return ("110101");
            }
            else if (instruccion == "STL")
            {
                return ("000101");
            }
            else if (instruccion == "STS")
            {
                return ("011111");
            }
            else if (instruccion == "STSW")
            {
                return ("111010");
            }
            else if (instruccion == "STT")
            {
                return ("100001");
            }
            else if (instruccion == "STX")
            {
                return ("000100");
            }
            else if (instruccion == "SUB")
            {
                return ("000111");
            }
            else if (instruccion == "SUBF")
            {
                return ("010111");
            }
            else if (instruccion == "SUBR")
            {
                return ("94");
            }
            else if (instruccion == "SVC")
            {
                return ("B0");
            }
            else if (instruccion == "TD")
            {
                return ("111000");
            }
            else if (instruccion == "TIO")
            {
                return ("F8");
            }
            else if (instruccion == "TIX")
            {
                return ("001011");
            }
            else if (instruccion == "TIXR")
            {
                return ("B8");
            }
            else if (instruccion == "WS")
            {
                return ("110111");
            }

            return "ERROR";
        }

        private string valorNumero(string valor)
        {
            try
            {
                int iV = Convert.ToInt32(valor, 16);
                return valor;
            }
            catch
            {
                return "ERROR SINTACTICO";
            }
        }

        private string regresarHexa(string obj)
        {
            int il = obj.Length;

            string n1 = obj.Substring(0, 4);
            string n2 = obj.Substring(4, 4);
            string n3 = obj.Substring(8, 4);

            int iN1 = Convert.ToInt32(n1, 2);
            int iN2 = Convert.ToInt32(n2, 2);
            int iN3 = Convert.ToInt32(n3, 2);


            string hN1 = iN1.ToString("X");
            string hN2 = iN2.ToString("X");
            string hN3 = iN3.ToString("X");

            return hN1 + hN2 + hN3;
        }

        public bool esConstante(string sDireccion)
        {
            try
            {
                int iN1 = Convert.ToInt32(sDireccion, 16);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void codigoOBJXE()
        {
            foreach (var linea in this.ensamblador.programa)
            {
                if (this.ensamblador.programa.IndexOf(linea) == 0)
                {
                    linea.sCodigoObjeto = "--------";
                }
                else
                {
                    if (linea.sCodigoOp == "BASE" || linea.sCodigoOp == "RESW" || linea.sCodigoOp == "RESB" || linea.sCodigoOp == "END")
                    {
                        linea.sCodigoObjeto = "--------";
                    }
                    else if (linea.sCodigoOp == "RSUB")
                    {
                        linea.sCodigoObjeto = "4C0000";
                    }
                    else if (linea.sCodigoOp == "BYTE")
                    {
                        if (linea.sDireccion[0] == 'C')
                        {
                            linea.sCodigoObjeto = this.codigoCadena(linea.sDireccion);
                            //l.sDireccionamiento = "DIRECTO";
                        }
                        else if (linea.sDireccion[0] == 'X')
                        {

                            string hexa = linea.sDireccion.ToString();
                            if (linea.sDireccion.Length < 4)
                            {
                                switch (hexa.Length)
                                {
                                    case 1:
                                        hexa = "000" + hexa;
                                        break;

                                    case 2:
                                        hexa = "00" + hexa;
                                        break;

                                    case 3:
                                        hexa = "0" + hexa;
                                        break;

                                }

                                linea.sCodigoObjeto = this.obtenerCodigo(hexa);
                            }
                            else
                            {

                                linea.sCodigoObjeto = this.obtenerCodigo(linea.sDireccion);
                                if (linea.sCodigoObjeto.Length < 4)
                                {
                                    switch (linea.sCodigoObjeto.Length)
                                    {
                                        case 1:
                                            linea.sCodigoObjeto = "000" + linea.sDireccion;
                                            break;
                                        case 2:
                                            linea.sCodigoObjeto = "00" + linea.sCodigoObjeto;
                                            break;
                                        case 3:
                                            linea.sCodigoObjeto = "0" + linea.sCodigoObjeto;
                                            break;
                                    }
                                }
                                //l.sDireccionamiento = "DIRECTO";
                            }
                        }
                    }
                    else if (linea.sCodigoOp == "WORD")
                    {
                        if (linea.sDireccion.Contains("H"))
                        {
                            string hexa = linea.sDireccion.Replace("H", "");
                            if (hexa.Length <= 5)
                            {
                                switch (hexa.Length)
                                {
                                    case 1:
                                        hexa = "00000" + hexa;
                                        break;

                                    case 2:
                                        hexa = "0000" + hexa;
                                        break;

                                    case 3:
                                        hexa = "000" + hexa;
                                        break;

                                    case 4:
                                        hexa = "00" + hexa;
                                        break;

                                    case 5:
                                        hexa = "0" + hexa;
                                        break;
                                }
                            }
                            linea.sCodigoObjeto = hexa;
                        }
                        else
                        {
                            int iCodigo = Int32.Parse(linea.sDireccion);
                            string hexa = iCodigo.ToString("X");
                            if (hexa.Length <= 5)
                            {
                                switch (hexa.Length)
                                {
                                    case 1:
                                        hexa = "00000" + hexa;
                                        break;

                                    case 2:
                                        hexa = "0000" + hexa;
                                        break;

                                    case 3:
                                        hexa = "000" + hexa;
                                        break;

                                    case 4:
                                        hexa = "00" + hexa;
                                        break;

                                    case 5:
                                        hexa = "0" + hexa;
                                        break;
                                }
                            }
                            linea.sCodigoObjeto = hexa;
                        }

                    }
                    else if (this.formatoInstruccion(linea.sCodigoOp) == 1)
                    {
                        linea.sCodigoObjeto = this.codInsXE(linea.sCodigoOp);
                    }
                    else if (this.formatoInstruccion(linea.sCodigoOp) == 2)
                    {
                        linea.sCodigoObjeto = this.codInsXE(linea.sCodigoOp);

                        if (linea.sDireccion.Length >= 1)
                        {
                            string trim = ",";
                            string[] aRegistros = linea.sDireccion.Split(trim[0]);
                            foreach (var a in aRegistros)
                            {
                                if (a == "A" || a == "B" || a == "F" || a == "L" || a == "S" || a == "T" || a == "X")
                                {
                                    linea.sCodigoObjeto = linea.sCodigoObjeto + this.regresarRegistro(a);
                                }
                                else if (this.valorNumero(a) != "ERROR SINTACTICO")
                                {
                                    linea.sCodigoObjeto = linea.sCodigoObjeto + a;
                                }
                                else if (this.valorNumero(a) == "ERROR SINTACTICO")
                                {
                                    linea.sCodigoObjeto = "ERROR SINTACTICO";
                                }
                            }

                            if (linea.sCodigoObjeto.Length < 4)
                            {
                                switch (linea.sCodigoObjeto.Length)
                                {
                                    case 1:
                                        linea.sCodigoObjeto = linea.sCodigoObjeto + "000";
                                        break;

                                    case 2:
                                        linea.sCodigoObjeto = linea.sCodigoObjeto + "00";
                                        break;

                                    case 3:
                                        linea.sCodigoObjeto = linea.sCodigoObjeto + "0";
                                        break;
                                }
                            }
                        }
                    }
                    else if (this.formatoInstruccion(linea.sCodigoOp) == 3)
                    {
                        if (linea.sDireccion.Contains("#"))
                        {
                            string nDireccion = linea.sDireccion.Substring(1);
                            if (this.esConstante(nDireccion))
                            {
                                string nixbpe = "0100000";
                                string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                string sDireccion = linea.sDireccion.Substring(1);
                                linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDireccion;
                            }
                            else if (buscarTABSIB(linea.sDireccion.Replace("#", "")) != null)
                            {
                                if (this.relativoContador(this.buscarTABSIB(linea.sDireccion), this.sContador(this.ensamblador.programa.IndexOf(linea))))
                                {

                                    string nixbpe = "010010";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(linea.sDireccion), 16);
                                    int iPC = Convert.ToInt32(this.sContador(this.ensamblador.programa.IndexOf(linea)), 16);
                                    int iDes = iTA - iPC;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = sCodigo + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = sCodigo + sDesplazamiento;
                                    }
                                }
                                else if (this.relativoBase(this.buscarTABSIB(linea.sDireccion), this.buscaBase()))
                                {

                                    string nixbpe = "010100";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(linea.sDireccion), 16);
                                    int iBase = Convert.ToInt32(this.buscaBase(), 16);
                                    int iDes = iTA - iBase;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = sCodigo + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = sCodigo + sDesplazamiento;
                                    }
                                }
                                else
                                {
                                    linea.sCodigoObjeto = "ERROR la ins. no es relativa ni al contador ni a la base";
                                }
                            }
                            else if (buscarTABSIB(linea.sDireccion.Substring(1)) == null)
                            {
                                linea.sCodigoObjeto = "ERROR simbolo no existe";
                            }
                        }
                        else if (linea.sDireccion.Contains("@"))
                        {
                            string nDireccion = linea.sDireccion.Substring(1);
                            if (this.esConstante(nDireccion))
                            {
                                string nixbpe = "100000";
                                string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                string sDireccion = linea.sDireccion.Substring(1);
                                linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDireccion;
                            }
                            else if (buscarTABSIB(linea.sDireccion.Replace("@", "")) != null)
                            {
                                if (this.relativoContador(this.buscarTABSIB(nDireccion), this.sContador(this.ensamblador.programa.IndexOf(linea))))
                                {

                                    string nixbpe = "100010";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(linea.sDireccion.Replace("@", "")), 16);
                                    int iPC = Convert.ToInt32(this.sContador(this.ensamblador.programa.IndexOf(linea)), 16);
                                    int iDes = iTA - iPC;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDesplazamiento;
                                    }
                                }
                                else if (this.relativoBase(this.buscarTABSIB(nDireccion), this.buscaBase()))
                                {

                                    string nixbpe = "100100";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(linea.sDireccion), 16);
                                    int iBase = Convert.ToInt32(this.buscaBase(), 16);
                                    int iDes = iTA - iBase;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDesplazamiento;
                                    }
                                }
                                else
                                {
                                    linea.sCodigoObjeto = "ERROR la ins. no es relativa ni al contador ni a la base";
                                }
                            }
                            else if (buscarTABSIB(linea.sDireccion.Substring(1)) == null)
                            {
                                linea.sCodigoObjeto = "ERROR simbolo no existe";
                            }
                        }
                        else if (linea.sDireccion.Contains(","))
                        {
                            int index = linea.sDireccion.IndexOf(",");
                            string nDireccion = linea.sDireccion.Substring(0, index);
                            if (this.esConstante(nDireccion))
                            {
                                string nixbpe = "111000";
                                string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                string sDireccion = linea.sDireccion.Substring(1);
                                linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDireccion;
                            }
                            else if (buscarTABSIB(nDireccion) != null)
                            {
                                if (this.relativoContador(this.buscarTABSIB(nDireccion), this.sContador(this.ensamblador.programa.IndexOf(linea))))
                                {

                                    string nixbpe = "111010";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(nDireccion), 16);
                                    int iPC = Convert.ToInt32(this.sContador(this.ensamblador.programa.IndexOf(linea)), 16);
                                    int iDes = iTA - iPC;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = sCodigo + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = sCodigo + sDesplazamiento;
                                    }
                                }
                                else if (this.relativoBase(this.buscarTABSIB(nDireccion), this.buscaBase()))
                                {

                                    string nixbpe = "111100";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(nDireccion), 16);
                                    int iBase = Convert.ToInt32(this.buscaBase(), 16);
                                    int iDes = iTA - iBase;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = sCodigo + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = sCodigo + sDesplazamiento;
                                    }
                                }
                                else
                                {
                                    linea.sCodigoObjeto = "ERROR la ins. no es relativa ni al contador ni a la base";
                                }
                            }
                            else if (buscarTABSIB(nDireccion) == null)
                            {
                                linea.sCodigoObjeto = "ERROR simbolo no existe";
                            }
                        }
                        else
                        {
                            string nDireccion = linea.sDireccion;
                            if (this.esConstante(nDireccion))
                            {
                                string nixbpe = "110000";
                                string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                string sDireccion = linea.sDireccion.Substring(1);
                                linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDireccion;
                            }
                            else if (buscarTABSIB(linea.sDireccion) != null)
                            {
                                if (this.relativoContador(this.buscarTABSIB(linea.sDireccion), this.sContador(this.ensamblador.programa.IndexOf(linea))))
                                {

                                    string nixbpe = "110010";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(linea.sDireccion), 16);
                                    int iPC = Convert.ToInt32(this.sContador(this.ensamblador.programa.IndexOf(linea)), 16);
                                    int iDes = iTA - iPC;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = sCodigo + sDes;
                                    }
                                    else
                                    {
                                        linea.sCodigoObjeto = sCodigo + sDesplazamiento;
                                    }
                                }
                                else if (this.relativoBase(this.buscarTABSIB(linea.sDireccion), this.buscaBase()))
                                {

                                    string nixbpe = "110100";
                                    string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                    int iTA = Convert.ToInt32(this.buscarTABSIB(linea.sDireccion), 16);
                                    int iBase = Convert.ToInt32(this.buscaBase(), 16);
                                    int iDes = iTA - iBase;
                                    string sDesplazamiento = iDes.ToString("X");
                                    if (iDes < 0)
                                    {
                                        string sDes = this.desplazamiento(sDesplazamiento);
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDes;
                                    }
                                    else if (iDes > 0)
                                    {
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + sDesplazamiento;
                                    }
                                }
                                else
                                {
                                    linea.sCodigoObjeto = "ERROR la ins. no es relativa ni al contador ni a la base";
                                }
                            }
                            else if (buscarTABSIB(linea.sDireccion.Substring(1)) == null)
                            {
                                linea.sCodigoObjeto = "ERROR simbolo no existe";
                            }
                        }
                    }
                    else if (this.formatoInstruccion(linea.sCodigoOp) == 4)
                    {
                        if (linea.sDireccion.Contains("#"))
                        {
                            //nixbpe
                            //010001
                            string nixbpe = "010001";
                            string direccion = linea.sDireccion.Replace("#", "");
                            string valorDireccion = this.buscarTABSIB(direccion);
                            if (valorDireccion != null)
                            {
                                string sCodigo = this.codInsXE(linea.sCodigoOp.Replace("+", "")) + nixbpe;
                                if (valorDireccion.Length < 6)
                                {
                                    for (int i = 0; i <= 6 - valorDireccion.Length; i++)
                                    {
                                        valorDireccion = "0" + valorDireccion;
                                    }
                                }

                                linea.sCodigoObjeto = this.regresarHexa(sCodigo) + valorDireccion;
                            }
                            else
                            {
                                linea.sCodigoObjeto = "ERROR simbolo no existe";
                            }
                        }
                        else if (linea.sDireccion.Contains("@"))
                        {
                            //nixbpe
                            //100001
                            string nixbpe = "100001";
                            string direccion = linea.sDireccion.Replace('@', ' ');
                            string valorDireccion = this.buscarTABSIB(direccion);
                            string sCodigo = this.codInsXE(linea.sCodigoOp.Replace("+", "")) + nixbpe;
                            if (valorDireccion.Length <= 5)
                            {
                                for (int i = 0; i < 5 - valorDireccion.Length; i++)
                                {
                                    valorDireccion = "0" + direccion;
                                }
                            }

                            linea.sCodigoObjeto = this.regresarHexa(sCodigo) + valorDireccion;
                        }
                        else if (linea.sDireccion.Contains(","))
                        {
                            string nixbpe = "111001";
                            string trim = ",";
                            string[] aRegistros = linea.sDireccion.Split(trim[0]);
                            foreach (var a in aRegistros)
                            {
                                if (a != "X")
                                {
                                    try
                                    {
                                        string direccion = a.Replace("H", "");
                                        int iN1 = Convert.ToInt32(direccion, 16);
                                        //string direccion = a.Replace("H", "");
                                        string sCodigo = this.codInsXE(linea.sCodigoOp.Replace("+", "")) + nixbpe;
                                        if (direccion.Length <= 6)
                                        {
                                            for (int i = 0; i <= 6 - direccion.Length; i++)
                                            {
                                                direccion = "0" + direccion;
                                            }
                                        }
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + direccion;
                                    }
                                    catch
                                    {
                                        string direccion = a.Replace("H", "");
                                        string valorDireccion = this.buscarTABSIB(direccion);
                                        string sCodigo = this.codInsXE(linea.sCodigoOp) + nixbpe;
                                        if (direccion.Length <= 5)
                                        {
                                            for (int i = 0; i < 5 - direccion.Length; i++)
                                            {
                                                direccion = "0" + direccion;
                                            }
                                        }
                                        linea.sCodigoObjeto = this.regresarHexa(sCodigo) + direccion;
                                    }
                                }
                            }
                        }
                        else if (this.esConstante(linea.sDireccion))
                        {
                            string nixbpe = "110001";
                            string sCodigo = this.codInsXE(linea.sCodigoOp.Replace("+", "")) + nixbpe;
                            string direccion = linea.sDireccion;
                            if (direccion.Length <= 5)
                            {
                                for (int i = 0; i < 5 - direccion.Length; i++)
                                {
                                    direccion = "0" + direccion;
                                }
                            }
                            linea.sCodigoObjeto = this.regresarHexa(sCodigo) + direccion;

                        }
                        else if (this.esConstante(linea.sDireccion))
                        {

                            linea.sCodigoObjeto = "ERROR OPERANDO NO EXISTE";
                        }
                    }
                }
            }

            this.llenarDataGridXE();
        }

        public bool relativoContador(string TA, string PC)
        {
            int iTA = Convert.ToInt32(TA, 16);
            int iPC = Convert.ToInt32(PC, 16);

            int iDes = iTA - iPC;

            if (iDes > -2048 && iDes < 2047)
            {
                return true;
            }

            return false;
        }

        public bool relativoBase(string TA, string BASE)
        {
            int iTA = Convert.ToInt32(TA, 16);
            int iBase = Convert.ToInt32(BASE, 16);

            int iDesp = iTA - iBase;

            if (iDesp > 0 && iDesp < 4095)
            {
                return true;
            }

            return false;
        }

        public string desplazamiento(string sHexa)
        {
            int iL = sHexa.Length;
            return sHexa.Substring(iL - 3);
        }

        public string buscaBase()
        {
            foreach (var l in this.ensamblador.programa)
            {
                if (l.sCodigoOp == "BASE")
                {
                    return l.sDireccionHEXA;
                }
            }

            return null;
        }



    }
}
