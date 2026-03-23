using System.Linq;
using BreakLineEvents.Models;

namespace BreakLineEvents.Services;

public class ServicioConciliacion
{
    public HashSet<Participante> Preregistrados { get; } = new HashSet<Participante>();
    public HashSet<Participante> RegistroManual { get; } = new HashSet<Participante>();
    public HashSet<Participante> InvitadosVip { get; } = new HashSet<Participante>();
    public HashSet<Participante> ListaNegra { get; } = new HashSet<Participante>();
    public HashSet<Participante> AsistentesReales { get; } = new HashSet<Participante>();
    public HashSet<InscripcionTaller> Inscripciones { get; } = new HashSet<InscripcionTaller>();

    public List<Taller> Talleres { get; } = new List<Taller>();
    public List<string> DuplicadosDetectados { get; } = new List<string>();
    public List<string> InscripcionesRechazadas { get; } = new List<string>();
    public HashSet<Participante> ParticipantesConIntentoInvalido { get; } = new HashSet<Participante>();

    public HashSet<Participante> Autorizados { get; set; } = new HashSet<Participante>();
    public HashSet<Participante> NoAutorizados { get; set; } = new HashSet<Participante>();
    public HashSet<Participante> Ausentes { get; set; } = new HashSet<Participante>();

    public void CargarDatosDePrueba()
    {
        LimpiarEstado();
        CargarTalleres();
        CargarParticipantes();
    }

    public void ProcesarConciliacion()
    {
        // autorizados = (preregistrados ∪ registroManual ∪ invitadosVip) - listaNegra
        Autorizados = new HashSet<Participante>(Preregistrados);
        Autorizados.UnionWith(RegistroManual);
        Autorizados.UnionWith(InvitadosVip);
        Autorizados.ExceptWith(ListaNegra);

        // noAutorizados = asistentesReales - autorizados
        NoAutorizados = new HashSet<Participante>(AsistentesReales);
        NoAutorizados.ExceptWith(Autorizados);

        // ausentes = autorizados - asistentesReales
        Ausentes = new HashSet<Participante>(Autorizados);
        Ausentes.ExceptWith(AsistentesReales);

        // 32.md — IntersectWith, IsSubsetOf, IsSupersetOf, Overlaps, SetEquals (uso en codigo; el PDF no pide mostrarlos)
        HashSet<Participante> asistentesAutorizados = new HashSet<Participante>(AsistentesReales);
        asistentesAutorizados.IntersectWith(Autorizados);
        _ = asistentesAutorizados.IsSubsetOf(Autorizados);
        _ = Autorizados.IsSupersetOf(asistentesAutorizados);

        HashSet<Participante> candidatosSinFiltrar = new HashSet<Participante>(Preregistrados);
        candidatosSinFiltrar.UnionWith(RegistroManual);
        candidatosSinFiltrar.UnionWith(InvitadosVip);
        _ = candidatosSinFiltrar.Overlaps(ListaNegra);

        HashSet<Participante> verificacionNoAutorizados = new HashSet<Participante>(AsistentesReales);
        verificacionNoAutorizados.ExceptWith(Autorizados);
        _ = verificacionNoAutorizados.SetEquals(NoAutorizados);

        // 32.md — Opcion 2: calcular inscripciones validas y rechazadas (reglas de negocio §5)
        Inscripciones.Clear();
        InscripcionesRechazadas.Clear();
        ParticipantesConIntentoInvalido.Clear();
        ProcesarInscripciones();
    }

    private void LimpiarEstado()
    {
        Preregistrados.Clear();
        RegistroManual.Clear();
        InvitadosVip.Clear();
        ListaNegra.Clear();
        AsistentesReales.Clear();
        Inscripciones.Clear();

        Talleres.Clear();
        DuplicadosDetectados.Clear();
        InscripcionesRechazadas.Clear();
        ParticipantesConIntentoInvalido.Clear();

        Autorizados.Clear();
        NoAutorizados.Clear();
        Ausentes.Clear();
    }

    private void CargarTalleres()
    {
        Talleres.Add(new Taller
        {
            Nombre = "Docker Pro",
            HoraInicio = new TimeOnly(9, 0),
            HoraFin = new TimeOnly(11, 0),
            Capacidad = 1
        });

        Talleres.Add(new Taller
        {
            Nombre = "Microservicios Avanzados",
            HoraInicio = new TimeOnly(10, 0),
            HoraFin = new TimeOnly(12, 0),
            Capacidad = 30
        });

        Talleres.Add(new Taller
        {
            Nombre = "Kubernetes Basico",
            HoraInicio = new TimeOnly(13, 0),
            HoraFin = new TimeOnly(15, 0),
            Capacidad = 20
        });
    }

    private void CargarParticipantes()
    {
        Participante ana = P("1001", "Ana Torres", "ana@correo.com");
        Participante laura = P("1122", "Laura Pérez", "laura@correo.com");
        Participante carlos = P("7788", "Carlos Ruiz", "carlos@correo.com");
        Participante luis = P("999", "Luis Díaz", "LDiaz@correo.com");
        Participante maria = P("1005", "Maria Lopez", "maria@correo.com", true);
        Participante jorge = P("1006", "Jorge Rios", "jorge@correo.com");
        Participante sofia = P("1007", "Sofia Vargas", "sofia@correo.com", true);
        Participante camilo = P("1008", "Camilo Prada", "camilo@correo.com");
        Participante diana = P("1009", "Diana Castro", "diana@correo.com");
        Participante felipe = P("1010", "Felipe Munoz", "felipe@correo.com");
        Participante valentina = P("1011", "Valentina Gil", "vgil@correo.com");
        Participante tomas = P("2001", "Tomas Nieto", "tomas@hotmail.com");
        Participante juliana = P("2002", "Juliana Soto", "juliana@hotmail.com");
        Participante andres = P("2003", "Andres Cruz", "andres@hotmail.com");
        Participante robertoVip = P("1122", "Laura Pérez", "laura@correo.com", true);
        Participante intruso = P("9999", "Intruso X", "intruso@mail.com");
        Participante sinRegistro = P("5555", "Sin Registro", "sinreg@mail.com");

        Participante dupDocumentoA = P("123", "Ana Torres", "ana@gmail.com");
        Participante dupDocumentoB = P("123", "Ana T.", "anatorres@gmail.com");
        Participante dupEmailA = P("999", "Luis Díaz", "LDiaz@correo.com");
        Participante dupEmailB = P("888", "Luis D.", "ldiaz@correo.com ");

        Agregar(Preregistrados, "preregistro web", ana);
        Agregar(Preregistrados, "preregistro web", laura);
        Agregar(Preregistrados, "preregistro web", carlos);
        Agregar(Preregistrados, "preregistro web", luis);
        Agregar(Preregistrados, "preregistro web", maria);
        Agregar(Preregistrados, "preregistro web", jorge);
        Agregar(Preregistrados, "preregistro web", sofia);
        Agregar(Preregistrados, "preregistro web", camilo);
        Agregar(Preregistrados, "preregistro web", diana);
        Agregar(Preregistrados, "preregistro web", felipe);
        Agregar(Preregistrados, "preregistro web", valentina);
        Agregar(Preregistrados, "preregistro web", dupDocumentoA);

        Agregar(Preregistrados, "preregistro web", dupDocumentoB, true);
        Agregar(Preregistrados, "preregistro web", dupEmailA);
        Agregar(Preregistrados, "preregistro web", dupEmailB, true);

        Agregar(RegistroManual, "registro manual", tomas);
        Agregar(RegistroManual, "registro manual", juliana);
        Agregar(RegistroManual, "registro manual", andres);
        Agregar(RegistroManual, "registro manual", P("1012", "Ricardo Mora", "rmora@correo.com"));

        Agregar(InvitadosVip, "invitados VIP", maria);
        Agregar(InvitadosVip, "invitados VIP", sofia);
        Agregar(InvitadosVip, "invitados VIP", robertoVip);

        Agregar(ListaNegra, "lista negra", carlos);
        Agregar(ListaNegra, "lista negra", intruso);

        Agregar(AsistentesReales, "asistencia real", ana);
        Agregar(AsistentesReales, "asistencia real", carlos);
        Agregar(AsistentesReales, "asistencia real", luis);
        Agregar(AsistentesReales, "asistencia real", dupDocumentoA);
        Agregar(AsistentesReales, "asistencia real", maria);
        Agregar(AsistentesReales, "asistencia real", jorge);
        Agregar(AsistentesReales, "asistencia real", sofia);
        Agregar(AsistentesReales, "asistencia real", camilo);
        Agregar(AsistentesReales, "asistencia real", diana);
        Agregar(AsistentesReales, "asistencia real", felipe);
        Agregar(AsistentesReales, "asistencia real", valentina);
        Agregar(AsistentesReales, "asistencia real", tomas);
        Agregar(AsistentesReales, "asistencia real", sinRegistro);
        Agregar(AsistentesReales, "asistencia real", P("1012", "Ricardo Mora", "rmora@correo.com"));
    }

    /// <summary>
    /// Valida e intenta registrar inscripciones segun 32.md §5 (usa Autorizados ya conciliado).
    /// </summary>
    private void ProcesarInscripciones()
    {
        Taller? docker = BuscarTallerPorNombre("Docker Pro");
        Taller? micro = BuscarTallerPorNombre("Microservicios Avanzados");
        Taller? kube = BuscarTallerPorNombre("Kubernetes Basico");

        Participante? ana = Buscar("1001");
        Participante? luis = Buscar("999");
        Participante? carlos = Buscar("7788");
        Participante? maria = Buscar("1005");

        if (ana != null && docker != null && micro != null)
        {
            Inscribir(ana, docker);
            Inscribir(ana, micro);
        }

        if (luis != null && docker != null)
        {
            Inscribir(luis, docker);
        }

        if (carlos != null && kube != null)
        {
            Inscribir(carlos, kube);
        }

        if (maria != null && kube != null)
        {
            Inscribir(maria, kube);
        }
    }

    private Taller? BuscarTallerPorNombre(string nombre)
    {
        foreach (Taller t in Talleres)
        {
            if (t.Nombre == nombre)
            {
                return t;
            }
        }

        return null;
    }

    private Participante? Buscar(string documentoNorm)
    {
        string key = documentoNorm.Trim();
        Participante? p = BuscarEnConjunto(Preregistrados, key);
        if (p != null)
        {
            return p;
        }

        p = BuscarEnConjunto(RegistroManual, key);
        if (p != null)
        {
            return p;
        }

        p = BuscarEnConjunto(InvitadosVip, key);
        if (p != null)
        {
            return p;
        }

        p = BuscarEnConjunto(ListaNegra, key);
        if (p != null)
        {
            return p;
        }

        return BuscarEnConjunto(AsistentesReales, key);
    }

    private static Participante? BuscarEnConjunto(HashSet<Participante> conjunto, string documentoTrim)
    {
        foreach (Participante p in conjunto)
        {
            if (string.Equals(p.DocumentoNorm, documentoTrim, StringComparison.OrdinalIgnoreCase))
            {
                return p;
            }
        }

        return null;
    }

    private void Agregar(HashSet<Participante> destino, string fuente, Participante nuevo, bool registrarDuplicado = false)
    {
        _ = fuente;
        if (destino.TryGetValue(nuevo, out Participante? existente))
        {
            if (registrarDuplicado)
            {
                RegistrarMotivoDuplicado(nuevo, existente);
            }

            return;
        }

        destino.Add(nuevo);
    }

    private void RegistrarMotivoDuplicado(Participante nuevo, Participante existente)
    {
        if (nuevo.DocumentoNorm.Length > 0 && existente.DocumentoNorm.Length > 0 &&
            string.Equals(nuevo.DocumentoNorm, existente.DocumentoNorm, StringComparison.OrdinalIgnoreCase))
        {
            DuplicadosDetectados.Add($"Documento repetido: {nuevo.DocumentoNorm}");
            return;
        }

        if (nuevo.EmailNorm.Length > 0 && existente.EmailNorm.Length > 0 &&
            string.Equals(nuevo.EmailNorm, existente.EmailNorm, StringComparison.OrdinalIgnoreCase))
        {
            DuplicadosDetectados.Add($"Email repetido: {nuevo.EmailNorm}");
        }
    }

    private void Inscribir(Participante participante, Taller taller)
    {
        if (!Autorizados.Contains(participante))
        {
            Rechazar(participante, taller, "participante no autorizado");
            return;
        }

        int ocupados = ContarInscripcionesPorTaller(taller);
        if (ocupados >= taller.Capacidad)
        {
            Rechazar(participante, taller, "sin cupo");
            return;
        }

        if (TieneCruceHorario(participante, taller))
        {
            Rechazar(participante, taller, "cruce de horario");
            return;
        }

        Inscripciones.Add(new InscripcionTaller
        {
            Participante = participante,
            Taller = taller
        });
    }

    private int ContarInscripcionesPorTaller(Taller taller)
    {
        // LINQ solo como apoyo (32.md); la conciliación usa HashSet y operaciones de conjunto.
        return Inscripciones.Count(i => i.Taller.Equals(taller));
    }

    private bool TieneCruceHorario(Participante participante, Taller taller)
    {
        foreach (InscripcionTaller i in Inscripciones)
        {
            if (i.Participante.Equals(participante) && i.Taller.SeCruzaCon(taller))
            {
                return true;
            }
        }

        return false;
    }

    private void Rechazar(Participante p, Taller t, string motivo)
    {
        InscripcionesRechazadas.Add($"{p.NombreCompleto} -> Taller \"{t.Nombre}\" | Motivo: {motivo}");
        ParticipantesConIntentoInvalido.Add(p);
    }

    private static Participante P(string doc, string nombre, string email, bool vip = false)
    {
        return new Participante
        {
            Documento = doc,
            NombreCompleto = nombre,
            Email = email,
            EsVip = vip
        };
    }
}
