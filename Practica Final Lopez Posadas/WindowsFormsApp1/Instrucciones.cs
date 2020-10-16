using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Instrucciones
    {
        public List<Memoria> m = new List<Memoria>();//mapa de memoria

        public Instrucciones(List<Memoria> m)
        {
            this.m = m;
        }

        public int buscaindice(int dir)
        {
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].dir == dir)
                    return i;
            }
            return -1;
        }

        public int mm1m2(int dir_m)
        {
            int idx = buscaindice(dir_m);
            string res = m[idx].valor.ToString() + m[idx + 1].valor.ToString() + m[idx + 2].valor.ToString();
            return Convert.ToInt32(res);
        }

        public int parentesis(int x)
        {
            int n_x = 0; //Valor que se encuentra en la direccion especificada
            n_x = mm1m2(x);
            return n_x;
        }

        #region Instrucciones 

        //ADD m    |    A ← (A) + (m..m+2) 
        public int add(int dir_m, int p_a)
        {
            int a = 0;
            a = parentesis(p_a) + mm1m2(dir_m); 
            return a;
        }

        //AND m    |    A ← (A) & (m..m+2) 
        public int and(int dir_m, int a)
        {
            int n_a = 0;
            n_a = parentesis(a) & mm1m2(dir_m);
            return n_a;
        }
        
        /*COMP m    |   28
         * 
         * (A) : (m..m+2) Compara el valor del registro A 
         * con una palabra en memoria y establece el código 
         * de condición (bandera CC) para indicar 
         * el resultado (<, = ó >) 
         */
        public char comp(int dir_m, int a)
        {
            char cc = ' ';

            if (parentesis(a) < mm1m2(dir_m))
                return '<';
            else if (parentesis(a) > mm1m2(dir_m))
                return '>';
            else if (parentesis(a) == mm1m2(dir_m))
                return '=';

            return cc;
        }

        //DIV m     |   24   |    A ← (A) / (m..m+2) 
        public int div(int dir_m, int p_a)
        {
            int a = p_a / mm1m2(dir_m);
            return a;
        }

        //J m   |   3C  |    CP ← m 
        public int j(int m)
        {
            int cp = m;
            return cp;
        }

        //JEQ m  |   30    |    CP ← m si CC está en = 
        public int jeq(int m, char cc)
        {
            int cp = -1; //Si cc no es '=' entonces regresa -1.
            //En la clase donde se llame este metodo revisamos.
            if (cc == '=')
                cp = m;
            
            return cp;
        }

        //JGT m     |   34  |    CP ← m si CC está en > 
        public int jgt(int m, char cc)
        {
            int cp = -1; //Si cc no es '=' entonces regresa -1.
            //En la clase donde se llame este metodo revisamos.
            if (cc == '>')
                cp = m;

            return cp;
        }

        //JLT m     |   34  |    CP ← m si CC está en <
        public int jlt(int m, char cc)
        {
            int cp = -1; //Si cc no es '=' entonces regresa -1.
            //En la clase donde se llame este metodo revisamos.
            if (cc == '<')
                cp = m;

            return cp;
        }

        //JSUB m  |     48  |   L ← (CP); CP ← m
        public Tuple<int, int> jsub(int m, int cp)
        {
            int L = 0;
            int n_cp = 0;
            L = parentesis(cp);
            n_cp = m;
            return Tuple.Create(L, n_cp);
        }

        //-------------------------------------------------------------------------------------------
        //public void ejemplo()//ejemplo para usar Tuple para los metodos que regresan dos valores.
        //{
        //    int x, y;
        //    x = jsub(1, 2).Item1;
        //    y = jsub(1, 2).Item2;
        //}
        //--------------------------------------------------------------------------------------------

        //LDA m     |   00  |   A ← (m..m+2) 
        public int lda(int m)
        {
            int a = 0;
            a = mm1m2(m);
            return a;
        }

        //LDCH m    |   50  |   A [el byte de más a la derecha] ← (m) 
        public int ldch(int a, int m)
        {
            int n_a = 0;
            n_a = a;
            char[] c_a = a.ToString().ToCharArray();
            string c_m = parentesis(m).ToString();
            c_a[c_a.Length - 1] = c_m[0];
            c_a[c_a.Length] = c_m[1];
            n_a = Convert.ToInt32(new string(c_a));
            return n_a;
        }

        //LDL m   |      08     |    L ← (m..m+2) 
        public int ldl(int m)
        {
            int L = 0;
            L = mm1m2(m);
            return L;
        }

        //LDX m     |    04     |   X ← (m..m+2)
        public int ldx(int m)
        {
            int x = 0;
            x = mm1m2(m);
            return x;
        }

        //MUL m     |    20     |   A ← (A) * (m..m+2) 
        public int mul(int A, int m)
        {
            int n_a = 0;
            n_a = parentesis(A) * mm1m2(m);
            return n_a;
        }

        //OR m      |    44     |  A ← (A) | (m..m+2) 
        public int or(int a, int m)
        {
            int n_a = 0;
            n_a = parentesis(a) | mm1m2(m);
            return n_a;
        }

        //RD m      |   D8      |  A[el byte de más a la derecha] ← datos del dispositivo especificado por(m)
        public int rd(int a, int m)
        {
            int n_a = 0;
            n_a = a;
            char[] c_a = a.ToString().ToCharArray();
            string c_m = parentesis(m).ToString();
            c_a[c_a.Length - 1] = c_m[0];
            c_a[c_a.Length] = c_m[1];
            n_a = Convert.ToInt32(new string(c_a));
            return n_a;
        }

        //RSUB  |   4C      |   PC ← (L) 
        public int rsub(int L)
        {
            int cp = 0;
            cp = parentesis(L); 
            return cp;
        }

        //STA m     |   0C  |   m..m+2 ← (A) 
        public int sta(int A)
        {
            int m = 0;
            m = parentesis(A);
            return m;
        }

        //STCH m    |    54     |   m ← (A) [el byte más a la derecha]
        public int stch(int A)
        {
            int m = 0;
            char[] c_a = parentesis(A).ToString().ToCharArray();
            string s_m = c_a[c_a.Length - 1].ToString() + c_a[c_a.Length].ToString();
            m = Convert.ToInt32(s_m);
            return m;
        }

        //STL m     |   14     |     m..m+2 ← (L) 
        public int stl(int L)
        {
            int m = 0;
            m = parentesis(L);
            return m;
        }

        //STSW m    |   E8      |     m..m+2 ← (SW) 
        public int stsw(int SW)
        {
            int m = 0;
            m = parentesis(SW);
            return m;
        }

        //STX m     |   10      |   m..m+2 ← (X) 
        public int stx(int X)
        {
            int m = 0;
            m = parentesis(X);
            return m;
        }

        //SUB m     |   1C      |   A ← (A) – (m..m+2) 
        public int sub(int A, int m)
        {
            int n_a = 0;
            n_a = parentesis(A) - mm1m2(m);
            return n_a;
        }

        /*
         * TD m     |   E0 
         * 
         * Prueba el dispositivo especificado por (m). 
         * Modifica el código de condición para indicar ç
         * el resultado de la prueba. 
         * < significa que está listo para enviar o recibir, 
         * = significa que está ocupado; 
         * > significa que no está operativ0
         */
        public void td() 
        {

        }

        /*
         * TIX m    |    2C 
         * 
         * X ← (X) + 1; (X) : (m..m+2) 
         * Incrementa el valor de X en 1 y lo compara 
         * con una palabra en memoria y establece el 
         * código de condición para indicar el resultado 
         * (<, = o >) 
         */
        public Tuple<int, char> tix(int X, int m)
        {

            int n_x = 0;
            n_x = parentesis(X) + 1;
            char cc = ' ';

            if (parentesis(X) < mm1m2(m))
                cc = '<';
            else if (parentesis(X) > mm1m2(m))
                cc = '>';
            else if (parentesis(X) == mm1m2(m))
                cc = '=';

            return Tuple.Create(n_x, cc);
        }

        //WD m      |       DC      |       Dispositivo especificado por (m) ← (A)[el byte de más a la derecha] 
        public void wd()
        {

        }
        #endregion
    }
}
