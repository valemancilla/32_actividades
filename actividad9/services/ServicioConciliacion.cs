using BreakLineEvents.Models;

namespace BreakLineEvents.Services;

public sealed class ServicioConciliacion
{
    // Colecciones requeridas (HashSet con objetos personalizados)
    public HashSet<Participante> Preregistrados { get; } = [];
    public HashSet<Participante> RegistroManual { get; } = [];
    public HashSet<Participante> InvitadosVip { get; } = [];
    public HashSet<Participante> ListaNegra { get; } = [];
    public HashSet<Participante> AsistentesReales { get; } = [];
    public HashSet<InscripcionTaller> Inscripciones { get; } = [];

    public List<Taller> Talleres { get; } = [];
    public List<string> DuplicadosDetectados { get; } = [];
    public List<string> InscripcionesRechazadas { get; } = [];
    public HashSet<Participante> ParticipantesConIntentoInvalido { get; } = [];

    public HashSet<Participante> Autorizados { get; private set; } = [];
    public HashSet<Participante> NoAutorizados { get; private set; } = [];
    public HashSet<Participante> Ausentes { get; private set; } = [];

    private readonly Dictionary<string, Participante> _indiceDocumento = new();
    private readonly Dictionary<string, Participante> _indiceEmail = new();

    public void CargarDatosDePrueba()
    {
        LimpiarEstado();
        CargarTalleres();
        CargarParticipantes();
        CargarInscripciones();

        Console.WriteLine("Datos de prueba cargados correctamente.");
        Console.WriteLine($"Preregistrados: {Preregistrados.Count}");
        Console.WriteLine($"Registro manual: {RegistroManual.Count}");
        Console.WriteLine($"Invitados VIP: {InvitadosVip.Count}");
        Console.WriteLine($"Lista negra: {ListaNegra.Count}");
        Console.WriteLine($"Asistentes reales: {AsistentesReales.Count}");
    }

    public void ProcesarConciliacion()
    {
        // autorizados = (preregistrados U registroManual U invitadosVip) - listaNegra
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

        // Operacion requerida adicional
        var asistentesAutorizados = new HashSet<Participante>(AsistentesReales);
        asistentesAutorizados.IntersectWith(Autorizados);
        bool subconjuntoValido = asistentesAutorizados.IsSubsetOf(Autorizados);

        Console.WriteLine("Conciliacion procesada.");
        Console.WriteLine($"Autorizados finales: {Autorizados.Count}");
        Console.WriteLine($"No autorizados: {NoAutorizados.Count}");
        Console.WriteLine($"Autorizados ausentes: {Ausentes.Count}");
        Console.WriteLine($"Inscripciones validas: {Inscripciones.Count}");
        Console.WriteLine($"Inscripciones rechazadas: {InscripcionesRechazadas.Count}");
        Console.WriteLine($"Validacion IsSubsetOf (asistentes autorizados ⊆ autorizados): {subconjuntoValido}");
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

        _indiceDocumento.Clear();
        _indiceEmail.Clear();
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
        // Base
        var ana = P("1001", "Ana Torres", "ana@correo.com");
        var laura = P("1122", "Laura Perez", "laura@correo.com");
        var carlos = P("7788", "Carlos Ruiz", "carlos@correo.com");
        var luis = P("999", "Luis Diaz", "LDiaz@correo.com");
        var maria = P("1005", "Maria Lopez", "maria@correo.com", true);
        var jorge = P("1006", "Jorge Rios", "jorge@correo.com");
        var sofia = P("1007", "Sofia Vargas", "sofia@correo.com", true);
        var camilo = P("1008", "Camilo Prada", "camilo@correo.com");
        var diana = P("1009", "Diana Castro", "diana@correo.com");
        var felipe = P("1010", "Felipe Munoz", "felipe@correo.com");
        var valentina = P("1011", "Valentina Gil", "vgil@correo.com");
        var tomas = P("2001", "Tomas Nieto", "tomas@hotmail.com");
        var juliana = P("2002", "Juliana Soto", "juliana@hotmail.com");
        var andres = P("2003", "Andres Cruz", "andres@hotmail.com");
        var robertoVip = P("1122", "Laura Perez", "laura@correo.com", true);
        var intruso = P("9999", "Intruso X", "intruso@mail.com");
        var sinRegistro = P("5555", "Sin Registro", "sinreg@mail.com");

        // Casos requeridos de duplicado
        var dupDocumentoA = P("123", "Ana Torres", "ana@gmail.com");
        var dupDocumentoB = P("123", "Ana T.", "anatorres@gmail.com");
        var dupEmailA = P("999", "Luis Díaz", "LDiaz@correo.com");
        var dupEmailB = P("888", "Luis D.", "ldiaz@correo.com ");

        // Preregistro (12)
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

        // Duplicados lógicos
        Agregar(Preregistrados, "preregistro web", dupDocumentoB, registrarDuplicado: true); // mismo documento
        Agregar(Preregistrados, "preregistro web", dupEmailA);
        Agregar(Preregistrados, "preregistro web", dupEmailB, registrarDuplicado: true); // mismo email normalizado

        // Registro manual (4)
        Agregar(RegistroManual, "registro manual", tomas);
        Agregar(RegistroManual, "registro manual", juliana);
        Agregar(RegistroManual, "registro manual", andres);
        Agregar(RegistroManual, "registro manual", P("1012", "Ricardo Mora", "rmora@correo.com"));

        // VIP (3)
        Agregar(InvitadosVip, "invitados VIP", maria);
        Agregar(InvitadosVip, "invitados VIP", sofia);
        Agregar(InvitadosVip, "invitados VIP", robertoVip);

        // Lista negra (2): caso requerido participante preregistrado y en lista negra
        Agregar(ListaNegra, "lista negra", carlos);
        Agregar(ListaNegra, "lista negra", intruso);

        // Asistentes reales (14): incluye no registrado
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
        Agregar(AsistentesReales, "asistencia real", sinRegistro); // no registrado
        Agregar(AsistentesReales, "asistencia real", P("1012", "Ricardo Mora", "rmora@correo.com"));
    }

    private void CargarInscripciones()
    {
        var docker = Talleres.Single(t => t.Nombre == "Docker Pro");
        var micro = Talleres.Single(t => t.Nombre == "Microservicios Avanzados");
        var kube = Talleres.Single(t => t.Nombre == "Kubernetes Basico");

        // Calcula autorizados para validar inscripciones.
        ProcesarAutorizadosSilencioso();

        var ana = Buscar("1001");
        var luis = Buscar("999");
        var carlos = Buscar("7788");
        var maria = Buscar("1005");

        if (ana is not null)
        {
            Inscribir(ana, docker); // valida
            Inscribir(ana, micro); // rechazo por cruce
        }

        if (luis is not null)
        {
            Inscribir(luis, docker); // rechazo por sin cupo
        }

        if (carlos is not null)
        {
            Inscribir(carlos, kube); // rechazo por no autorizado (lista negra)
        }

        if (maria is not null)
        {
            Inscribir(maria, kube); // valida
        }
    }

    private void ProcesarAutorizadosSilencioso()
    {
        Autorizados = new HashSet<Participante>(Preregistrados);
        Autorizados.UnionWith(RegistroManual);
        Autorizados.UnionWith(InvitadosVip);
        Autorizados.ExceptWith(ListaNegra);
    }

    private Participante? Buscar(string documentoNorm)
    {
        string key = documentoNorm.Trim();
        return _indiceDocumento.GetValueOrDefault(key);
    }

    private void Agregar(HashSet<Participante> destino, string fuente, Participante nuevo, bool registrarDuplicado = false)
    {
        _ = fuente;
        var canonico = ResolverCanonico(nuevo, out string? motivoDuplicado);
        if (registrarDuplicado && motivoDuplicado is not null)
        {
            DuplicadosDetectados.Add(motivoDuplicado);
        }

        destino.Add(canonico);
    }

    private Participante ResolverCanonico(Participante p, out string? motivo)
    {
        motivo = null;

        string doc = p.DocumentoNorm;
        string email = p.EmailNorm;

        if (doc.Length > 0 && _indiceDocumento.TryGetValue(doc, out Participante? existentePorDoc))
        {
            motivo = $"Documento repetido: {doc}";
            return existentePorDoc;
        }

        if (email.Length > 0 && _indiceEmail.TryGetValue(email, out Participante? existentePorEmail))
        {
            motivo = $"Email repetido: {email}";
            return existentePorEmail;
        }

        if (doc.Length > 0)
        {
            _indiceDocumento[doc] = p;
        }

        if (email.Length > 0)
        {
            _indiceEmail[email] = p;
        }

        return p;
    }

    private void Inscribir(Participante participante, Taller taller)
    {
        if (!Autorizados.Contains(participante))
        {
            Rechazar(participante, taller, "participante no autorizado");
            return;
        }

        int ocupados = Inscripciones.Count(i => i.Taller.Equals(taller));
        if (ocupados >= taller.Capacidad)
        {
            Rechazar(participante, taller, "sin cupo");
            return;
        }

        bool cruza = Inscripciones
            .Where(i => i.Participante.Equals(participante))
            .Any(i => i.Taller.SeCruzaCon(taller));

        if (cruza)
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

    private void Rechazar(Participante p, Taller t, string motivo)
    {
        InscripcionesRechazadas.Add($"{p.NombreCompleto} -> Taller \"{t.Nombre}\" | Motivo: {motivo}");
        ParticipantesConIntentoInvalido.Add(p);
    }

    private static Participante P(string doc, string nombre, string email, bool vip = false)
        => new()
        {
            Documento = doc,
            NombreCompleto = nombre,
            Email = email,
            EsVip = vip
        };
}
