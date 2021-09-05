using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfijoPosfijo
{
    /// <summary>
    ///     Clase molde que representa a cada operador en una expresión.
    /// </summary>
    /// <Para>
    ///     Crear operadores, con su respectivo tipo, precedencia, y asociatividad, para su uso en el algoritmo
    ///     Shunting Yard.
    /// </Para>
    /// <Supuestos>
    ///     Ninguno.
    /// </Supuestos>
    /// <Autor>
    ///     José Luis Carreón Reyes
    ///     José Ángel Rocha García
    /// </Autor>
    /// <FechaCreacion>
    ///     30/08/2021
    /// </FechaCreacion>
    class Operador
    {
        //****************************************************************************************
        // VARIABLES
        //****************************************************************************************
        #region Variables
        public string CodigoOperador { get; set; }
        public int Asociatividad { get; set; }
        public int Precedencia { get; set; }
        #endregion Variables
    }

    /// <summary>
    ///     Implementación del algoritmo Shunting Yard.
    /// </summary>
    /// <Para>
    ///     Convertir expresiones infijas a posfijas (notación polaca revertida) con el algoritmo Shunting Yard.
    /// </Para>
    /// <Supuestos>
    ///     La expresión a evaluar es una cadena con espacios entre cada término.
    /// </Supuestos>
    /// <Autor>
    ///     José Luis Carreón Reyes
    ///     José Ángel Rocha García
    /// </Autor>
    /// <FechaCreacion>
    ///     30/08/2021
    /// </FechaCreacion>
    class ShuntingYard
    {
        //****************************************************************************************
        // VARIABLES
        //****************************************************************************************
        #region Variables
        const int IzquierdaAsociatividad = 0;
        const int DerechaAsociatividad = 1;
        static Dictionary<string, Operador> Operadores = new Dictionary<string, Operador>();
        #endregion Variables

        //****************************************************************************************
        // MÉTODOS
        //****************************************************************************************
        #region Metodos
        /// <summary>
        ///     Inicializa los operadores permitidos con su precedencia y
        ///     asociatividad correspondiente.
        /// </summary>
        public static void InicializarOperadores()
        {
            Operadores.Add("^", new Operador { CodigoOperador = "^", Asociatividad = DerechaAsociatividad, Precedencia = 2 });
            Operadores.Add("√", new Operador { CodigoOperador = "√", Asociatividad = IzquierdaAsociatividad, Precedencia = 2 });
            Operadores.Add("/", new Operador { CodigoOperador = "/", Asociatividad = IzquierdaAsociatividad, Precedencia = 1 });
            Operadores.Add("*", new Operador { CodigoOperador = "*", Asociatividad = IzquierdaAsociatividad, Precedencia = 1 });
            Operadores.Add("-", new Operador { CodigoOperador = "-", Asociatividad = IzquierdaAsociatividad, Precedencia = 0 });
            Operadores.Add("+", new Operador { CodigoOperador = "+", Asociatividad = IzquierdaAsociatividad, Precedencia = 0 });
        }

        /// <summary>
        ///     Determina si la pila Operadores contiene un determinado token.
        /// </summary>
        /// <param name="Token"></param>
        /// <returns>Booleano.</returns>
        private static bool EsOperador(String Token)
        {
            return Operadores.ContainsKey(Token);
        }

        /// <summary>
        ///     Convierte una expresión infija a posfija.
        /// </summary>
        /// <param name="ExpresionInfija"></param>
        /// <returns>Una cadena con la expresión, con un espacio entre cada término.</returns>
        public static string ConvertirInfijaAPosfija(string ExpresionInfija)
        {
            try
            {
                // Cada término en la expresión infija está separado por un espacio
                char[] Separador = { ' ' };
                string[] ArregloTokens = ExpresionInfija.Split(Separador, StringSplitOptions.RemoveEmptyEntries);
                Stack<string> PilaOperadores = new Stack<string>();
                StringBuilder Cola = new StringBuilder();

                // Se leen los tokens uno por uno
                for (int i = 0; i < ArregloTokens.Length; i++)
                {
                    string Token = ArregloTokens[i];

                    // Si el token es un paréntesis izquierdo, entonces se agrega a la pila
                    if (Token.Equals("("))
                    {
                        PilaOperadores.Push(Token);
                    }
                    // Si el token es un paréntesis derecho
                    else if (Token.Equals(")"))
                    {
                        bool ParentesisIzquierdoEncontrado = false;
                        // Hasta que el token en el tope de la pila sea un paréntesis izquierdo, sacar los operadores de la pila y meterlos en la cola
                        for (int k = 0; k < PilaOperadores.Count; k++)
                        {
                            if (PilaOperadores.Peek().Equals("("))
                            {
                                // Saca el paréntesis de la pila, pero no lo mete en la cola.
                                PilaOperadores.Pop();
                                ParentesisIzquierdoEncontrado = true;
                                break;
                            }
                            else
                            {
                                Cola.Append(PilaOperadores.Pop() + " ");
                            }
                        }

                        // Si la pila se acaba sin encontrar un paréntesis izquierdo, entonces hay paréntesis que no concuerdan
                        if (PilaOperadores.Count == 0 && ParentesisIzquierdoEncontrado == false)
                        {
                            throw (new Exception("Error en los paréntesis."));
                        }
                    }
                    // Si el token es un operador o1
                    else if (EsOperador(Token))
                    {
                        // Mientras haya un operador en el tope de la pila
                        while (PilaOperadores.Count > 0 && EsOperador(PilaOperadores.Peek()))
                        {
                            string TokenTopePila = PilaOperadores.Peek();

                            Operador o1 = Operadores.Values.Where(opCode => opCode.CodigoOperador.Equals(Token)).First();
                            Operador o2 = Operadores.Values.Where(opCode => opCode.CodigoOperador.Equals(TokenTopePila)).First();

                            // Si o1 tiene asociatividad izquierda y su precedencia es igual o mayor a la de o2, o si
                            // o1 tiene asociatividad derecha, y tiene una precedencia menor que o2
                            if ((o1.Asociatividad == IzquierdaAsociatividad && o1.Precedencia <= o2.Precedencia) || (o1.Asociatividad == DerechaAsociatividad && o1.Precedencia < o2.Precedencia))
                            {
                                // Quitar o2 de la pila, y agregarla a la cola
                                Cola.Append(PilaOperadores.Pop() + " ");
                                continue;
                            }
                            break;
                        }
                        // Se agrega o1 al tope de la pila                    
                        PilaOperadores.Push(Token);
                    }
                    // Si el token es un número
                    else
                    {
                        // Se agrega a la cola
                        Cola.Append(Token + " ");
                    }
                }

                // Cuando no haya más tokens que leer
                // Si el operador en el tope de la pila es un paréntesis, entonces hay paréntesis que no concuerdan.
                if (PilaOperadores.Count > 0)
                {
                    if (PilaOperadores.Peek().Equals("(") || PilaOperadores.Peek().Equals(")"))
                    {
                        throw (new Exception("Error en los paréntesis."));
                    }

                    // Mientras haya tokens de operadores en la pila
                    while (PilaOperadores.Count > 0)
                    {
                        if (EsOperador(PilaOperadores.Peek()))
                        {
                            // Sacar el operador y meterlo en la cola
                            Cola.Append(PilaOperadores.Pop() + " ");
                        }
                        else
                        {
                            PilaOperadores.Pop();
                        }
                    }
                }

                return Cola.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Metodos
    }
}
