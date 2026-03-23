class Program // Clase principal del programa.
{
    static void Main() // Punto de entrada.
    {
        HashSet<string> palabrasUnicas = new HashSet<string>(); // Guarda palabras únicas (no admite duplicados).

        PedirPalabras(palabrasUnicas); // Solicita las 8 palabras e intenta guardarlas en el HashSet.
        MostrarResultados(palabrasUnicas); // Muestra la cantidad y la lista de palabras únicas.
    }

    static void PedirPalabras(HashSet<string> palabrasUnicas) // Método que pide palabras al usuario.
    {
        Console.Clear(); // Limpia la consola para mostrar una entrada ordenada.

        Console.WriteLine("Ingresa 8 palabras (una por línea):"); // Instrucción general.
        Console.WriteLine(); // Línea en blanco para mejorar la presentación.

        for (int i = 1; i <= 8; i++) // Repite el proceso 8 veces (i=1..8).
        {
            Console.Write($"Palabra {i}: "); // Pide la palabra i.
            string palabra = Console.ReadLine() ?? ""; // Lee la palabra; si llega null, usa "".
            palabrasUnicas.Add(palabra); // Agrega al HashSet (si es duplicada, no se agrega).
        }
    }

    static void MostrarResultados(HashSet<string> palabrasUnicas) // Método que imprime resultados.
    {
        Console.Clear(); // Limpia antes de mostrar el resumen.

        Console.WriteLine($"Cantidad de palabras únicas: {palabrasUnicas.Count}"); // Muestra cuántas palabras únicas se guardaron.
        Console.WriteLine(); // Línea en blanco.
        Console.WriteLine("Lista de palabras únicas:"); // Encabezado de la lista.

        foreach (string palabra in palabrasUnicas) // Recorre cada palabra única guardada.
        {
            Console.WriteLine(palabra); // Imprime la palabra.
        }
    }
}
