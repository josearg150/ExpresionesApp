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
        public string Valor { set; get; }
        public Nodo Izquierda { set; get; }
        public Nodo Derecha { set; get; }

        public Nodo(string Valor)
        {
            this.Valor = Valor;
            this.Izquierda = null;
            this.Derecha = null;
        }

        public Nodo()
        {
            this.Izquierda = null;
            this.Derecha = null;
        }
    }
}
