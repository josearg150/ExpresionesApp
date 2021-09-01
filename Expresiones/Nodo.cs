using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expresiones
{
    /// <summary>
    /// Clase nodo para la clase Arbol binario 
    /// Contiene los atributos de un Nodo 
    /// </summary>
    /// 
    /// <Para>
    /// Con esta clase se pueden crear los nodos que seran usados por el arbol binario 
    /// </Para>
    /// 
    /// <Supuestos>
    /// </Supuestos>
    /// 
    /// <Autor>
    /// Jose angel rocha garcia 
    /// Jose luis carreon reyes
    /// </Autor>
    /// 
    /// <FechaCreacion >
    /// 30/08/2021
    /// </FechaCreacion>
    class Nodo
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables Locales 
        private char caracter;
        private Nodo izquierdo;
        private Nodo derecho;
        #endregion

        //***************************************
        //Constructores
        //***************************************
        #region Constructores 
        //Constructor sin parametros 
        public Nodo()
        {
            caracter = ' ';
            izquierdo = null;
            derecho = null;
        }

        //Constructor con parametros 
        public Nodo(char _caracter)
        {
            caracter = _caracter;
            izquierdo = null;
            derecho = null;
        }
        public Nodo(char _caracter, Nodo _izquierdo, Nodo _derecho)
        {
            caracter = _caracter;
            izquierdo = _izquierdo;
            derecho = _derecho;
        }
        #endregion
        //***************************************
        //Metodos 
        //***************************************
        #region Metodos

        public Nodo obtenerDerecho()
        {
            return derecho;
        }

        public Nodo obtenerIzquierdo()
        {
            return izquierdo;
        }

        public void setCaracter(char _caracter)
        {
            caracter = _caracter;
        }

        public char obtenerCaracter()
        {
            return caracter;
        }

        public Nodo insertar(Nodo a, Nodo b)
        {
            //Comparamos si su lado izquierdo para saber si esta vacio 
            if (b.caracter.CompareTo(a.caracter) < 0)
            {
                if (a.izquierdo == null)
                {
                    a.izquierdo = b;
                    return a;
                }//Seguimos insertando hasta que tenga un lado izquierdo disponible 
                else
                {
                    a.izquierdo = insertar(a.izquierdo, b);
                    return a;
                }
            }//Hacemos el mismo procedimiento en el lado derecho 
            else if (b.caracter.CompareTo(a.caracter) > 0)
            {
                if (a.derecho == null)
                {
                    a.derecho = b;
                    return a;
                }
                else
                {
                    a.derecho = insertar(a.derecho, b);
                    return a;
                }
            }//si ambos lados estan llenos regresamos null 
            else
            {
                return null;
            }
        }
        #endregion
    }
}
