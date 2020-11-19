using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensamblador_SIC
{
    public class Ejecucion
    {
        string sCp;
        string sBytes;
        string sInstruccion;
        string sEfecto;

        public Ejecucion(string scp, string sbytes, string sinstruccion, string sefecto)
        {
            this.sCp = scp;
            this.sBytes = sbytes;
            this.sInstruccion = sinstruccion;
            this.sEfecto = sefecto;
        }
    }
}
