using BreakLineEvents.Services;
using BreakLineEvents.Utils;

namespace BreakLineEvents;

internal static class Program
{
    private static readonly ServicioConciliacion Servicio = new();
    private static bool _datosCargados;
    private static bool _conciliacionProcesada;

    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            string opcion = (Console.ReadLine() ?? string.Empty).Trim();

            switch (opcion)
            {
                case "1":
                    ConsoleUi.ClearScreen();
                    Servicio.CargarDatosDePrueba();
                    _datosCargados = true;
                    _conciliacionProcesada = false;
                    Pausa();
                    break;

                case "2":
                    ConsoleUi.ClearScreen();
                    if (!_datosCargados)
                    {
                        Console.WriteLine("Primero debes cargar datos (opcion 1).");
                        Pausa();
                        break;
                    }

                    Servicio.ProcesarConciliacion();
                    _conciliacionProcesada = true;
                    Pausa();
                    break;

                case "3":
                    ConsoleUi.ClearScreen();
                    if (!_datosCargados)
                    {
                        Console.WriteLine("Primero debes cargar datos (opcion 1).");
                        Pausa();
                        break;
                    }

                    if (!_conciliacionProcesada)
                    {
                        Console.WriteLine("Primero debes procesar la conciliacion (opcion 2).");
                        Pausa();
                        break;
                    }

                    ReporteService.MostrarReporte(Servicio);
                    Pausa();
                    break;

                case "4":
                    ConsoleUi.ClearScreen();
                    Console.WriteLine("Hasta luego.");
                    salir = true;
                    break;

                default:
                    ConsoleUi.ClearScreen();
                    Console.WriteLine("Opcion invalida. Usa 1, 2, 3 o 4.");
                    Pausa();
                    break;
            }
        }
    }

    private static void MostrarMenu()
    {
        ConsoleUi.ClearScreen();
        Console.WriteLine("================================================");
        Console.WriteLine(" BREAKLINE EVENTS - Sistema de Conciliacion ");
        Console.WriteLine("================================================");
        Console.WriteLine();
        Console.WriteLine("1. Cargar datos de prueba");
        Console.WriteLine("2. Procesar conciliacion");
        Console.WriteLine("3. Mostrar reporte consolidado");
        Console.WriteLine("4. Salir");
        Console.WriteLine();
        Console.Write("Selecciona una opcion: ");
    }

    private static void Pausa()
    {
        Console.WriteLine();
        Console.Write("Presiona Enter para continuar...");
        Console.ReadLine();
    }
}
