// Actividad 26: Filtrar múltiplos de 3 en una lista

class Program
{
    static void Main(string[] args)
    {
        // Lista donde guardaremos los 15 números que ingresa el usuario
        List<int> listaOriginal = new List<int>();

        // Pedimos 15 números: en cada vuelta limpiamos la consola y pedimos el siguiente
        for (int i = 0; i < 15; i++)
        {
            Console.Clear();

            // i + 1 es solo para mostrar "número 1", "número 2", etc.
            Console.Write("Ingrese el número entero " + (i + 1) + " de 15:");

            string texto = Console.ReadLine() ?? "";
            int numero = int.Parse(texto);

            // Guardamos el número en la lista original
            listaOriginal.Add(numero);
        }

        // Segunda lista: solo los que son múltiplos de 3 (resto de dividir entre 3 es 0)
        List<int> listaMultiplosDe3 = new List<int>();

        // Recorremos la lista original y evaluamos cada número
        for (int j = 0; j < listaOriginal.Count; j++)
        {
            int valor = listaOriginal[j];

            if (valor % 3 == 0)
            {
                listaMultiplosDe3.Add(valor);
            }
        }

        // Antes de mostrar resultados, limpiamos la consola
        Console.Clear();

        Console.WriteLine("--- Lista original (15 números) ---");
        for (int k = 0; k < listaOriginal.Count; k++)
        {
            Console.WriteLine(listaOriginal[k]);
        }

        Console.WriteLine();
        Console.WriteLine("--- Lista de múltiplos de 3 ---");
        for (int m = 0; m < listaMultiplosDe3.Count; m++)
        {
            Console.WriteLine(listaMultiplosDe3[m]);
        }
    }
}
