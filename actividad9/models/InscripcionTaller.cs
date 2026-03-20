namespace BreakLineEvents.Models;

public sealed class InscripcionTaller : IEquatable<InscripcionTaller>
{
    public Participante Participante { get; init; } = null!;
    public Taller Taller { get; init; } = null!;

    public bool Equals(InscripcionTaller? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Participante.Equals(other.Participante) && Taller.Equals(other.Taller);
    }

    public override bool Equals(object? obj) => Equals(obj as InscripcionTaller);
    public override int GetHashCode() => HashCode.Combine(Participante, Taller);
}
