namespace BreakLineEvents.Models;

// Estrategia consistente:
// - Equals/GetHashCode usan Id para mantener contrato valido en HashSet.
// - La identidad logica del enunciado (Documento o Email normalizado)
//   se aplica en el servicio de conciliacion al momento de cargar datos.
public sealed class Participante : IEquatable<Participante>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Documento { get; init; } = string.Empty;
    public string NombreCompleto { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public bool EsVip { get; init; }

    public string DocumentoNorm => Documento.Trim();
    public string EmailNorm => Email.Trim().ToLowerInvariant();

    public bool Equals(Participante? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj) => Equals(obj as Participante);
    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString()
        => $"{NombreCompleto} | DOC: {DocumentoNorm} | EMAIL: {EmailNorm}";
}
