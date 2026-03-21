class Program
{
    static void Main()
    {
        HashSet<string> palabrasUnicas = new HashSet<string>();

        PedirPalabras(palabrasUnicas);
        MostrarResultados(palabrasUnicas);
    }

    static void PedirPalabras(HashSet<string> palabrasUnicas)
    {
        Console.Clear();

        Console.WriteLine("Ingresa 8 palabras (una por línea):");
        Console.WriteLine();

        for (int i = 1; i <= 8; i++)
        {
            Console.Write($"Palabra {i}: ");
            string palabra = Console.ReadLine() ?? "";
            palabrasUnicas.Add(palabra);
        }
    }

    static void MostrarResultados(HashSet<string> palabrasUnicas)
    {
        Console.Clear();

        Console.WriteLine($"Cantidad de palabras únicas: {palabrasUnicas.Count}");
        Console.WriteLine();
        Console.WriteLine("Lista de palabras únicas:");

        foreach (string palabra in palabrasUnicas)
        {
            Console.WriteLine(palabra);
        }
    }
}
