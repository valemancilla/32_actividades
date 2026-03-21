#nullable disable
using System;
using System.Collections.Generic;

internal class Program
{
    private const double FinIngreso = -1;

    private static void Main(string[] args)
    {
        List<double> notas = new List<double>();

        RefrescarPantallaIngreso(notas);

        bool terminarIngreso = false;
        while (!terminarIngreso)
        {
            Console.Write("Ingrese una nota: ");
            string linea = Console.ReadLine();

            if (linea == null || linea.Trim().Length == 0)
            {
                Console.WriteLine("Debe ingresar un valor numérico.");
            }
            else
            {
                double valor;
                if (!double.TryParse(linea, out valor))
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número decimal válido.");
                }
                else if (valor == FinIngreso)
                {
                    Console.Clear();
                    terminarIngreso = true;
                }
                else
                {
                    notas.Add(valor);
                    RefrescarPantallaIngreso(notas);
                }
            }
        }

        Console.WriteLine();
        if (notas.Count == 0)
        {
            Console.WriteLine("No se registraron notas.");
            return;
        }

        Console.WriteLine("Todas las notas:");
        int n = 1;
        foreach (double nota in notas)
        {
            Console.WriteLine($"  {n}. {nota}");
            n++;
        }

        double suma = 0;
        foreach (double nota in notas)
        {
            suma += nota;
        }

        double promedio = suma / notas.Count;
        Console.WriteLine();
        Console.WriteLine($"Promedio: {promedio:F2}");

        int superioresOIgualesA3 = 0;
        foreach (double nota in notas)
        {
            if (nota >= 3.0)
            {
                superioresOIgualesA3++;
            }
        }

        Console.WriteLine(
            $"Cantidad de notas superiores o iguales a 3.0: {superioresOIgualesA3}");
    }

    private static void RefrescarPantallaIngreso(List<double> notas)
    {
        Console.Clear();
        Console.WriteLine("Registro de notas. Escriba -1 para terminar el ingreso.");
        Console.WriteLine();

        if (notas.Count > 0)
        {
            Console.WriteLine("Notas en la lista:");
            int i = 1;
            foreach (double nota in notas)
            {
                Console.WriteLine($"  {i}. {nota}");
                i++;
            }

            Console.WriteLine();
        }
    }
}
