using System.Linq;
using BreakLineEvents.Models;
using BreakLineEvents.Utils;

namespace BreakLineEvents.Services;

/// <summary>
/// Reporte de inconsistencias — 32.md §6 y salida esperada (ejemplo del PDF).
/// </summary>
public static class ReporteService
{
    public static void MostrarReporte(ServicioConciliacion s)
    {
        ConsoleMarcos.MarcoDoble("OPCIÓN 3 — REPORTE CONSOLIDADO", "Reporte final");
        Console.WriteLine();

        ConsoleMarcos.MarcoSimple("TOTALES (RESUMEN)");
        Console.WriteLine($"    Total preregistrados: {s.Preregistrados.Count}");
        Console.WriteLine($"    Total autorizados: {s.Autorizados.Count}");
        Console.WriteLine($"    Total asistentes reales: {s.AsistentesReales.Count}");
        Console.WriteLine();

        ConsoleMarcos.MarcoSimple("DETALLE POR FUENTES Y CONTEOS");
        Console.WriteLine($"    Preregistrados: {s.Preregistrados.Count}");
        Console.WriteLine($"    Registro manual: {s.RegistroManual.Count}");
        Console.WriteLine($"    Invitados VIP: {s.InvitadosVip.Count}");
        Console.WriteLine($"    Lista negra: {s.ListaNegra.Count}");
        Console.WriteLine($"    Autorizados finales: {s.Autorizados.Count}");
        Console.WriteLine($"    Asistentes reales: {s.AsistentesReales.Count}");
        Console.WriteLine($"    Inscripciones válidas: {s.Inscripciones.Count}");

        ImprimirBloque("No autorizados", s.NoAutorizados);
        ImprimirBloque("Autorizados ausentes", s.Ausentes);

        ConsoleMarcos.MarcoSimple("INSCRIPCIONES RECHAZADAS");
        if (s.InscripcionesRechazadas.Count == 0)
        {
            Console.WriteLine("    - (ninguna)");
        }
        else
        {
            for (int i = 0; i < s.InscripcionesRechazadas.Count; i++)
            {
                Console.WriteLine($"    - {s.InscripcionesRechazadas[i]}");
            }
        }

        ConsoleMarcos.MarcoSimple("TALLERES LLENOS");
        List<Taller> talleresLlenos = new List<Taller>();
        foreach (Taller t in s.Talleres)
        {
            int inscritos = ContarInscripcionesEnTaller(s, t);
            if (inscritos >= t.Capacidad)
            {
                talleresLlenos.Add(t);
            }
        }

        if (talleresLlenos.Count == 0)
        {
            Console.WriteLine("    - (ninguno)");
        }
        else
        {
            foreach (Taller t in talleresLlenos)
            {
                Console.WriteLine($"    - {t.Nombre}");
            }
        }

        ImprimirBloque("Participantes con intento de inscripcion invalida", s.ParticipantesConIntentoInvalido);

        ConsoleMarcos.MarcoSimple("DUPLICADOS DETECTADOS EN CARGA");
        if (s.DuplicadosDetectados.Count == 0)
        {
            Console.WriteLine("    - (ninguno)");
        }
        else
        {
            for (int i = 0; i < s.DuplicadosDetectados.Count; i++)
            {
                Console.WriteLine($"    - {s.DuplicadosDetectados[i]}");
            }
        }
    }

    private static int ContarInscripcionesEnTaller(ServicioConciliacion s, Taller taller)
    {
        return s.Inscripciones.Count(i => i.Taller.Equals(taller));
    }

    private static void ImprimirBloque(string titulo, HashSet<Participante> participantes)
    {
        ConsoleMarcos.MarcoSimple(titulo.ToUpperInvariant());

        bool hay = false;
        foreach (Participante p in participantes)
        {
            hay = true;
            Console.WriteLine($"    - {p}");
        }

        if (!hay)
        {
            Console.WriteLine("    - (ninguno)");
        }
    }
}
