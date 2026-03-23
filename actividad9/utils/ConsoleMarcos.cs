namespace BreakLineEvents.Utils; // Espacio de nombres para utilidades de consola.

public static class ConsoleMarcos
{
    public const int AnchoMarco = 54; // Define el ancho fijo del marco de caracteres.

    public static void MarcoDoble(string tituloPrincipal, string subtitulo) // Muestra un marco con titulo y subtitulo.
    {
        string barra = new string('═', AnchoMarco); // Crea una barra repetida para construir el marco.
        Console.WriteLine(); // Salto de línea para separar el marco.
        Console.WriteLine("  ╔" + barra + "╗"); // Línea superior del marco.
        Console.WriteLine("  ║" + Centrar(tituloPrincipal, AnchoMarco) + "║"); // Centra el titulo dentro del ancho.
        Console.WriteLine("  ║" + Centrar(subtitulo, AnchoMarco) + "║"); // Centra el subtitulo dentro del ancho.
        Console.WriteLine("  ╚" + barra + "╝"); // Línea inferior del marco.
    }

    public static void MarcoSimple(string titulo)
    {
        string barra = new string('═', AnchoMarco); // Crea la barra del marco.
        Console.WriteLine(); // Salto de línea antes del marco.
        Console.WriteLine("  ╔" + barra + "╗"); // Borde superior.
        Console.WriteLine("  ║" + Centrar(titulo, AnchoMarco) + "║"); // Titulo centrado.
        Console.WriteLine("  ╚" + barra + "╝"); // Borde inferior.
    }

    public static void LineaFina() // Muestra una linea horizontal fina separadora.
    {
        Console.WriteLine("  " + new string('─', AnchoMarco + 2)); // Genera caracteres repetidos para la linea.
    }

    public static void MetricaAlineada(string etiqueta, int valor) // Imprime una métrica alineada en columnas.
    {
        const int colEtiqueta = 36; // Ancho máximo de la etiqueta.
        string e = etiqueta.Length > colEtiqueta ? etiqueta.Substring(0, colEtiqueta) : etiqueta; // Corta etiqueta si excede.
        Console.WriteLine($"    {e.PadRight(colEtiqueta)} │ {valor}"); // Imprime etiqueta (centrada/ajustada) y el valor.
    }

    public static string Centrar(string texto, int ancho) // Centra un texto dentro de un ancho dado.
    {
        if (string.IsNullOrEmpty(texto)) // Si el texto está vacío o es null...
        {
            return new string(' ', ancho); // ...devuelve espacios para ocupar todo el ancho.
        }

        if (texto.Length >= ancho) // Si el texto ya cabe o es más largo...
        {
            return texto.Substring(0, ancho); // ...lo recorta al tamaño del ancho.
        }

        int espacios = ancho - texto.Length; // Cantidad total de espacios a repartir.
        int izq = espacios / 2; // Espacios a la izquierda.
        int der = espacios - izq; // Espacios restantes a la derecha.
        return new string(' ', izq) + texto + new string(' ', der); // Construye texto centrado.
    }
}
