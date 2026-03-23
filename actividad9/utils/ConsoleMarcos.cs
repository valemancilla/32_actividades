namespace BreakLineEvents.Utils;

/// <summary>
/// Marcos de consola unificados (mismo estilo en menú, opciones 1–3 y reporte).
/// </summary>
public static class ConsoleMarcos
{
    public const int AnchoMarco = 54;

    public static void MarcoDoble(string tituloPrincipal, string subtitulo)
    {
        string barra = new string('═', AnchoMarco);
        Console.WriteLine();
        Console.WriteLine("  ╔" + barra + "╗");
        Console.WriteLine("  ║" + Centrar(tituloPrincipal, AnchoMarco) + "║");
        Console.WriteLine("  ║" + Centrar(subtitulo, AnchoMarco) + "║");
        Console.WriteLine("  ╚" + barra + "╝");
    }

    /// <summary>Una sola línea de título dentro del mismo marco que <see cref="MarcoDoble"/>.</summary>
    public static void MarcoSimple(string titulo)
    {
        string barra = new string('═', AnchoMarco);
        Console.WriteLine();
        Console.WriteLine("  ╔" + barra + "╗");
        Console.WriteLine("  ║" + Centrar(titulo, AnchoMarco) + "║");
        Console.WriteLine("  ╚" + barra + "╝");
    }

    public static void LineaFina()
    {
        Console.WriteLine("  " + new string('─', AnchoMarco + 2));
    }

    public static void MetricaAlineada(string etiqueta, int valor)
    {
        const int colEtiqueta = 36;
        string e = etiqueta.Length > colEtiqueta ? etiqueta.Substring(0, colEtiqueta) : etiqueta;
        Console.WriteLine($"    {e.PadRight(colEtiqueta)} │ {valor}");
    }

    public static string Centrar(string texto, int ancho)
    {
        if (string.IsNullOrEmpty(texto))
        {
            return new string(' ', ancho);
        }

        if (texto.Length >= ancho)
        {
            return texto.Substring(0, ancho);
        }

        int espacios = ancho - texto.Length;
        int izq = espacios / 2;
        int der = espacios - izq;
        return new string(' ', izq) + texto + new string(' ', der);
    }
}
