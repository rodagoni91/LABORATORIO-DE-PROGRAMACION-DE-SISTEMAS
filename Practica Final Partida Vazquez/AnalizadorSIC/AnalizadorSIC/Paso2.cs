using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace AnalizadorSIC
{
    class Paso2 : gramticSicEstandarBaseVisitor<string>
    {
        Dictionary<string, int> tabsim = new Dictionary<string, int>();
        List<string> listaCodigoObjeto = new List<string>();
        public int longitudPrograma;
        public string dirInicio;
        Dictionary<string, string> codOp = new Dictionary<string, string>()
        {   { "ADD", "18" }, {"AND", "40" }, {"COMP", "28" }, {"DIV", "24" }, {"J", "3C"}, {"JEQ", "30"}, {"JGT", "34"}, {"JLT", "38"},
            {"JSUB", "48"}, {"LDA", "00"}, {"LDCH", "50"}, {"LDL", "08"}, {"LDX", "04"}, {"MUL", "20"}, {"OR", "44"}, {"RD", "D8"},
            { "STA", "0C"}, {"STCH", "54"}, {"STL", "14"}, {"STSW", "E8"}, {"STX", "10"}, {"SUB", "1C"}, {"TD", "E0"}, { "TIX", "2C"},
            { "WD", "DC"}};
        public string registroH = "";

        public Paso2(Dictionary<string, int> tabsim, int longitudPrograma)
        {
            this.tabsim = tabsim;
            this.longitudPrograma = longitudPrograma;
        }

        public override string VisitInicioHexadecimal([NotNull] gramticSicEstandarParser.InicioHexadecimalContext context)
        {
            char[] trim = { 'H', 'h' };
            if (context.children[0].GetText().Length > 6)
            {
                string cad = "";
                for(int i=0; i<6;i++)
                {
                    cad += context.children[0].GetText()[i];
                }
                registroH = "H" + cad;
            }
            else
            {
                registroH = "H" + context.children[0].GetText().PadRight(6, ' ');
            }
            // Dirección Inicial

            registroH += context.NUMH().GetText().TrimEnd(trim).PadLeft(6, '0');
            dirInicio= context.NUMH().GetText().TrimEnd(trim).PadLeft(6, '0');
            registroH += longitudPrograma.ToString("X").PadLeft(6, '0');
            return "------";
        }

        public override string VisitCInstruccion([NotNull] gramticSicEstandarParser.CInstruccionContext context)
        {
            int codigoObjeto = 0;
            int indexado = 0;
            string aux;
            string modoDir = context.oper().GetText();
            if (modoDir[modoDir.Length - 2] == ',')
            {
                indexado = 1 << 15;
                modoDir = modoDir.TrimEnd(',', 'X');
            }

            // Se verifica que la etiqueta exista en la tabla de tabsim.
            if (tabsim.ContainsKey(modoDir))
            {
                codigoObjeto = Convert.ToInt32(codOp[context.CODOP().GetText()], 16) << 16 | indexado |
                    tabsim[modoDir];
                aux=codigoObjeto.ToString("X").PadLeft(6, '0');
            }
            else
            {
                codigoObjeto = Convert.ToInt32(codOp[context.CODOP().GetText()], 16) << 16 | indexado |
                    Convert.ToInt32("7FFF", 16);
                aux = codigoObjeto.ToString("X").PadLeft(6, '0') + ",error";

            }

            listaCodigoObjeto.Add(aux);
            return aux;
        }
       
        public override string VisitCodRsub([NotNull] gramticSicEstandarParser.CodRsubContext context)
        {
            int codigoObjeto = Convert.ToInt32("4C", 16) << 16;
            listaCodigoObjeto.Add(codigoObjeto.ToString("X").PadLeft(6, '0'));
            return codigoObjeto.ToString("X").PadLeft(6, '0');
        }

        public override string VisitFuncionByte([NotNull] gramticSicEstandarParser.FuncionByteContext context)
        {
            string constante = context.constantes().GetText();
            if (constante[0] == 'X')
            {

                if (constante.Length % 2 != 0)
                    return constante.Trim('X', '\'');
                else
                    return "0" + constante.Trim('X', '\'');
            }

            constante = constante.Remove(0, 2);
            constante = constante.Remove(constante.Length - 1);

            byte[] codigoAscci = Encoding.ASCII.GetBytes(constante);
            listaCodigoObjeto.Add(BitConverter.ToString(codigoAscci).Replace("-", ""));
            return BitConverter.ToString(codigoAscci).Replace("-", "");
        }

        public override string VisitFuncionDirectiva([NotNull] gramticSicEstandarParser.FuncionDirectivaContext context)
        {

            string constante = context.children[1].GetText().ToString();
            string valor = context.operdir().GetText();
            String val = context.tipodir().ToString();
            if (valor.Contains("H"))
            {
                switch (context.tipodir().GetText())
                {
                    case "RESW":
                        listaCodigoObjeto.Add("------");
                        constante = "------";
                        break;
                    case "RESB":
                        listaCodigoObjeto.Add("------");
                        constante = "------";
                        break;
                    case "WORD":
                        char[] delimiter = { 'h', 'H' };
                        if (valor.Contains("h")||valor.Contains('H'))
                            constante = valor.TrimEnd(delimiter).PadLeft(6,'0');
                        else
                            constante = (int.Parse(valor).ToString("X").PadLeft(6, '0'));

                        listaCodigoObjeto.Add(constante);
                        break;
                }
            }
            else
            {
                String dir = context.tipodir().GetText();
                switch (dir)
                {
                    case "RESW":
                        listaCodigoObjeto.Add("------");
                        constante = "------";
                        break;
                    case "RESB":
                        listaCodigoObjeto.Add("------");
                        constante = "------";
                        break;
                    case "WORD":
                        char[] delimiter = { 'h', 'H' };
                        if (valor.Contains("h")||valor.Contains('H'))
                            constante = valor.TrimEnd(delimiter).PadLeft(6, '0');
                        else
                            constante = (int.Parse(valor).ToString("X").PadLeft(6, '0'));

                        listaCodigoObjeto.Add(constante);
                        break;
                }
            }
            
            return constante;
        }
        public override string VisitFunEnd([NotNull] gramticSicEstandarParser.FunEndContext context)
        {
            string cadena = "------";
            return cadena;
        }
    }
}
