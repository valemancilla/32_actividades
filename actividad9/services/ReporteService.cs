using BreakLineEvents.Models;

namespace BreakLineEvents.Services;

public static class ReporteService
{
    public static void MostrarReporte(ServicioConciliacion s)
    {
        Console.WriteLine("===== REPORTE FINAL =====");
        Console.WriteLine($"Preregistrados: {s.Preregistrados.Count}");
        Console.WriteLine($"Registro manual: {s.RegistroManual.Count}");
        Console.WriteLine($"Invitados VIP: {s.InvitadosVip.Count}");
        Console.WriteLine($"Lista negra: {s.ListaNegra.Count}");
        Console.WriteLine($"Autorizados finales: {s.Autorizados.Count}");
        Console.WriteLine($"Asistentes reales: {s.AsistentesReales.Count}");

        ImprimirBloque("No autorizados", s.NoAutorizados);
        ImprimirBloque("Autorizados ausentes", s.Ausentes);

        Console.WriteLine();
        Console.WriteLine("Inscripciones rechazadas:");
        if (s.InscripcionesRechazadas.Count == 0)
        {
            Console.WriteLine("- (ninguna)");
        }
        else
        {
            foreach (string item in s.InscripcionesRechazadas)
            {
                Console.WriteLine($"- {item}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Talleres llenos:");
        var talleresLlenos = s.Talleres
            .Where(t => s.Inscripciones.Count(i => i.Taller.Equals(t)) >= t.Capacidad)
            .ToList();

        if (talleresLlenos.Count == 0)
        {
            Console.WriteLine("- (ninguno)");
        }
        else
        {
            foreach (Taller t in talleresLlenos)
            {
                Console.WriteLine($"- {t.Nombre}");
            }
        }

        ImprimirBloque("Participantes con intento de inscripcion invalida", s.ParticipantesConIntentoInvalido);

        Console.WriteLine();
        Console.WriteLine("Duplicados detectados en carga:");
        if (s.DuplicadosDetectados.Count == 0)
        {
            Console.WriteLine("- (ninguno)");
        }
        else
        {
            foreach (string d in s.DuplicadosDetectados)
            {
                Console.WriteLine($"- {d}");
            }
        }
    }

    private static void ImprimirBloque(string titulo, IEnumerable<Participante> participantes)
    {
        Console.WriteLine();
        Console.WriteLine($"{titulo}:");

        bool hay = false;
        foreach (Participante p in participantes)
        {
            hay = true;
            Console.WriteLine($"- {p}");
        }

        if (!hay)
        {
            Console.WriteLine("- (ninguno)");
        }
    }
}
