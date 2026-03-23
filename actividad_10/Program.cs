
using System;
using System.Collections.Generic;

class Program
{
    // Punto de entrada: pide correos en bucle hasta que escriban "salir".
    static void Main()
    {
        // HashSet guarda textos sin repetir (no admite duplicados).
        HashSet<string> correos = new HashSet<string>();

        while (true)
        {
            Console.Clear();
            MostrarPantallaPedirCorreo();

            // ReadLine puede devolver null; lo pasamos a string seguro.
            string entrada = "";
            string? temporal = Console.ReadLine();

            if (temporal != null)
            {
                entrada = temporal;
            }

            // Palabra clave para cerrar el registro (no se guarda como correo).
            if (entrada == "salir")
            {
                break;
            }

            // Add devuelve true si era nuevo, false si ya estaba en el conjunto.
            bool seAgrego = correos.Add(entrada);
            MostrarResultado(seAgrego);

            Console.WriteLine();
            Console.WriteLine("  ─── Pulsa Enter para continuar ───");
            Console.ReadLine();
        }

        Console.Clear();
        MostrarListaFinal(correos);
    }

    // Dibuja el encabezado y el texto donde el usuario escribe el correo.
    static void MostrarPantallaPedirCorreo()
    {
        Console.WriteLine();
        Console.WriteLine("  ╔════════════════════════════════════════════╗");
        Console.WriteLine("  ║     REGISTRO DE CORREOS ELECTRÓNICOS       ║");
        Console.WriteLine("  ╠════════════════════════════════════════════╣");
        Console.WriteLine("  ║  Opción para terminar: escribe  salir      ║");
        Console.WriteLine("  ║    (se mostrará la lista y se cerrará)     ║");
        Console.WriteLine("  ╚════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.Write("  » Ingrese un correo: ");
    }

    // Muestra si el correo se agregó o si ya existía (mismo texto que pide la actividad).
    static void MostrarResultado(bool seAgrego)
    {
        Console.WriteLine();
        if (seAgrego)
        {
            Console.WriteLine("  ┌────────────────────────────────────────┐");
            Console.WriteLine("  │  ✓  Correo agregado correctamente.    │");
            Console.WriteLine("  └────────────────────────────────────────┘");
        }
        else
        {
            Console.WriteLine("  ┌────────────────────────────────────────┐");
            Console.WriteLine("  │  !  El correo ya estaba registrado.   │");
            Console.WriteLine("  └────────────────────────────────────────┘");
        }
    }

    // Lista todos los correos guardados en el HashSet.
    static void MostrarListaFinal(HashSet<string> correos)
    {
        Console.WriteLine();
        Console.WriteLine("  ╔════════════════════════════════════════════╗");
        Console.WriteLine("  ║            LISTA FINAL                     ║");
        Console.WriteLine("  ╚════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("  Correos registrados:");

        foreach (string correo in correos)
        {
            Console.WriteLine("  - " + correo);
        }

        Console.WriteLine();
    }
}
