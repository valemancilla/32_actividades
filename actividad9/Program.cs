using BreakLineEvents.Services; // Contiene servicios de negocio usados por el programa.
using BreakLineEvents.Utils; // Contiene utilidades para mostrar marcos/formatos en consola.

namespace BreakLineEvents; // Espacio de nombres del proyecto.

internal static class Program // Clase principal del programa (estática porque solo tiene métodos y campos auxiliares).
{
    private static readonly ServicioConciliacion Servicio = new(); // Instancia única del servicio que realiza el procesamiento.
    private static bool _datosCargados; // Indica si ya se cargaron datos de prueba.
    private static bool _conciliacionProcesada; // Indica si ya se procesó la conciliación.

    private static void Main() // Punto de entrada del programa.
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Asegura salida con caracteres UTF-8.

        bool salir = false; // Bandera para controlar cuándo salir del menú principal.
        while (!salir) // Ciclo que se repite hasta que el usuario elija salir.
        {
            MostrarMenu(); // Dibuja el menú en pantalla.
            string opcion = (Console.ReadLine() ?? string.Empty).Trim(); // Lee opción, evita null y quita espacios.

            switch (opcion) // Ejecuta el caso según la opción elegida.
            {
                case "1":
                    Console.Clear(); // Limpia antes de iniciar la opción 1.
                    Servicio.CargarDatosDePrueba(); // Carga datos ficticios para trabajar.
                    _datosCargados = true; // Marca que los datos ya están listos.
                    _conciliacionProcesada = false; // Reinicia la marca del procesamiento (aún no se procesó).
                    ConsoleMarcos.MarcoDoble("OPCIÓN 1 — CARGAR DATOS DE PRUEBA", "Colecciones inicializadas en memoria"); // Muestra un marco visual.
                    Console.WriteLine(); // Salto de línea.
                    Console.WriteLine("    Estado: correcto. Puedes continuar con la opción 2."); // Mensaje de estado.
                    Pausa(); // Espera a que el usuario presione Enter.
                    break; // Sale del caso y vuelve al menú (while continúa).

                case "2":
                    Console.Clear(); // Limpia antes de la opción 2.
                    if (!_datosCargados) // Verifica prerequisito: primero se deben cargar datos.
                    {
                        Console.WriteLine("Primero debes cargar datos (opcion 1)."); // Aviso al usuario.
                        Pausa(); // Pausa para que lea el mensaje.
                        break; // Vuelve al menú principal.
                    }

                    Servicio.ProcesarConciliacion(); // Procesa la conciliación usando los datos cargados.
                    _conciliacionProcesada = true; // Marca que el procesamiento se completó.

                    ConsoleMarcos.MarcoDoble("OPCIÓN 2 — PROCESAR CONCILIACIÓN", "Valores calculados"); // Muestra encabezado.
                    Console.WriteLine(); // Salto de línea.
                    ConsoleMarcos.MetricaAlineada("Autorizados", Servicio.Autorizados.Count); // Muestra métricas calculadas.
                    ConsoleMarcos.MetricaAlineada("No autorizados", Servicio.NoAutorizados.Count); // Muestra métricas calculadas.
                    ConsoleMarcos.MetricaAlineada("Ausentes", Servicio.Ausentes.Count); // Muestra métricas calculadas.
                    ConsoleMarcos.MetricaAlineada("Inscripciones válidas", Servicio.Inscripciones.Count); // Muestra métricas calculadas.
                    ConsoleMarcos.MetricaAlineada("Inscripciones rechazadas", Servicio.InscripcionesRechazadas.Count); // Muestra métricas calculadas.
                    Pausa(); // Pausa antes de volver al menú.
                    break; // Sale del caso y vuelve al menú (while continúa).

                case "3":
                    Console.Clear(); // Limpia antes de mostrar reporte.
                    if (!_datosCargados) // Verifica prerequisito de datos cargados.
                    {
                        Console.WriteLine("Primero debes cargar datos (opcion 1)."); // Aviso de prerequisito.
                        Pausa(); // Pausa para leer.
                        break; // Vuelve al menú.
                    }

                    if (!_conciliacionProcesada) // Verifica prerequisito de procesamiento previo.
                    {
                        Console.WriteLine("Primero debes procesar la conciliacion (opcion 2)."); // Aviso de prerequisito.
                        Pausa(); // Pausa para leer.
                        break; // Vuelve al menú.
                    }

                    ReporteService.MostrarReporte(Servicio); // Genera y muestra el reporte consolidado.
                    Pausa(); // Pausa final de la opción 3.
                    break; // Sale del caso y vuelve al menú (while continúa).

                case "4":
                    Console.Clear(); // Limpia antes del mensaje final.
                    Console.WriteLine("Hasta luego."); // Mensaje de despedida.
                    salir = true; // Cambia la bandera para salir del while.
                    break; // Termina el switch.

                default:
                    Console.Clear(); // Limpia para mostrar error claro.
                    Console.WriteLine("Opcion invalida. Usa 1, 2, 3 o 4."); // Mensaje de opción inválida.
                    Pausa(); // Pausa para que el usuario lea.
                    break; // Vuelve al menú.
            }
        }
    }

    private static void MostrarMenu() // Imprime el menú principal.
    {
        Console.Clear(); // Limpia la consola antes de mostrar menú.
        ConsoleMarcos.MarcoDoble("BREAKLINE EVENTS", "Conciliación de asistentes y talleres"); // Encabezado visual.
        Console.WriteLine(); // Salto de línea.
        Console.WriteLine("  1. Cargar datos de prueba"); // Opción 1.
        Console.WriteLine("  2. Procesar conciliación"); // Opción 2.
        Console.WriteLine("  3. Mostrar reporte consolidado"); // Opción 3.
        Console.WriteLine("  4. Salir"); // Opción 4.
        Console.WriteLine(); // Salto de línea.
        ConsoleMarcos.LineaFina(); // Línea separadora.
        Console.WriteLine(); // Salto de línea.
        Console.Write("  Selecciona una opción: "); // Prompt del menú.
    }

    private static void Pausa() // Pausa genérica para esperar Enter.
    {
        Console.WriteLine(); // Línea en blanco para separar.
        ConsoleMarcos.LineaFina(); // Línea separadora.
        Console.Write("  Presiona Enter para continuar..."); // Mensaje de pausa.
        Console.ReadLine(); // Espera la entrada del usuario (Enter).
    }
}
