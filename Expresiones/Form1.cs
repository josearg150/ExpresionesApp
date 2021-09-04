using Expresiones;
using InfixToRPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Formulario principal para la interfaz de la aplicación.
/// 
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
/// <FechaCreacion>
/// 30/08/2021
/// </FechaCreacion>
namespace wfExpresionesArbolBinario
{
    public partial class Form1 : Form
    {
        private char[] Operadores = { '+', '-', '*', '/', '^', '√' };
        private char[] Numeros = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private bool OperadoresShuntingInicializados = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Expresion = ValidarInput(txbExpresion.Text);
            if (Expresion.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Input inválido. Intente de nuevo.");
            } else
            {
                if (!OperadoresShuntingInicializados)
                    ShuntingYard.InitializeOperators();
                    OperadoresShuntingInicializados = true;
                string ExpresionRPN = ShuntingYard.GetRPN(Expresion);
                System.Windows.Forms.MessageBox.Show(ExpresionRPN);
                List<string> ExpresionRPNArreglo = new List<string>(ExpresionRPN.Split(' ').ToList());
                ExpresionRPNArreglo.RemoveAt(ExpresionRPNArreglo.Count - 1);
                Graficar(ExpresionRPNArreglo);
            }
        }

        private string ValidarInput(string expresion)
        {
            if (expresion.Equals(""))
            {
                return "";
            } else
            {
                string AuxChar = "";
                List<string> ExpresionValidada = new List<string>();

                int i = 0;
                foreach (char c in expresion)
                {
                    // No se aceptan espacios
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

                    if (AuxChar == "num" && Numeros.Contains(c))
                    {
                        ExpresionValidada.Insert(ExpresionValidada.Count - 1, ExpresionValidada.ElementAt(ExpresionValidada.Count - 1) + c.ToString());
                        ExpresionValidada.RemoveAt(ExpresionValidada.Count - 1);
                        i++;
                        AuxChar = "num";
                        continue;
                    }

                    // Se lleva si el caracter de la iteración anterior es número u operador
                    if (Numeros.Contains(c))
                    {
                        AuxChar = "num";
                    }
                    else if (Operadores.Contains(c))
                    {
                        AuxChar = "op";
                    }

                    ExpresionValidada.Add(c.ToString());
                    i++;
                }
                return string.Join(" ", ExpresionValidada);
            }
        }

        private void Graficar(List<string> expPostfija)
        {
            //create a form 
            System.Windows.Forms.Form Formulario = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer Visor = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph Grafica = new Microsoft.Msagl.Drawing.Graph("graph");
            Stack<Microsoft.Msagl.Drawing.Node> Pila = new Stack<Microsoft.Msagl.Drawing.Node>();
            foreach (string c in expPostfija)
            {
                if (Numeros.Contains(c[0]))
                {
                    var Nodo = Grafica.AddNode(c);
                    Pila.Push(Nodo);
                }
                else if (Operadores.Contains(c[0]))
                {
                    var T1 = Pila.Pop();
                    var T2 = Pila.Pop();
                    var Nodo = Grafica.AddNode(c);
                    Grafica.AddEdge(Nodo.Id, "", T1.Id);
                    Grafica.AddEdge(Nodo.Id, "", T2.Id);
                    Pila.Push(Nodo);
                }
            }
            //bind the graph to the viewer 
            Visor.Graph = Grafica;
            //associate the viewer with the form 
            Formulario.SuspendLayout();
            Visor.Dock = System.Windows.Forms.DockStyle.Fill;
            Formulario.Controls.Add(Visor);
            Formulario.ResumeLayout();
            //show the form 
            Formulario.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Se presiona el botón de "Aceptar" al presionar <Enter>
        private void txbExpresion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void informaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Restricciones:\n" +
                                                 "1. No se permite introducir operadores al principio de la expresión (excepto la raíz cuadrada).\n" +
                                                 "2. No se permite introducir operadores al final de la expresión.\n" +
                                                 "3. No se permite introducir caracteres que no sean operadores o números.\n" +
                                                 "4. Dos operadores no pueden colocarse consecutivamente, excepto por la raíz cuadrada.\n" +
                                                 "5. Todo espacio se ignora.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            txbExpresion.Text = "";
        }
    }
}
