using System.Linq; // Usamos LINQ para contar y filtrar en el reporte.
using BreakLineEvents.Models; // Contiene los modelos del dominio usados por el reporte.
using BreakLineEvents.Utils; // Contiene utilidades de consola para mostrar marcos.

namespace BreakLineEvents.Services; // Contiene la lógica del reporte consolidado.


public static class ReporteService
{
    public static void MostrarReporte(ServicioConciliacion s) // Imprime el reporte final usando los datos calculados en el servicio.
    {
        ConsoleMarcos.MarcoDoble("OPCIÓN 3 — REPORTE CONSOLIDADO", "Reporte final"); // Marco principal del reporte.
        Console.WriteLine(); // Separador en blanco.

        ConsoleMarcos.MarcoSimple("TOTALES (RESUMEN)"); // Sección de totales/resumen.
        Console.WriteLine($"    Total preregistrados: {s.Preregistrados.Count}"); // Cantidad de preregistrados.
        Console.WriteLine($"    Total autorizados: {s.Autorizados.Count}"); // Cantidad de autorizados finales.
        Console.WriteLine($"    Total asistentes reales: {s.AsistentesReales.Count}"); // Cantidad de asistentes reales.
        Console.WriteLine(); // Separador antes del detalle.

        ConsoleMarcos.MarcoSimple("DETALLE POR FUENTES Y CONTEOS"); // Sección de detalle por fuentes.
        Console.WriteLine($"    Preregistrados: {s.Preregistrados.Count}"); // Conteo de preregistrados.
        Console.WriteLine($"    Registro manual: {s.RegistroManual.Count}"); // Conteo de registro manual.
        Console.WriteLine($"    Invitados VIP: {s.InvitadosVip.Count}"); // Conteo de invitados VIP.
        Console.WriteLine($"    Lista negra: {s.ListaNegra.Count}"); // Conteo de lista negra.
        Console.WriteLine($"    Autorizados finales: {s.Autorizados.Count}"); // Autorizados finales tras excluir lista negra.
        Console.WriteLine($"    Asistentes reales: {s.AsistentesReales.Count}"); // Asistentes reales.
        Console.WriteLine($"    Inscripciones válidas: {s.Inscripciones.Count}"); // Inscripciones que pasaron validaciones.

        ImprimirBloque("No autorizados", s.NoAutorizados); // Imprime el bloque de no autorizados.
        ImprimirBloque("Autorizados ausentes", s.Ausentes); // Imprime el bloque de autorizados ausentes.

        ConsoleMarcos.MarcoSimple("INSCRIPCIONES RECHAZADAS"); // Sección de motivos de rechazo.
        if (s.InscripcionesRechazadas.Count == 0)
        {
            Console.WriteLine("    - (ninguna)"); // Si no hay rechazos, lo indicamos.
        }
        else
        {
            for (int i = 0; i < s.InscripcionesRechazadas.Count; i++) // Recorre los motivos rechazados.
            {
                Console.WriteLine($"    - {s.InscripcionesRechazadas[i]}"); // Imprime cada motivo.
            }
        }

        ConsoleMarcos.MarcoSimple("TALLERES LLENOS"); // Sección de talleres con cupo completo.
        List<Taller> talleresLlenos = new List<Taller>(); // Aquí guardamos talleres con cupo lleno.
        foreach (Taller t in s.Talleres)
        {
            int inscritos = ContarInscripcionesEnTaller(s, t); // Cuenta inscritos para el taller actual.
            if (inscritos >= t.Capacidad) // Si alcanzó (o superó) la capacidad...
            {
                talleresLlenos.Add(t); // ...se considera "lleno".
            }
        }

        if (talleresLlenos.Count == 0)
        {
            Console.WriteLine("    - (ninguno)"); // Si no hay talleres llenos, lo indicamos.
        }
        else
        {
            foreach (Taller t in talleresLlenos)
            {
                Console.WriteLine($"    - {t.Nombre}"); // Imprime el nombre de cada taller lleno.
            }
        }

        ImprimirBloque("Participantes con intento de inscripcion invalida", s.ParticipantesConIntentoInvalido); // Imprime el bloque de intentos inválidos.

        ConsoleMarcos.MarcoSimple("DUPLICADOS DETECTADOS EN CARGA"); // Sección de duplicados detectados al cargar.
        if (s.DuplicadosDetectados.Count == 0)
        {
            Console.WriteLine("    - (ninguno)"); // Si no hay duplicados, lo indicamos.
        }
        else
        {
            for (int i = 0; i < s.DuplicadosDetectados.Count; i++) // Recorre los textos de duplicados detectados.
            {
                Console.WriteLine($"    - {s.DuplicadosDetectados[i]}"); // Imprime el motivo de duplicado.
            }
        }
    }

    private static int ContarInscripcionesEnTaller(ServicioConciliacion s, Taller taller)
    {
        return s.Inscripciones.Count(i => i.Taller.Equals(taller)); // Cuenta inscripciones cuyo taller coincide.
    }

    private static void ImprimirBloque(string titulo, HashSet<Participante> participantes)
    {
        ConsoleMarcos.MarcoSimple(titulo.ToUpperInvariant()); // Titulo en mayusculas dentro de un marco simple.

        bool hay = false; // Indica si el conjunto tenía elementos.
        foreach (Participante p in participantes) // Recorre participantes del bloque.
        {
            hay = true; // Ya sabemos que hay al menos uno.
            Console.WriteLine($"    - {p}"); // Imprime el participante (usa ToString()).
        }

        if (!hay) // Si no se imprimió nada...
        {
            Console.WriteLine("    - (ninguno)"); // ...se muestra que no hay elementos.
        }
    }
}
