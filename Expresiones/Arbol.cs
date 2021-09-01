using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expresiones
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <Para>
    ///
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
    ///
    /// </FechaCreacion>
    class Arbol
    {
        //***************************************
        //Variables locales                     
        //***************************************
        #region Variables Locales 
        Nodo raiz;
        #endregion

        #region Constructores 
        //Constructor sin parametros 
        public Arbol()
        {
            raiz = null;
        }
        #endregion

        //***************************************
        //Metodos 
        //*********
        #region Metodos

        public void insertar(Nodo a, Nodo b)
        {  ///Hay que cambiar el metodo para los operadores 
            //Comparamos si su lado izquierdo para saber si esta vacio 
            if (b.obtenerCaracter().CompareTo(a.obtenerCaracter()) < 0)
            {
                if (a.obtenerIzquierdo() == null)
                {
                    a.setIzquierdo(b);
                }//Seguimos recorriendo hasta que tenga un lado izquierdo disponible 
                else
                {
                    insertar(a.obtenerIzquierdo(), b);

                }
            }//Hacemos el mismo procedimiento en el lado derecho 
            else if (b.obtenerCaracter().CompareTo(a.obtenerCaracter()) > 0)
            {
                if (a.obtenerDerecho() == null)
                {
                    a.setDerecho(b);

                }
                else
                {
                    insertar(a.obtenerDerecho(), b);
                }
            }

            
            
        }
        public void recorrerArbol(Nodo n)
        {
            if (n != null)
            {
                recorrerArbol(n.obtenerIzquierdo());
                //Aqui falta algo para mostrar por consola
                recorrerArbol(n.obtenerDerecho());

            }
        }

        #endregion
    }

}
