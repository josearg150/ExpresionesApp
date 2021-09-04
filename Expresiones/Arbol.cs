using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expresiones
{
    /// <summary>
    /// Clase arbol para generar un arbol binario 
    /// Contiene el nodo padre
    /// </summary>
    /// 
    /// <Para>
    ///  Esta clase unicamente sirve para crear el arbol y sus nodos 
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
        #region Variables  
        //con esta forma se crea la variable y sus metodos get y set 
        public Nodo Raiz { set; get; }
        #endregion 
        public Arbol(Nodo Raiz)
        {
            this.Raiz = Raiz;
        }
    }
}
