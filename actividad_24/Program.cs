using System;
using System.Collections;

class Program
{
    static void Main()
    {
       
        // ArrayList = colección no genérica (guarda object; aquí solo guardamos nombres string)
        ArrayList inventario = new ArrayList();

        // El usuario decide cuándo dejar de agregar productos
        string seguir = "s";

        // Ciclo while: permite ingresar varios productos hasta que el usuario elija salir
        while (seguir == "s" || seguir == "S")
        {
            // Limpiar la consola antes de pedir cada producto (o la primera vez)
            Console.Clear();

            Console.WriteLine("=== Inventario simple ===");
            Console.WriteLine();
            Console.WriteLine("Escriba el nombre del producto:");
            string nombre = Console.ReadLine() ?? "";
            nombre = nombre.Trim();

            if (nombre != "")
            {
                // Guardar el producto en el ArrayList
                inventario.Add(nombre);
            }

            // Limpiar antes de la siguiente interacción con el usuario
            Console.Clear();

            if (nombre != "")
            {
                Console.WriteLine("Producto agregado al inventario.");
            }
            else
            {
                Console.WriteLine("No escribió un nombre. No se guardó ningún producto.");
            }

            Console.WriteLine();
            Console.WriteLine("¿Desea agregar otro producto?");
            Console.WriteLine("Escriba s para sí o n para no:");
            seguir = Console.ReadLine() ?? "";
            seguir = seguir.Trim();
        }

        // Limpiar la consola antes de mostrar la lista final
        Console.Clear();

        Console.WriteLine("=== Lista de productos registrados ===");
        Console.WriteLine();

        if (inventario.Count == 0)
        {
            Console.WriteLine("No hay productos guardados.");
        }
        else
        {
            // Ciclo foreach: recorre la colección no genérica y muestra cada elemento
            int i = 1;
            foreach (var item in inventario)
            {
                Console.WriteLine(i + ". " + item);
                i = i + 1;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total de productos: " + inventario.Count);
    }
}
