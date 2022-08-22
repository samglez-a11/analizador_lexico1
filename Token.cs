using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejem1
{
    class Token
    {
        private String lexema;
        private String idToken;
        private int numToken;
        private int linea;
        private int columna;
        private int indice;
        public Token(String lexema, String idToken,int numToken, int linea, int columna, int indice)
        {

            this.lexema = lexema;
            this.idToken = idToken;
            this.numToken = numToken;
            this.linea = linea;
            this.columna = columna;
            this.indice = indice;
        }

        public int getIndice()
        {
            return this.indice;
        }
        public String getLexema()
        {
            return this.lexema;
        }
        public String getIdToken()
        {
            return this.idToken;
        }
        public int getNumToken()
        {
            return this.numToken;
        }
        public int getLinea()
        {
            return this.linea;
        }
        public int getColumna()
        {
            return this.columna;
        }
    }
}
