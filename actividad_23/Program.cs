using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Lista donde guardaremos los 12 números enteros
        List<int> numeros = new List<int>();

        // Pedir 12 números al usuario
        for (int i = 0; i < 12; i++)
        {
            // Limpiar la consola antes de cada petición (cada interacción)
            Console.Clear();

            // Indicar qué número va (del 1 al 12)
            Console.WriteLine("Ingrese el número " + (i + 1) + " de 12:");
            string? texto = Console.ReadLine();
            int numero;
            // Repetir hasta que el texto sea un entero válido (TryParse no lanza excepción)
            while (!int.TryParse(texto, out numero))
            {
                Console.WriteLine("Debe escribir un número entero. Intente de nuevo:");
                texto = Console.ReadLine();
            }
            numeros.Add(numero);
        }

        // Antes de mostrar resultados finales, limpiar la consola
        Console.Clear();

        // Mostrar todos los números que se ingresaron
        Console.WriteLine("Números ingresados:");
        for (int i = 0; i < numeros.Count; i++)
        {
            Console.WriteLine(numeros[i]);
        }

        // Crear un HashSet con los mismos valores (no guarda duplicados)
        HashSet<int> unicos = new HashSet<int>();
        for (int i = 0; i < numeros.Count; i++)
        {
            unicos.Add(numeros[i]);
        }

        // Mostrar cuántos valores distintos hay (tamaño del conjunto)
        Console.WriteLine();
        Console.WriteLine("Cantidad de números únicos: " + unicos.Count);
    }
}
