internal class Program
{
    private static void Main(string[] args)
    {
        bool salir = false;

        do
        {
            Console.Clear();
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Saludar");
            Console.WriteLine("2. Mostrar fecha simulada");
            Console.WriteLine("3. Calcular cuadrado de un número");
            Console.WriteLine("4. Salir");
            Console.Write("Opción: ");

            var lineaOpcion = Console.ReadLine();
            string opcion = lineaOpcion == null ? "" : lineaOpcion.Trim();
            Console.Clear();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("¡Hola! Un gusto saludarte.");
                    break;

                case "2":
                    DateTime fechaSimulada = new DateTime(2026, 6, 15, 14, 30, 0);
                    Console.WriteLine($"Fecha simulada: {fechaSimulada:dddd, dd MMMM yyyy, HH:mm}");
                    break;

                case "3":
                    Console.Write("Ingresa un número: ");
                    var lineaNumero = Console.ReadLine();
                    string entradaNumero = lineaNumero == null ? "" : lineaNumero.Trim();
                    Console.Clear();
                    int numero;
                    if (int.TryParse(entradaNumero, out numero))
                    {
                        int cuadrado = numero * numero;
                        Console.WriteLine($"El cuadrado de {numero} es {cuadrado}.");
                    }
                    else
                    {
                        Console.WriteLine("No ingresaste un número entero válido.");
                    }
                    break;

                case "4":
                    Console.WriteLine("¡Hasta luego!");
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida. Elige un número del 1 al 4.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPulse una tecla para continuar...");
                Console.ReadKey(true);
            }
        } while (!salir);
    }
}
