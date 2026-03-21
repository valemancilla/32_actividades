using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static readonly List<string> FilasTabla = new()
    {
        "1 | Juan Pérez | Madrid",
        "2 | Ana López | Barcelona",
        "3 | Pedro Jiménez | Valencia"
    };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            LimpiarConsola();
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string? opcion = Console.ReadLine()?.Trim();

            if (opcion == "3")
            {
                LimpiarConsola();
                Console.WriteLine("Fin del programa.");
                break;
            }

            if (opcion == "1")
            {
                LimpiarConsola();
                Console.WriteLine("Datos de la tabla (puede buscar en cualquier parte del texto de cada fila):\n");
                foreach (string fila in FilasTabla)
                    Console.WriteLine(fila);
                Console.WriteLine("\nPulse Enter para volver al menú...");
                Console.ReadLine();
                continue;
            }

            if (opcion == "2")
            {
                LimpiarConsola();
                Console.WriteLine("Filtrado: coincidencia parcial y sin distinguir mayúsculas/minúsculas.");
                Console.WriteLine("Ejemplo: J → filas 1 y 3; Ju → solo la fila 1.\n");
                Console.Write("Escriba un texto de búsqueda: ");
                string? textoBusqueda = Console.ReadLine();
                LimpiarConsola();
                Console.WriteLine("Resultado:\n");
                int encontradas = FilterTable(FilasTabla, textoBusqueda ?? string.Empty);
                if (encontradas == 0)
                    Console.WriteLine("No hay resultados: ninguna fila contiene ese texto.");
                Console.WriteLine("\nPulse Enter para volver al menú...");
                Console.ReadLine();
                continue;
            }

            LimpiarConsola();
            Console.WriteLine("Opción no válida. Use 1, 2 o 3.");
            Console.WriteLine("\nPulse Enter para continuar...");
            Console.ReadLine();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("=== Filtrar datos en consola ===\n");
        Console.WriteLine("1. Ver filas de la tabla (qué datos hay)");
        Console.WriteLine("2. Filtrar por texto de búsqueda");
        Console.WriteLine("3. Salir\n");
    }

    static int FilterTable(List<string> filas, string textoBusqueda)
    {
        textoBusqueda ??= string.Empty;

        int coincidencias = 0;
        foreach (string fila in filas)
        {
            if (fila.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(fila);
                coincidencias++;
            }
        }

        return coincidencias;
    }

    static void LimpiarConsola()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // Consola integrada de VS Code / Cursor a veces no permite borrar el búfer.
        }
    }
}
