using System; // Provee la clase `Console` para entrada/salida.
using System.Collections.Generic; // Provee colecciones genéricas como `HashSet<T>`.



class Program // Clase principal del programa.
{
    static void Main() // Punto de entrada del programa.
    {
        // Conjunto para guardar correos únicos (no admite duplicados)
        HashSet<string> correos = new HashSet<string>(); // Guarda correos sin repetición.

        // Se repite hasta que el usuario escriba "salir"
        while (true) // Ciclo infinito; terminará con `break` cuando el usuario escriba "salir".
        {
            // Pantalla ordenada en cada vuelta del ciclo
            Console.Clear(); // Limpia la consola antes de mostrar el formulario del ciclo.

            Console.WriteLine("=== Registro de correos ==="); // Título del programa.
            Console.WriteLine("Escriba un correo electrónico."); // Indica qué tipo de dato ingresar.
            Console.WriteLine("Escriba salir para terminar."); // Indica cómo salir del programa.
            Console.WriteLine(); // Línea en blanco para separar.
            Console.Write("Correo: "); // Prompt para que el usuario escriba el correo.

            // Leer lo que escribió el usuario (si es null, usamos cadena vacía)
            string correo = Console.ReadLine() ?? ""; // Lee la entrada; si es null usa cadena vacía.

            // 3) Validar si quiere salir
            if (correo == "salir") // Si el usuario escribió "salir", terminamos.
            {
                Console.WriteLine(); // Separación visual.
                Console.WriteLine("Programa finalizado. ¡Hasta luego!"); // Mensaje final antes de salir.
                break; // Sale del `while`.
            }

            // 4) Verificar si el correo ya está en el conjunto
            if (correos.Contains(correo)) // Si el HashSet ya contiene ese correo...
            {
                Console.WriteLine(); // Separación visual.
                Console.WriteLine("Ese correo ya está registrado (está repetido)."); // Informa duplicado.
            }
            else // Si no existe todavía...
            {
                // 5) Guardar solo si no existía
                correos.Add(correo); // Se agrega el correo al conjunto (sin duplicados).
                Console.WriteLine(); // Separación visual.
                Console.WriteLine("Correo registrado correctamente."); // Confirmación de registro.
            }

            // Pausa para poder leer el mensaje antes de la siguiente limpieza
            Console.WriteLine(); // Línea en blanco antes de pausar.
            Console.WriteLine("Pulse Enter para continuar..."); // Instrucción para esperar.
            Console.ReadLine(); // Espera a que el usuario presione Enter.
        }
    }
}
