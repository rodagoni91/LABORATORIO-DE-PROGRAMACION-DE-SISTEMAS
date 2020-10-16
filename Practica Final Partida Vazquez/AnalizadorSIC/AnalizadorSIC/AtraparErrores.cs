using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorSIC
{
    class AtraparErrores : BaseErrorListener, IAntlrErrorListener<int>
    {
        string direccion;
        RichTextBox codErrores;
        int contErrores = 0;
        public List<int> ListaErrores;
        public AtraparErrores(string archivofuente, RichTextBox box)
            : base()
        {
            direccion = archivofuente;
            codErrores = box;
            ListaErrores = new List<int>();
        }

        /// <summary>
        /// Este metodo atrapa los errores sintacticos
        /// </summary>
        /// <param name="recognier"></param>
        /// <param name="offendingSymbol"></param>
        /// <param name="line">numero de linea</param>
        /// <param name="charPositionLine"></param>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public override void SyntaxError(IRecognizer recognier, IToken offendingSymbol, 
            int line, int charPositionLine, string msg, RecognitionException e)
        {
            codErrores.Text+= "Error en linea : " + (line).ToString()+'\n';
            StreamWriter strw = File.AppendText(Path.Combine(Path.GetDirectoryName(direccion), "errores.txt"));
            strw.WriteLine("Error en la linea: " + (line) + "\n");
            ListaErrores.Add(line);
            strw.Close();
            contErrores++;
            /*DAY	START	4000H
NUM	WORD	12H
	LDA	NUM
	END*/
        }
        /// <summary>
        /// Este metodo atrapa los errores Lexicos
        /// </summary>
        /// <param name="recognier"></param>
        /// <param name="offendingSymbol"></param>
        /// <param name="line"></param>
        /// <param name="charPositionInLine"></param>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public void SyntaxError(IRecognizer recognier, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            codErrores.Text += "Error en linea : " + (line-1).ToString() + '\n';
            StreamWriter strw = File.AppendText("errores.txt");
            strw.WriteLine("Error en la linea: " + (line-1)+ "\n");
            strw.Close();
            contErrores++;
        }

        /// <summary>
        /// Indica si la gramatica tuvo errores
        /// </summary>
        /// <returns></returns>
        public bool TieneErrores()
        {
            if (contErrores > 0)
                return true;
            return false;
        }
    }
}
