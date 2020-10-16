using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ArchivoIntermedio : Form
    {
       string basePath;
        string ruta="";
        string[] lineas; //Variable donde se guardan las lineas del texto a analizar
        string hexa = ""; //Variable donde se guarda el valor hexadecimal del cp
        int contp = 0; //Cp
        //Variables para TabSim
        List<string> direccion;
        List<string> etiqueta;
        //Variables para el grid de datos 
        List<string> cp;
        List<string> instrucciones;
        List<string> etiquetas;
        List<string> dir;
        List<string> codigoOb;
        //Variables para directivas e instucciones
        List<string> directivas = new List<string>(new[] { "BYTE", "RESW", "RESB","WORD" });
        //Instrucciones de tipo 3 o 4
        List<string> instruc = new List<string>(new[] { "ADD", "AND", "COMP", "DIV", "J", "JEQ", "JGT", "JLT", "JSUB", "LDA", "LDCH", "LDL", "LDX", "MUL", "OR", "RD", "RSUB", "STA", "STCH", "STL", "STSW", "STX", "SUB", "TD", "TIX", "WD", "ADDF", "COMPF", "DIVF", "LDB", "LDF", "LDS", "LDT", "LPS", "MULF", "SSK", "STB", "STF", "STI", "STS", "STT", "SUBF" });
        List<string> codOp = new List<string>(new[] { "18", "40", "28", "24", "3C", "30", "34", "38", "48", "00", "50", "08", "04", "20", "44", "D8", "4C", "0C", "54", "14", "E8", "10", "1C", "E0", "2C", "DC" });
        //Instrucciones tipo 2
        List<string> instruc2 = new List<string>(new[] { "ADDR", "CLEAR", "COMPR", "DIVR", "MULR", "RMO", "SHIFTL", "SHIFTR", "SUBR", "SVC", "TIXR" });
        //Instrucciones tipo 1
        List<string> instruc1 = new List<string>(new[] { "FIX", "FLOAT", "HIO", "NORM", "SIO", "TIO" });
        //Variable para saber en que lineas hay error
        List<int> linError = new List<int>();
        //Variables para calcular tamaño del programa
        int cpinicial = 0;
        int cpFinal = 0;
        public ArchivoIntermedio()
        {
            InitializeComponent();
            direccion = new List<string>(); ;
            etiqueta = new List<string>();
            cp = new List<string>();
            instrucciones = new List<string>();
            etiquetas = new List<string>();
            codigoOb = new List<string>();
            dir= new List<string>();
        }

        public bool checaXE(string input)
        {
            string[] aux;
            lineas = input.Split('\n');//Variable donde se guradan las lineas del texto

            aux = lineas[0].Split('\t');
            if (aux[2].Contains('h') || aux[2].Contains('H'))//Si contiene H se quita la 'H' y se guarda ese numero como cp
            {
                aux[2] = aux[2].Replace("h", "");
                aux[2] = aux[2].Replace("H", "");
                hexa = aux[2];
                contp = int.Parse(aux[2], System.Globalization.NumberStyles.HexNumber);
            }
            else // Si no se convierte a Hexadecimal
            {
                contp = Convert.ToInt32(aux[2]);
                hexa = contp.ToString("X");
            }

            if (contp > 0)
            {
                paso1(input);
                return false;
            }
            else
            {
                paso1XE(input);
                return true;
            }

        }

        private void checaIns(string instruccion)
        {
            if (instruccion.Contains('+'))
            {
                string instruccionAux = instruccion.Replace("+", "");
                if (instruc.Contains(instruccionAux))
                {
                    contp += 4;//Se suma 4 al cp
                    hexa = contp.ToString("X"); //Se convierte a Hexa
                }
            }
            if (instruc.Contains(instruccion))
            {
                contp += 3;//Se suma 3 al cp
                hexa = contp.ToString("X"); //Se convierte a Hexa
            }
            if (instruc2.Contains(instruccion))
            {
                contp += 2;//Se suma 3 al cp
                hexa = contp.ToString("X"); //Se convierte a Hexa
            }
            if (instruc1.Contains(instruccion))
            {
                contp += 2;//Se suma 3 al cp
                hexa = contp.ToString("X"); //Se convierte a Hexa
            }
        }

        private void paso1XE(string input)
        {
            //Se limpian las listas
            limpia();

            //Declaracion de variables auxiliares
            string[] aux;
            string[] aux2;
            lineas = input.Split('\n');//Variable donde se guradan las lineas del texto

            aux = lineas[0].Split('\t');
            if (aux[2].Contains('h') || aux[2].Contains('H'))//Si contiene H se quita la 'H' y se guarda ese numero como cp
            {
                aux[2] = aux[2].Replace("h", "");
                aux[2] = aux[2].Replace("H", "");
                hexa = aux[2];
                contp = int.Parse(aux[2], System.Globalization.NumberStyles.HexNumber);
            }
            else // Si no se convierte a Hexadecimal
            {
                contp = Convert.ToInt32(aux[2]);
                hexa = contp.ToString("X");
            }
            cpinicial = contp;
            aux2 = lineas[0].Split('\t');
            //Se añade la linea de inicio al grid
            etiquetas.Add(aux2[0]);
            instrucciones.Add(aux2[1]);
            dir.Add(aux2[2]);
            cp.Add(hexa);
            codigoOb.Add("");
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = 1;
            dataGridView1.Rows[0].Cells[1].Value = cp[0];
            dataGridView1.Rows[0].Cells[2].Value = etiquetas[0];
            dataGridView1.Rows[0].Cells[3].Value = instrucciones[0];
            dataGridView1.Rows[0].Cells[4].Value = dir[0];
            dataGridView1.Rows[0].Cells[5].Value = codigoOb[0];
            //Se comienza a recorrer las lineas despues del inicio
            //para analizarlas 
            for (int j = 1; j < lineas.Length; j++)
            {
                if (!linError.Contains(j + 1))//Se checa con el archivo de errores para ver si no la linea tiene error
                {
                    aux2 = lineas[j].Split('\t');//Se divide la cadena por tabuladores para obtener cada elemento
                    if (aux2.Length == 3)//Si el arreglo es de tamaño 3 es porque tiene etiqueta
                    {
                        if (etiqueta.Contains(aux2[0])) //Si la etiqueta ya existe se marca el error pero el cp continua
                            codigoOb.Add("Error:Etiqueta Duplicada");
                        else
                        {
                            codigoOb.Add("");
                            //Se checa si la etiqueta no existe ya en TABSIM y que no este vacio el campo
                            if (!etiqueta.Contains(aux2[0]) && aux2[0] != "")
                            {
                                //Se añade la etiqueta y su direccion a TabSim
                                etiqueta.Add(aux2[0]);
                                direccion.Add(hexa);
                            }
                        }
                        //Se añade la etiqueta, instruccion y el cp para el archivo intermedio
                        etiquetas.Add(aux2[0]);
                        instrucciones.Add(aux2[1]);
                        dir.Add(aux2[2]);
                        cp.Add(hexa);
                        //Se revisa si la instruccion no es una directiva
                        if (!directivas.Contains(aux2[1]))
                        {
                            checaIns(aux2[1]);
                        }
                        else
                        { //Si es una directiva se revisa cual es y se hace el calculo
                            contp += CalculaValor(aux2[1], aux2[2]); //Se suam el calculo al cp
                            hexa = contp.ToString("X"); //Se convierte a Hexa
                        }
                    }
                    else
                    {
                        if (aux2.Length == 2) //Si el arreglo es de tamaño 2 no tiene etiqueta
                        {
                            if (aux2[1] != "RSUB" && aux2[0] != "RSUB" && aux2[0] != "END" && aux2[1] != "END")//Se revisa que no sea RSUB
                            { //Se añade lo necesario para el archivo intermedio
                                etiquetas.Add(" ");
                                instrucciones.Add(aux2[0]);
                                dir.Add(aux2[1]);
                                cp.Add(hexa);
                                codigoOb.Add("");
                                //Se revisa si la instruccion no es una directiva
                                if (!directivas.Contains(aux2[0]))
                                {
                                    checaIns(aux2[0]);
                                }
                                else
                                {//Si es una directiva se revisa cual es y se hace el calculo
                                    contp += CalculaValor(aux2[0], aux2[1]);
                                    hexa = contp.ToString("X");
                                }
                            }
                            else
                            {
                                if (aux2[1] == "RSUB" || aux2[0] == "RSUB")
                                {//Caso RSUB que se agrega de igual forma y se suma el CP
                                    etiquetas.Add(" ");
                                    instrucciones.Add("RSUB");
                                    dir.Add(" ");
                                    cp.Add(hexa);
                                    codigoOb.Add("");
                                    contp += 3;
                                    hexa = contp.ToString("X");
                                }
                                if (aux2[1] == "END" || aux2[0] == "END")
                                {//Caso END que se agrega de igual forma y se suma el CP
                                    etiquetas.Add(" ");
                                    instrucciones.Add("END");
                                    dir.Add("");
                                    cp.Add(hexa);
                                    codigoOb.Add("");
                                    contp += 3;
                                    hexa = contp.ToString("X");
                                }
                            }
                        }
                        else
                        { //Caso RSUB que se agrega de igual forma y se suma el CP
                            if (aux2.Length == 1)
                            {
                                if (aux2[0] != "")
                                {
                                    if (aux2[0] == "RSUB")
                                    {
                                        etiquetas.Add(" ");
                                        instrucciones.Add("RSUB");
                                        cp.Add(hexa);
                                        dir.Add("");
                                        codigoOb.Add("");
                                        contp += 3;
                                        hexa = contp.ToString("X");
                                    }
                                    if (aux2[0] == "END")
                                    {//Caso END que se agrega de igual forma y se suma el CP
                                        etiquetas.Add(" ");
                                        instrucciones.Add("END");
                                        dir.Add("");
                                        cp.Add(hexa);
                                        codigoOb.Add("");
                                        //contp += 3;
                                        //hexa = contp.ToString("X");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                { //Si la linea contiene error se hace lo mismo que si no tuviera error
                  //solo que no se incrementa el cp ya que es error de sintaxis
                  //o instruccion no valida
                    aux2 = lineas[j].Split('\t');
                    if (aux2.Length == 3)
                    {
                        etiquetas.Add(aux2[0]);
                        instrucciones.Add(aux2[1]);
                        dir.Add(aux2[2]);
                        cp.Add(hexa);
                        if (!instruc.Contains(aux2[1]) && !directivas.Contains(aux2[1])) //Se revisa que la instruccion sea valida
                            codigoOb.Add("Error:Instrucción no valida");
                        else
                            codigoOb.Add("Error de sintaxis");
                    }
                    else
                    {
                        if (aux2.Length == 2)
                        {
                            if (aux2[1] != "RSUB" && aux2[0] != "RSUB")
                            {
                                etiquetas.Add(" ");
                                instrucciones.Add(aux2[0]);
                                dir.Add(aux2[1]);
                                cp.Add(hexa);
                                if (!instruc.Contains(aux2[0]) && !directivas.Contains(aux2[0]))//Se revisa que la instruccion sea valida
                                    codigoOb.Add("Error:Instrucción no valida");
                                else
                                    codigoOb.Add("Error de sintaxis");

                            }
                            else
                            {
                                etiquetas.Add(" ");
                                instrucciones.Add("RSUB");
                                cp.Add(hexa);
                                dir.Add("");
                                if (aux2[0] != "RSUB")
                                    codigoOb.Add("Error:Instrucción no valida");
                                else
                                    codigoOb.Add("Error de sintaxis");
                            }
                        }
                        else
                        {
                            if (aux2.Length == 1)
                            {
                                if (aux2[0] != "")
                                {
                                    etiquetas.Add(" ");
                                    instrucciones.Add("RSUB");
                                    dir.Add("");
                                    cp.Add(hexa);
                                    codigoOb.Add("Error de sintaxis");
                                }
                            }
                        }
                    }
                }
            }
            cpFinal = int.Parse(cp[cp.Count - 1], System.Globalization.NumberStyles.HexNumber) - cpinicial;
            llenaGrid();
        }

        public void paso1(string input)
        {
            //Se limpian las listas
            limpia();
            
            //Declaracion de variables auxiliares
            string[] aux;
            string[] aux2;
            lineas = input.Split('\n');//Variable donde se guradan las lineas del texto
            
            aux = lineas[0].Split('\t');
            if (aux[2].Contains('h') || aux[2].Contains('H'))//Si contiene H se quita la 'H' y se guarda ese numero como cp
            {
                aux[2] = aux[2].Replace("h", "");
                aux[2] = aux[2].Replace("H", "");
                hexa = aux[2];
                contp = int.Parse(aux[2], System.Globalization.NumberStyles.HexNumber);
            }
            else // Si no se convierte a Hexadecimal
            {
                contp = Convert.ToInt32(aux[2]);
                hexa = contp.ToString("X");
            }
            cpinicial = contp;
            aux2 = lineas[0].Split('\t');
            //Se añade la linea de inicio al grid
            etiquetas.Add(aux2[0]);
            instrucciones.Add(aux2[1]);
            dir.Add(aux2[2]);
            cp.Add(hexa);
            codigoOb.Add("");
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value =  1;
            dataGridView1.Rows[0].Cells[1].Value = cp[0];
            dataGridView1.Rows[0].Cells[2].Value = etiquetas[0];
            dataGridView1.Rows[0].Cells[3].Value = instrucciones[0];
            dataGridView1.Rows[0].Cells[4].Value = dir[0];
            dataGridView1.Rows[0].Cells[5].Value = codigoOb[0];
            //Se comienza a recorrer las lineas despues del inicio
            //para analizarlas 
            for (int j = 1; j < lineas.Length; j++)
            {
                if (!linError.Contains(j + 1))//Se checa con el archivo de errores para ver si no la linea tiene error
                {
                    aux2 = lineas[j].Split('\t');//Se divide la cadena por tabuladores para obtener cada elemento
                    if (aux2.Length == 3)//Si el arreglo es de tamaño 3 es porque tiene etiqueta
                    {
                        if (etiqueta.Contains(aux2[0])) //Si la etiqueta ya existe se marca el error pero el cp continua
                            codigoOb.Add("Error:Etiqueta Duplicada");
                        else
                        {
                            codigoOb.Add("");
                            //Se checa si la etiqueta no existe ya en TABSIM y que no este vacio el campo
                            if (!etiqueta.Contains(aux2[0]) && aux2[0] != "")
                            {
                                //Se añade la etiqueta y su direccion a TabSim
                                etiqueta.Add(aux2[0]);
                                direccion.Add(hexa);
                            }
                        }
                        //Se añade la etiqueta, instruccion y el cp para el archivo intermedio
                        etiquetas.Add(aux2[0]);
                        instrucciones.Add(aux2[1]);
                        dir.Add(aux2[2]);
                        cp.Add(hexa);
                        //Se revisa si la instruccion no es una directiva
                        if (!directivas.Contains(aux2[1]))
                        {
                            contp += 3;//Se suma 3 al cp
                            hexa = contp.ToString("X"); //Se convierte a Hexa
                        }
                        else
                        { //Si es una directiva se revisa cual es y se hace el calculo
                            contp += CalculaValor(aux2[1], aux2[2]); //Se suam el calculo al cp
                            hexa = contp.ToString("X"); //Se convierte a Hexa
                        }
                    }
                    else
                    {
                        if (aux2.Length == 2) //Si el arreglo es de tamaño 2 no tiene etiqueta
                        {
                            if (aux2[1] != "RSUB" && aux2[0] != "RSUB" && aux2[0] != "END" && aux2[1] != "END")//Se revisa que no sea RSUB
                            { //Se añade lo necesario para el archivo intermedio
                                etiquetas.Add(" ");
                                instrucciones.Add(aux2[0]);
                                dir.Add(aux2[1]);
                                cp.Add(hexa);
                                codigoOb.Add("");
                                //Se revisa si la instruccion no es una directiva
                                if (!directivas.Contains(aux2[0]))
                                {
                                    contp += 3;
                                    hexa = contp.ToString("X");
                                }
                                else
                                {//Si es una directiva se revisa cual es y se hace el calculo
                                    contp += CalculaValor(aux2[0], aux2[1]);
                                    hexa = contp.ToString("X");
                                }
                            }
                            else
                            {
                                if (aux2[1] == "RSUB" || aux2[0] == "RSUB")
                                {//Caso RSUB que se agrega de igual forma y se suma el CP
                                    etiquetas.Add(" ");
                                    instrucciones.Add("RSUB");
                                    dir.Add(" ");
                                    cp.Add(hexa);
                                    codigoOb.Add("");
                                    contp += 3;
                                    hexa = contp.ToString("X");
                                }
                                if (aux2[1] == "END" || aux2[0] == "END")
                                {//Caso END que se agrega de igual forma y se suma el CP
                                    etiquetas.Add(" ");
                                    instrucciones.Add("END");
                                    dir.Add("");
                                    cp.Add(hexa);
                                    codigoOb.Add("");
                                    contp += 3;
                                    hexa = contp.ToString("X");
                                }
                            }
                        }
                        else
                        { //Caso RSUB que se agrega de igual forma y se suma el CP
                            if (aux2.Length == 1)
                            {
                                if (aux2[0] != "")
                                {
                                    if (aux2[0] == "RSUB")
                                    {
                                        etiquetas.Add(" ");
                                        instrucciones.Add("RSUB");
                                        cp.Add(hexa);
                                        dir.Add("");
                                        codigoOb.Add("");
                                        contp += 3;
                                        hexa = contp.ToString("X");
                                    }
                                    if (aux2[0] == "END")
                                    {//Caso END que se agrega de igual forma y se suma el CP
                                        etiquetas.Add(" ");
                                        instrucciones.Add("END");
                                        dir.Add("");
                                        cp.Add(hexa);
                                        codigoOb.Add("");
                                        contp += 3;
                                        hexa = contp.ToString("X");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                { //Si la linea contiene error se hace lo mismo que si no tuviera error
                  //solo que no se incrementa el cp ya que es error de sintaxis
                  //o instruccion no valida
                    aux2 = lineas[j].Split('\t');
                    if (aux2.Length == 3)
                    {
                        etiquetas.Add(aux2[0]);
                        instrucciones.Add(aux2[1]);
                        dir.Add(aux2[2]);
                        cp.Add(hexa);
                        if (!instruc.Contains(aux2[1]) && !directivas.Contains(aux2[1])) //Se revisa que la instruccion sea valida
                            codigoOb.Add("Error:Instrucción no valida");
                        else
                            codigoOb.Add("Error de sintaxis");
                    }
                    else
                    {
                        if (aux2.Length == 2)
                        {
                            if (aux2[1] != "RSUB" && aux2[0] != "RSUB")
                            {
                                etiquetas.Add(" ");
                                instrucciones.Add(aux2[0]);
                                dir.Add(aux2[1]);
                                cp.Add(hexa);
                                if (!instruc.Contains(aux2[0]) && !directivas.Contains(aux2[0]))//Se revisa que la instruccion sea valida
                                    codigoOb.Add("Error:Instrucción no valida");
                                else
                                    codigoOb.Add("Error de sintaxis");

                            }
                            else
                            {
                                etiquetas.Add(" ");
                                instrucciones.Add("RSUB");
                                cp.Add(hexa);
                                dir.Add("");
                                if (aux2[0] != "RSUB")
                                    codigoOb.Add("Error:Instrucción no valida");
                                else
                                    codigoOb.Add("Error de sintaxis");
                            }
                        }
                        else
                        {
                            if (aux2.Length == 1)
                            {
                                if (aux2[0] != "")
                                {
                                    etiquetas.Add(" ");
                                    instrucciones.Add("RSUB");
                                    dir.Add("");
                                    cp.Add(hexa);
                                    codigoOb.Add("Error de sintaxis");
                                }
                            }
                        }
                    }
                }
            }
            cpFinal= int.Parse(cp[cp.Count-1], System.Globalization.NumberStyles.HexNumber)-cpinicial;

        }

        public void paso2()
        {
            string codigo; 
            for(int i=1;i<instrucciones.Count-1;i++)
            {
                if (!linError.Contains(i + 1))//Se checa con el archivo de errores para ver si no la linea tiene error
                {
                    codigo = "";
                    //Se checa que no sea ninguna instruccion que no genera codigo obj
                    if (instrucciones[i] != "START" && instrucciones[i] != "END" && instrucciones[i] != "RESB" && instrucciones[i] != "RESW")
                    {
                        //Se checa que no sean los casos especiales 
                        if (instrucciones[i] != "WORD" && instrucciones[i] != "BYTE" && instrucciones[i] != "RSUB")
                        {
                            codigo = codOp[instruc.IndexOf(instrucciones[i])];//Se obtiene el codigo de op
                            if (dir[i] != "" && !dir[i].Contains(","))//Si no es indexado
                            {
                                if (etiqueta.Contains(dir[i]))//Si existe el simbolo
                                {
                                    codigo += direccion[etiqueta.IndexOf(dir[i])].PadLeft(4,'0');
                                    codigoOb[i] = codigo;
                                }
                                else
                                {
                                    codigo += "7FFF";
                                    codigoOb[i] = codigo + "/Error: Simbolo no encontrado";
                                }
                            }
                            else
                            {
                                if (dir[i] != "" && dir[i].Contains(","))//Si es indxado
                                {
                                    string[] aux = dir[i].Split(',');//Se divide por la coma par sacar el simbolo
                                    
                                    if (etiqueta.Contains(aux[0]))//Si existe el simbolo
                                    {
                                        string d=direccion[etiqueta.IndexOf(aux[0])].PadLeft(4,'0');//Se obtiene su direccion
                                        int a = int.Parse(d[0].ToString(), System.Globalization.NumberStyles.HexNumber);//Se convierte a entero el bit mas significativo
                                        a = a + 8;//Se le suma 8
                                        codigo += a.ToString("X") + d[1] + d[2] + d[3];//Se vuelve a juntar toda la cadena
                                        codigoOb[i] = codigo;
                                    }
                                    else
                                    {
                                        codigo += "FFFF";
                                        codigoOb[i] = codigo + "/Error: Simbolo no encontrado";
                                    }
                                }
                            }
                        }
                        else
                        {
                            GeneraCodObj(instrucciones[i], dir[i],i);//Genera cod obj de los casos especiales
                        }
                    }
                }
            }
            llenaGrid(); //Se llena el grid del archivo intermedio
            generaArchivoObj();
        }

        private void GeneraCodObj(string inst, string dir, int ind)
        {
            string codig = "";
            if(inst=="WORD")
            {
                if (dir.Contains('h') || dir.Contains('H'))//Si contiene H se quita la 'H' y se guarda ese numero como cp
                {
                    dir = dir.Replace("h", "");
                    dir = dir.Replace("H", "");
                    codig = dir.PadLeft(6, '0');//Se guarda el valor en 6bits 
                }
                else // Si no se convierte a Hexadecimal
                {
                    int au = Convert.ToInt32(dir);
                    codig = au.ToString("X").PadLeft(6, '0'); //Se guarda el valor en 6bits 
                }
                codigoOb[ind] = codig;
                return;
            }
            if(inst=="RSUB")
            {
                codigoOb[ind] = "4C0000";
                return;
            }
            if(inst == "BYTE")
            {
                char[] aux = dir.ToCharArray();
                if (aux[0] == 'X')//Se revisa si es una X o C
                {
                    //Se quitan la X y las comillas simples
                    dir = dir.Replace("X", "");
                    dir = dir.Replace("'", "");
                    //Se checa que el tamaño sea un numero par de lo contrario se le suma 1
                    if ((dir.Length % 2) == 0)
                        codig = dir;
                    else
                    {
                        codig = "0"+dir;//Si no se le agrega un 0 a la izquierda
                    }
                }
                else
                {//Caso donde es una C
                 //Se quitan la C y las comillas simples
                    dir = dir.Replace("C", "");
                    dir = dir.Replace("'", "");
                    //Se regresa el tamaño tal cual porque son caracteres
                    for (int j=0;j< dir.Length; j++)//Se recorre la cadena
                    {
                        int ascii = char.ConvertToUtf32(dir, j);//Se obtiene el ascci del caracter
                        codig += ascii.ToString("X");//Se convierte a hexa y se agrega al codigo obj
                    }
                    
                }
                codigoOb[ind] = codig;
                return;
            }
        }

        private void generaArchivoObj()
        {
            //Se genera el registro de encabezado
            string archivo = "H";
            if(etiquetas[0].Length>=6)
            {
                archivo+=etiquetas[0].Substring(0, 6);
            }
            else
            {
                for(int a=etiquetas[0].Length;a<6; a++)
                {
                    etiquetas[0] += " ";
                }
                archivo += etiquetas[0];
            }
            archivo += cpinicial.ToString("X").PadLeft(6, '0');
            archivo += cpFinal.ToString("X").PadLeft(6, '0')+"\n";

            int contador = int.Parse(cp[BuscaInstruccion()], System.Globalization.NumberStyles.HexNumber); 
            int tamaño = 0;
            int tamSig = 0;
            string codigoObjeto = "";
            //Se genera registro T
            for (int i = 1; i < instrucciones.Count-1; i++)
            {
                
                if (!linError.Contains(i + 1))//Se checa con el archivo de errores para ver si no la linea tiene error
                {
                    if (instrucciones[i] != "RESB" && instrucciones[i] != "RESW" && instrucciones[i] != "END")
                    {
                        if (tamSig > 60)
                        {
                            tamaño = tamaño / 2;
                            archivo += "T" + contador.ToString("X").PadLeft(6, '0') + tamaño.ToString("X").PadLeft(2, '0') + codigoObjeto + "\n";
                            tamaño = 0;
                            tamSig = 0;
                            codigoObjeto = "";
                            contador = 0;
                        }
                        string[] auxiliar = codigoOb[i].Split('/');
                        codigoObjeto += auxiliar[0];
                        tamaño += auxiliar[0].Length;
                        if (!linError.Contains(i + 2))
                        {
                            auxiliar = codigoOb[i+1].Split('/');
                            tamSig = tamaño + auxiliar[0].Length;
                        }
                        if (contador == 0)
                        {
                            contador = int.Parse(cp[i], System.Globalization.NumberStyles.HexNumber);
                        }
                    }
                    else
                    {
                        if (codigoObjeto != "")
                        {
                            tamaño = tamaño / 2;
                            archivo += "T" + contador.ToString("X").PadLeft(6, '0') + tamaño.ToString("X").PadLeft(2, '0') + codigoObjeto + "\n";
                            tamaño = 0;
                            tamSig = 0;
                            codigoObjeto = "";
                            contador = 0; 
                        }
                    }
                }
            }
            //Si quedo algo se vacia
            if (codigoObjeto != "")
            {
                tamaño = tamaño / 2;
                archivo += "T" + contador.ToString("X").PadLeft(6, '0') + tamaño.ToString("X").PadLeft(2, '0') + codigoObjeto + "\n";
                tamaño = 0;
                tamSig = 0;
                codigoObjeto = "";
                contador = 0;
            }
            //Se genera registro E
            if (dir[dir.Count-1]!="")
            {
                if (etiqueta.Contains(dir[dir.Count - 1]))//Si existe el simbolo
                {
                    archivo += "E"+ direccion[etiqueta.IndexOf(dir[dir.Count - 1])].PadLeft(6, '0');
                }
                else
                {
                    archivo += "E" + "FFFFFF";
                }
            }
            else
            {
                int c = BuscaInstruccion();
                if (c != 0)
                    archivo += "E" + cp[c].PadLeft(6, '0');
            }
            basePath = Environment.CurrentDirectory;
            ruta = @basePath;
            //C:\Users\AGUSTIN\Desktop\UASLP 2020\Laboratorio de Programacion de Sistemas\2019-2020-II\02 Jueves\06 Lopez - Valerio\90\\

            string[] lineas = archivo.Split('\n');
            string auxi = etiquetas[0].Replace(" ", "");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(ruta, auxi+".obj")))
            {
                foreach (string linea in lineas)
                    outputFile.WriteLine(linea);
            }
        }

        public string regresaRuta()
        {
            string auxi = etiquetas[0].Replace(" ", "");
            return Path.Combine(ruta, auxi + ".obj");
        }

        private int BuscaInstruccion()
        {
            int a = 0;
            for (int i = 1; i < instrucciones.Count - 1; i++)
            {

                if (!linError.Contains(i + 1))//Se checa con el archivo de errores para ver si no la linea tiene error
                {
                    if (instrucciones[i] != "RESB" && instrucciones[i] != "RESW" && instrucciones[i] != "WORD" && instrucciones[i] != "BYTE")
                    {
                        return i;
                    }
                }
            }
            return a;

        }
        //Metodo que regresa el tam del programa
        public int regresaTam()
        {
            return cpFinal;
        }

        //Metodo que regresa el inicio del prigrama.
        public int regresaInicio()
        {
            return cpinicial;
        }

        public void limpiaErrores()
        {
            linError.Clear();
        }

        //Metodo que regresa la lista con los simbolos para TabSim
        public List<string> regresaSim()
        {
            return etiqueta;
        }

        //Metodo que regresa la lista con las direcciones para TabSim
        public List<string> regresaDir()
        {
            return direccion;
        }

        //Metodo que llena el grid del archivo intermedio
        private void llenaGrid()
        {
            for (int j = 1; j < cp.Count; j++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[j].Cells[0].Value = j + 1;
                dataGridView1.Rows[j].Cells[1].Value = cp[j];
                dataGridView1.Rows[j].Cells[2].Value = etiquetas[j];
                dataGridView1.Rows[j].Cells[3].Value = instrucciones[j];
                dataGridView1.Rows[j].Cells[4].Value = dir[j];
                dataGridView1.Rows[j].Cells[5].Value = codigoOb[j];

            }

        }

        //Metodo que limpia el grid y las listas
        public void limpia()
        {
            dataGridView1.Rows.Clear();
            cp.Clear();
            instrucciones.Clear();
            etiquetas.Clear();
            etiqueta.Clear();
            direccion.Clear();
            codigoOb.Clear();
            dir.Clear();
        }
    
        //Metodo que calcula el valor que se le sumara al cp
        private int CalculaValor(string a, string b)
        {
            int valor=0;
            if (a=="RESW")
            {//Se revisa si el numero ya esta en Hexa de ser asi se pasa el valor en decimal
             // se pasa a decimal porque asi se maneja el cp 
                if (b.Contains('h') || b.Contains('H'))
                {
                    b = b.Replace("h", "");
                    b = b.Replace("H", "");
                    valor = int.Parse(b, System.Globalization.NumberStyles.HexNumber);
                }
                else
                { //si no se pasa el valor directo
                    valor = Convert.ToInt32(b);                 
                }
                return valor * 3;//Regresa el valor multiplicado por 3 ya que es un RESW
            }
            if (a == "RESB")
            {//Se revisa si el numero ya esta en Hexa de ser asi se pasa el valor en decimal
             // se pasa a decimal porque asi se maneja el cp 
                if (b.Contains('h') || b.Contains('H'))//Si contiene H se quita la 'H' y se guarda ese numero como cp
                {
                    b = b.Replace("h", "");
                    b = b.Replace("H", "");
                    valor = int.Parse(b, System.Globalization.NumberStyles.HexNumber);                    
                }
                else
                {//si no se pasa el valor directo
                    valor = Convert.ToInt32(b);                  
                }
                return valor;// Regresa el valor directo
            }
            if (a == "BYTE")
            {
                char[] aux = b.ToCharArray();
                if (aux[0]=='X')//Se revisa si es una X o C
                {
                    //Se quitan la X y las comillas simples
                    b = b.Replace("X", "");
                    b = b.Replace("'","");
                    //Se checa que el tamaño sea un numero par de lo contrario se le suma 1
                    if ((b.Length % 2) == 0)
                        valor = b.Length/2;
                    else
                    {
                        valor = (b.Length + 1)/2;
                    }                    
                }
                else
                {//Caso donde es una C
                 //Se quitan la C y las comillas simples
                    b = b.Replace("C", "");
                    b = b.Replace("'", "");
                    //Se regresa el tamaño tal cual porque son caracteres
                    valor = b.Length;                   
                }
                return valor;
            }
            if (a == "WORD")
                return 3;
            return valor;

        }

        //Metodo que lee los errores del archivo para saber en que linea son
        public void leeErrores(string path)
        {
            string aux;
            if (path!="nada")//Si el archivo contiene errores
            {
                using (StreamReader sr = new StreamReader(path))//Se lee todo el archivo y se guarda en un string
                {
                    aux = sr.ReadToEnd();
                    sr.Close();
                }
                string[] lin = aux.Split('\n');//Se separa por saltos de linea
                string var;
                char[] aux2;
                for (int i = 0; i < lin.Length; i++)//Se recorre el arreglo
                {
                    aux2 = lin[i].ToCharArray();
                    var = "";
                    for (int j = 0; j < aux2.Length; j++)//Se recorre por caracter
                    {
                        if (char.IsNumber(aux2[j]))//Si es un numero lo guarda
                            var += aux2[j].ToString();
                        if (aux2[j] == ':')//Si se encuentra el simbolo ":" ahi acaba el numero entonce sigue a la sig linea
                        {
                            j = aux2.Length;
                            if(var != "")
                                if (!linError.Contains(Convert.ToInt32(var)))//Si no existe en la lista se agrega
                                    linError.Add(Convert.ToInt32(var));
                        }
                    }

                }
            }
        }
        
    }
}
