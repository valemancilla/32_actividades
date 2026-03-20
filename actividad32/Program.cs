
var graph = BuildExampleGraph();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Sistema de optimización de rutas (Dijkstra) ===");
    Console.WriteLine();
    Console.WriteLine("  1) Calcular ruta de menor consumo (recogida -> entrega)");
    Console.WriteLine("  2) Ver puntos y conexiones de la red");
    Console.WriteLine("  3) Salir");
    Console.WriteLine();
    Console.Write("Seleccione una opción (1-3): ");

    var choice = Console.ReadLine()?.Trim();
    Console.Clear();

    switch (choice)
    {
        case "1":
            RunDijkstraRoute(graph);
            break;
        case "2":
            PrintGraph(graph);
            break;
        case "3":
            Console.WriteLine("Fin del programa.");
            return;
        default:
            Console.WriteLine("Opción no válida. Pulse una tecla para volver al menú.");
            Console.ReadKey(true);
            continue;
    }

    Console.WriteLine();
    Console.WriteLine("Pulse una tecla para volver al menú...");
    Console.ReadKey(true);
}


static Dictionary<string, List<(string To, int Fuel)>> BuildExampleGraph()
{
    void Add(Dictionary<string, List<(string, int)>> g, string from, string to, int fuel)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(fuel, 0);

        if (!g.TryGetValue(from, out var list))
        {
            list = [];
            g[from] = list;
        }

        list.Add((to, fuel));
        g.TryAdd(to, []);
    }

    var g = new Dictionary<string, List<(string, int)>>(StringComparer.OrdinalIgnoreCase);

    
    Add(g, "A", "B", 4);
    Add(g, "A", "C", 2);
    Add(g, "B", "D", 5);
    Add(g, "C", "B", 1);
    Add(g, "C", "D", 8);
    Add(g, "C", "E", 10);
    Add(g, "D", "E", 2);
    Add(g, "E", "F", 3);
    Add(g, "D", "F", 6);

    Add(g, "F", "G", 2);
    Add(g, "D", "G", 4);
    Add(g, "G", "H", 4);
    Add(g, "H", "I", 3);
    Add(g, "I", "J", 2);
    Add(g, "J", "K", 5);
    Add(g, "K", "H", 6);
    Add(g, "E", "I", 8);

    return g;
}

static void PrintGraph(Dictionary<string, List<(string To, int Fuel)>> graph)
{
    Console.WriteLine("=== Red de puntos y consumo estimado ===");
    Console.WriteLine();
    var nodes = graph.Keys.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();
    foreach (var from in nodes)
    {
        if (graph[from].Count == 0)
        {
            Console.WriteLine($"{from}: (sin salidas)");
            continue;
        }

        foreach (var (to, fuel) in graph[from].OrderBy(e => e.To, StringComparer.OrdinalIgnoreCase))
            Console.WriteLine($"{from} -> {to} = {fuel}");
    }
}

static void RunDijkstraRoute(Dictionary<string, List<(string To, int Fuel)>> graph)
{
    Console.WriteLine("=== Calcular ruta de menor consumo ===");
    Console.WriteLine();
    Console.Write("Punto de recogida: ");
    var start = NormalizeNode(Console.ReadLine());
    Console.Write("Punto de entrega: ");
    var end = NormalizeNode(Console.ReadLine());

    if (string.IsNullOrEmpty(start) || string.IsNullOrEmpty(end))
    {
        Console.WriteLine("Debe indicar ambos puntos.");
        return;
    }

    if (!graph.ContainsKey(start))
    {
        Console.WriteLine($"No existe el punto de recogida «{start}» en la red.");
        return;
    }

    if (!graph.ContainsKey(end))
    {
        Console.WriteLine($"No existe el punto de entrega «{end}» en la red.");
        return;
    }

    if (start.Equals(end, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine();
        Console.WriteLine($"Ruta de menor consumo: {start}");
        Console.WriteLine("Consumo total estimado: 0");
        return;
    }

    var result = DijkstraShortestPath(graph, start, end);
    if (result is null)
    {
        Console.WriteLine("No existe ruta entre los puntos indicados.");
        return;
    }

    var (path, totalFuel) = result.Value;
    Console.WriteLine();
    Console.WriteLine($"Ruta de menor consumo: {string.Join(" -> ", path)}");
    Console.WriteLine($"Consumo total estimado: {totalFuel}");
}

static string? NormalizeNode(string? s)
{
    if (string.IsNullOrWhiteSpace(s)) return null;
    return s.Trim().ToUpperInvariant();
}


static (List<string> Path, int TotalFuel)? DijkstraShortestPath(
    Dictionary<string, List<(string To, int Fuel)>> graph,
    string start,
    string end)
{
    var dist = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    var prev = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
    foreach (var k in graph.Keys)
    {
        dist[k] = int.MaxValue;
        prev[k] = null;
    }

    if (!dist.ContainsKey(start))
        return null;

    dist[start] = 0;
    var pq = new PriorityQueue<string, int>();
    pq.Enqueue(start, 0);

    while (pq.Count > 0)
    {
        if (!pq.TryDequeue(out var u, out var dU) || u is null)
            break;

        if (dU != dist[u])
            continue;

        if (u.Equals(end, StringComparison.OrdinalIgnoreCase))
            break;

        foreach (var (v, w) in graph[u])
        {
            if (w <= 0)
                throw new InvalidOperationException("Los pesos deben ser positivos (enunciado).");

            var nd = dU + w;
            if (nd >= dist[v])
                continue;

            dist[v] = nd;
            prev[v] = u;
            pq.Enqueue(v, nd);
        }
    }

    if (dist[end] == int.MaxValue)
        return null;

    var path = new List<string>();
    for (string? at = end; at is not null; at = prev[at])
        path.Add(at);

    path.Reverse();
    return (path, dist[end]);
}
