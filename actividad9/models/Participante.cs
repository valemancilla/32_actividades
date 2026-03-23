namespace BreakLineEvents.Models; // Modelos del dominio: participante, taller, etc.

public class Participante : IEquatable<Participante>
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Identificador interno.
    public string Documento { get; set; } = string.Empty; // Documento (por ejemplo DNI) original.
    public string NombreCompleto { get; set; } = string.Empty; // Nombre y apellido.
    public string Email { get; set; } = string.Empty; // Email original.
    public bool EsVip { get; set; } // Indica si el participante es VIP.

    public string DocumentoNorm => Documento.Trim(); // Documento normalizado (sin espacios).
    public string EmailNorm => Email.Trim().ToLowerInvariant(); // Email normalizado (sin espacios y en minusculas).

    public bool Equals(Participante? other)
    {
        if (other is null) // Si no hay otro participante...
        {
            return false; // Si other es null, no son iguales.
        }

        if (ReferenceEquals(this, other)) // Si es la misma instancia...
        {
            return true; // Si es la misma referencia, son iguales.
        }

        if (DocumentoNorm.Length > 0 && other.DocumentoNorm.Length > 0 && // Si ambos tienen Documento...
            string.Equals(DocumentoNorm, other.DocumentoNorm, StringComparison.OrdinalIgnoreCase)) // ...y coincide ignorando mayus/min.
        {
            return true; // Son la misma persona por documento.
        }

        if (EmailNorm.Length > 0 && other.EmailNorm.Length > 0 && // Si ambos tienen Email...
            string.Equals(EmailNorm, other.EmailNorm, StringComparison.OrdinalIgnoreCase)) // ...y coincide ignorando mayus/min.
        {
            return true; // Son la misma persona por email.
        }

        return false; // No coincide por documento ni por email.
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Participante); // Llama al Equals tipado.
    }

    public override int GetHashCode()
    {
        return 0; // Hash constante para mantener coherencia con el contrato Equals.
    }

    public override string ToString()
    {
        return $"{NombreCompleto} | DOC: {DocumentoNorm} | EMAIL: {EmailNorm}"; // Formato amigable para imprimir.
    }
}
