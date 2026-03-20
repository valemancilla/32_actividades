namespace BreakLineEvents.Models;

public sealed class Taller : IEquatable<Taller>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nombre { get; init; } = string.Empty;
    public TimeOnly HoraInicio { get; init; }
    public TimeOnly HoraFin { get; init; }
    public int Capacidad { get; init; }

    public bool SeCruzaCon(Taller otro)
        => HoraInicio < otro.HoraFin && otro.HoraInicio < HoraFin;

    public bool Equals(Taller? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id;
    }

    public override bool Equals(object? obj) => Equals(obj as Taller);
    public override int GetHashCode() => Id.GetHashCode();
}
