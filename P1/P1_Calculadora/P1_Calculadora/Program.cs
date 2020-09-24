using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr;
using Antlr.Runtime;

namespace P1_Calculadora
{
    class Program
    {
        /*static void Main(string[] args)
        {
        }*/
        static void Main(string[] args)
        {
            Console.Write("|| PRACTICA 1 ||\n");
            Console.Write(":: Escribe tu expresion aritmetica ::\n");
            string line = "";
            //VARIABLE PARA ALMACENAR LA CADENA DE ENTRADA
            while (true)
            {
                line = Console.ReadLine();
                //SE ALMACENA LA CADENA DE ENTRADA
                if (line.Contains("EXIT") || line.Contains("exit"))
                    //SI DETECTA EXIT SALE DEL PROGRAMA
                    break;

                var entrada = line + Environment.NewLine;
                byte[] byteArray = Encoding.ASCII.GetBytes(entrada);
                MemoryStream stream = new MemoryStream(byteArray);
                var parametro1 = new ANTLRInputStream(stream);
                Calculadora1Lexer lex = new Calculadora1Lexer(parametro1);
                //CREAMOS UN LEXER CON LA CADENA QUE ESCRIBIO EL USUARIO
                CommonTokenStream tokens = new CommonTokenStream(lex);
                //CREAMOS LOS TOKENS SEGUN EL LEXER CREADO
                Calculadora1Parser parser = new Calculadora1Parser(tokens);
                //CREAMOS EL PARSER CON LOS TOKENS CREADOS
                try
                {
                    int iResultado = parser.expresion();
                    Console.WriteLine(line + " = " + iResultado);
                    //SE VERIFICA QUE EL ANALIZADOR EMPIECE CON LA EXPRESION
                }
                catch (RecognitionException e)
                {
                    Console.Error.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
