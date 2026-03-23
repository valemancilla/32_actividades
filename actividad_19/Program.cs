#nullable disable // Desactiva el análisis de nullability para que no muestre advertencias por null.
using System; // Contiene tipos base como Console.
using System.Collections.Generic; // Contiene colecciones genéricas como List<T>.

internal class Program // Clase principal del programa.
{
    private const double FinIngreso = -1; // Valor centinela: cuando el usuario escribe -1, se termina el ingreso.

    private static void Main(string[] args) // Método principal que se ejecuta al iniciar el programa.
    {
        List<double> notas = new List<double>(); // Lista para almacenar todas las notas válidas ingresadas.

        RefrescarPantallaIngreso(notas); // Limpia la consola y muestra el estado inicial (y las notas si ya hay).

        bool terminarIngreso = false; // Controla cuándo se sale del ciclo de ingreso.
        while (!terminarIngreso) // Se repite hasta que terminarIngreso sea true.
        {
            Console.Write("Ingrese una nota: "); // Pide al usuario una nota.
            string linea = Console.ReadLine(); // Lee la entrada del usuario como texto (string).

            if (linea == null || linea.Trim().Length == 0) // Valida si el texto es null o está vacío (o solo espacios).
            {
                Console.WriteLine("Debe ingresar un valor numérico."); // Mensaje de error si no se puede interpretar como número.
            }
            else
            {
                double valor; // Variable donde se guardará el número convertido.
                if (!double.TryParse(linea, out valor)) // Intenta convertir el texto a double sin lanzar excepción.
                {
                    Console.WriteLine("Entrada no válida. Ingrese un número decimal válido."); // Mensaje si la conversión falla.
                }
                else if (valor == FinIngreso) // Si el usuario escribió el valor centinela (-1)...
                {
                    Console.Clear(); // Limpia la consola antes de terminar el ingreso.
                    terminarIngreso = true; // Cambia la bandera para salir del ciclo.
                }
                else
                {
                    notas.Add(valor); // Guarda la nota válida en la lista.
                    RefrescarPantallaIngreso(notas); // Actualiza la pantalla para mostrar el registro actual.
                }
            }
        }

        Console.WriteLine(); // Salto de línea para separar mejor las salidas.
        if (notas.Count == 0) // Si no se registró ninguna nota...
        {
            Console.WriteLine("No se registraron notas."); // Informa al usuario.
            return; // Sale del método Main sin continuar.
        }

        Console.WriteLine("Todas las notas:"); // Encabezado para mostrar las notas registradas.
        int n = 1; // Contador para numerar visualmente cada nota.
        foreach (double nota in notas) // Recorre todas las notas guardadas.
        {
            Console.WriteLine($"  {n}. {nota}"); // Muestra el número de orden y el valor de la nota.
            n++; // Incrementa el contador para la siguiente nota.
        }

        double suma = 0; // Acumulador para la suma total de las notas.
        foreach (double nota in notas) // Recorre nuevamente la lista para sumar.
        {
            suma += nota; // Suma cada nota al acumulador.
        }

        double promedio = suma / notas.Count; // Calcula el promedio dividiendo entre la cantidad de notas.
        Console.WriteLine(); // Salto de línea para separar secciones.
        Console.WriteLine($"Promedio: {promedio:F2}"); // Muestra el promedio con 2 decimales (F2).

        int superioresOIgualesA3 = 0; // Contador de notas que son >= 3.0.
        foreach (double nota in notas) // Recorre de nuevo para contar.
        {
            if (nota >= 3.0) // Si la nota es superior o igual a 3.0...
            {
                superioresOIgualesA3++; // Incrementa el contador.
            }
        }

        Console.WriteLine( // Muestra la cantidad final calculada.
            $"Cantidad de notas superiores o iguales a 3.0: {superioresOIgualesA3}");
    }

    private static void RefrescarPantallaIngreso(List<double> notas) // Método para limpiar y mostrar el registro de notas.
    {
        Console.Clear(); // Borra el contenido de la consola.
        Console.WriteLine("Registro de notas. Escriba -1 para terminar el ingreso."); // Instrucciones para el usuario.
        Console.WriteLine(); // Línea en blanco.

        if (notas.Count > 0) // Solo muestra la lista si ya hay notas registradas.
        {
            Console.WriteLine("Notas en la lista:"); // Encabezado del listado.
            int i = 1; // Contador para numerar las notas.
            foreach (double nota in notas) // Recorre cada nota guardada.
            {
                Console.WriteLine($"  {i}. {nota}"); // Imprime el índice y el valor.
                i++; // Incrementa el contador.
            }

            Console.WriteLine(); // Línea en blanco al final del listado.
        }
    }
}
