using System;
using System.Windows.Forms;
using wfExpresionesArbolBinario;

namespace Expresiones
{
    /// <summary>
    ///     Punto de entrada para la aplicación.
    /// </summary>
    /// <Para>
    ///     Iniciar la aplicación.
    /// </Para>
    /// <Supuestos>
    ///     ...
    /// </Supuestos>
    /// <Autor>
    ///     José Luis Carreón Reyes
    ///     José Ángel Rocha García
    /// </Autor>
    /// <FechaCreacion>
    ///     30/08/2021
    /// </FechaCreacion>
    static class Program
    {
        /// <summary>
        ///     Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
