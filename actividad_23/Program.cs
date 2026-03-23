using System.Collections.Generic; // Contiene List<T> y HashSet<T>.

class Program // Clase que encapsula toda la lógica del ejercicio.
{
    static void Main(string[] args) // Método principal del programa.
    {
        // Lista donde guardaremos los 12 números enteros
        List<int> numeros = new List<int>(); // Lista para guardar los 12 números enteros.

        // Pedir 12 números al usuario
        for (int i = 0; i < 12; i++) // Repite 12 veces para pedir cada número.
        {
            // Limpiar la consola antes de cada petición (cada interacción)
            Console.Clear(); // Limpia la consola antes de pedir el siguiente número.

            // Indicar qué número va (del 1 al 12)
            Console.WriteLine("Ingrese el número " + (i + 1) + " de 12:"); // Muestra qué número va (1..12).
            string? texto = Console.ReadLine(); // Lee la entrada como texto (puede ser null).
            int numero;
            // Repetir hasta que el texto sea un entero válido (TryParse no lanza excepción)
            while (!int.TryParse(texto, out numero)) // Intenta convertir; si falla, sigue pidiendo.
            {
                Console.WriteLine("Debe escribir un número entero. Intente de nuevo:"); // Aviso de error de conversión.
                texto = Console.ReadLine(); // Vuelve a leer el texto para reintentar la conversión.
            }
            numeros.Add(numero); // Agrega el número válido a la lista.
        }

        // Antes de mostrar resultados finales, limpiar la consola
        Console.Clear(); // Limpia para mostrar resultados finales sin el historial.

        // Mostrar todos los números que se ingresaron
        Console.WriteLine("Números ingresados:"); // Encabezado de la lista original.
        for (int i = 0; i < numeros.Count; i++) // Recorre la lista para imprimir cada número.
        {
            Console.WriteLine(numeros[i]); // Imprime el número en la posición i.
        }

        // Crear un HashSet con los mismos valores (no guarda duplicados)
        HashSet<int> unicos = new HashSet<int>(); // Conjunto para guardar solo valores distintos (sin duplicados).
        for (int i = 0; i < numeros.Count; i++) // Recorre la lista y va agregando al conjunto.
        {
            unicos.Add(numeros[i]); // Agrega; si es repetido, el HashSet no lo duplicará.
        }

        // Mostrar cuántos valores distintos hay (tamaño del conjunto)
        Console.WriteLine();
        Console.WriteLine("Cantidad de números únicos: " + unicos.Count); // Muestra cuántos distintos se encontraron.
    }
}
