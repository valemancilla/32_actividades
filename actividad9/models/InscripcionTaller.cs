namespace BreakLineEvents.Models;

/// <summary>
/// Modelo mínimo 32.md: pareja participante-taller.
/// Igualdad: mismo participante lógico (IEquatable Participante) y mismo taller (Guid).
/// Hash: combina los códigos de participante y taller para alinearse con Equals (32.md: integridad).
/// </summary>
public class InscripcionTaller : IEquatable<InscripcionTaller>
{
    public Participante Participante { get; set; } = null!;
    public Taller Taller { get; set; } = null!;

    public bool Equals(InscripcionTaller? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Participante.Equals(other.Participante) && Taller.Equals(other.Taller);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as InscripcionTaller);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Participante.GetHashCode(), Taller.GetHashCode());
    }
}
