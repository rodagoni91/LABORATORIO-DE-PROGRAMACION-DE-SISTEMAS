using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace AnalizadorSIC
{
    class Paso1 : gramticSicEstandarBaseVisitor<int>
    {
        int contadorPrograma;
        public bool formato4 = false;
        String cpHexadecimal;
        Dictionary<string, int> tabsim = new Dictionary<string, int>();
        public Dictionary<string, int> TABSIM { get { return tabsim; } }
        
        public int CP
        {
            get { return contadorPrograma; }
            set { contadorPrograma = value; }
        }

        public override int VisitInicioDecimal([NotNull] gramticSicEstandarParser.InicioDecimalContext context)
        {
            string valor = context.NUMD().GetText();
            if (valor != "")
            {
                contadorPrograma = Convert.ToInt32(valor);
            }
            return contadorPrograma;
        }

        public override int VisitInicioHexadecimal([NotNull] gramticSicEstandarParser.InicioHexadecimalContext context)
        {
            char[] trim = { 'H', 'h' };
            string valor = context.NUMH().GetText();
            if (valor != "")
            {
                contadorPrograma = Convert.ToInt32(valor.TrimEnd(trim), 16);
            }
            return contadorPrograma;

        }
        public override int VisitCodRsub([NotNull] gramticSicEstandarParser.CodRsubContext context)
        {
            string etiqueta1 = "";
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null && context.ChildCount != 3)
                etiqueta1 = context.children[1].GetChild(0).GetText();
            if (!ChecaPalabrasReservadas(etiqueta1))
            {
                contadorPrograma += 3;
            }
            return contadorPrograma;
        }

        public override int VisitCInstruccion([NotNull] gramticSicEstandarParser.CInstruccionContext context)
        {
            string etiqueta1 = "";
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null && context.ChildCount != 3)
                etiqueta1 = context.children[1].GetChild(0).GetText();
            if (!ChecaPalabrasReservadas(etiqueta1))
            {
                if (context.etiqueta() != null)
                {
                    string etiqueta = context.etiqueta().GetText();
                    // Se verifica que no exista la etiqueta de lo contrario se genera un error (SIMBOLO DUPLICADOS).
                    if (!tabsim.ContainsKey(etiqueta))
                        tabsim.Add(etiqueta, contadorPrograma);
                    else
                    {
                        SumaDirectivaOInstruccion(context);
                        throw new Exception("Error: Simbolos Duplicados: ");
                    }
                }

                SumaDirectivaOInstruccion(context);
            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                tabsim.Add(etiqueta, contadorPrograma);
                contadorPrograma += 3;
            }
            return contadorPrograma;
        }

        private void SumaDirectivaOInstruccion(gramticSicEstandarParser.CInstruccionContext context)
        {
            if (context.CODOP() == null)
                contadorPrograma = base.VisitCInstruccion(context);
            else
            {
               if(context.children[0].GetText()!="+")
                {
                    contadorPrograma += 3;
                }
                else
                {
                    formato4 = true;
                    contadorPrograma += 4;
                }
            }
              
        }

        public override int VisitFuncionDirectiva([NotNull] gramticSicEstandarParser.FuncionDirectivaContext context)
        {
            string etiqueta1 = "";
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null && context.ChildCount != 3)
                etiqueta1 = context.children[1].GetChild(0).GetText();
            if (!ChecaPalabrasReservadas(etiqueta1))
            {
                if (context.etiqueta() != null)
                {
                    string etiqueta = context.etiqueta().GetText();
                    // Se verifica que no exista la etiqueta de lo contrario se genera un error (SIMBOLO DUPLICADOS).
                    if (!tabsim.ContainsKey(etiqueta))
                        tabsim.Add(etiqueta, contadorPrograma);
                }
                string valor = context.operdir().GetText();
                if (valor.Contains("H"))
                {
                    string AUX = context.tipodir().GetText();
                    switch (AUX)
                    {
                        case "RESW":
                            contadorPrograma += 3 * Convert.ToInt32(valor, 16);
                            break;
                        case "RESB":
                            contadorPrograma += Convert.ToInt32(valor.TrimEnd('H'), 16);
                            break;
                        case "WORD":
                            contadorPrograma += 3;
                            break;
                    }
                }
                else
                {
                    String dir = context.tipodir().GetText();
                    switch (dir)
                    {
                        case "RESW":
                            contadorPrograma += 3 * Convert.ToInt32(valor);
                            break;
                        case "RESB":
                            contadorPrograma += Convert.ToInt32(valor); ;
                            break;
                        case "WORD":
                            contadorPrograma += 3;
                            break;
                    }
                }
            }
            return contadorPrograma;
        }

        public override int VisitFuncionByte([NotNull] gramticSicEstandarParser.FuncionByteContext context)
        {
            string hexValue = context.constantes().GetText();
            int cont = 0;
            string etiqueta="";
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null&&context.ChildCount!=3)
                etiqueta = context.children[1].GetChild(0).GetText();
            //bool band = false;
            foreach (char C in hexValue)
            {
                if (C=='\'')
                {
                    cont++;
                }

            }
            if (context.etiqueta() != null)
            {
                string etiqueta2 = context.etiqueta().GetText();
                // Se verifica que no exista la etiqueta de lo contrario se genera un error (SIMBOLO DUPLICADOS).
                if (!tabsim.ContainsKey(ET))
                    tabsim.Add(ET, contadorPrograma);
            }
            if (hexValue.Contains('X')&&cont==2&& !ChecaPalabrasReservadas(etiqueta))
            {
                hexValue = hexValue.Remove(0, 1);
                    
                char[] delimiter = { '\'' };
                hexValue = hexValue.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[0];

                if (hexValue.Length % 2 == 0)
                {
                    contadorPrograma += hexValue.Length / 2;
                }
                else
                {
                    contadorPrograma += (hexValue.Length+1) / 2;
                }

            }
            else
            {
                if(hexValue.Contains('C') && cont == 2&&!ChecaPalabrasReservadas(etiqueta))
                {
                    hexValue = hexValue.Remove(0, 1);
                    char[] delimiter = { '\'' };
                    hexValue = hexValue.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)[0];

                    contadorPrograma += hexValue.Length;
                }
            }   
            
            return contadorPrograma;
        }

        private bool ChecaPalabrasReservadas(string palabra)
        {
            string[] palabrasRes = { "RSUB","ADD","AND","COMP","DIV","J",
                    "JEQ","JGT","JLT","JSUB","LDA",
                    "LDCH","LDL","LDX","MUL","OR",
                    "RD","STA","STCH","STL",
                    "STSW","STX","SUB","TD","TIX","WD","BYTE","WORD","RESB","RESW","END","START" };

            foreach(string s in palabrasRes)
            {
                if (palabra == s)
                    return true;
            }
            return false;
        }

        public override int VisitFomratoDosUno([NotNull] gramticSicEstandarParser.FomratoDosUnoContext context)
        {
            string etiqueta1 = "";
            formato4 = true;
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null && context.ChildCount != 3)
                etiqueta1 = context.children[1].GetChild(0).GetText();
            if (!ChecaPalabrasReservadas(etiqueta1))
            {
                if (context.etiqueta() != null)
                {
                    string etiqueta = context.etiqueta().GetText();
                    // Se verifica que no exista la etiqueta de lo contrario se genera un error (SIMBOLO DUPLICADOS).
                    if (!tabsim.ContainsKey(etiqueta))
                        tabsim.Add(etiqueta, contadorPrograma);
                    else
                    {
                        contadorPrograma += 1;
                        throw new Exception("Error: Simbolos Duplicados: ");
                    }
                }
                contadorPrograma++;
            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                tabsim.Add(etiqueta, contadorPrograma);
                contadorPrograma += 1;
            }
            return contadorPrograma;
        }
        public override int VisitFormatoDosDos([NotNull] gramticSicEstandarParser.FormatoDosDosContext context)
        {
            formato4 = true;
            string etiqueta1 = "";
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null && context.ChildCount != 3)
                etiqueta1 = context.children[1].GetChild(0).GetText();
            if (!ChecaPalabrasReservadas(etiqueta1))
            {
                if (context.etiqueta() != null)
                {
                    string etiqueta = context.etiqueta().GetText();
                    // Se verifica que no exista la etiqueta de lo contrario se genera un error (SIMBOLO DUPLICADOS).
                    if (!tabsim.ContainsKey(etiqueta))
                        tabsim.Add(etiqueta, contadorPrograma);
                    else
                    {
                        contadorPrograma += 2;
                        throw new Exception("Error: Simbolos Duplicados: ");
                    }
                }
                contadorPrograma+=2;
            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                tabsim.Add(etiqueta, contadorPrograma);
                contadorPrograma += 2;
            }
            return contadorPrograma;
        }

        public override int VisitFormatoDosN([NotNull] gramticSicEstandarParser.FormatoDosNContext context)
        {
            string etiqueta1 = "";
            formato4 = true;
            string ET = context.children[0].GetText();
            if (context.children[1].GetChild(1) != null && context.ChildCount != 3)
                etiqueta1 = context.children[1].GetChild(0).GetText();
            if (!ChecaPalabrasReservadas(etiqueta1))
            {
                if (context.etiqueta() != null)
                {
                    string etiqueta = context.etiqueta().GetText();
                    // Se verifica que no exista la etiqueta de lo contrario se genera un error (SIMBOLO DUPLICADOS).
                    if (!tabsim.ContainsKey(etiqueta))
                        tabsim.Add(etiqueta, contadorPrograma);
                    else
                    {
                        contadorPrograma += 2;
                        throw new Exception("Error: Simbolos Duplicados: ");
                    }
                }
                contadorPrograma += 2;
            }
            else
            {
                string etiqueta = context.etiqueta().GetText();
                tabsim.Add(etiqueta, contadorPrograma);
                contadorPrograma += 2;
            }
            return contadorPrograma;
        }
    }
}
