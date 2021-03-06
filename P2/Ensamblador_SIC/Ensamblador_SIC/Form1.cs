﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Ensamblador_SIC
{
    public partial class Form1 : Form
    {
        private string sPrograma;
        private Programa ensamblador;
        private List<Etiqueta> etiquetas;
        private List<Instruccion> instrucciones;
        private List<Direccion> lDirecciones;
        private List<string> errores;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;*/

            this.sPrograma = "";
            this.ensamblador = new Programa();
            this.etiquetas = new List<Etiqueta>();
            this.errores = new List<string>();
            this.instrucciones = new List<Instruccion>();
            this.lDirecciones = new List<Direccion>();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
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
                //parser.prog();
                this.separarPrograma();
                this.separarEtiquetas();
                this.separarInstrucciones();
                this.separDirecciones();
                //this.separDirecciones();
                this.buscarErrores();

                this.crearArchivo();


            }
            catch (Exception error)
            {
                //Console.Error.WriteLine(e.StackTrace);
                MessageBox.Show("A ocurrido un error inesperado " + error.Message);
            }
        }

        private void separarPrograma()
        {
            ensamblador = new Programa();
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

                        if (instrucciones.Length == 3)
                        {
                            string etiqueta = instrucciones[0];
                            string operacion = instrucciones[1];
                            string direccion = instrucciones[2];
                            lLinea = new Linea(etiqueta, operacion, direccion);
                            ensamblador.programa.Add(lLinea);
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

            string[] separar1 = sLinea.Split('\t');

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

            foreach (var p in ensamblador.programa)
            {
                if(p.sDireccion != null)
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
                                catch(Exception a)
                                {
                                    direccion = new Direccion(p.sDireccion, 'Z', ensamblador.programa.IndexOf(p));
                                    if (this.etiquetaExiste(p.sDireccion) == false)
                                    {
                                         mensaje = mensaje + "La etiqueta "+ p.sDireccion + " No Existe, Error en Linea: " + ensamblador.programa.IndexOf(p) + "\r\n";


                                    }
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

        private void instruccionExiste()
        {
            List<string> listaInstrucciones = new List<string>() { "START", "END", "BYTE", "ADD", "WORD", "RESB", "RESW", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCG", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD" };
            string mensaje = "Errores de instrucciones y/o directivas \r\n";

            foreach (var i in instrucciones)
            {
                if (listaInstrucciones.Contains(i.nInstruccion) == false)
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
            
            foreach (var e in etiquetas)
            {
                if(e.nEtiqueta == etiqueta)
                {
                    return true;
                }
            }

            return false;
        }

        private void crearArchivo()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ERRORES.txt" ;


            StreamWriter fichero; //Clase que representa un fichero
            fichero = File.CreateText("error.error");
            fichero.WriteLine(textBox2.Text); // Lo mismo que cuando escribimos por consola
            //fichero.Write("fin de la cita.");
            fichero.Close(); // Al cerrar el fic
            MessageBox.Show("Archivo de errores generado en: " + path);

        }
    }
}
