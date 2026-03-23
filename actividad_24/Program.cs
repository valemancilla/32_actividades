using System; // Permite usar la consola (Console).
using System.Collections; // Incluye ArrayList.

class Program // Clase principal del programa.
{
    static void Main() // Punto de entrada.
    {
       
        // ArrayList = colección no genérica (guarda object; aquí solo guardamos nombres string)
        ArrayList inventario = new ArrayList(); // Guarda productos (como objetos) en una colección no genérica.

        // El usuario decide cuándo dejar de agregar productos
        string seguir = "s"; // Controla si el usuario continúa agregando productos.

        // Ciclo while: permite ingresar varios productos hasta que el usuario elija salir
        while (seguir == "s" || seguir == "S") // Mantiene el ciclo mientras el usuario responda s/S.
        {
            // Limpiar la consola antes de pedir cada producto 
            Console.Clear(); // Limpia la consola antes de pedir cada producto.

            Console.WriteLine("=== Inventario simple ==="); // Encabezado del programa.
            Console.WriteLine(); // Línea en blanco.
            Console.WriteLine("Escriba el nombre del producto:"); // Indica qué dato ingresar.
            string nombre = Console.ReadLine() ?? ""; // Lee el nombre; si es null, usa "".
            nombre = nombre.Trim(); // Quita espacios al inicio y al final.

            if (nombre != "") // Si el nombre no está vacío...
            {
                // Guardar el producto en el ArrayList
                inventario.Add(nombre); // Agrega el producto al inventario.
            }

            // Limpiar antes de la siguiente interacción con el usuario
            Console.Clear(); // Limpia para mostrar el resultado de lo ingresado.

            if (nombre != "") // Si el nombre era válido...
            {
                Console.WriteLine("Producto agregado al inventario."); // Confirma la adición.
            }
            else
            {
                Console.WriteLine("No escribió un nombre. No se guardó ningún producto."); // Informa que no se guardó.
            }

            Console.WriteLine(); // Línea en blanco.
            Console.WriteLine("¿Desea agregar otro producto?"); // Pregunta si se seguirá agregando.
            Console.WriteLine("Escriba s para sí o n para no:"); // Instrucciones de respuesta.
            seguir = Console.ReadLine() ?? ""; // Lee la respuesta del usuario.
            seguir = seguir.Trim(); // Limpia espacios en la respuesta.
        }

        // Limpiar la consola antes de mostrar la lista final
        Console.Clear(); // Limpia para mostrar la lista final.

        Console.WriteLine("=== Lista de productos registrados ==="); // Encabezado de resultados.
        Console.WriteLine(); // Línea en blanco.

        if (inventario.Count == 0) // Si no hay productos...
        {
            Console.WriteLine("No hay productos guardados."); // Informa que la lista está vacía.
        }
        else
        {
            // Ciclo foreach: recorre la colección no genérica y muestra cada elemento
            int i = 1; // Contador para numerar los productos.
            foreach (var item in inventario) // Recorre cada producto del ArrayList.
            {
                Console.WriteLine(i + ". " + item); // Imprime índice y producto.
                i = i + 1; // Incrementa el contador.
            }
        }

        Console.WriteLine(); // Línea en blanco final.
        Console.WriteLine("Total de productos: " + inventario.Count); // Muestra cuántos productos se registraron.
    }
}
