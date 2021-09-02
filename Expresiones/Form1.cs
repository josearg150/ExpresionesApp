using DotNetGraph;
using DotNetGraph.Edge;
using DotNetGraph.Extensions;
using DotNetGraph.Node;
using Expresiones;
using InfixToRPN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                //System.Windows.Forms.MessageBox.Show(ShuntingYard.GetRPN(txbExpresion.Text));
                //System.Windows.Forms.MessageBox.Show(Expresion);
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
            var Grafica = new DotGraph("Árbol de expresiones");
            Stack<DotNode> Pila = new Stack<DotNode>();
            foreach (string c in expPostfija)
            {
                if (Numeros.Contains(c[0]))
                {
                    var Nodo = new DotNode(c)
                    {
                        Shape = DotNodeShape.Circle,
                        Label = c,
                        FillColor = Color.Coral,
                        FontColor = Color.Black,
                        Style = DotNodeStyle.Dotted,
                        Width = 0.5f,
                        Height = 0.5f,
                        PenWidth = 1.5f
                    };
                    Pila.Push(Nodo);
                } else if (Operadores.Contains(c[0]))
                {
                    var T1 = Pila.Pop();
                    var T2 = Pila.Pop();
                    var Nodo = new DotNode(c)
                    {
                        Shape = DotNodeShape.Circle,
                        Label = c,
                        FillColor = Color.Coral,
                        FontColor = Color.Black,
                        Style = DotNodeStyle.Dotted,
                        Width = 0.5f,
                        Height = 0.5f,
                        PenWidth = 1.5f
                    };
                    var Linea = new DotEdge(Nodo, T1)
                    {
                        ArrowHead = DotEdgeArrowType.Box,
                        ArrowTail = DotEdgeArrowType.Diamond,
                        Color = Color.Red,
                        FontColor = Color.Black,
                        Label = "",
                        Style = DotEdgeStyle.Dashed,
                        PenWidth = 1.5f
                    };
                    Grafica.Elements.Add(Linea);
                    var Linea2 = new DotEdge(Nodo, T2)
                    {
                        ArrowHead = DotEdgeArrowType.Box,
                        ArrowTail = DotEdgeArrowType.Diamond,
                        Color = Color.Red,
                        FontColor = Color.Black,
                        Label = "",
                        Style = DotEdgeStyle.Dashed,
                        PenWidth = 1.5f
                    };
                    Grafica.Elements.Add(Linea2);
                    Pila.Push(Nodo);
                }
            }
            var dot = Grafica.Compile(true);
            File.WriteAllText("myFile.dot", dot);
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
    }
}
