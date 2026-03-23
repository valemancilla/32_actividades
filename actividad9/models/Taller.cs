namespace BreakLineEvents.Models;

/// <summary>
/// Modelo mínimo según 32.md: Guid, Nombre, TimeOnly de inicio/fin, capacidad.
/// </summary>
public class Taller : IEquatable<Taller>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nombre { get; set; } = string.Empty;
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
    public int Capacidad { get; set; }

    /// <summary>
    /// Solape estricto de intervalos [inicio, fin) en el mismo día lógico (32.md).
    /// </summary>
    public bool SeCruzaCon(Taller otro)
    {
        return HoraInicio < otro.HoraFin && otro.HoraInicio < HoraFin;
    }

    public bool Equals(Taller? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Taller);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
