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
        public string sRegistroW;
        public string CC;

        public int iRegistroX;
        public int iRegistroM;
        public int iRegistroPC;
        public int iRegistroA;
        public int iRegistroL;
        public int iRegistroW;

        public string sCP;
        public string iCP;

        public string sInicio;
        public int iInicio;
        public string sFin;
        public int iFin;

        public bool banderaInicio;

        private Dictionary<string, List<string>> instrucciones = new Dictionary<string, List<string>>();

        private Dictionary<string, string> codOp = new Dictionary<string, string>()
        {   { "ADD", "18" }, {"AND", "40" }, {"COMP", "28" }, {"DIV", "24" }, {"J", "3C"}, {"JEQ", "30"}, {"JGT", "34"}, {"JLT", "38"}, {"RSUB","4C"},
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
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
            this.dataGridView3.Rows.Clear();
            this.dataGridView3.Refresh();
            this.mapaMemoria();
            sRegistroA = "000000";
            sRegistroM = "000000";
            sRegistroX = "000001";
            sRegistroPC = "0000000";
            sRegistroL = "000002";
            sRegistroW = "000000";
            this.banderaInicio = false;
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

            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            this.iInicio = inicioProgrma;
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            this.iFin = finalProgrma;
            int inicio = inicioProgrma;
            int final = this.RoundUp(finalProgrma);
            string sDirIni = $"{inicio:X}";
            this.sInicio = sDirIni;
            string sDirFin = $"{final:X}";
            this.sFin = sDirFin;
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
                this.dataGridView1.Rows.Add(d.Key, d.Value[0], d.Value[1], d.Value[2], d.Value[3], d.Value[4], d.Value[5], d.Value[6], d.Value[7], d.Value[8], d.Value[9], d.Value[10], d.Value[11], d.Value[12], d.Value[13], d.Value[14], d.Value[15]);
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

        public void ejecutar()
        {

            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int iInstruccion = inicioProgrma;
            int j = inicioProgrma;
            string sIns = "";
            //registro m
            string m = "";
            sRegistroA = "000000";
            sRegistroM = "000000";
            sRegistroX = "000001";
            sRegistroPC = "0000000";
            sRegistroL = "000002";
            sRegistroW = "000000";
            foreach (var ins in this.dMapaMemoria)
            {
                foreach (var value in ins.Value)
                {
                    //j = iInstruccion;
                    if (j == iInstruccion)
                    {
                        sIns = this.regresarInstruccion(value);
                        if (sIns != "ERROR")
                        {
                            //int iPos = ins.Value.IndexOf(value) + 1;
                            m = this.registroM(j);
                            j = this.instruccion(sIns, m, j, value, iInstruccion);

                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error la instruccion no existe");
                            break;
                        }
                    }
                    iInstruccion += 1;
                    //j++;
                }
            }

            this.llenarInstruciones();
            MessageBox.Show("La ejecuacion del programa a finalizado");
        }

        public int ejecutarPasoPaso(int iDir, string sDir)
        {
            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int iInstruccion = inicioProgrma;
            int j = iDir;
            string sIns = "";
            //registro m
            string m = "";
            sRegistroA = "000000";
            sRegistroM = "000000";
            sRegistroX = "000000";
            sRegistroPC = "0000000";
            sRegistroL = "000000";
            sRegistroW = "000000";
            foreach (var ins in this.dMapaMemoria)
            {
                foreach (var value in ins.Value)
                {
                    //j = iInstruccion;
                    if (iDir == iInstruccion)
                    {
                        sIns = this.regresarInstruccion(value);
                        if (sIns != "ERROR")
                        {
                            //int iPos = ins.Value.IndexOf(value) + 1;
                            m = this.registroM(j);
                            j = this.instruccion(sIns, m, j, value, iInstruccion);

                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error la instruccion no existe");
                            break;
                        }
                    }
                    iInstruccion += 1;
                    //j++;
                }
            }

            return j;
        }

        public string registroM(int iM)
        {
            int iInstruccion = 0;
            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int iPosicion = inicioProgrma;
            bool bandera = false;
            string sRegistroM = "";

            foreach (var ins in this.dMapaMemoria)
            {
                foreach (var value in ins.Value)
                {
                    if (iPosicion == iM)
                    {
                        bandera = true;
                    }
                    if (bandera && iPosicion > iM)
                    {
                        sRegistroM = sRegistroM + value;
                        iInstruccion++;
                    }
                    if (iInstruccion == 2)
                    {
                        bandera = false;
                        break;
                    }
                    iPosicion++;

                }
            }
            return sRegistroM;
        }

        private string regresaM(int iM, int registros)
        {
            int iInstruccion = 0;
            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int iPosicion = inicioProgrma;
            bool bandera = false;
            string sRegistroM = "";

            foreach (var ins in this.dMapaMemoria)
            {
                foreach (var value in ins.Value)
                {
                    if (iPosicion == iM)
                    {
                        bandera = true;
                    }
                    if (bandera && iPosicion > iM)
                    {
                        sRegistroM = sRegistroM + value;
                        iInstruccion++;
                    }
                    if (iInstruccion == registros)
                    {
                        bandera = false;
                        break;
                    }
                    iPosicion++;

                }
            }
            return sRegistroM;
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

            private int instruccion(string instruccion, string m, int cp, string sCodigo, int i)
            {
                string bytesInstruccion = "";
                if (instruccion == "ADD")
                {
                    //A <- (A) + (m..m + 2)
                    bytesInstruccion = sCodigo + m;
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    if (sRegM == "")
                        sRegM = "00";
                    int iValorM = Convert.ToInt32(sRegM, 16);

                    int iLimite = 6 - iValorM.ToString().Length;
                   // for(int )

                    iRegistroA = iRegistroA + iValorM;
                    for (int iii = 0; iii < iLimite; iii++)
                        sRegistroA = "0" + sRegistroA;
                    m = $"{iRegistroA:X}";
                
                    this.sRegistroA = $"{iRegistroA:X}";
                    for (int iii = 0; iii < iLimite; iii++)
                        sRegistroA = "0" + sRegistroA;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "ADD m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";

                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "AND")
                {
                    //A <- (A) & (m..m + 2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    if (sRegM == "")
                        sRegM = "00";
                    int iValorM = Convert.ToInt32(sRegM, 16);
                    iRegistroA = iRegistroA & iValorM;
                    m = $"{iRegistroA:X}";
                    bytesInstruccion = sCodigo + m;
                    this.sRegistroA = $"{iRegistroA:X}";
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "AND m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "COMP")
                {
                    //A : (m..m+2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    iRegistroM = Convert.ToInt32(sRegistroM);
                    iRegistroA = Convert.ToInt32(sRegistroA);
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
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "COMP m", "CC <- " + this.CC));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);

                }
                if (instruccion == "DIV")
                {
                    //A <- (A) / (m..m + 2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    if (sRegM == "")
                        sRegM = "00";
                    int iValorM = Convert.ToInt32(sRegM, 16);
                    iRegistroA = iRegistroA / iValorM;
                    m = $"{iRegistroA:X}";
                    bytesInstruccion = sCodigo + m;
                    this.sRegistroA = $"{iRegistroA:X}";
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "DIV m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "J")
                {
                    //CP <- m
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    this.sCP = sRegM;
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "J m", "CP <- " + this.sCP));
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "JEQ")
                {
                    //CP <- m si CC =
                    if (CC == "=")
                    {
                        string sRegM = this.registroM(Convert.ToInt32(m, 16));
                        this.sCP = sRegM;
                        bytesInstruccion = sCodigo + m;
                        this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "JEQ m", "CP <- " + this.sCP));
                        return Convert.ToInt32(sCP, 16);
                    }

                    return i + 3;
                }
                if (instruccion == "JGT")
                {
                    //CP <- m si CC >
                    if (CC == ">")
                    {
                        string sRegM = this.registroM(Convert.ToInt32(m, 16));
                        this.sCP = sRegM;
                        bytesInstruccion = sCodigo + m;
                        this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "JGT m", "CP <- " + this.sCP));
                        return Convert.ToInt32(sCP, 16);
                    }

                    return i + 3;
                }
                if (instruccion == "JLT")
                {
                    //CP <- m si CC >
                    if (CC == "<")
                    {
                        string sRegM = this.registroM(Convert.ToInt32(m, 16));
                        this.sCP = sRegM;
                        bytesInstruccion = sCodigo + m;
                        this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "JLT m", "CP <- " + this.sCP));
                        return Convert.ToInt32(sCP, 16);
                    }

                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "JSUB")
                {
                    //L <- (CP):
                    //CP <- m;
                    this.sRegistroL = this.sCP;
                    this.sCP = m;
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "JSUB m", "L <- " + this.sRegistroL + "; CP <-" + this.sCP));
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "LDA")
                {
                    //A <- (m)...(m+2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    string sRegM = this.regresaM(Convert.ToInt32(m, 16), 3);
                    if (sRegM == "")
                        sRegM = "000000";
                    sRegistroA = sRegM;
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "LDA m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "LDCH")
                {
                    //A <- [Byte mas a la derecha de m]
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    //List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                    sRegistroA = sRegM[0].ToString().Substring(1);
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "LDCH m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "LDL")
                {
                    //L <- (m)...(m+2)
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    sRegistroL = sRegM;
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "LDL m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "LDX")
                {
                    //X <- (m)...(m+2)
                    if (sRegistroX == "")
                        sRegistroX = "000001";
                    string sRegM = this.regresaM(Convert.ToInt32(m, 16), 3);
                    sRegistroX = sRegM;
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "LDX m", "X <- " + this.sRegistroX));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "MUL")
                {
                    //A <- (A) * (m..m + 2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    if (sRegM == "")
                        sRegM = "00";
                    int iValorM = Convert.ToInt32(sRegM, 16);
                    iRegistroA = iRegistroA * iValorM;
                    m = $"{iRegistroA:X}";
                    bytesInstruccion = sCodigo + m;
                    this.sRegistroA = $"{iRegistroA:X}";
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "MUL m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "OR")
                {
                    //A <- (A) | (m..m + 2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    if (sRegM == "")
                        sRegM = "00";
                    int iValorM = Convert.ToInt32(sRegM, 16);
                    iRegistroA = iRegistroA | iValorM;
                    m = $"{iRegistroA:X}";
                    bytesInstruccion = sCodigo + m;
                    this.sRegistroA = $"{iRegistroA:X}";
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "OR m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "RSUB")
                {
                    //PC <- L
                    this.sRegistroPC = sRegistroL;
                    //List<int> valorM = this.valorM(Convert.ToInt32(m, 16));
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "RSUB m", "PC <- " + this.sRegistroPC));
                    //sCP = $"{i + 3:X}";
                    sCP = this.sRegistroPC;
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "STA")
                {
                    //m .. m + 2 <- (A)
                    string srm = this.regresaM(Convert.ToInt32(m, 16), 3);
                    if (sRegistroA == "")
                        sRegistroA = "000000";

                    int iLimite = sRegistroA.Length;
                    for (int yi = 0; yi < 6 - iLimite; yi++)
                        sRegistroA = "0" + sRegistroA;

                    int iRegM = Convert.ToInt32(m, 16);

                    this.modificarM(iRegM, sRegistroA);
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "STA m", "PC <- " + this.sRegistroPC));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "STCH")
                {
                    // m <- a[byte as a la derecha]
                    int iRegM = Convert.ToInt32(m, 16);
                    this.modificarM(iRegM, sRegistroA[sRegistroA.Length - 1].ToString());
                    bytesInstruccion = sCodigo + this.valorM(iRegM);
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "STCH m", "m .. m + 2 <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "STL")
                {
                    //m .. m + 2 <- L
                    int iRegM = Convert.ToInt32(m, 16);
                    this.modificarM(iRegM, sRegistroL);
                    bytesInstruccion = sCodigo + this.valorM(iRegM);
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "STL m", "m .. m + 2 <- " + this.sRegistroL));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "STSW")
                {
                    //m .. m + 2 <- sw
                    int iRegM = Convert.ToInt32(m, 16);
                    this.modificarM(iRegM, sRegistroW);
                    bytesInstruccion = sCodigo + this.valorM(iRegM);
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "STSW m", "m .. m + 2 <- " + this.sRegistroW));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "STX")
                {
                    //m .. m + 2 <- x
                    if (sRegistroX == "")
                        sRegistroX = "000000";
                    int iRegM = Convert.ToInt32(m, 16);
                    this.modificarM(iRegM, sRegistroX);
                    bytesInstruccion = sCodigo + this.valorM(iRegM);
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "STSX m", "m .. m + 2 <- " + this.sRegistroX));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "SUB")
                {
                    //A <- (A) + (m..m + 2)
                    if (sRegistroA == "")
                        sRegistroA = "000000";
                    iRegistroA = Convert.ToInt32(this.sRegistroA, 16);
                    string sRegM = this.registroM(Convert.ToInt32(m, 16));
                    if (sRegM == "")
                        sRegM = "00";
                    int iValorM = Convert.ToInt32(sRegM, 16);
                    iRegistroA = iRegistroA - iValorM;
                    m = $"{iRegistroA:X}";
                    bytesInstruccion = sCodigo + sRegM;
                    this.sRegistroA = $"{iRegistroA:X}";
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "SUB m", "A <- " + this.sRegistroA));
                    sCP = $"{i + 3:X}";

                    return Convert.ToInt32(sCP, 16);
                }
                if (instruccion == "TD")
                {
                    // no se que hace
                }
                if (instruccion == "TIX")
                {
                    //X <- X + 1; (X) : X : M .. M + 2
                    if (sRegistroX == "")
                        sRegistroX = "000000";
                    iRegistroX = Convert.ToInt32(sRegistroX, 16) + 1;
                    string srm = this.regresaM(Convert.ToInt32(m, 16),3);
                    if (srm == "")
                        srm = "00";
                    int im = Convert.ToInt32(srm, 16);
                    if (iRegistroX < im)
                    {
                        this.CC = "<";
                    }
                    if (iRegistroX > im)
                    {
                        this.CC = ">";
                    }
                    if (iRegistroX == im)
                    {
                        this.CC = "=";
                    }
                    bytesInstruccion = sCodigo + m;
                    this.programa.Add(new Ejecucion($"{cp:X}", bytesInstruccion, "TIX m", "X <- X + 2 : " + m));
                    sCP = $"{i + 3:X}";
                    return Convert.ToInt32(sCP, 16);
                }
                return 0;
            }

        private string seisDigitos(string instruccion)
        {
            int limite = 6 - instruccion.Length;
            for (int i = 0; i < limite; i++)
            {
                instruccion = "0" + instruccion;
            }

            return instruccion;
        }

        private void modificarM(int registroM, string sNuevoValor)
        {
            int iInstruccion = 0;
            int inicioProgrma = Convert.ToInt32(this.sTamaInicial, 16);
            int finalProgrma = Convert.ToInt32(this.sTamaFinal, 16);
            int iPosicion = inicioProgrma;
            bool bandera = false;

            sNuevoValor = this.seisDigitos(sNuevoValor);

            string uno = sNuevoValor[0].ToString() + sNuevoValor[1].ToString();
            string dos = sNuevoValor[2].ToString() + sNuevoValor[3].ToString();
            string tres = sNuevoValor[4].ToString() + sNuevoValor[5].ToString();

            List<string> nuevaM = new List<string>();
            nuevaM.Add(uno);
            nuevaM.Add(dos);
            nuevaM.Add(tres);

            foreach (var item in this.dMapaMemoria)
            {
                for (int iC = 0; iC < 16; iC++)
                {
                    if (iPosicion == registroM)
                    {
                        bandera = true;
                    }
                    if (bandera)
                    {
                        item.Value[iC] = nuevaM[iInstruccion];
                        iInstruccion++;
                    }
                    if (iInstruccion == 2)
                    {
                        bandera = false;
                        break;
                    }
                }
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

        private void llenarInstruciones()
        {
            foreach (var c in programa)
            {
                this.dataGridView3.Rows.Add(c.sCp, c.sBytes, c.sInstruccion, c.sEfecto);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.iInicio <= this.iFin - 3)
            {
                //paso a paso
                this.iInicio = this.ejecutarPasoPaso(this.iInicio, this.sInicio);
                this.sInicio = $"{this.iInicio:X}";
                int iTotal = programa.Count() - 1;
                this.dataGridView3.Rows.Add(programa[iTotal].sCp, programa[iTotal].sBytes, programa[iTotal].sInstruccion, programa[iTotal].sEfecto);
            }
            else
            {
                MessageBox.Show("La ejecuacion del programa a finalizado");
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
