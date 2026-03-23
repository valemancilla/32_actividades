using System.Collections; // Contiene ArrayList (colección no genérica).

class Program // Clase principal del programa.
{
    static void Main() // Punto de entrada donde se ejecuta la lógica.
    {
        string nombre; // Guardará el nombre ingresado.
        int edad; // Guardará la edad (entero).
        double estatura; // Guardará la estatura (decimal).
        bool estado; // Guardará el estado booleano (True/False).

        // --- Entrada: pantalla limpia en cada paso ---
        Console.Clear(); // Limpia la consola antes de pedir el dato 1.
        Console.WriteLine("--- DATOS PERSONALES (1/4) ---"); // Título del paso 1.
        Console.WriteLine(); // Línea en blanco para separar.
        Console.Write("Ingrese su nombre:"); // Pide el nombre.
        nombre = Console.ReadLine() ?? ""; // Lee el nombre; si es null usa cadena vacía.

        Console.Clear(); // Limpia la consola antes de pedir el dato 2.
        Console.WriteLine("--- DATOS PERSONALES (2/4) ---"); // Título del paso 2.
        Console.WriteLine(); // Línea en blanco.
        Console.Write("Ingrese su edad:"); // Pide la edad.
        edad = int.Parse(Console.ReadLine()!); // Convierte el texto a entero (si falla, lanzará excepción).

        Console.Clear(); // Limpia la consola antes del dato 3.
        Console.WriteLine("--- DATOS PERSONALES (3/4) ---"); // Título del paso 3.
        Console.WriteLine(); // Línea en blanco.
        Console.Write("Ingrese su estatura (por ejemplo 1,75):"); // Pide la estatura.
        estatura = double.Parse(Console.ReadLine()!); // Convierte el texto a double (si falla, lanzará excepción).

        Console.Clear(); // Limpia la consola antes del dato 4.
        Console.WriteLine("--- DATOS PERSONALES (4/4) ---"); // Título del paso 4.
        Console.WriteLine(); // Línea en blanco.
        Console.Write("Ingrese un estado booleano (True o False):"); // Pide el valor booleano.
        estado = bool.Parse(Console.ReadLine()!); // Convierte a bool (True/False).

        // Guardar en ArrayList
        ArrayList datos = new ArrayList(); // Crea el contenedor para guardar los datos con sus tipos.
        datos.Add(nombre); // Agrega el nombre (string).
        datos.Add(edad); // Agrega la edad (int).
        datos.Add(estatura); // Agrega la estatura (double).
        datos.Add(estado); // Agrega el estado (bool).

        // Salida ordenada
        Console.Clear(); // Limpia la consola antes de la salida ordenada.
        Console.WriteLine(); // Línea en blanco.
        Console.WriteLine("  =============================================="); // Separador superior.
        Console.WriteLine("     CONTENIDO DEL ARRAYLIST (valor y tipo)"); // Encabezado de contenido.
        Console.WriteLine("  =============================================="); // Separador medio.
        Console.WriteLine(); // Línea en blanco.

        int numero = 1; // Contador para mostrar el número del elemento.
        foreach (object elemento in datos) // Recorre cada valor guardado en el ArrayList.
        {
            Console.WriteLine("  +------------------------------------------+"); // Borde superior del bloque del elemento.
            Console.WriteLine("  |  Elemento " + numero); // Imprime el índice (número de elemento).
            Console.WriteLine("  +------------------------------------------+"); // Borde inferior del bloque.
            Console.WriteLine("      Valor :  " + elemento); // Imprime el valor del objeto.
            Console.WriteLine("      Tipo  :  " + elemento.GetType()); // Imprime el tipo real en tiempo de ejecución.
            Console.WriteLine(); // Línea en blanco.
            numero++; // Incrementa el contador para el siguiente elemento.
        }

        Console.WriteLine("  =============================================="); // Separador final.
    }
}
