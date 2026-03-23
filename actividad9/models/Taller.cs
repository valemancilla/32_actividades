namespace BreakLineEvents.Models; // Modelos del dominio (talleres, participantes, inscripciones).

public class Taller : IEquatable<Taller>
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Identificador único del taller.
    public string Nombre { get; set; } = string.Empty; // Nombre del taller.
    public TimeOnly HoraInicio { get; set; } // Hora de inicio (solo hora, sin fecha).
    public TimeOnly HoraFin { get; set; } // Hora de fin (solo hora, sin fecha).
    public int Capacidad { get; set; } // Máximo de participantes.

    public bool SeCruzaCon(Taller otro)
    {
        return HoraInicio < otro.HoraFin && otro.HoraInicio < HoraFin; // Solapa si los intervalos se interceptan.
    }

    public bool Equals(Taller? other)
    {
        if (other is null) // Si el otro es null, no son iguales.
        {
            return false; // Si el otro es null, no son iguales.
        }

        if (ReferenceEquals(this, other)) // Si es la misma instancia...
        {
            return true; // Si es la misma instancia, son iguales.
        }

        return Id == other.Id; // Comparamos por Id.
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Taller); // Llama a Equals(Taller).
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode(); // Hash coherente con Equals por Id.
    }
}
