using System; // Para usar tipos base y la clase Console.
using System.Collections.Generic; // Para usar colecciones como List<T>.
using System.IO; // Para usar IOException en el catch.

class Program // Clase principal que contiene el menú y la lógica.
{
    static readonly List<string> FilasTabla = new() // Lista fija con las filas “de ejemplo” de la tabla.
    {
        "1 | Juan Pérez | Madrid", // Fila 1 con datos de la tabla.
        "2 | Ana López | Barcelona", // Fila 2 con datos de la tabla.
        "3 | Pedro Jiménez | Valencia" // Fila 3 con datos de la tabla.
    };

    static void Main() // Punto de entrada del programa.
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Asegura que se impriman correctamente caracteres como acentos.

        while (true) // Ciclo infinito: termina solo con el `break`.
        {
            LimpiarConsola(); // Limpia la consola para mostrar el menú.
            MostrarMenu(); // Muestra el menú en pantalla.
            Console.Write("Seleccione una opción: "); // Pide al usuario su elección.
            string? opcion = Console.ReadLine()?.Trim(); // Lee la opción y elimina espacios; puede ser null si el input falla.

            if (opcion == "3") // Opción 3: salir.
            {
                LimpiarConsola(); // Limpia antes del mensaje final.
                Console.WriteLine("Fin del programa."); // Mensaje de finalización.
                break; // Sale del ciclo y termina el programa.
            }

            if (opcion == "1") // Opción 1: mostrar todas las filas.
            {
                LimpiarConsola(); // Limpia antes de imprimir.
                Console.WriteLine("Datos de la tabla (puede buscar en cualquier parte del texto de cada fila):\n"); // Encabezado de las filas.
                foreach (string fila in FilasTabla) // Recorre cada fila de la lista.
                    Console.WriteLine(fila); // Imprime la fila completa.
                Console.WriteLine("\nPulse Enter para volver al menú..."); // Pide presionar Enter.
                Console.ReadLine(); // Espera la entrada del usuario.
                continue; // Vuelve a mostrar el menú desde el inicio del while.
            }

            if (opcion == "2") // Opción 2: filtrar por texto.
            {
                LimpiarConsola(); // Limpia para mostrar explicación y pedir búsqueda.
                Console.WriteLine("Filtrado: coincidencia parcial y sin distinguir mayúsculas/minúsculas."); // Explica la regla del filtrado.
                Console.WriteLine("Ejemplo: J → filas 1 y 3; Ju → solo la fila 1.\n"); // Da ejemplo para entender coincidencia parcial.
                Console.Write("Escriba un texto de búsqueda: "); // Pide el texto a buscar.
                string? textoBusqueda = Console.ReadLine(); // Lee la búsqueda; puede ser null.
                LimpiarConsola(); // Limpia antes de mostrar resultados.
                Console.WriteLine("Resultado:\n"); // Encabezado de resultados.
                int encontradas = FilterTable(FilasTabla, textoBusqueda ?? string.Empty); // Llama al filtro usando string vacío si era null.
                if (encontradas == 0) // Si no hay coincidencias...
                    Console.WriteLine("No hay resultados: ninguna fila contiene ese texto."); // Informa que no se encontró nada.
                Console.WriteLine("\nPulse Enter para volver al menú..."); // Pausa para volver.
                Console.ReadLine(); // Espera Enter.
                continue; // Regresa al menú.
            }

            LimpiarConsola(); // Limpia antes de mostrar error.
            Console.WriteLine("Opción no válida. Use 1, 2 o 3."); // Mensaje si la opción no es válida.
            Console.WriteLine("\nPulse Enter para continuar..."); // Instrucción de pausa.
            Console.ReadLine(); // Espera antes de reintentar.
        }
    }

    static void MostrarMenu() // Imprime las opciones del menú.
    {
        Console.WriteLine("=== Filtrar datos en consola ===\n"); // Encabezado.
        Console.WriteLine("1. Ver filas de la tabla (qué datos hay)"); // Opción 1.
        Console.WriteLine("2. Filtrar por texto de búsqueda"); // Opción 2.
        Console.WriteLine("3. Salir\n"); // Opción 3.
    }

    static int FilterTable(List<string> filas, string textoBusqueda) // Devuelve cuántas filas coinciden.
    {
        textoBusqueda ??= string.Empty; // Si viniera null, lo convertimos a string vacío (seguridad).

        int coincidencias = 0; // Contador de coincidencias.
        foreach (string fila in filas) // Recorre cada fila.
        {
            if (fila.Contains(textoBusqueda, StringComparison.OrdinalIgnoreCase)) // Busca texto parcial sin distinguir mayúsculas/minúsculas.
            {
                Console.WriteLine(fila); // Imprime la fila que coincide.
                coincidencias++; // Incrementa el contador.
            }
        }

        return coincidencias; // Devuelve cuántas coincidieron.
    }

    static void LimpiarConsola() // Limpia la consola, pero evita que un error termine el programa.
    {
        try // Intentamos limpiar.
        {
            Console.Clear(); // Borra el contenido visible.
        }
        catch (IOException) // Si ocurre un error de IO...
        {
            // No hacemos nada: seguimos el programa.
        }
    }
}
