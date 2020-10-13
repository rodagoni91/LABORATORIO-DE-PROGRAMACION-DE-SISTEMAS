using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ensamblador_SIC
{
    public class Linea
    {
        public string sEtiqueta;
        public string sCodigoOp;
        public string sDireccion;

        public string sDireccionHEXA;


        public Linea(string etiqueta,string codigo, string direccion)
        {
            this.sEtiqueta = etiqueta;
            this.sCodigoOp = codigo;
            this.sDireccion = direccion;
            this.sDireccionHEXA = "000000";
        }

        public Linea(string codigo, string direccion)
        {
            this.sCodigoOp = codigo;
            this.sDireccion = direccion;
        }

        public Linea(string codigo)
        {
            this.sCodigoOp = codigo;
        }
    }
}
