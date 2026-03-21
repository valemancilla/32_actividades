using System;
using System.Collections.Generic;



class Program
{
    static void Main()
    {
        // Conjunto para guardar correos únicos (no admite duplicados)
        HashSet<string> correos = new HashSet<string>();

        // Se repite hasta que el usuario escriba "salir"
        while (true)
        {
            // Pantalla ordenada en cada vuelta del ciclo
            Console.Clear();

            Console.WriteLine("=== Registro de correos ===");
            Console.WriteLine("Escriba un correo electrónico.");
            Console.WriteLine("Escriba salir para terminar.");
            Console.WriteLine();
            Console.Write("Correo: ");

            // Leer lo que escribió el usuario (si es null, usamos cadena vacía)
            string correo = Console.ReadLine() ?? "";

            // 3) Validar si quiere salir
            if (correo == "salir")
            {
                Console.WriteLine();
                Console.WriteLine("Programa finalizado. ¡Hasta luego!");
                break;
            }

            // 4) Verificar si el correo ya está en el conjunto
            if (correos.Contains(correo))
            {
                Console.WriteLine();
                Console.WriteLine("Ese correo ya está registrado (está repetido).");
            }
            else
            {
                // 5) Guardar solo si no existía
                correos.Add(correo);
                Console.WriteLine();
                Console.WriteLine("Correo registrado correctamente.");
            }

            // Pausa para poder leer el mensaje antes de la siguiente limpieza
            Console.WriteLine();
            Console.WriteLine("Pulse Enter para continuar...");
            Console.ReadLine();
        }
    }
}
