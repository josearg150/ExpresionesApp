using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expresiones
{
    public partial class Form1 : Form
    {
        private char[] operadores = { '+', '-', '*', '/', '^', '√' };
        private char[] numeros = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            Nodo n = new Nodo('a');
            Nodo der = new Nodo('b');
            n.setDerecho(der);
            lblPruebas.Text = der.obtenerCaracter().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expresion = tbExpresion.Text;
            string auxChar = "";
            List<char> expresionValidada = new List<char>();

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
                    System.Windows.Forms.MessageBox.Show("Input inválido. Operadores que no sean operadores o números no se aceptan.");
                    tbExpresion.Clear();
                }
                // La expresión no puede comenzar con un operador
                if (i == 0 && operadores.Contains(c) && c != '√')
                {
                    System.Windows.Forms.MessageBox.Show("Input inválido. La expresión no puede comenzar con un operador.");
                    tbExpresion.Clear();
                }
                // A menos que sea una raíz cuadrada
                else if (i == 0 && c == '√')
                {
                    auxChar = "op";
                }
                // La expresión no puede terminar con un operador
                else if (i == expresion.Length - 1 && operadores.Contains(c))
                {
                    System.Windows.Forms.MessageBox.Show("Input inválido. La expresión no puede terminar con un operador.");
                    tbExpresion.Clear();
                }
                // Dos operadores no pueden estar uno al lado del otro, excepto por la raíz cuadrada (el 2 es implícito)
                if (auxChar.Equals("op") && operadores.Contains(c))
                {
                    if (c == '√')
                    {
                        expresionValidada.Add(c);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Input inválido. Dos operadores no pueden estar uno al lado del otro.");
                        tbExpresion.Clear();
                    }
                    // Se lleva si el caracter de la iteración anterior es número u operador
                    if (numeros.Contains(c))
                    {
                        auxChar = "num";
                    }
                    else if (operadores.Contains(c))
                    {
                        auxChar = "op";
                    }
                }
                expresionValidada.Add(c);
                i++;
            }
            System.Windows.Forms.MessageBox.Show(new string(expresionValidada.ToArray()));
        }
        private void txbExpresion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
    }
}
