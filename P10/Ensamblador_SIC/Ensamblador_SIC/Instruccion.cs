using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensamblador_SIC
{
    public class Instruccion
    {
        public string nInstruccion;
        public int iNoLinea;

        public Instruccion(string instruccion, int linea)
        {
            this.nInstruccion = instruccion;
            this.iNoLinea = linea;
        }

    }
}
