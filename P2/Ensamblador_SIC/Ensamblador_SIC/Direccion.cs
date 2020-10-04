using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensamblador_SIC
{
    public class Direccion
    {
        public string sPalabra;
        public string sDireccionHexadecimal;
        public string sEtiqueta;
        public int iNumeroDecimal;
        public char cRegistro;
        public int iLenea;
  

        public Direccion(string direccion)
        {
            this.sDireccionHexadecimal = direccion;
            this.iNumeroDecimal = Int32.Parse(direccion.Substring(0, direccion.Length - 1));
            this.iLenea = 1;
        }

        //Contructor Palabra
        public Direccion(char registro, string palabra, int linea)
        {
            this.cRegistro = registro;
            this.sPalabra = palabra;
            this.iLenea = linea + 1;
        }

        //Contructor direccion hex
        public Direccion(string hexadecimal, int linea)
        {
            this.sDireccionHexadecimal = hexadecimal;
            //this.iNumeroDecimal = int.Parse(this.sDireccionHexadecimal, System.Globalization.NumberStyles.HexNumber);
            this.iNumeroDecimal = Convert.ToInt32(hexadecimal.ToString(), 16);
            this.iLenea = linea + 1;
        }


        //Contructor registro
        public Direccion(string etiqueta, char registro, int linea)
        {
            this.sEtiqueta = etiqueta;
            if(registro != 'Z')
                this.cRegistro = registro;
            this.iLenea = linea + 1;
        }


        //Contructor decimal
        public Direccion(int direccion, int linea)
        {
            this.iNumeroDecimal = direccion;
            this.iLenea = linea + 1;
        }


    }
}
