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
                            else if (p.sDireccion[0] == 'X')
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
                            if (this.etiquetaExiste(etiqueta) == false)
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
            List<string> listaInstrucciones = new List<string>() { "START", "END", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCH", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };
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
                if (l.sCodigoObjeto != "---")
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
    }
}
