using System; // Permite usar clases del sistema como `Console` para entrada y salida.
using System.Collections.Generic; // Permite usar colecciones genéricas como `List<T>`.

class Program // Define la clase principal del programa.
{
    static void Main() // Punto de entrada del programa (se ejecuta primero).
    {
        Console.Clear(); // Limpia la consola para que el usuario vea una pantalla limpia.

        List<int> numeros = new List<int>(); // Crea una lista para almacenar los 8 números enteros.

        Console.WriteLine("Ingrese 8 números:"); // Muestra un mensaje pidiendo los datos al usuario.
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"Número {i + 1}: "); // Muestra el número de turno (1 a 8) esperando la entrada.
            numeros.Add(int.Parse(Console.ReadLine()!)); // Lee la entrada del usuario y la convierte a entero para guardarla.
        }

        int mayor = numeros[0]; // Inicializa `mayor` con el primer número de la lista.
        foreach (int n in numeros)
        {
            if (n > mayor) // Si el número actual es mayor que el registrado hasta ahora...
                mayor = n; // ...actualiza el valor de `mayor`.
        }

        int menor = numeros[0]; // Inicializa `menor` con el primer número de la lista.
        foreach (int n in numeros)
        {
            if (n < menor) // Si el número actual es menor que el registrado hasta ahora...
                menor = n; // ...actualiza el valor de `menor`.
        }

        int suma = 0; // Inicia la variable donde se irá acumulando la suma.
        foreach (int n in numeros)
        {
            suma += n; // Suma cada número acumulándolo en `suma`.
        }

        double promedio = suma / 8.0; // Calcula el promedio usando 8.0 para obtener división decimal.

        Console.Clear(); // Limpia la consola nuevamente antes de mostrar los resultados.
        Console.WriteLine("--- Resultados ---"); // Encabezado para organizar la salida.
        Console.WriteLine($"Número mayor: {mayor}"); // Muestra el mayor valor encontrado.
        Console.WriteLine($"Número menor: {menor}"); // Muestra el menor valor encontrado.
        Console.WriteLine($"Promedio: {promedio}"); // Muestra el promedio de los 8 números.
    }
}
