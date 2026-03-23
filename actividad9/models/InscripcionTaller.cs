namespace BreakLineEvents.Models; // Modelo de inscripción (participante + taller).

public class InscripcionTaller : IEquatable<InscripcionTaller>
{
    public Participante Participante { get; set; } = null!; // Participante inscrito (no null en uso).
    public Taller Taller { get; set; } = null!; // Taller asociado a la inscripción (no null en uso).

    public bool Equals(InscripcionTaller? other)
    {
        if (other is null) // Si no hay objeto a comparar...
        {
            return false; // Si other es null, no son iguales.
        }

        if (ReferenceEquals(this, other)) // Si es la misma referencia...
        {
            return true; // Es la misma instancia, son iguales.
        }

        return Participante.Equals(other.Participante) && Taller.Equals(other.Taller); // Igual si coincide participante y taller.
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as InscripcionTaller); // Convierte y llama a Equals tipado.
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Participante.GetHashCode(), Taller.GetHashCode()); // Combina hashes para HashSet.
    }
}
