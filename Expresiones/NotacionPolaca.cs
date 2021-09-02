using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expresiones
{
    /// <summary>
    /// Clase para acomodo en notacion polaca 
    /// </summary>
    /// 
    /// <Para>
    /// Con esta clase se organizan los simbolos para ser mostrados en el arbol 
    /// </Para>
    /// 
    /// <Supuestos>
    /// </Supuestos>
    /// 
    /// <Autor>
    /// Jose angel rocha garcia 
    /// Jose luis carreon reyes
    /// Osvaldo santacruz 
    /// </Autor>
    /// 
    /// <FechaCreacion >
    ///  01/09/2021
    /// </FechaCreacion>
    class Not_Polaca
    {
        //***************************************
        //Enumerados y tipos                      
        //***************************************
        #region Enumerados y tipos 
        public enum Simbolo { OPERANDO, PIZQ, PDER, SUMARES, MULTDIV, POW };
        #endregion
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables locales
        #endregion
        //***************************************
        //Metodos                      
        //***************************************
        #region Metodos 
        
        public StringBuilder convertir_pos(string Ei)
        {
            char[] Epos = new char[Ei.Length]; //Arreglo de char para indicar la posicion, 
                                               //la dimension es definida por el parametro que llega 
            int tam = Ei.Length; // igualamos una variable tamaño para mejor manejo de la dimesion y legibilidad 
                                 //del codigo 
            Stack<int> Pila = new Stack<int>(tam); //Declaramos la pila donde entraran y saldran los simbolos 
                                                   //con el fin de acomodarlo

            int i, pos = 0; //Estas variables serviran para el conteo y posicion en el ciclo 
            for (i = 0; i < Epos.Length; i++)
            {
                char car = Ei[i]; //Se define un caracter con el que se recorrera el ciclo, tomando el charAt de la cadena
                Simbolo actual = Tipo_y_Presendecia(car);//usamos el enumrando para saber que simbolo detecto
                switch (actual)
                {
                    case Simbolo.OPERANDO: Epos[pos++] = car; break;//si es un operando, se agrega al arreglo de Epos y se
                                                                    //incrementa la posicion
                    case Simbolo.SUMARES:                          
                        {
                            //cuando es + o - comprobamos que, la pila no este vacia 
                            // y que el simbolo tenga mayor jerarquia que el actual 
                            while (!(Pila.Count == 0) && Tipo_y_Presendecia((char)Pila.ElementAt(Pila.Count - 1)) >= actual)
                            {
                                // Sacamos ese simbolo de la pila y lo agregamos al arreglo de Epos, incrementando su posicion
                                Epos[pos++] = (char)Pila.Pop();
                            }
                            //Metemos el caracter leido a la pila 
                            Pila.Push(car);
                        }
                        break;
                    case Simbolo.MULTDIV:
                        {
                            //cuando es * o / comprobamos que, la pila no este vacia 
                            // y que el simbolo tenga mayor jerarquia que el actual 
                            while (!(Pila.Count == 0) && Tipo_y_Presendecia((char)Pila.ElementAt(Pila.Count - 1)) >= actual)
                            {
                                // Sacamos ese simbolo de la pila y lo agregamos al arreglo de Epos, incrementando su posicion
                                Epos[pos++] = (char)Pila.Pop();
                            }
                            //Metemos el caracter leido a la pila 
                            Pila.Push(car);
                        }
                        break;
                    case Simbolo.POW:
                        {
                            //cuando es ^ comprobamos que, la pila no este vacia 
                            // y que el simbolo tenga mayor jerarquia que el actual 
                            while (!(Pila.Count == 0) && Tipo_y_Presendecia((char)Pila.ElementAt(Pila.Count - 1)) >= actual)
                            {
                                // Sacamos ese simbolo de la pila y lo agregamos al arreglo de Epos, incrementando su posicion
                                Epos[pos++] = (char)Pila.Pop();
                            }
                            //Metemos el caracter leido a la pila 
                            Pila.Push(car);
                        }
                        break;
                        //para el simbolo ( insertamos directamente el caracter a la pila 
                    case Simbolo.PIZQ: Pila.Push(car); break;
                    case Simbolo.PDER://para el simbolo derecho se saca el simbolo de la pila y se asigna a x
                        {
                            char x = (char)Pila.Pop();
                            //se comprueba que no sea un parentesis izquierdo 
                            while (Tipo_y_Presendecia(x) != Simbolo.PIZQ)
                            {
                                //Se agrega al arreglo 
                                Epos[pos++] = x; 
                                x = (char)Pila.Pop();//se le asigna el tope de la pila a x
                            }
                        }
                        break;
                }
            }
            //mientras que la pila no este vacia 
            while (!(Pila.Count == 0))
            {
                if (pos < Epos.Length) // y la posicion sea menor que la dimension de epos 
                    Epos[pos++] = (char)Pila.Pop(); //le asginamos a epos el tope de la pila 
                else
                    break;
            }
            //Creamos una cadena del tamañao de la cadena que llego 
            StringBuilder regresa = new StringBuilder(Ei);

            for (int r = 0; r < Epos.Length; r++)
                regresa[r] = Epos[r];//Asignamos los simbolos que encontramos durante el proceso a la cadena que retornara
            return regresa;
        }

        public Simbolo Tipo_y_Presendecia(char s)//metodo creado para definir los tipos y su presedencia 
        {
            Simbolo simbolo; //clase de los enumerandos 
            switch (s)//Segun el caracter que llegue se asignara uno de los siguientes valores 
            {
                case '+': simbolo = Simbolo.SUMARES; break;//tenemos los operadores acomodados por jerarquia 
                case '-': simbolo = Simbolo.SUMARES; break;
                case '*': simbolo = Simbolo.MULTDIV; break;
                case '/': simbolo = Simbolo.MULTDIV; break;
                case '(': simbolo = Simbolo.PIZQ; break;
                case ')': simbolo = Simbolo.PDER; break;
                case '^': simbolo = Simbolo.POW; break;
                default: simbolo = Simbolo.OPERANDO; break;
            }
            return simbolo;//Regresamos el valor asignado 
        }
        #endregion
    }
}