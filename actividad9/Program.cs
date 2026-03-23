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
                    Console.Clear();
                    Servicio.CargarDatosDePrueba();
                    _datosCargados = true;
                    _conciliacionProcesada = false;
                    ConsoleMarcos.MarcoDoble("OPCIÓN 1 — CARGAR DATOS DE PRUEBA", "Colecciones inicializadas en memoria");
                    Console.WriteLine();
                    Console.WriteLine("    Estado: correcto. Puedes continuar con la opción 2.");
                    Pausa();
                    break;

                case "2":
                    Console.Clear();
                    if (!_datosCargados)
                    {
                        Console.WriteLine("Primero debes cargar datos (opcion 1).");
                        Pausa();
                        break;
                    }

                    Servicio.ProcesarConciliacion();
                    _conciliacionProcesada = true;

                    ConsoleMarcos.MarcoDoble("OPCIÓN 2 — PROCESAR CONCILIACIÓN", "Valores calculados");
                    Console.WriteLine();
                    ConsoleMarcos.MetricaAlineada("Autorizados", Servicio.Autorizados.Count);
                    ConsoleMarcos.MetricaAlineada("No autorizados", Servicio.NoAutorizados.Count);
                    ConsoleMarcos.MetricaAlineada("Ausentes", Servicio.Ausentes.Count);
                    ConsoleMarcos.MetricaAlineada("Inscripciones válidas", Servicio.Inscripciones.Count);
                    ConsoleMarcos.MetricaAlineada("Inscripciones rechazadas", Servicio.InscripcionesRechazadas.Count);
                    Pausa();
                    break;

                case "3":
                    Console.Clear();
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
                    Console.Clear();
                    Console.WriteLine("Hasta luego.");
                    salir = true;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Opcion invalida. Usa 1, 2, 3 o 4.");
                    Pausa();
                    break;
            }
        }
    }

    private static void MostrarMenu()
    {
        Console.Clear();
        ConsoleMarcos.MarcoDoble("BREAKLINE EVENTS", "Conciliación de asistentes y talleres");
        Console.WriteLine();
        Console.WriteLine("  1. Cargar datos de prueba");
        Console.WriteLine("  2. Procesar conciliación");
        Console.WriteLine("  3. Mostrar reporte consolidado");
        Console.WriteLine("  4. Salir");
        Console.WriteLine();
        ConsoleMarcos.LineaFina();
        Console.WriteLine();
        Console.Write("  Selecciona una opción: ");
    }

    private static void Pausa()
    {
        Console.WriteLine();
        ConsoleMarcos.LineaFina();
        Console.Write("  Presiona Enter para continuar...");
        Console.ReadLine();
    }
}
