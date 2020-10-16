using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Errores : Form
    {
        string path;
        string basePath;
       
        bool bandErrors;
        public Errores()
        {
            InitializeComponent();
        }

        public void compila(string directorio)
        {
            
            bandErrors = false;
            string nombre;
            AntlrFileStream antFile;
            SIC_gramaticaLexer lex;
            SIC_gramaticaParser parser;
            CommonTokenStream tokens;
            FileStream stream = null;
            StreamWriter writer = null;
            
                nombre = new FileInfo(directorio).Name;
                string nombre2 = nombre.Replace(".s", "");
            basePath = Environment.CurrentDirectory;

            path = @basePath + nombre2 + "Error.t";
            
            try
            {
                    //crear archivo
                    stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new StreamWriter(stream);
                    Console.SetError(writer);
                    antFile = new AntlrFileStream(directorio);
                    lex = new SIC_gramaticaLexer(antFile);
                    tokens = new CommonTokenStream(lex);
                    parser = new SIC_gramaticaParser(tokens);

                    parser.prog();

                    writer.Close();
                    stream.Close();
                 
                    if (parser.NumberOfSyntaxErrors != 0)
                    {
                        bandErrors = true;
                    }

                if (!bandErrors)
                {
                    File.Delete(path);
                    richTextBox1.Text = "El archivo esta correcto";
                }
                else
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        richTextBox1.Text = sr.ReadToEnd();
                        sr.Close();
                    }
                }
                    
            }
                catch
                {
                    writer.Close();
                    stream.Close();
                    File.Delete(path);

                    Console.WriteLine("**No se encuentra el archivo**");
                }
            
        }

        public void limpia()
        {
            richTextBox1.Clear();
        }

        public string regresaDirErro()
        {
            string dir = "nada";
            if (!bandErrors)
            {
                dir = "nada";
            }
            else
            {
                dir = path;
            }
            return dir;
        }

    }
}
