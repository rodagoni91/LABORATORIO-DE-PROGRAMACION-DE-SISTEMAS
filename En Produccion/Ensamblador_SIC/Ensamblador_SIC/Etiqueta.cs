using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensamblador_SIC
{
    public class Etiqueta
    {
        public string nEtiqueta;
        public int iNoLinea;

        public Etiqueta(string etiqueta, int linea)
        {
            this.nEtiqueta = etiqueta;
            this.iNoLinea = linea;
        }
    }
}
