namespace BreakLineEvents.Models;

/// <summary>
/// Modelo mínimo según 32.md (Guid, documento, nombre, email, VIP).
///
/// Estrategia de igualdad (regla del enunciado):
/// dos participantes son la misma persona si comparten el mismo documento (tras Trim,
/// comparación ordinal sin distinguir mayúsculas) O el mismo email normalizado
/// (Trim + minúsculas invariantes).
///
/// Como esa relación es "O" y no se puede derivar un GetHashCode perfecto sin colisiones
/// falsas entre documento y email, se usa GetHashCode constante para cumplir el contrato
/// de object.Equals/GetHashCode y de IEquatable con HashSet; el coste es O(n) por cubeta,
/// aceptable para los volúmenes del ejercicio (32.md: conservar coherencia en igualdad).
/// </summary>
public class Participante : IEquatable<Participante>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Documento { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool EsVip { get; set; }

    public string DocumentoNorm => Documento.Trim();
    public string EmailNorm => Email.Trim().ToLowerInvariant();

    public bool Equals(Participante? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (DocumentoNorm.Length > 0 && other.DocumentoNorm.Length > 0 &&
            string.Equals(DocumentoNorm, other.DocumentoNorm, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (EmailNorm.Length > 0 && other.EmailNorm.Length > 0 &&
            string.Equals(EmailNorm, other.EmailNorm, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return false;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Participante);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString()
    {
        return $"{NombreCompleto} | DOC: {DocumentoNorm} | EMAIL: {EmailNorm}";
    }
}
