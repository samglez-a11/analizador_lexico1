using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace ejem1
{
    class Analizador
    {
        ArrayList tokens;
        static private List<Token> listaTokens;
        private String retorno;
        public Analizador()
        {
            listaTokens = new List<Token>();
            tokens = new ArrayList();

        }

        public void addToken(String lexema, String idToken, int numToken, int linea, int columna, int indice)
        {
            Token nuevo = new Token(lexema, idToken, numToken, linea, columna, indice);
            listaTokens.Add(nuevo);
        }
        public void Analizador_cadena(String entrada)
        {
            int estado = 0;
            int columna = 0;
            int fila = 1;
            string lexema = "";
            Char c;
            entrada = entrada + " ";
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                columna++;
                switch (estado)
                {
                    case 0:
                        if (char.IsWhiteSpace(c))
                        {
                            estado = 0;
                        }
                        else if (char.IsLetter(c) || c == '_')
                        {
                            estado = 1;
                            lexema += c;

                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }
                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "Punto y Coma", 12, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '"')
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (c == ',')
                        {
                            estado = 8;
                            i--;
                            columna--;
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            addToken(lexema, "parentesis izquierdo", 14, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            addToken(lexema, "parentesis derecho", 15, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '{')
                        {
                            lexema += c;
                            addToken(lexema, "llave izquierda", 16, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            addToken(lexema, "llave derecha", 17, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '=')
                        {
                            lexema += c;
                            addToken(lexema, "igual", 18, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "opSuma", 5, fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            addToken(lexema, "opSuma", 5, fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            addToken(lexema, "opMultiplicacion", 6, fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            addToken(lexema, "opMultiplicacion", 6, fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '<')
                        {
                            lexema += c;
                            addToken(lexema, "opRelacional", 17, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "opRelacional", 7, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '|')
                        {
                            estado = 3;
                            lexema += c;
                        }
                        else if (c == '&')
                        {
                            estado = 3;
                            lexema += c;
                        }
                        else if (c == '$')
                        {
                            lexema += c;
                            addToken(lexema, "signo de pesos", 23, fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else
                        {
                            
                            MessageBox.Show("Hay un error lexico con: " + c);
                            estado = 0;
                            i = entrada.Length;
                            
                        }
                        break;
                    case 1:
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;
                        }
                        else
                        {
                            int op = verificarReservada(lexema);
                            if (op != 0)
                            {
                                switch (op)
                                {
                                    case 1:
                                        addToken(lexema, "Reservada while", 20, fila, columna, i - lexema.Length);
                                        break;

                                    case 2:
                                        addToken(lexema, "Reservada if", 19, fila, columna, i - lexema.Length);
                                        break;
                                    case 3:
                                        addToken(lexema, "Reservada return", 21, fila, columna, i - lexema.Length);
                                        break;

                                    case 4:
                                        addToken(lexema, "Reservada else", 22, fila, columna, i - lexema.Length);
                                        break;
                                }
                            }
                            else
                            {
                                Boolean encontrado = false;
                                encontrado = Macht_enReser(lexema);
                                if (encontrado)
                                {
                                    addToken(lexema, "Tipo de dato", 4, fila, columna, i - lexema.Length);
                                }
                                else
                                {
                                    lexema += c;
                                    estado = 9;

                                }
                            }
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;

                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else if (c == '.')
                        {
                            lexema += c;
                            estado = 4;
                        }
                        else
                        {
                            addToken(lexema, "Entero", 1, fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (c == '|')
                        {
                            lexema += c;
                            addToken(lexema, "opLogico", 15, fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '&')
                        {
                            lexema += c;
                            addToken(lexema, "opLogico", 15, fila, columna, i);
                            lexema = "";
                        }
                        break;
                    case 4:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            MessageBox.Show("Hay un error lexico con: " + c + "despues del punto decimal se esperan uno o mas numeros");
                            estado = 0;
                            i = entrada.Length;
                        }
                        break;
                    case 5:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            addToken(lexema, "Real", 2, fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 6:
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 7;
                        }
                        break;
                    case 7:
                        if (c != '"')
                        {
                            lexema += c;
                            estado = 6;
                        }
                        else
                        {
                            estado = 8;
                            i--;
                            columna--;
                        }
                        break;
                    case 8:
                        if(c == '"')
                        {
                            addToken(lexema, "Cadena", 3, fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else
                        {
                            lexema += c;
                            addToken(lexema, "Coma", 13, fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsLetterOrDigit(c))
                        {
                            lexema += c;
                            estado = 9;
                        }
                        else if(c == ' ' || c = '\n')
                        {
                            addToken(lexema, "Id", 0, fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        else 
                        {
                            MessageBox.Show("Hay un error lexico con: " + c);
                            estado = 0;
                            i = entrada.Length;
                        }
                        break;
                    case -99:
                        lexema += c;


                        estado = 0;
                        lexema = "";
                        break;
                }
            }


        }

        public int verificarReservada(String sente)
        {
            int op = 0;
            if(sente == "while")
            {
                op = 1;
            }
            else if(sente == "if")
            {
                op = 2;
            }
            else if(sente == "return")
            {
                op = 3;
            }
            else if (sente == "else")
            {
                op = 4;
            }
            return op;
        }

        public Boolean Macht_enReser(String sente)
        {
            Boolean enco = false;
            if (sente == "int")
            {
                enco = true;
            }
            else if (sente == "float")
            {
                enco = true;
            }
            else if(sente == "void")
            {
                enco = true;
            }
            else
            {
                enco = false;
            }
            
            return enco;
        }
        public void generarLista()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = listaTokens.ElementAt(i); 
                retorno += "Lexema: " + actual.getLexema() + " [*] " + " Token: " + actual.getIdToken() + " [*] " + " NumToken:  " + actual.getNumToken() + Environment.NewLine;
            }
        }
        public String getRetorno()
        {
            return this.retorno;
        }

        public List<Token> getListaTokens()
        {
            return listaTokens;
        }
    }
}
