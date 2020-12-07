using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensamblador_SIC
{
    public class Ejecucion
    {
        public string sCp;
        public string sBytes;
        public string sInstruccion;
        public string sEfecto;

        public Ejecucion(string scp, string sbytes, string sinstruccion, string sefecto)
        {
            this.sCp = scp;
            this.sBytes = sbytes;
            this.sInstruccion = sinstruccion;
            this.sEfecto = sefecto;
        }
    }
}
