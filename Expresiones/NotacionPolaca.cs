using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expresiones
{
    class Not_Polaca
    {
        public enum Simbolo { OPERANDO, PIZQ, PDER, SUMARES, MULTDIV, POW };
        public StringBuilder convertir_pos(string Ei)
        {
            char[] Epos = new char[Ei.Length];
            int tam = Ei.Length;
            Stack<int> Pila = new Stack<int>(tam);

            int i, pos = 0;
            for (i = 0; i < Epos.Length; i++)
            {
                char car = Ei[i];
                Simbolo actual = Tipo_y_Presendecia(car);
                switch (actual)
                {
                    case Simbolo.OPERANDO: Epos[pos++] = car; break;
                    case Simbolo.SUMARES:
                        {
                            while (!(Pila.Count == 0) && Tipo_y_Presendecia((char)Pila.ElementAt(Pila.Count - 1)) >= actual)
                            {
                                Epos[pos++] = (char)Pila.Pop();
                            }
                            Pila.Push(car);
                        }
                        break;
                    case Simbolo.MULTDIV:
                        {
                            while (!(Pila.Count == 0) && Tipo_y_Presendecia((char)Pila.ElementAt(Pila.Count - 1)) >= actual)
                            {
                                Epos[pos++] = (char)Pila.Pop();
                            }
                            Pila.Push(car);
                        }
                        break;
                    case Simbolo.POW:
                        {
                            while (!(Pila.Count == 0) && Tipo_y_Presendecia((char)Pila.ElementAt(Pila.Count - 1)) >= actual)
                            {
                                Epos[pos++] = (char)Pila.Pop();
                            }
                            Pila.Push(car);
                        }
                        break;
                    case Simbolo.PIZQ: Pila.Push(car); break;
                    case Simbolo.PDER:
                        {
                            char x = (char)Pila.Pop();
                            while (Tipo_y_Presendecia(x) != Simbolo.PIZQ)
                            {
                                Epos[pos++] = x;
                                x = (char)Pila.Pop();
                            }
                        }
                        break;
                }
            }
            while (!(Pila.Count == 0))
            {
                if (pos < Epos.Length)
                    Epos[pos++] = (char)Pila.Pop();
                else
                    break;
            }
            StringBuilder regresa = new StringBuilder(Ei);

            for (int r = 0; r < Epos.Length; r++)
                regresa[r] = Epos[r];
            return regresa;
        }
        public Simbolo Tipo_y_Presendecia(char s)
        {
            Simbolo simbolo;
            switch (s)
            {
                case '+': simbolo = Simbolo.SUMARES; break;
                case '-': simbolo = Simbolo.SUMARES; break;
                case '*': simbolo = Simbolo.MULTDIV; break;
                case '/': simbolo = Simbolo.MULTDIV; break;
                case '(': simbolo = Simbolo.PIZQ; break;
                case ')': simbolo = Simbolo.PDER; break;
                case '^': simbolo = Simbolo.POW; break;
                default: simbolo = Simbolo.OPERANDO; break;
            }
            return simbolo;
        }
    }
}