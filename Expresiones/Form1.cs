using Expresiones;
using InfijoPosfijo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace wfExpresionesArbolBinario
{
    /// <summary>
    ///     Formulario principal para la interfaz de la aplicación.
    /// </summary>
    /// <Para>
    ///     Invocar al formulario y sus componentes (botones, menús, etc.)
    /// </Para>
    /// <Supuestos>
    ///     Para que aparezca la interfaz, es necesario no remover las llamadas pertinentes en main().
    /// </Supuestos>
    /// <Autor>
    ///     José Luis Carreón Reyes
    ///     José Ángel Rocha García
    /// </Autor>
    /// <FechaCreacion>
    ///     30/08/2021
    /// </FechaCreacion>
    public partial class Form1 : Form
    {
        //****************************************************************************************
        // CONSTANTES
        //****************************************************************************************
        #region Constantes
        // Arreglos de referencia para establecer los caracteres que están permitidos en la expresión.
        private readonly char[] Operadores = { '+', '-', '*', '/', '^', '√' };
        private readonly char[] Numeros = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        #endregion Constantes

        //****************************************************************************************
        // VARIABLES
        //****************************************************************************************
        #region Variables
        private bool OperadoresShuntingInicializados = false; // Lleva cuenta de si los operadores permitidos
                                                              // ya están inicializados con su precedencia y
                                                              // asociatividad
        #endregion Variables

        //****************************************************************************************
        // CONSTRUCTORES
        //****************************************************************************************
        #region Constructores
        /// <summary>
        ///     Inicializa el formulario.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion Constructores

        //****************************************************************************************
        // EVENTOS
        //****************************************************************************************
        #region Eventos
        /// <summary>
        ///     Es donde se lee, valida y transforma la expresión dada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string Expresion = ValidarInput(txbExpresion.Text); // La expresión validada
            if (Expresion.Equals("")) // Se muestra un popup avisando que la validación no fue exitosa.
            {
                System.Windows.Forms.MessageBox.Show("Input inválido. Intente de nuevo.");
            } else
            {
                if (!OperadoresShuntingInicializados)       // Se inicializan los operadores permitidos con su precedencia
                    ShuntingYard.InicializarOperadores();     // y asociatividad, tal como lo indica el algoritmo usado
                    OperadoresShuntingInicializados = true; // (Shunting Yard)
                string ExpresionRPN = ShuntingYard.ConvertirInfijaAPosfija(Expresion); // Expresion en notación polaca revertida
                System.Windows.Forms.MessageBox.Show(ExpresionRPN);
                // Se convierte la cadena de la expresión en notación polaca revertida en un arreglo
                List<string> ExpresionRPNArreglo = new List<string>(ExpresionRPN.Split(' ').ToList());
                // Se elimina el objeto vacío sobrante al final del arreglo
                ExpresionRPNArreglo.RemoveAt(ExpresionRPNArreglo.Count - 1);
                Graficar(ExpresionRPNArreglo);
            }
        }

        /// <summary>
        ///     Acciones a tomar en cuanto se inicialice el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            informaciónToolStripMenuItem_Click(this, new EventArgs());
        }

        /// <summary>
        ///     Se presiona el botón de "Aceptar" al presionar <Enter>, al escribir la expresión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbExpresion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        /// <summary>
        ///     Termina la ejecución del programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        ///     Muestra un popup con consideraciones a tomar al escribir la expresión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Consideraciones:\n" +
                                                 "1. No se permite introducir operadores al principio de la expresión (excepto la raíz cuadrada).\n" +
                                                 "2. No se permite introducir operadores al final de la expresión.\n" +
                                                 "3. No se permite introducir caracteres que no sean operadores (+, -, *, /, √, ^) o números.\n" +
                                                 "4. Dos operadores no pueden colocarse consecutivamente, excepto por la raíz cuadrada.\n" +
                                                 "5. Todo espacio se ignora.\n" +
                                                 "6. Las expresiones con paréntesis no están implementadas.");
        }

        /// <summary>
        ///     Limpia el campo de texto de la expresión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            txbExpresion.Text = "";
        }
        #endregion Eventos

        //****************************************************************************************
        // MÉTODOS
        //****************************************************************************************
        #region Metodos
        /// <summary>
        ///     Valida el input dado por el usuario.
        /// </summary>
        /// <param name="expresion">Cadena con la expresión a validar.</param>
        /// <returns>La expresión validada en forma de cadena, o una cadena vacía en caso de error.</returns>
        private string ValidarInput(string expresion)
        {
            if (expresion.Equals(""))
            {
                // Se retorna una cadena vacía cuando haya error de validación.
                return "";
            } else
            {
                // Cadena que lleva cuenta del tipo de caracter en cada iteración (si es operador, número)
                string AuxChar = "";
                // Lista genérica de cadenas usada para ir armando la expresión validada.
                List<string> ExpresionValidada = new List<string>();

                int i = 0;
                // Por cada caracter en la expresión dada...
                foreach (char c in expresion)
                {
                    // Se ignoran los espacios
                    if (c.Equals(' '))
                    {
                        i++;
                        continue;
                    }
                    // Operadores que no sean operadores o números no se aceptan
                    if (!Operadores.Contains(c) && !Numeros.Contains(c))
                    {
                        return "";
                    }
                    // La expresión no puede comenzar con un operador
                    if (i == 0 && Operadores.Contains(c) && c != '√')
                    {
                        return "";
                    }
                    // A menos que sea una raíz cuadrada
                    else if (i == 0 && c == '√')
                    {
                        AuxChar = "op";
                    }
                    // La expresión no puede terminar con un operador
                    else if (i == expresion.Length - 1 && Operadores.Contains(c))
                    {
                        return "";
                    }
                    // Dos operadores no pueden estar uno al lado del otro, excepto por la raíz cuadrada (el 2 es implícito)
                    if (AuxChar.Equals("op") && Operadores.Contains(c))
                    {
                        if (c == '√')
                        {
                            ExpresionValidada.Add("2");
                        }
                        else
                        {
                            return "";
                        }
                    }

                    // Como la iteración se lleva a cabo caracter por caracter, si se encuentra un número y el caracter
                    // anterior también fue un número, ambos se unen para formar un número de x dígitos
                    if (AuxChar == "num" && Numeros.Contains(c))
                    {
                        ExpresionValidada.Insert(ExpresionValidada.Count - 1, ExpresionValidada.ElementAt(ExpresionValidada.Count - 1) + c.ToString());
                        ExpresionValidada.RemoveAt(ExpresionValidada.Count - 1);
                        i++;
                        AuxChar = "num";
                        continue;
                    }

                    // Se lleva cuenta de si el caracter de la iteración anterior es número u operador
                    if (Numeros.Contains(c))
                    {
                        AuxChar = "num";
                    }
                    else if (Operadores.Contains(c))
                    {
                        AuxChar = "op";
                    }

                    // Se inserta el término evaluado en el arreglo que se retornará como cadena al final
                    ExpresionValidada.Add(c.ToString());
                    i++;
                }
                // Se retorna la cadena con la expresión validada con un espacio para dividir cada término,
                // puesto que el algoritmo Shunting Yard así lo requiere.
                return string.Join(" ", ExpresionValidada);
            }
        }

        /// <summary>
        ///     Grafica la expresión dada.
        /// </summary>
        /// <param name="ExpresionPosfija">La expresión validada en notación polaca revertida a evaluar en forma de una lista genérica de cadenas.</param>
        private void Graficar(List<string> ExpresionPosfija)
        {
            // Entero que se irá incrementando progresivamente para identificar a los nodos del árbol.
            int Id = 0;
            // Se crea un formulario (requerido por la librería Microsoft.Msagl)
            System.Windows.Forms.Form Formulario = new System.Windows.Forms.Form();
            // Se ajusta el tamaño del formulario
            Formulario.Size = new Size(800, 600);
            // Objeto para visualizar los elementos (nodos, líneas) que se vayan creando.
            Microsoft.Msagl.GraphViewerGdi.GViewer Visor = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            // Pila de nodos de la librería Microsoft.Msagl
            Stack<Microsoft.Msagl.Drawing.Node> PilaGrafica = new Stack<Microsoft.Msagl.Drawing.Node>();
            // Se crea el objeto gráfica, al cual se irán añadiendo elementos visuales.
            Microsoft.Msagl.Drawing.Graph Grafica = new Microsoft.Msagl.Drawing.Graph("Grafica");
            // Se sigue el algoritmo adecuado para crear el árbol binario de expresiones
            // Se implementó en base en la descripción encontrada en: https://en.wikipedia.org/wiki/Binary_expression_tree#Construction_of_an_expression_tree
            // Para cada término en la expresión...
            foreach (string c in ExpresionPosfija)
            {
                // Se incrementa el entero para identificar al siguiente nodo que se cree
                Id++;
                // Si el término es un número...
                if (Numeros.Contains(c[0]))
                {
                    // Se crea un nuevo nodo con el número
                    var Nodo = Grafica.AddNode(Id.ToString());
                    Nodo.LabelText = c;
                    // Se introduce el nodo creado a la pila
                    PilaGrafica.Push(Nodo);
                }
                // Si el término es una expresión...
                else if (Operadores.Contains(c[0]))
                {
                    // Se sacan dos nodos (números) de la pila... 
                    var T1 = PilaGrafica.Pop();
                    var T2 = PilaGrafica.Pop();
                    // Se crea un nuevo nodo con el operador
                    var Nodo = Grafica.AddNode(Id.ToString());
                    Nodo.LabelText = c;
                    // y se enlazan al nodo creado (operador)
                    Grafica.AddEdge(Nodo.Id, "", T1.Id);
                    Grafica.AddEdge(Nodo.Id, "", T2.Id);
                    // Se introduce el nodo creado a la pila
                    PilaGrafica.Push(Nodo);
                }
            }
            // Se enlaza la gráfica al visor de elementos
            Visor.Graph = Grafica;
            // Se asocia el visor al formulario creado al principio del método
            Formulario.SuspendLayout();
            Visor.Dock = System.Windows.Forms.DockStyle.Fill;
            Formulario.Controls.Add(Visor);
            Formulario.ResumeLayout();
            // Muestra el formulario (la gráfica)
            Formulario.ShowDialog();
        }

        /// <summary>
        ///     Convierte la expresión validada en notación polaca revertida a un árbol. (No se usa, solo se
        ///     implementó para un potencial uso futuro con otros analizadores.)
        /// </summary>
        /// <param name="ExpresionPosfija">La expresión validada en notación polaca revertida a evaluar en forma de una lista genérica de cadenas.</param>
        /// <returns>Un árbol binario de expresiones.</returns>
        private Arbol ConvertirRPNAArbol(List<string> ExpresionPosfija)
        {
            // Se sigue exactamente el mismo algoritmo descrito en el método Graficar().
            // Sólo cambian los objetos utilizados para las operaciones.
            Stack<Nodo> PilaArbol = new Stack<Nodo>();
            foreach (string c in ExpresionPosfija)
            {
                if (Numeros.Contains(c[0]))
                {
                    Nodo Nodo = new Nodo(c);
                    PilaArbol.Push(Nodo);
                }
                else if (Operadores.Contains(c[0]))
                {
                    Nodo T1 = PilaArbol.Pop();
                    Nodo T2 = PilaArbol.Pop();
                    Nodo Nodo = new Nodo(c);
                    Nodo.Izquierda = T1;
                    Nodo.Derecha = T2;
                    PilaArbol.Push(Nodo);
                }
            }
            Arbol Arbol = new Arbol(PilaArbol.Pop());
            return Arbol;
        }
        #endregion Metodos
    }
}
