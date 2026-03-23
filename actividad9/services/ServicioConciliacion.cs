using System.Linq; // Usamos LINQ en algunos cálculos internos (por ejemplo para contar).
using BreakLineEvents.Models; // Contiene los modelos del dominio: Participante, InscripcionTaller, etc.

namespace BreakLineEvents.Services; // Espacio de nombres de la capa de servicios.

public class ServicioConciliacion // Clase que realiza la conciliación y valida inscripciones según reglas del ejercicio.
{
    public HashSet<Participante> Preregistrados { get; } = new HashSet<Participante>(); // Personas preregistradas (fuente 1).
    public HashSet<Participante> RegistroManual { get; } = new HashSet<Participante>(); // Personas registradas manualmente (fuente 2).
    public HashSet<Participante> InvitadosVip { get; } = new HashSet<Participante>(); // Personas invitadas VIP (fuente 3).
    public HashSet<Participante> ListaNegra { get; } = new HashSet<Participante>(); // Personas que están en “lista negra” (se excluyen).
    public HashSet<Participante> AsistentesReales { get; } = new HashSet<Participante>(); // Personas que realmente asistieron.
    public HashSet<InscripcionTaller> Inscripciones { get; } = new HashSet<InscripcionTaller>(); // Inscripciones válidas (taller + participante) sin duplicados.

    public List<Taller> Talleres { get; } = new List<Taller>(); // Lista de talleres disponibles.
    public List<string> DuplicadosDetectados { get; } = new List<string>(); // Mensajes con motivos de duplicados detectados.
    public List<string> InscripcionesRechazadas { get; } = new List<string>(); // Motivos de inscripciones rechazadas.
    public HashSet<Participante> ParticipantesConIntentoInvalido { get; } = new HashSet<Participante>(); // Participantes que intentaron inscribirse de forma inválida.

    public HashSet<Participante> Autorizados { get; set; } = new HashSet<Participante>(); // Conjunto final de personas autorizadas.
    public HashSet<Participante> NoAutorizados { get; set; } = new HashSet<Participante>(); // Personas reales que no quedaron autorizadas.
    public HashSet<Participante> Ausentes { get; set; } = new HashSet<Participante>(); // Autorizados que no aparecieron como asistentes reales.

    public void CargarDatosDePrueba() // Llena talleres y conjuntos con datos de ejemplo.
    {
        LimpiarEstado(); // Borra cualquier estado previo para empezar limpio.
        CargarTalleres(); // Carga los talleres en la lista.
        CargarParticipantes(); // Carga los participantes y los llena en sus sets/fuentes.
    }

    public void ProcesarConciliacion() // Calcula autorizados, no autorizados y ausentes, y luego valida inscripciones.
    {
        Autorizados = new HashSet<Participante>(Preregistrados); // Autorizados inicia con preregistrados.
        Autorizados.UnionWith(RegistroManual); // Agrega registro manual a autorizados.
        Autorizados.UnionWith(InvitadosVip); // Agrega invitados VIP a autorizados.
        Autorizados.ExceptWith(ListaNegra); // Quita los que estén en lista negra.

        NoAutorizados = new HashSet<Participante>(AsistentesReales); // No autorizados inicia con asistentes reales.
        NoAutorizados.ExceptWith(Autorizados); // Luego quita los que sí están autorizados.

        Ausentes = new HashSet<Participante>(Autorizados); // Ausentes inicia con autorizados.
        Ausentes.ExceptWith(AsistentesReales); // Quita los que sí asistieron: lo restante son ausentes.

        HashSet<Participante> asistentesAutorizados = new HashSet<Participante>(AsistentesReales); // Copia de asistentes reales para intersectar.
        asistentesAutorizados.IntersectWith(Autorizados); // Se queda con quienes están autorizados también (intersección).
        _ = asistentesAutorizados.IsSubsetOf(Autorizados); // Verifica subset (se ignora el resultado, solo para practicar).
        _ = Autorizados.IsSupersetOf(asistentesAutorizados); // Verifica superset (se ignora el resultado).

        HashSet<Participante> candidatosSinFiltrar = new HashSet<Participante>(Preregistrados); // Candidatos base: preregistrados.
        candidatosSinFiltrar.UnionWith(RegistroManual); // Suma registro manual.
        candidatosSinFiltrar.UnionWith(InvitadosVip); // Suma VIP.
        _ = candidatosSinFiltrar.Overlaps(ListaNegra); // Comprueba si se solapan con lista negra (práctica).

        HashSet<Participante> verificacionNoAutorizados = new HashSet<Participante>(AsistentesReales); // Copia para verificar cálculo.
        verificacionNoAutorizados.ExceptWith(Autorizados); // Resta autorizados para obtener “no autorizados” (verificación).
        _ = verificacionNoAutorizados.SetEquals(NoAutorizados); // Compara sets iguales (se ignora el resultado).

        Inscripciones.Clear(); // Limpia inscripciones válidas para recalcular.
        InscripcionesRechazadas.Clear(); // Limpia lista de rechazos para recalcular.
        ParticipantesConIntentoInvalido.Clear(); // Limpia participantes con intento inválido para recalcular.
        ProcesarInscripciones(); // Aplica reglas de negocio para llenar inscripciones válidas y rechazadas.
    }

    private void LimpiarEstado() // Borra todos los conjuntos/listas para reiniciar el procesamiento.
    {
        Preregistrados.Clear(); // Vacía preregistrados.
        RegistroManual.Clear(); // Vacía registro manual.
        InvitadosVip.Clear(); // Vacía invitados VIP.
        ListaNegra.Clear(); // Vacía lista negra.
        AsistentesReales.Clear(); // Vacía asistentes reales.
        Inscripciones.Clear(); // Vacía inscripciones válidas.

        Talleres.Clear(); // Vacía talleres.
        DuplicadosDetectados.Clear(); // Vacía mensajes de duplicados.
        InscripcionesRechazadas.Clear(); // Vacía motivos de rechazo.
        ParticipantesConIntentoInvalido.Clear(); // Vacía participantes con intento inválido.

        Autorizados.Clear(); // Vacía autorizados.
        NoAutorizados.Clear(); // Vacía no autorizados.
        Ausentes.Clear(); // Vacía ausentes.
    }

    private void CargarTalleres() // Crea los talleres base con horarios y capacidad.
    {
        Talleres.Add(new Taller // Agrega un taller nuevo a la lista.
        {
            Nombre = "Docker Pro", // Nombre del taller.
            HoraInicio = new TimeOnly(9, 0), // Hora de inicio (09:00).
            HoraFin = new TimeOnly(11, 0), // Hora de fin (11:00).
            Capacidad = 1 // Capacidad máxima para este taller.
        }); // Cierra la inicialización y agrega el taller.

        Talleres.Add(new Taller // Agrega otro taller a la lista.
        {
            Nombre = "Microservicios Avanzados", // Nombre del taller.
            HoraInicio = new TimeOnly(10, 0), // Inicio (10:00).
            HoraFin = new TimeOnly(12, 0), // Fin (12:00).
            Capacidad = 30 // Capacidad máxima.
        }); // Agrega el taller 2.

        Talleres.Add(new Taller // Agrega el tercer taller a la lista.
        {
            Nombre = "Kubernetes Basico", // Nombre del taller.
            HoraInicio = new TimeOnly(13, 0), // Inicio (13:00).
            HoraFin = new TimeOnly(15, 0), // Fin (15:00).
            Capacidad = 20 // Capacidad máxima.
        }); // Agrega el taller 3.
    }

    private void CargarParticipantes() // Carga los participantes de ejemplo y los distribuye en sus conjuntos/fuentes.
    {
        Participante ana = P("1001", "Ana Torres", "ana@correo.com"); // Crea el participante Ana Torres.
        Participante laura = P("1122", "Laura Pérez", "laura@correo.com"); // Crea el participante Laura Pérez.
        Participante carlos = P("7788", "Carlos Ruiz", "carlos@correo.com"); // Crea el participante Carlos Ruiz.
        Participante luis = P("999", "Luis Díaz", "LDiaz@correo.com"); // Crea el participante Luis Díaz.
        Participante maria = P("1005", "Maria Lopez", "maria@correo.com", true); // Crea María y la marca como VIP (true).
        Participante jorge = P("1006", "Jorge Rios", "jorge@correo.com"); // Crea el participante Jorge Rios.
        Participante sofia = P("1007", "Sofia Vargas", "sofia@correo.com", true); // Crea Sofía como VIP.
        Participante camilo = P("1008", "Camilo Prada", "camilo@correo.com"); // Crea Camilo Prada.
        Participante diana = P("1009", "Diana Castro", "diana@correo.com"); // Crea Diana Castro.
        Participante felipe = P("1010", "Felipe Munoz", "felipe@correo.com"); // Crea Felipe Munoz.
        Participante valentina = P("1011", "Valentina Gil", "vgil@correo.com"); // Crea Valentina Gil.
        Participante tomas = P("2001", "Tomas Nieto", "tomas@hotmail.com"); // Crea Tomás Nieto.
        Participante juliana = P("2002", "Juliana Soto", "juliana@hotmail.com"); // Crea Juliana Soto.
        Participante andres = P("2003", "Andres Cruz", "andres@hotmail.com"); // Crea Andrés Cruz.
        Participante robertoVip = P("1122", "Laura Pérez", "laura@correo.com", true); // Crea otro VIP con el mismo documento/email (para simular duplicados).
        Participante intruso = P("9999", "Intruso X", "intruso@mail.com"); // Crea un intruso (no autorizado o fuera de reglas).
        Participante sinRegistro = P("5555", "Sin Registro", "sinreg@mail.com"); // Crea un participante sin preregistro/registro.

        Participante dupDocumentoA = P("123", "Ana Torres", "ana@gmail.com"); // Participante con documento duplicado (variante A).
        Participante dupDocumentoB = P("123", "Ana T.", "anatorres@gmail.com"); // Participante con el mismo documento (variante B).
        Participante dupEmailA = P("999", "Luis Díaz", "LDiaz@correo.com"); // Participante con email que se repetirá (A).
        Participante dupEmailB = P("888", "Luis D.", "ldiaz@correo.com "); // Participante con email repetido (B, con espacios).

        Agregar(Preregistrados, "preregistro web", ana); // Agrega Ana al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", laura); // Agrega Laura al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", carlos); // Agrega Carlos al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", luis); // Agrega Luis al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", maria); // Agrega María al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", jorge); // Agrega Jorge al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", sofia); // Agrega Sofía al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", camilo); // Agrega Camilo al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", diana); // Agrega Diana al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", felipe); // Agrega Felipe al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", valentina); // Agrega Valentina al conjunto preregistrados.
        Agregar(Preregistrados, "preregistro web", dupDocumentoA); // Agrega duplicado por documento (A).

        Agregar(Preregistrados, "preregistro web", dupDocumentoB, true); // Agrega duplicado por documento (B) registrando duplicado.
        Agregar(Preregistrados, "preregistro web", dupEmailA); // Agrega participante con email (A).
        Agregar(Preregistrados, "preregistro web", dupEmailB, true); // Agrega participante con email (B) registrando duplicado.

        Agregar(RegistroManual, "registro manual", tomas); // Agrega Tomás en registro manual.
        Agregar(RegistroManual, "registro manual", juliana); // Agrega Juliana en registro manual.
        Agregar(RegistroManual, "registro manual", andres); // Agrega Andrés en registro manual.
        Agregar(RegistroManual, "registro manual", P("1012", "Ricardo Mora", "rmora@correo.com")); // Agrega un participante extra en registro manual.

        Agregar(InvitadosVip, "invitados VIP", maria); // Agrega María como VIP.
        Agregar(InvitadosVip, "invitados VIP", sofia); // Agrega Sofía como VIP.
        Agregar(InvitadosVip, "invitados VIP", robertoVip); // Agrega VIP adicional (simula duplicado).

        Agregar(ListaNegra, "lista negra", carlos); // Carlos cae en lista negra.
        Agregar(ListaNegra, "lista negra", intruso); // Intruso cae en lista negra.

        Agregar(AsistentesReales, "asistencia real", ana); // Ana asistió realmente.
        Agregar(AsistentesReales, "asistencia real", carlos); // Carlos asistió (pero estaba en lista negra).
        Agregar(AsistentesReales, "asistencia real", luis); // Luis asistió realmente.
        Agregar(AsistentesReales, "asistencia real", dupDocumentoA); // DupDocumentoA aparece como asistente real.
        Agregar(AsistentesReales, "asistencia real", maria); // María asistió realmente.
        Agregar(AsistentesReales, "asistencia real", jorge); // Jorge asistió realmente.
        Agregar(AsistentesReales, "asistencia real", sofia); // Sofía asistió realmente.
        Agregar(AsistentesReales, "asistencia real", camilo); // Camilo asistió realmente.
        Agregar(AsistentesReales, "asistencia real", diana); // Diana asistió realmente.
        Agregar(AsistentesReales, "asistencia real", felipe); // Felipe asistió realmente.
        Agregar(AsistentesReales, "asistencia real", valentina); // Valentina asistió realmente.
        Agregar(AsistentesReales, "asistencia real", tomas); // Tomás asistió realmente.
        Agregar(AsistentesReales, "asistencia real", sinRegistro); // SinRegistro asistió (sin estar en registros de prueba).
        Agregar(AsistentesReales, "asistencia real", P("1012", "Ricardo Mora", "rmora@correo.com")); // Ricardo Mora asistió realmente.
    }

    private void ProcesarInscripciones() // Valida y registra inscripciones según reglas (usa Autorizados ya conciliado).
    {
        Taller? docker = BuscarTallerPorNombre("Docker Pro"); // Busca el taller “Docker Pro”.
        Taller? micro = BuscarTallerPorNombre("Microservicios Avanzados"); // Busca el taller “Microservicios Avanzados”.
        Taller? kube = BuscarTallerPorNombre("Kubernetes Basico"); // Busca el taller “Kubernetes Basico”.

        Participante? ana = Buscar("1001"); // Busca participante con documento 1001.
        Participante? luis = Buscar("999"); // Busca participante con documento 999.
        Participante? carlos = Buscar("7788"); // Busca participante con documento 7788.
        Participante? maria = Buscar("1005"); // Busca participante con documento 1005.

        if (ana != null && docker != null && micro != null) // Si existen ana y los 2 talleres, intenta inscribir.
        {
            Inscribir(ana, docker); // Intenta inscribir a ana en Docker Pro.
            Inscribir(ana, micro); // Intenta inscribir a ana en Microservicios Avanzados.
        }

        if (luis != null && docker != null) // Si existen luis y Docker Pro, intenta inscribir.
        {
            Inscribir(luis, docker); // Intenta inscribir a luis en Docker Pro.
        }

        if (carlos != null && kube != null) // Si existen carlos y Kubernetes Básico, intenta inscribir.
        {
            Inscribir(carlos, kube); // Intenta inscribir a carlos en Kubernetes Básico.
        }

        if (maria != null && kube != null) // Si existen maria y Kubernetes Básico, intenta inscribir.
        {
            Inscribir(maria, kube); // Intenta inscribir a maria en Kubernetes Básico.
        }
    }

    private Taller? BuscarTallerPorNombre(string nombre) // Busca un taller en la lista por nombre exacto.
    {
        foreach (Taller t in Talleres) // Recorre todos los talleres disponibles.
        {
            if (t.Nombre == nombre) // Si el nombre coincide...
            {
                return t; // ...retorna el taller encontrado.
            }
        }

        return null; // Si no se encontró coincidencia, retorna null.
    }

    private Participante? Buscar(string documentoNorm) // Busca un participante en las diferentes fuentes usando un documento normalizado.
    {
        string key = documentoNorm.Trim(); // Quita espacios al documento para usarlo como clave.
        Participante? p = BuscarEnConjunto(Preregistrados, key); // Primero busca en preregistrados.
        if (p != null) // Si lo encontró...
        {
            return p; // ...devuelve ese participante.
        }

        p = BuscarEnConjunto(RegistroManual, key); // Si no, busca en registro manual.
        if (p != null) // Si lo encontró...
        {
            return p; // ...devuelve ese participante.
        }

        p = BuscarEnConjunto(InvitadosVip, key); // Si no, busca en VIP.
        if (p != null) // Si lo encontró...
        {
            return p; // ...devuelve ese participante.
        }

        p = BuscarEnConjunto(ListaNegra, key); // Si no, busca en lista negra.
        if (p != null) // Si lo encontró...
        {
            return p; // ...devuelve ese participante.
        }

        return BuscarEnConjunto(AsistentesReales, key); // Finalmente busca en asistentes reales.
    }

    private static Participante? BuscarEnConjunto(HashSet<Participante> conjunto, string documentoTrim) // Busca dentro de un HashSet comparando DocumentoNorm sin distinguir mayúsculas/minúsculas.
    {
        foreach (Participante p in conjunto) // Recorre el conjunto recibido.
        {
            if (string.Equals(p.DocumentoNorm, documentoTrim, StringComparison.OrdinalIgnoreCase)) // Compara documento normalizado ignorando mayúsculas.
            {
                return p; // ...devuelve el participante encontrado.
            }
        }

        return null; // Si no coincide con ninguno, retorna null.
    }

    private void Agregar(HashSet<Participante> destino, string fuente, Participante nuevo, bool registrarDuplicado = false) // Agrega a un conjunto; si ya existe y registrarDuplicado es true, registra el motivo del duplicado.
    {
        _ = fuente; // Variable no usada (queda para mantener la firma del ejercicio).
        if (destino.TryGetValue(nuevo, out Participante? existente)) // Intenta obtener si el participante ya existe en el HashSet.
        {
            if (registrarDuplicado) // Solo si pedimos registrar duplicados...
            {
                RegistrarMotivoDuplicado(nuevo, existente); // ...se guarda el motivo del duplicado.
            }

            return; // Si ya existía, no se agrega nuevamente (HashSet evita duplicados).
        }

        destino.Add(nuevo); // Si no existía, se agrega el nuevo participante.
    }

    private void RegistrarMotivoDuplicado(Participante nuevo, Participante existente) // Compara documento y email normalizado para registrar por qué se considera duplicado.
    {
        if (nuevo.DocumentoNorm.Length > 0 && existente.DocumentoNorm.Length > 0 &&
            string.Equals(nuevo.DocumentoNorm, existente.DocumentoNorm, StringComparison.OrdinalIgnoreCase))
        {
            DuplicadosDetectados.Add($"Documento repetido: {nuevo.DocumentoNorm}"); // Registra duplicado por documento.
            return; // Si ya se detectó por documento, salimos.
        }

        if (nuevo.EmailNorm.Length > 0 && existente.EmailNorm.Length > 0 &&
            string.Equals(nuevo.EmailNorm, existente.EmailNorm, StringComparison.OrdinalIgnoreCase))
        {
            DuplicadosDetectados.Add($"Email repetido: {nuevo.EmailNorm}"); // Registra duplicado por email.
        }
    }

    private void Inscribir(Participante participante, Taller taller) // Intenta inscribir a un participante en un taller aplicando reglas de negocio.
    {
        if (!Autorizados.Contains(participante)) // Si no está en el conjunto de autorizados...
        {
            Rechazar(participante, taller, "participante no autorizado"); // ...se rechaza el intento con motivo.
            return; // Se sale porque no puede inscribirse.
        }

        int ocupados = ContarInscripcionesPorTaller(taller); // Cuenta cuántos ya están inscritos en ese taller.
        if (ocupados >= taller.Capacidad) // Si ya no hay cupo...
        {
            Rechazar(participante, taller, "sin cupo"); // ...se rechaza por falta de cupo.
            return; // Se sale del método.
        }

        if (TieneCruceHorario(participante, taller)) // Si el participante ya tiene otro taller que se cruza...
        {
            Rechazar(participante, taller, "cruce de horario"); // ...se rechaza por cruce.
            return; // Se sale porque no es válido.
        }

        Inscripciones.Add(new InscripcionTaller
        {
            Participante = participante, // Asigna el participante.
            Taller = taller // Asigna el taller.
        }); // Cierra la inicialización y agrega la inscripción al conjunto.
    }

    private int ContarInscripcionesPorTaller(Taller taller) // Cuenta cuántas inscripciones existentes hay para el taller indicado.
    {
        return Inscripciones.Count(i => i.Taller.Equals(taller)); // LINQ cuenta inscripciones cuyo taller coincide con el parámetro.
    }

    private bool TieneCruceHorario(Participante participante, Taller taller) // Verifica si el participante tiene un taller con horario que se cruza.
    {
        foreach (InscripcionTaller i in Inscripciones) // Recorre todas las inscripciones válidas.
        {
            if (i.Participante.Equals(participante) && i.Taller.SeCruzaCon(taller)) // Si es el mismo participante y hay cruce de horario...
            {
                return true; // ...entonces sí hay cruce.
            }
        }

        return false; // Si nunca encontramos cruce, devolvemos false.
    }

    private void Rechazar(Participante p, Taller t, string motivo) // Registra un rechazo: agrega mensaje y marca el participante como intento inválido.
    {
        InscripcionesRechazadas.Add($"{p.NombreCompleto} -> Taller \"{t.Nombre}\" | Motivo: {motivo}"); // Guarda el motivo del rechazo.
        ParticipantesConIntentoInvalido.Add(p); // Marca al participante como con intento inválido.
    }

    private static Participante P(string doc, string nombre, string email, bool vip = false) // Crea una instancia de Participante con los datos dados.
    {
        return new Participante // Retorna un nuevo participante inicializado.
        {
            Documento = doc, // Asigna documento.
            NombreCompleto = nombre, // Asigna nombre completo.
            Email = email, // Asigna email.
            EsVip = vip // Asigna si es VIP.
        }; // Cierra el objeto inicializado y lo retorna como nuevo Participante.
    }
}
