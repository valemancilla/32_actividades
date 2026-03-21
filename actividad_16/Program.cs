using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Clear();

        List<int> numeros = new List<int>();

        Console.WriteLine("Ingrese 8 números:");
        for (int i = 0; i < 8; i++)
        {
            Console.Write($"Número {i + 1}: ");
            numeros.Add(int.Parse(Console.ReadLine()!));
        }

        int mayor = numeros[0];
        foreach (int n in numeros)
        {
            if (n > mayor)
                mayor = n;
        }

        int menor = numeros[0];
        foreach (int n in numeros)
        {
            if (n < menor)
                menor = n;
        }

        int suma = 0;
        foreach (int n in numeros)
        {
            suma += n;
        }

        double promedio = suma / 8.0;

        Console.Clear();
        Console.WriteLine("--- Resultados ---");
        Console.WriteLine($"Número mayor: {mayor}");
        Console.WriteLine($"Número menor: {menor}");
        Console.WriteLine($"Promedio: {promedio}");
    }
}
