// Actividad 26: Filtrar múltiplos de 3 en una lista

class Program // Clase principal del programa.
{
    static void Main(string[] args) // Punto de entrada.
    {
        // Lista donde guardaremos los 15 números que ingresa el usuario
        List<int> listaOriginal = new List<int>(); // Guarda los 15 números que ingresa el usuario.

        // Pedimos 15 números: en cada vuelta limpiamos la consola y pedimos el siguiente
        for (int i = 0; i < 15; i++) // Recorre 15 veces para pedir 15 números.
        {
            Console.Clear(); // Limpia la consola para cada entrada.

            // i + 1 es solo para mostrar "número 1", "número 2", etc.
            Console.Write("Ingrese el número entero " + (i + 1) + " de 15:"); // Muestra el número de turno (1..15).

            string texto = Console.ReadLine() ?? ""; // Lee la entrada como texto (si es null, usa "").
            int numero = int.Parse(texto); // Convierte el texto a entero.

            // Guardamos el número en la lista original
            listaOriginal.Add(numero); // Agrega el número a la lista original.
        }

        // Segunda lista: solo los que son múltiplos de 3 (resto de dividir entre 3 es 0)
        List<int> listaMultiplosDe3 = new List<int>(); // Lista donde guardaremos los múltiplos de 3.

        // Recorremos la lista original y evaluamos cada número
        for (int j = 0; j < listaOriginal.Count; j++) // Recorre toda la lista original.
        {
            int valor = listaOriginal[j]; // Toma el valor en la posición j.

            if (valor % 3 == 0) // Un número es múltiplo de 3 si al dividir entre 3 el residuo es 0.
            {
                listaMultiplosDe3.Add(valor); // Agrega el número a la lista de múltiplos.
            }
        }

        // Antes de mostrar resultados, limpiamos la consola
        Console.Clear(); // Limpia antes de imprimir las listas.

        Console.WriteLine("--- Lista original (15 números) ---"); // Encabezado de la lista original.
        for (int k = 0; k < listaOriginal.Count; k++) // Recorre la lista original para imprimirla.
        {
            Console.WriteLine(listaOriginal[k]); // Imprime el elemento en posición k.
        }

        Console.WriteLine();
        Console.WriteLine("--- Lista de múltiplos de 3 ---"); // Encabezado de la lista filtrada.
        for (int m = 0; m < listaMultiplosDe3.Count; m++) // Recorre la lista de múltiplos para imprimirla.
        {
            Console.WriteLine(listaMultiplosDe3[m]); // Imprime el múltiplo de 3 en posición m.
        }
    }
}
