class Program // Clase que contiene el programa de consola
{
    static void Main(string[] args) // Metodo principal: aqui empieza la ejecucion
    {
        Console.Clear(); // Borra lo que habia en la consola
        Console.WriteLine("Ingrese una expresion:"); // Pide al usuario que escriba la expresion
        string? expresion = Console.ReadLine(); // Lee la linea que escribe el usuario

        if (expresion == null) // Si ReadLine devolvio nulo (por seguridad)
        {
            expresion = ""; // Usamos cadena vacia en lugar de nulo
        }

        int resultado = SimbEquilibrados(expresion); // Llama a la funcion y guarda el numero que devuelve

        Console.Clear(); // Limpia la consola antes de mostrar el resultado
        Console.WriteLine(resultado); // Muestra -1 o la posicion del error
    }

    static int SimbEquilibrados(string texto) // Funcion que revisa parentesis, corchetes y llaves
    {
        char[] aperturas = new char[texto.Length]; // Arreglo: simbolos de apertura que vamos guardando
        int[] posiciones = new int[texto.Length]; // Arreglo: posicion en la cadena de cada apertura
        int tope = -1; // Indice del ultimo simbolo guardado (-1 = pila vacia)
        int i = 0; // Contador para recorrer la cadena

        for (i = 0; i < texto.Length; i++) // Recorre cada caracter de la expresion
        {
            char caracter = texto[i]; // Caracter actual de la cadena

            if (caracter == '(' || caracter == '[' || caracter == '{') // Es simbolo de apertura
            {
                tope = tope + 1; // Subimos un nivel en la "pila"
                aperturas[tope] = caracter; // Guardamos que simbolo se abrio
                posiciones[tope] = i; // Guardamos su posicion en la cadena
            }
            else if (caracter == ')' || caracter == ']' || caracter == '}') // Es simbolo de cierre
            {
                if (tope == -1) // No hay apertura pendiente
                {
                    return i; // Error: cierre sin apertura
                }

                char ultimoAbierto = aperturas[tope]; // Ultimo simbolo que quedo abierto
                bool coincide = (ultimoAbierto == '(' && caracter == ')') // Par parentesis
                    || (ultimoAbierto == '[' && caracter == ']') // Par corchetes
                    || (ultimoAbierto == '{' && caracter == '}'); // Par llaves

                if (!coincide) // El cierre no corresponde al ultimo abierto
                {
                    return i; // Error de anidamiento
                }

                tope = tope - 1; // Cierre valido: quitamos la ultima apertura
            }
        }

        if (tope != -1) // Quedan aperturas sin cerrar al terminar
        {
            return posiciones[tope]; // Posicion de la apertura que falta cerrar
        }

        return -1; // Todo correcto
    }
}
