// Lista de compras: almacena los nombres de los productos
List<string> listaCompras = new List<string>(); // Lista donde se guardan los productos agregados por el usuario.


bool salir = false; // Controla cuándo termina el programa (cuando sea true se sale del while).

while (!salir) // Repite el menú hasta que el usuario elija la opción de salir.
{
   
    Console.Clear(); // Limpia la pantalla para mostrar el menú con claridad.
    Console.WriteLine("=== LISTA DE COMPRAS ==="); // Título del programa.
    Console.WriteLine("1. Agregar producto"); // Opción del menú.
    Console.WriteLine("2. Mostrar productos"); // Opción del menú.
    Console.WriteLine("3. Eliminar producto por nombre"); // Opción del menú.
    Console.WriteLine("4. Salir"); // Opción del menú.
    Console.Write("Elija una opción: "); // Pide que el usuario elija una opción.

    string opcion = Console.ReadLine() ?? ""; // Lee la opción; si es null usa "".

    
    Console.Clear(); // Limpia para mostrar solo el resultado de la opción elegida.

    switch (opcion) // Evalúa la opción seleccionada y ejecuta el caso correspondiente.
    {
        case "1": // Agregar producto a la lista.
            // Pedir el nombre del producto y agregarlo a la lista
            Console.Write("Nombre del producto: "); // Pide el nombre del producto.
            string producto = Console.ReadLine() ?? ""; // Lee el nombre; si es null usa "".
            listaCompras.Add(producto); // Agrega el producto a la lista.
            Console.WriteLine("Producto agregado."); // Confirma que se agregó.
            Console.WriteLine("Pulse una tecla para continuar..."); // Informa pausa.
            Console.ReadKey(); // Espera una tecla para seguir.
            break;

        case "2": // Mostrar todos los productos.
            // Mostrar todos los productos guardados
            if (listaCompras.Count == 0) // Si la lista está vacía...
            {
                Console.WriteLine("La lista está vacía."); // Informa que no hay productos.
            }
            else
            {
                Console.WriteLine("Productos en la lista:"); // Encabezado de la lista.
                int indice = 0; // Índice para recorrer la lista con while.
                while (indice < listaCompras.Count) // Recorre mientras no se pase del final.
                {
                    Console.WriteLine("- " + listaCompras[indice]); // Imprime el producto en la posición actual.
                    indice = indice + 1; // Avanza al siguiente índice.
                }
            }
            Console.WriteLine("Pulse una tecla para continuar..."); // Pausa al terminar la impresión.
            Console.ReadKey(); // Espera una tecla.
            break;

        case "3": // Eliminar producto por nombre.
            // Pedir nombre y eliminar si existe
            Console.Write("Nombre del producto a eliminar: "); // Pide el nombre a buscar para eliminar.
            string nombreEliminar = Console.ReadLine() ?? ""; // Lee el nombre a eliminar.
            if (listaCompras.Remove(nombreEliminar)) // Remove devuelve true si encontró y eliminó.
            {
                Console.WriteLine("Producto eliminado."); // Confirma eliminación.
            }
            else
            {
                Console.WriteLine("No se encontró ese producto en la lista."); // Informa si no existe.
            }
            Console.WriteLine("Pulse una tecla para continuar..."); // Pausa para seguir.
            Console.ReadKey(); // Espera tecla.
            break;

        case "4": // Salir del programa.
            // Terminar el programa
            salir = true; // Hace que el while termine.
            break;

        default:
            // Opción no reconocida
            Console.WriteLine("Opción no válida."); // Error si la opción no existe.
            Console.WriteLine("Pulse una tecla para continuar..."); // Pausa.
            Console.ReadKey(); // Espera tecla.
            break;
    }
}
