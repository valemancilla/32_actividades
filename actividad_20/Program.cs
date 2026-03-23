internal class Program // Clase que contiene el menú y la lógica del programa.
{
    private static void Main(string[] args) // Punto de entrada del programa.
    {
        bool salir = false; // Bandera para controlar si el programa termina.

        do // Ejecuta el bloque al menos una vez.
        {
            Console.Clear(); // Limpia la consola para mostrar el menú limpio.
            Console.WriteLine("\n--- MENÚ ---"); // Muestra el encabezado del menú.
            Console.WriteLine("1. Saludar"); // Opción 1: saludar.
            Console.WriteLine("2. Mostrar fecha simulada"); // Opción 2: mostrar fecha.
            Console.WriteLine("3. Calcular cuadrado de un número"); // Opción 3: calcular cuadrado.
            Console.WriteLine("4. Salir"); // Opción 4: terminar.
            Console.Write("Opción: "); // Pide al usuario que elija una opción.

            var lineaOpcion = Console.ReadLine(); // Lee la opción como texto.
            string opcion = lineaOpcion == null ? "" : lineaOpcion.Trim(); // Si es null usa "", si no elimina espacios.
            Console.Clear(); // Limpia para que la salida de la opción no se mezcle con el menú.

            switch (opcion) // Evalúa la opción elegida y ejecuta el bloque correspondiente.
            {
                case "1": // Si el usuario escribe "1"...
                    Console.WriteLine("¡Hola! Un gusto saludarte."); // ...muestra el saludo.
                    break; // Sale del switch para no ejecutar más casos.

                case "2": // Si el usuario escribe "2"...
                    DateTime fechaSimulada = new DateTime(2026, 6, 15, 14, 30, 0); // Crea una fecha fija (simulada).
                    Console.WriteLine($"Fecha simulada: {fechaSimulada:dddd, dd MMMM yyyy, HH:mm}"); // Muestra la fecha formateada.
                    break; // Sale del switch.

                case "3": // Si el usuario escribe "3"...
                    Console.Write("Ingresa un número: "); // Pide un número entero.
                    var lineaNumero = Console.ReadLine(); // Lee el número como texto.
                    string entradaNumero = lineaNumero == null ? "" : lineaNumero.Trim(); // Normaliza el texto (evita null y quita espacios).
                    Console.Clear(); // Limpia para mostrar solo el resultado del cálculo.
                    int numero; // Variable donde se guardará el número convertido.
                    if (int.TryParse(entradaNumero, out numero)) // Intenta convertir el texto a entero.
                    {
                        int cuadrado = numero * numero; // Calcula el cuadrado del número.
                        Console.WriteLine($"El cuadrado de {numero} es {cuadrado}."); // Muestra el resultado.
                    }
                    else
                    {
                        Console.WriteLine("No ingresaste un número entero válido."); // Mensaje si la conversión falla.
                    }
                    break; // Sale del switch.

                case "4": // Si el usuario escribe "4"...
                    Console.WriteLine("¡Hasta luego!"); // Despide al usuario.
                    salir = true; // Activa la bandera para terminar el do-while.
                    break; // Sale del switch.

                default: // Si no coincide con ninguna opción válida...
                    Console.WriteLine("Opción inválida. Elige un número del 1 al 4."); // Muestra error y vuelve al menú.
                    break; // Sale del switch.
            }

            if (!salir) // Si todavía no se ha pedido salir...
            {
                Console.WriteLine("\nPulse una tecla para continuar..."); // Indica que avance.
                Console.ReadKey(true); // Espera una tecla sin mostrarla (true oculta).
            }
        } while (!salir); // Repite el menú mientras salir sea false.
    }
}
