

using System; // Base del lenguaje y acceso a Console/Math.
using System.Collections.Generic; // Colecciones genéricas como List<T>.

// Guarda el mapa: puntos (nodos) y caminos con costo (combustible).
// Cada camino es una fila: Origenes[i] va a Destinos[i] gastando Costos[i].
public class RedRutas // Representa la “red” de puntos y aristas con costo.
{
    public List<string> Nodos { get; } // Lista de puntos (nodos) existentes.
    public List<string> Origenes { get; } // Origen de cada arista (misma posición que Destinos y Costos).
    public List<string> Destinos { get; } // Destino de cada arista (misma posición que Origenes y Costos).
    public List<int> Costos { get; } // Costo/combustible asociado a cada arista.

    public RedRutas() // Constructor: inicializa las listas vacías.
    {
        Nodos = new List<string>(); // Inicia la lista de nodos vacía.
        Origenes = new List<string>(); // Inicia la lista de orígenes vacía.
        Destinos = new List<string>(); // Inicia la lista de destinos vacía.
        Costos = new List<int>(); // Inicia la lista de costos vacía.
    }

    // Pone en el programa la red del enunciado (y un poco más de puntos).
    public void CargarEjemploDelEnunciado() // Carga la red de ejemplo del enunciado.
    {
        // Ejemplo del archivo.md (A hasta F)
        AgregarArista("A", "B", 4); // Arista: A -> B con costo 4.
        AgregarArista("A", "C", 2); // Arista: A -> C con costo 2.
        AgregarArista("B", "D", 5); // Arista: B -> D con costo 5.
        AgregarArista("C", "B", 1); // Arista: C -> B con costo 1.
        AgregarArista("C", "D", 8); // Arista: C -> D con costo 8.
        AgregarArista("C", "E", 10); // Arista: C -> E con costo 10.
        AgregarArista("D", "E", 2); // Arista: D -> E con costo 2.
        AgregarArista("E", "F", 3); // Arista: E -> F con costo 3.
        AgregarArista("D", "F", 6); // Arista: D -> F con costo 6.

        // Más puntos para probar
        AgregarArista("F", "G", 2); // Arista adicional: F -> G con costo 2.
        AgregarArista("D", "G", 4); // Arista adicional: D -> G con costo 4.
        AgregarArista("G", "H", 4); // Arista adicional: G -> H con costo 4.
        AgregarArista("H", "I", 3); // Arista adicional: H -> I con costo 3.
        AgregarArista("I", "J", 2); // Arista adicional: I -> J con costo 2.
        AgregarArista("J", "K", 5); // Arista adicional: J -> K con costo 5.
        AgregarArista("K", "H", 6); // Arista adicional: K -> H con costo 6.
        AgregarArista("E", "I", 8); // Arista adicional: E -> I con costo 8.
    }

    // Agrega un camino de "desde" a "hasta" con su combustible (solo si el costo es positivo).
    void AgregarArista(string desde, string hasta, int combustible) // Agrega una conexión desde->hasta si el costo es válido.
    {
        if (combustible <= 0) // Si el costo no es positivo...
            return; // ...no se agrega la arista.

        desde = desde.Trim().ToUpperInvariant(); // Normaliza origen (sin espacios y en mayúsculas).
        hasta = hasta.Trim().ToUpperInvariant(); // Normaliza destino (sin espacios y en mayúsculas).

        if (!ContieneNodo(desde)) // Si el nodo origen no existe...
            Nodos.Add(desde); // ...lo agregamos a la lista de nodos.
        if (!ContieneNodo(hasta)) // Si el nodo destino no existe...
            Nodos.Add(hasta); // ...lo agregamos a la lista de nodos.

        Origenes.Add(desde); // Guarda el origen en la posición correspondiente.
        Destinos.Add(hasta); // Guarda el destino en la posición correspondiente.
        Costos.Add(combustible); // Guarda el costo en la posición correspondiente.
    }

    public bool ContieneNodo(string nombre) // Indica si un nodo existe en la lista Nodos.
    {
        return IndiceDeNodo(nombre) >= 0; // Si el índice es >= 0, el nodo existe.
    }

    // En qué posición está el punto en la lista Nodos (-1 = no está).
    public int IndiceDeNodo(string nombre) // Devuelve el índice del nodo o -1 si no existe.
    {
        for (int i = 0; i < Nodos.Count; i++) // Recorre todos los nodos.
        {
            if (Nodos[i].Equals(nombre, StringComparison.OrdinalIgnoreCase)) // Compara ignorando mayúsculas/minúsculas.
                return i; // Retorna el índice donde se encontró el nodo.
        }
        return -1; // No se encontró el nodo.
    }
}

// Dijkstra: encuentra el camino más barato (menos combustible total).
// Versión simple: en cada vuelta elijo el punto no visitado con menor costo acumulado.
public static class RutaDijkstra // Contiene la implementación del algoritmo de Dijkstra.
{
    // Número grande = "todavía no llegamos a ese punto"
    const int SinCaminoConocido = 1000000000;

    // Devuelve true y llena ruta + combustibleTotal si hay camino; false si no se puede llegar.
    public static bool CalcularMenorRuta( // Calcula si existe ruta y devuelve la de menor costo.
        RedRutas red,
        string inicio,
        string fin,
        out List<string> ruta,
        out int combustibleTotal)
    {
        ruta = new List<string>(); // Se inicializa la ruta vacía (por salida).
        combustibleTotal = 0; // Se inicializa el costo total.

        int indiceInicio = red.IndiceDeNodo(inicio); // Índice del nodo inicio en Nodos.
        int indiceFin = red.IndiceDeNodo(fin); // Índice del nodo fin en Nodos.

        int n = red.Nodos.Count; // Cantidad de nodos en la red.
        int[] distancia = new int[n];   // Mejor costo conocido desde el inicio hasta cada nodo.
        int[] anterior = new int[n];    // Nodo anterior en la mejor ruta (-1 si no hay).
        bool[] visitado = new bool[n]; // Marca si el nodo ya fue “cerrado” en Dijkstra.

        for (int i = 0; i < n; i++) // Inicializa estructuras para todos los nodos.
        {
            distancia[i] = SinCaminoConocido; // Aún no conocemos costo, lo marcamos como “infinito”.
            anterior[i] = -1; // No hay predecesor todavía.
            visitado[i] = false; // Ningún nodo se ha visitado aún.
        }

        distancia[indiceInicio] = 0; // El costo desde inicio hasta inicio es 0.

        for (int paso = 0; paso < n; paso++) // Repite pasos para construir la ruta mínima.
        {
            // Tomar el punto no visitado más barato de llegar hasta ahora
            int u = -1; // Nodo seleccionado en esta iteración.
            int mejor = SinCaminoConocido; // Mejor distancia encontrada entre los no visitados.
            for (int i = 0; i < n; i++) // Busca el no visitado con menor distancia.
            {
                if (!visitado[i] && distancia[i] < mejor) // Si no visitado y es mejor costo...
                {
                    mejor = distancia[i]; // Actualiza el mejor costo.
                    u = i; // Actualiza el nodo con el mejor costo.
                }
            }

            if (u < 0 || distancia[u] == SinCaminoConocido) // Si no hay nodo alcanzable...
                break; // ...termina porque no se puede avanzar.

            visitado[u] = true; // Marca el nodo u como visitado/cerrado.

            if (u == indiceFin) // Si ya llegamos al nodo destino...
                break; // ...terminamos los pasos.

            // Revisar salidas desde u: si por aquí es más barato, actualizo distancia y anterior
            for (int e = 0; e < red.Origenes.Count; e++) // Recorre todas las aristas para encontrar las que salen desde u.
            {
                if (!red.Origenes[e].Equals(red.Nodos[u], StringComparison.OrdinalIgnoreCase)) // Si esta arista no sale desde u...
                    continue; // ...la ignoramos.

                int indiceVecino = red.IndiceDeNodo(red.Destinos[e]); // Índice del vecino (destino) para esta arista.
                if (indiceVecino < 0) // Si el destino no existe en la lista de nodos...
                    continue; // ...se ignora esta arista.

                int peso = red.Costos[e]; // Costo de la arista actual.
                if (peso <= 0) // Si el costo no es positivo...
                    continue; // ...no se considera.

                long posible = (long)distancia[u] + peso; // Nuevo costo si vamos desde inicio hasta u y luego a vecino.
                if (posible < distancia[indiceVecino]) // Si es más barato que lo que teníamos guardado...
                {
                    distancia[indiceVecino] = (int)posible; // Actualizamos la mejor distancia al vecino.
                    anterior[indiceVecino] = u; // Guardamos desde qué nodo venimos en la mejor ruta.
                }
            }
        }

        if (distancia[indiceFin] == SinCaminoConocido) // Si el destino nunca fue alcanzado...
            return false; // ...no hay ruta.

        // Armo la lista del final al inicio y la doy vuelta
        int actual = indiceFin; // Comenzamos reconstrucción desde el destino.
        while (actual >= 0) // Recorremos la cadena anterior hasta llegar a -1.
        {
            ruta.Add(red.Nodos[actual]); // Agrega el nodo actual al final de la lista (luego se invertirá).
            actual = anterior[actual]; // Avanza al nodo anterior en el camino óptimo.
        }

        ruta.Reverse(); // Invierte la ruta para que quede inicio -> fin.
        combustibleTotal = distancia[indiceFin]; // Guarda el costo total estimado de la ruta.
        return true; // Indica que sí existió camino.
    }
}

class Program // Contiene la interacción con el usuario.
{
    static void Main() // Punto de entrada de la aplicación.
    {
        RedRutas red = new RedRutas(); // Crea la estructura de la red.
        red.CargarEjemploDelEnunciado(); // Carga los datos ejemplo de rutas.

        PedirYMostrarRuta(red); // Ejecuta el diálogo para pedir puntos y mostrar la ruta.

        Console.WriteLine(); // Línea en blanco final.
        Console.WriteLine("Pulse una tecla para cerrar..."); // Mensaje final.
        Console.ReadKey(true); // Pausa esperando una tecla.
    }

    // Limpio espacios y paso a mayúsculas para que coincida con los nombres del mapa.
    static string? NormalizarEntrada(string? texto) // Limpia la entrada para que coincida con nombres normalizados.
    {
        if (string.IsNullOrWhiteSpace(texto)) // Si está vacía o null...
            return null; // ...retornamos null para indicar “no válido”.
        return texto.Trim().ToUpperInvariant(); // Quita espacios y pasa a mayúsculas.
    }

    // Pausa para que el usuario lea el error antes de volver a preguntar.
    static void EsperarParaReintentar() // Pausa el programa tras mostrar un error.
    {
        Console.WriteLine(); // Línea en blanco.
        Console.WriteLine("Pulse una tecla para intentar de nuevo..."); // Instrucción al usuario.
        Console.ReadKey(true); // Espera una tecla sin mostrarla.
    }

    // Pregunta recogida y entrega; si algo falla, vuelve a preguntar sin cerrar el programa.
    static void PedirYMostrarRuta(RedRutas red) // Solicita puntos y muestra la ruta más barata.
    {
        while (true) // Repite hasta que se muestre una ruta válida o un caso de salida.
        {
            Console.Clear(); // Limpia para comenzar el intento.

            Console.Write("Punto de recogida: "); // Pide punto inicial.
            string? inicio = NormalizarEntrada(Console.ReadLine()); // Normaliza el inicio; puede ser null.
            Console.Write("Punto de entrega: "); // Pide punto final.
            string? fin = NormalizarEntrada(Console.ReadLine()); // Normaliza el fin; puede ser null.

            if (inicio == null || fin == null) // Si alguno no es válido...
            {
                Console.WriteLine("Debe indicar ambos puntos."); // Mensaje de error.
                EsperarParaReintentar(); // Pausa.
                continue; // Vuelve a pedir.
            }

            if (!red.ContieneNodo(inicio)) // Si el nodo de inicio no existe...
            {
                Console.WriteLine("No existe el punto de recogida «" + inicio + "» en la red."); // Error de nodo inexistente.
                EsperarParaReintentar(); // Pausa para reintentar.
                continue; // Vuelve a pedir.
            }

            if (!red.ContieneNodo(fin)) // Si el nodo final no existe...
            {
                Console.WriteLine("No existe el punto de entrega «" + fin + "» en la red."); // Error de nodo inexistente.
                EsperarParaReintentar(); // Pausa.
                continue; // Vuelve a pedir.
            }

            // Mismo punto: ruta de un solo paso, consumo 0
            if (inicio.Equals(fin, StringComparison.OrdinalIgnoreCase)) // Si inicio y fin son el mismo punto...
            {
                Console.Clear(); // Limpia antes del mensaje.
                Console.WriteLine("Ruta de menor consumo: " + inicio); // Muestra la ruta trivial.
                Console.WriteLine("Consumo total estimado: 0"); // El consumo es 0 porque no se viaja.
                break; // Sale del while: ya está la salida.
            }

            List<string> ruta; // Ruta calculada como lista de nodos.
            int total; // Consumo total estimado.
            bool hayCamino = RutaDijkstra.CalcularMenorRuta(red, inicio, fin, out ruta, out total); // Ejecuta Dijkstra.

            if (!hayCamino) // Si no hay camino...
            {
                Console.WriteLine("No existe ruta entre los puntos indicados."); // Mensaje de no hay ruta.
                EsperarParaReintentar(); // Pausa.
                continue; // Vuelve a pedir puntos.
            }

            Console.Clear(); // Limpia para mostrar el resultado final.
            Console.WriteLine("Ruta de menor consumo: " + string.Join(" -> ", ruta)); // Une la ruta con flechas.
            Console.WriteLine("Consumo total estimado: " + total); // Muestra el costo total.
            break; // Sale del while: solución encontrada.
        }
    }
}
