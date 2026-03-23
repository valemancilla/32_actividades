// Lista de compras: almacena los nombres de los productos
List<string> listaCompras = new List<string>();

// El programa sigue hasta que el usuario elija salir
bool salir = false;

while (!salir)
{
    // Limpiar pantalla y mostrar el menú en cada vuelta
    Console.Clear();
    Console.WriteLine("=== LISTA DE COMPRAS ===");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Mostrar productos");
    Console.WriteLine("3. Eliminar producto por nombre");
    Console.WriteLine("4. Salir");
    Console.Write("Elija una opción: ");

    string opcion = Console.ReadLine() ?? "";

    // Limpiar para que solo se vea la acción elegida (sin el menú encima)
    Console.Clear();

    switch (opcion)
    {
        case "1":
            // Pedir el nombre del producto y agregarlo a la lista
            Console.Write("Nombre del producto: ");
            string producto = Console.ReadLine() ?? "";
            listaCompras.Add(producto);
            Console.WriteLine("Producto agregado.");
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();
            break;

        case "2":
            // Mostrar todos los productos guardados
            if (listaCompras.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                Console.WriteLine("Productos en la lista:");
                int indice = 0;
                while (indice < listaCompras.Count)
                {
                    Console.WriteLine("- " + listaCompras[indice]);
                    indice = indice + 1;
                }
            }
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();
            break;

        case "3":
            // Pedir nombre y eliminar si existe
            Console.Write("Nombre del producto a eliminar: ");
            string nombreEliminar = Console.ReadLine() ?? "";
            if (listaCompras.Remove(nombreEliminar))
            {
                Console.WriteLine("Producto eliminado.");
            }
            else
            {
                Console.WriteLine("No se encontró ese producto en la lista.");
            }
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();
            break;

        case "4":
            // Terminar el programa
            salir = true;
            break;

        default:
            // Opción no reconocida
            Console.WriteLine("Opción no válida.");
            Console.WriteLine("Pulse una tecla para continuar...");
            Console.ReadKey();
            break;
    }
}
