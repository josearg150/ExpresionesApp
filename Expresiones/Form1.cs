using InfixToRPN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private char[] operadores = { '+', '-', '*', '/', '^', '√' };
        private char[] numeros = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

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
                //ShuntingYard ExpresionRPN = new ShuntingYard(Expresion);
                //System.Windows.Forms.MessageBox.Show(ShuntingYard.GetRPN(Expresion));
                ShuntingYard.InitializeOperators();
                System.Windows.Forms.MessageBox.Show(ShuntingYard.GetRPN(Expresion));
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
                List<char> ExpresionValidada = new List<char>();

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
                    if (!operadores.Contains(c) && !numeros.Contains(c))
                    {
                        return "";
                    }
                    // La expresión no puede comenzar con un operador
                    if (i == 0 && operadores.Contains(c) && c != '√')
                    {
                        return "";
                    }
                    // A menos que sea una raíz cuadrada
                    else if (i == 0 && c == '√')
                    {
                        AuxChar = "op";
                    }
                    // La expresión no puede terminar con un operador
                    else if (i == expresion.Length - 1 && operadores.Contains(c))
                    {
                        return "";
                    }
                    // Dos operadores no pueden estar uno al lado del otro, excepto por la raíz cuadrada (el 2 es implícito)
                    if (AuxChar.Equals("op") && operadores.Contains(c))
                    {
                        if (c == '√')
                        {
                            ExpresionValidada.Add('2');
                        }
                        else
                        {
                            return "";
                        }
                    }
                    // Se lleva si el caracter de la iteración anterior es número u operador
                    if (numeros.Contains(c))
                    {
                        AuxChar = "num";
                    }
                    else if (operadores.Contains(c))
                    {
                        AuxChar = "op";
                    }
                    ExpresionValidada.Add(c);
                    i++;
                }
                return new string(ExpresionValidada.ToArray());
            }
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
