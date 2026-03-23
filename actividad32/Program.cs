

using System;
using System.Collections.Generic;

// Guarda el mapa: puntos (nodos) y caminos con costo (combustible).
// Cada camino es una fila: Origenes[i] va a Destinos[i] gastando Costos[i].
public class RedRutas
{
    public List<string> Nodos { get; }
    public List<string> Origenes { get; }
    public List<string> Destinos { get; }
    public List<int> Costos { get; }

    public RedRutas()
    {
        Nodos = new List<string>();
        Origenes = new List<string>();
        Destinos = new List<string>();
        Costos = new List<int>();
    }

    // Pone en el programa la red del enunciado (y un poco más de puntos).
    public void CargarEjemploDelEnunciado()
    {
        // Ejemplo del archivo.md (A hasta F)
        AgregarArista("A", "B", 4);
        AgregarArista("A", "C", 2);
        AgregarArista("B", "D", 5);
        AgregarArista("C", "B", 1);
        AgregarArista("C", "D", 8);
        AgregarArista("C", "E", 10);
        AgregarArista("D", "E", 2);
        AgregarArista("E", "F", 3);
        AgregarArista("D", "F", 6);

        // Más puntos para probar
        AgregarArista("F", "G", 2);
        AgregarArista("D", "G", 4);
        AgregarArista("G", "H", 4);
        AgregarArista("H", "I", 3);
        AgregarArista("I", "J", 2);
        AgregarArista("J", "K", 5);
        AgregarArista("K", "H", 6);
        AgregarArista("E", "I", 8);
    }

    // Agrega un camino de "desde" a "hasta" con su combustible (solo si el costo es positivo).
    void AgregarArista(string desde, string hasta, int combustible)
    {
        if (combustible <= 0)
            return;

        desde = desde.Trim().ToUpperInvariant();
        hasta = hasta.Trim().ToUpperInvariant();

        if (!ContieneNodo(desde))
            Nodos.Add(desde);
        if (!ContieneNodo(hasta))
            Nodos.Add(hasta);

        Origenes.Add(desde);
        Destinos.Add(hasta);
        Costos.Add(combustible);
    }

    public bool ContieneNodo(string nombre)
    {
        return IndiceDeNodo(nombre) >= 0;
    }

    // En qué posición está el punto en la lista Nodos (-1 = no está).
    public int IndiceDeNodo(string nombre)
    {
        for (int i = 0; i < Nodos.Count; i++)
        {
            if (Nodos[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }
}

// Dijkstra: encuentra el camino más barato (menos combustible total).
// Versión simple: en cada vuelta elijo el punto no visitado con menor costo acumulado.
public static class RutaDijkstra
{
    // Número grande = "todavía no llegamos a ese punto"
    const int SinCaminoConocido = 1000000000;

    // Devuelve true y llena ruta + combustibleTotal si hay camino; false si no se puede llegar.
    public static bool CalcularMenorRuta(
        RedRutas red,
        string inicio,
        string fin,
        out List<string> ruta,
        out int combustibleTotal)
    {
        ruta = new List<string>();
        combustibleTotal = 0;

        int indiceInicio = red.IndiceDeNodo(inicio);
        int indiceFin = red.IndiceDeNodo(fin);

        int n = red.Nodos.Count;
        int[] distancia = new int[n];   // mejor costo conocido desde el inicio hasta cada punto
        int[] anterior = new int[n];    // de dónde venimos en el mejor camino (-1 = nadie)
        bool[] visitado = new bool[n]; // ya cerramos ese punto

        for (int i = 0; i < n; i++)
        {
            distancia[i] = SinCaminoConocido;
            anterior[i] = -1;
            visitado[i] = false;
        }

        distancia[indiceInicio] = 0;

        for (int paso = 0; paso < n; paso++)
        {
            // Tomar el punto no visitado más barato de llegar hasta ahora
            int u = -1;
            int mejor = SinCaminoConocido;
            for (int i = 0; i < n; i++)
            {
                if (!visitado[i] && distancia[i] < mejor)
                {
                    mejor = distancia[i];
                    u = i;
                }
            }

            if (u < 0 || distancia[u] == SinCaminoConocido)
                break;

            visitado[u] = true;

            if (u == indiceFin)
                break;

            // Revisar salidas desde u: si por aquí es más barato, actualizo distancia y anterior
            for (int e = 0; e < red.Origenes.Count; e++)
            {
                if (!red.Origenes[e].Equals(red.Nodos[u], StringComparison.OrdinalIgnoreCase))
                    continue;

                int indiceVecino = red.IndiceDeNodo(red.Destinos[e]);
                if (indiceVecino < 0)
                    continue;

                int peso = red.Costos[e];
                if (peso <= 0)
                    continue;

                long posible = (long)distancia[u] + peso;
                if (posible < distancia[indiceVecino])
                {
                    distancia[indiceVecino] = (int)posible;
                    anterior[indiceVecino] = u;
                }
            }
        }

        if (distancia[indiceFin] == SinCaminoConocido)
            return false;

        // Armo la lista del final al inicio y la doy vuelta
        int actual = indiceFin;
        while (actual >= 0)
        {
            ruta.Add(red.Nodos[actual]);
            actual = anterior[actual];
        }

        ruta.Reverse();
        combustibleTotal = distancia[indiceFin];
        return true;
    }
}

class Program
{
    static void Main()
    {
        RedRutas red = new RedRutas();
        red.CargarEjemploDelEnunciado();

        PedirYMostrarRuta(red);

        Console.WriteLine();
        Console.WriteLine("Pulse una tecla para cerrar...");
        Console.ReadKey(true);
    }

    // Limpio espacios y paso a mayúsculas para que coincida con los nombres del mapa.
    static string? NormalizarEntrada(string? texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return null;
        return texto.Trim().ToUpperInvariant();
    }

    // Pausa para que el usuario lea el error antes de volver a preguntar.
    static void EsperarParaReintentar()
    {
        Console.WriteLine();
        Console.WriteLine("Pulse una tecla para intentar de nuevo...");
        Console.ReadKey(true);
    }

    // Pregunta recogida y entrega; si algo falla, vuelve a preguntar sin cerrar el programa.
    static void PedirYMostrarRuta(RedRutas red)
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Punto de recogida: ");
            string? inicio = NormalizarEntrada(Console.ReadLine());
            Console.Write("Punto de entrega: ");
            string? fin = NormalizarEntrada(Console.ReadLine());

            if (inicio == null || fin == null)
            {
                Console.WriteLine("Debe indicar ambos puntos.");
                EsperarParaReintentar();
                continue;
            }

            if (!red.ContieneNodo(inicio))
            {
                Console.WriteLine("No existe el punto de recogida «" + inicio + "» en la red.");
                EsperarParaReintentar();
                continue;
            }

            if (!red.ContieneNodo(fin))
            {
                Console.WriteLine("No existe el punto de entrega «" + fin + "» en la red.");
                EsperarParaReintentar();
                continue;
            }

            // Mismo punto: ruta de un solo paso, consumo 0
            if (inicio.Equals(fin, StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Ruta de menor consumo: " + inicio);
                Console.WriteLine("Consumo total estimado: 0");
                break;
            }

            List<string> ruta;
            int total;
            bool hayCamino = RutaDijkstra.CalcularMenorRuta(red, inicio, fin, out ruta, out total);

            if (!hayCamino)
            {
                Console.WriteLine("No existe ruta entre los puntos indicados.");
                EsperarParaReintentar();
                continue;
            }

            Console.Clear();
            Console.WriteLine("Ruta de menor consumo: " + string.Join(" -> ", ruta));
            Console.WriteLine("Consumo total estimado: " + total);
            break;
        }
    }
}
