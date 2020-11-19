using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ensamblador_SIC
{
    public partial class Form2 : Form
    {
        private List<Ejecucion> programa;

        public string sTamaInicial;
        public string sTamaFinal;
        public Dictionary<string, List<string>> dMapaMemoria;
        public List<string> lRegistros;

        public string sRegistroX;
        public string sRegistroM;
        public string sRegistroPC;
        public string sRegistroA;
        public string sRegistroL;
        public string CC;

        public int iRegistroX;
        public int iRegistroM;
        public int iRegistroPC;
        public int iRegistroA;
        public int iRegistroL;

        public string sCP;
        public string iCP;

        private Dictionary<string, List<string>> instrucciones = new Dictionary<string, List<string>>();

        private Dictionary<string, string> codOp = new Dictionary<string, string>()
        {   { "ADD", "18" }, {"AND", "40" }, {"COMP", "28" }, {"DIV", "24" }, {"J", "3C"}, {"JEQ", "30"}, {"JGT", "34"}, {"JLT", "38"},
            {"JSUB", "48"}, {"LDA", "00"}, {"LDCH", "50"}, {"LDL", "08"}, {"LDX", "04"}, {"MUL", "20"}, {"OR", "44"}, {"RD", "D8"},
            { "STA", "0C"}, {"STCH", "54"}, {"STL", "14"}, {"STSW", "E8"}, {"STX", "10"}, {"SUB", "1C"}, {"TD", "E0"}, { "TIX", "2C"},
            { "WD", "DC"}
        };

        public Form2()
        {
            InitializeComponent();
            this.sTamaInicial = "";
            this.sTamaFinal = "";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.mapaMemoria();
            sRegistroA = "000000";
            sRegistroM = "000000";
            sRegistroX = "000000";
            sRegistroPC = "0000000";
            sRegistroL = "000000";
            programa = new List<Ejecucion>();
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

        private void mapaMemoria()
        {
            this.dataGridView1.Rows.Clear();
            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int inicio = inicioProgrma;
            int final = this.RoundUp(finalProgrma);
            string sDirIni = $"{inicio:X}";
            string sDirFin = $"{final:X}";
            string direccion = "";
            string dirInicio = "";
            List<string> lAux = new List<string>();


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
                this.dataGridView1.Rows.Add(sHeader[j], d.Value[0], d.Value[1], d.Value[2], d.Value[3], d.Value[4], d.Value[5], d.Value[6], d.Value[7], d.Value[7], d.Value[8], d.Value[9], d.Value[10], d.Value[11], d.Value[12], d.Value[13], d.Value[14], d.Value[15]);
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

            return lista;
        }

        public void ejecutar()
        {
            int iInstruccion = 0;
            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);

            for (int i = inicioProgrma; i < finalProgrma; i += 3)
            {
                //iInstruccion = this.regresarInstruccion()
                int j = 0;
                string sIns = "";
                string m = "";
                foreach (var ins in this.dMapaMemoria)
                {
                    foreach (var value in ins.Value)
                    {
                        if (j == i)
                        {
                            sIns = this.regresarInstruccion(value);
                            if (sIns != "ERROR")
                            {
                                int iPos = ins.Value.IndexOf(value) + 1;
                                m = ins.Value[iPos] + ins.Value[iPos + 1];
                                this.instruccion(sIns, m, sCP, value, i);
                            }
                            else
                            {
                                MessageBox.Show("Ocurrio un error la instruccion no existe");
                                break;
                            }
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.ejecutar();
        }

        private string regresarInstruccion(string codOp)
        {
            string resultado = "ERROR";

            foreach (var c in this.codOp)
            {
                if (c.Value == codOp)
                {
                    return c.Key;
                }
            }


            return resultado;
        }

        private void instruccion(string instruccion, string m, string cp, string sCodigo, int i)
        {
            string bytesInstruccion = "";
            if (instruccion == "ADD")
            {
                //A <- (A) + (m..m + 2)
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                int iValorM = Convert.ToInt32(valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString(), 16);
                iRegistroA = iRegistroA + iValorM;
                bytesInstruccion = sCodigo + m;
                this.sRegistroA = $"{iRegistroA:X}";
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "ADD m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "AND")
            {
                //A <- (A) & (m..m + 2)
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                int iValorM = Convert.ToInt32(valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString(), 16);
                iRegistroA = iRegistroA & iValorM;
                bytesInstruccion = sCodigo + m;
                this.sRegistroA = $"{iRegistroA:X}";
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "AND m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "COMP")
            {
                //A : (m..m+2)
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                sRegistroM = valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString();
                iRegistroM = Convert.ToInt32(sRegistroM);
                if (iRegistroM > iRegistroA)
                {
                    this.CC = ">";
                }
                else if (iRegistroM < iRegistroA)
                {
                    this.CC = "<";
                }
                else
                {
                    this.CC = "=";
                }
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "COMP m", "CC <- " + this.CC));
                sCP = $"{i + 3:X}";

            }
            if (instruccion == "DIV")
            {
                //A <- (A) / (m..m + 2)
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                int iValorM = Convert.ToInt32(valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString(), 16);
                iRegistroA = iRegistroA / iValorM;
                bytesInstruccion = sCodigo + m;
                this.sRegistroA = $"{iRegistroA:X}";
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "DIV m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "J")
            {
                //CP <- m
                this.sCP = m;
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(this.sCP, bytesInstruccion, "CP m", "CP <- " + this.sCP));
            }
            if (instruccion == "JEQ")
            {
                //CP <- m si CC =
                if (CC == "=")
                {
                    this.sCP = m;
                    List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion(this.sCP, bytesInstruccion, "JEQ m", "CP <- " + this.sCP));
                }
            }
            if (instruccion == "JGT")
            {
                //CP <- m si CC >
                if (CC == ">")
                {
                    this.sCP = m;
                    List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion(this.sCP, bytesInstruccion, "JGT m", "CP <- " + this.sCP));
                }
            }
            if (instruccion == "JLT")
            {
                //CP <- m si CC >
                if (CC == "<")
                {
                    this.sCP = m;
                    List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion(this.sCP, bytesInstruccion, "JLT m", "CP <- " + this.sCP));
                }
            }
            if (instruccion == "JSUB")
            {
                //L <- (CP):
                //CP <- m;
                this.sRegistroL = this.sCP;
                this.sCP = m;
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(this.sCP, bytesInstruccion, "JSUB m", "L <- " + this.sRegistroL + "; CP <-" + this.sCP));
            }
            if (instruccion == "LDA")
            {
                //A <- (m)...(m+2)
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                sRegistroA = valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString();
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "LDA m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "LDCH")
            {
                //A <- [Byte mas a la derecha de m]
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                sRegistroA = valorM[0].ToString().Substring(1);
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "LDCH m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "LDL")
            {
                //L <- (m)...(m+2)
                iRegistroL = Convert.ToInt32(this.sRegistroL, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                sRegistroL = valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString();
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "LDL m", "L <- " + this.sRegistroL));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "LDX")
            {
                //X <- (m)...(m+2)
                iRegistroX = Convert.ToInt32(this.sRegistroX, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                sRegistroX = valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString();
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "LDX m", "L <- " + this.sRegistroX));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "MUL")
            {
                //A <- (A) * (m..m + 2)
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                int iValorM = Convert.ToInt32(valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString(), 16);
                iRegistroA = iRegistroA * iValorM;
                bytesInstruccion = sCodigo + m;
                this.sRegistroA = $"{iRegistroA:X}";
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "MUL m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "OR")
            {
                //A <- (A) | (m..m + 2)
                iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                int iValorM = Convert.ToInt32(valorM[0].ToString() + valorM[1].ToString() + valorM[2].ToString(), 16);
                iRegistroA = iRegistroA | iValorM;
                bytesInstruccion = sCodigo + m;
                this.sRegistroA = $"{iRegistroA:X}";
                this.programa.Add(new Ejecucion(cp, bytesInstruccion, "OR m", "A <- " + this.sRegistroA));
                sCP = $"{i + 3:X}";
            }
            if (instruccion == "RSUB")
            {
                //PC <- L
                this.sRegistroPC = sRegistroL;
                List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                bytesInstruccion = sCodigo + m;
                this.programa.Add(new Ejecucion(this.sCP, bytesInstruccion, "PC m", "PC <- " + this.sRegistroPC));
                sCP = $"{i + 3:X}";
            }
        }

        private List<int> valorM(int m)
        {
            int iCount = 0;
            foreach (var k in this.dMapaMemoria)
            {
                foreach (var v in k.Value)
                {
                    if (iCount == m)
                    {
                        int iM = Convert.ToInt32(v);
                        int iPos = k.Value.IndexOf(v);
                        int iM1 = Convert.ToInt32(k.Value[iPos + 1]);
                        int iM2 = Convert.ToInt32(k.Value[iPos + 2]);
                        return new List<int>() { iM, iM1, iM2 };
                        //return new List<int>() { };
                    }
                    else
                    {
                        iCount++;
                    }
                }
            }

            return null;
        }

    }
}
