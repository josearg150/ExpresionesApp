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
        public Nodo Raiz { set; get; }
        public Microsoft.Msagl.Drawing.Graph Grafica;

        public Arbol(Nodo Raiz)
        {
            this.Raiz = Raiz;
            this.Grafica = new Microsoft.Msagl.Drawing.Graph("Grafica");
        }

        public Microsoft.Msagl.Drawing.Graph TransformarAGrafica(Nodo Nodo)
        {
            var NodoGrafico = Grafica.AddNode(Nodo.Valor);
            if (Nodo.Izquierda != null)
            {
                Grafica.AddEdge(NodoGrafico.Id, "", Grafica.AddNode(Nodo.Izquierda.Valor).Id);
                TransformarAGrafica(Nodo.Izquierda);
            }
            if(Nodo.Derecha != null)
            {
                Grafica.AddEdge(NodoGrafico.Id, "", Grafica.AddNode(Nodo.Derecha.Valor).Id);
                TransformarAGrafica(Nodo.Derecha);
            }
            return Grafica;
        }
    }
}
