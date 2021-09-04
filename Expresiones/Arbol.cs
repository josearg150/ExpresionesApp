namespace Expresiones
{
    /// <summary>
    ///     Clase arbol para generar un arbol binario 
    ///     Contiene el nodo raiz
    /// </summary>
    /// 
    /// <Para>
    ///  Esta clase unicamente sirve para crear el arbol y sus nodos 
    /// </Para>
    /// 
    /// <Supuestos>
    ///     
    /// </Supuestos>
    /// 
    /// <Autor>
    ///     Jose angel rocha garcia 
    ///     Jose luis carreon reyes
    /// </Autor>
    /// 
    /// <FechaCreacion>
    ///     04/09/2021
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

        //***************************************
        //Constructores   
        //***************************************
        #region Constructores
        public Arbol(Nodo Raiz)
        {
            this.Raiz = Raiz;
        }
        #endregion Constructores
    }
}
