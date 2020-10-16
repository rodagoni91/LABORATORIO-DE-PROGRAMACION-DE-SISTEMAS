using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Memoria
    {
        public int dir = 0;
        public string valor = "";

        public Memoria(int dir, string valor)
        {
            this.dir = dir;
            this.valor = valor;
        }
    }
}
