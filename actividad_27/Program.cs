class Program // Clase principal del programa.
{
    static void Main() // Punto de entrada.
    {
        HashSet<string> codigosEstudiantes = new HashSet<string>(); // Guarda códigos únicos (evita duplicados).

        for (int i = 0; i < 10; i++) // Repite para ingresar 10 códigos (i = 0..9).
        {
            Console.Clear(); // Limpia la consola antes de capturar el código del estudiante.

            string codigo = ""; // Variable para almacenar el código ingresado.
            while (true) // Ciclo de validación hasta que el código sea válido (no vacío).
            {
                Console.Write("Ingrese el código del estudiante (" + (i + 1) + " de 10):"); // Pide el código indicando el turno.
                codigo = (Console.ReadLine() ?? "").Trim(); // Lee y limpia el texto; si es null, usa "".

                if (codigo == "") // Si el código está vacío...
                {
                    Console.Clear(); // Limpia para mostrar el mensaje del error sin ruido.
                    Console.WriteLine("Debe ingresar un código. No puede dejar el campo vacío."); // Mensaje de validación.
                    continue; // Vuelve a intentar el mismo estudiante.
                }

                break; // Sale del `while` interno porque el código ya es válido.
            }

            if (codigosEstudiantes.Contains(codigo)) // Si el HashSet ya contiene ese código...
            {
                Console.WriteLine("Ese código ya fue registrado."); // Informa que se detectó un duplicado.
            }
            else
            {
                codigosEstudiantes.Add(codigo); // Agrega el nuevo código (solo si no existía).
            }
        }

        Console.Clear(); // Limpia para mostrar el resumen final.
        Console.WriteLine("¿Desea ver todos los códigos agregados? (s/n):"); // Pregunta si se imprimen todos.
        string opcion = Console.ReadLine() ?? ""; // Lee la respuesta como texto.

        if (opcion == "s" || opcion == "S") // Si la opción es sí (s/S)...
        {
            Console.Clear(); // Limpia antes de imprimir la lista.
            Console.WriteLine("======Códigos agregados:=========="); // Encabezado de la lista.
            foreach (string c in codigosEstudiantes) // Recorre todos los códigos únicos guardados.
            {
                Console.WriteLine(c); // Imprime cada código.
            }
        }
    }
}
