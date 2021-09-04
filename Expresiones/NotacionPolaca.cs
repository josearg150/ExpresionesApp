using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expresiones
{
    class Not_Polaca
    {
        public enum Simbolo { SUMRES, MULTDIV, POW, PIZQ, PDER, OPERANDO };
        public StringBuilder convertirPostFija(string expInfija)
        {
            //Validar el espacio requerido, la exp posfija no requiere de parentesis
            char[] Epos = new char[expInfija.Length];
            Stack<int> pila = new Stack<int>(expInfija.Length);
            //EL tamaño debera ser solo del numero de operadores en la expresion
            //Mas los parentesis izquierdos
            //Validar o analizar la entrada para obtener dicho valor

            int i, pos = 0;
            for (i = 0; i < expInfija.Length; i++)
            {
                char car = expInfija[i];
                Simbolo actual = tipo_y_predencia(car);
                switch (actual)
                {
                    case Simbolo.OPERANDO: Epos[pos++] = car; break;
                    case Simbolo.SUMRES:
                    case Simbolo.MULTDIV:
                    case Simbolo.POW:
                        {
                            while (!(pila.Count == 0) && tipo_y_predencia((char)pila.ElementAt(pila.Count - 1)) >= actual)
                                Epos[pos++] = (char)pila.Pop();
                            pila.Push(car);
                        }
                        break;
                    case Simbolo.PIZQ: pila.Push(car); break;
                    case Simbolo.PDER:
                        {
                            char x = (char)pila.Pop();
                            while (tipo_y_predencia(x) != Simbolo.PIZQ)
                            {
                                Epos[pos++] = x;
                                x = (char)pila.Pop();
                            }

                        }
                        break;

                }

            }
            while (!(pila.Count == 0))
            {
                if (pos < expInfija.Length)
                    Epos[pos++] = (char)pila.Pop();
                else
                    break;
            }
            StringBuilder regresa = new StringBuilder(expInfija);

            for (int r = 0; r < Epos.Length; r++)
                regresa[r] = Epos[r];
            return regresa;
            //Epos[pos] = '\0';
            //return Epos;
        }
        public Simbolo tipo_y_predencia(char c)
        {
            Simbolo simbolo;
            switch (c)
            {
                case '+': case '-': simbolo = Simbolo.SUMRES; break;
                case '*': case '/': simbolo = Simbolo.MULTDIV; break;
                case '^': simbolo = Simbolo.POW; break;
                case '(': simbolo = Simbolo.PIZQ; break;
                case ')': simbolo = Simbolo.PDER; break;
                default: simbolo = Simbolo.OPERANDO; break;

            }
            return simbolo;
        }
    }
}