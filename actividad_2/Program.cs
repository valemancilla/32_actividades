using System; // Importa las clases básicas de C#

namespace actividad_2 // Define el namespace del proyecto
{ 
    internal class Program // Clase principal donde está el programa
    { 
        public static int[] ObtenerRepetidos(int[] arreglo) // Función que recibe un array y devuelve otro con repetidos
        { 
            int cantidad = arreglo.Length; // Guarda la cantidad de elementos del arreglo original

            int[] repetidos = new int[cantidad]; // Crea un arreglo con tamaño máximo posible para repetidos
            int cantidadRepetidos = 0; // Lleva la cantidad real de repetidos encontrados

            for (int i = 0; i < cantidad; i++) // Recorre cada elemento del arreglo original
            { 
                bool apareceAntes = false; // Indica si el valor ya apareció antes

                for (int j = 0; j < i; j++) // Compara contra posiciones anteriores
                { 
                    if (arreglo[j] == arreglo[i]) // Si encuentra el mismo número antes
                    { 
                        apareceAntes = true; // Marca que aparece antes
                    } 
                } 

                if (apareceAntes) // Si ya apareció antes, entonces puede ser repetido
                { 
                    bool yaAgregado = false; // Para no agregar el repetido más de una vez

                    for (int k = 0; k < cantidadRepetidos; k++) // Revisa si ya está en el arreglo repetidos
                    { 
                        if (repetidos[k] == arreglo[i]) // Si el número ya fue agregado
                        { 
                            yaAgregado = true; // Marca que no se agregará otra vez
                        } 
                    } 

                    if (!yaAgregado) // Si todavía no se agregó
                    { 
                        repetidos[cantidadRepetidos] = arreglo[i]; // Guarda el número repetido
                        cantidadRepetidos = cantidadRepetidos + 1; // Aumenta el contador
                    } 
                } 
            } 

            int[] repetidosFinal = new int[cantidadRepetidos]; // Crea el arreglo final con el tamaño exacto

            for (int i = 0; i < cantidadRepetidos; i++) // Copia los valores encontrados al arreglo final
            { 
                repetidosFinal[i] = repetidos[i]; // Copia uno por uno
            } 

            return repetidosFinal; // Devuelve el arreglo con repetidos
        } 

        public static void Main(string[] args) // Punto de entrada del programa
        { 
            Console.Clear(); // Limpia la consola al inicio

            Console.WriteLine("========================================");
            Console.WriteLine("      ACTIVIDAD 2 - REPETIDOS");
            Console.WriteLine("========================================");
            Console.WriteLine(); // Salto de línea

            Console.WriteLine("¿Cuántos números vas a ingresar?"); // Pide la cantidad de números
            int cantidad; // Variable donde se guardará la cantidad
            string entradaCantidad = Console.ReadLine(); // Lee la entrada del usuario como texto

            while (!int.TryParse(entradaCantidad, out cantidad) || cantidad <= 0) // Valida que sea entero positivo
            { 
                Console.Clear(); // Limpia antes de volver a pedir
                Console.WriteLine("Cantidad inválida. Debe ser un entero positivo."); // Mensaje de error
                Console.WriteLine("¿Cuántos números vas a ingresar?"); // Vuelve a pedir la cantidad
                entradaCantidad = Console.ReadLine(); // Lee nuevamente
            } 

            int[] numeros = new int[cantidad]; // Crea el arreglo original con el tamaño indicado

            for (int i = 0; i < cantidad; i++) // Recorre para llenar el arreglo con los números del usuario
            { 
                Console.Clear(); // Limpia antes de pedir cada número
                Console.WriteLine($"Ingrese el número {i + 1} de {cantidad}:"); // Pide el i-ésimo número

                int numero; // Variable para el número ingresado
                string entradaNumero = Console.ReadLine(); // Lee el número como texto

                while (!int.TryParse(entradaNumero, out numero) || numero <= 0) // Valida que sea entero positivo
                { 
                    Console.Clear(); // Limpia antes de volver a pedir
                    Console.WriteLine("Número inválido. Debe ser entero positivo."); // Mensaje de error
                    Console.WriteLine($"Ingrese el número {i + 1} de {cantidad}:"); // Vuelve a pedir el mismo índice
                    entradaNumero = Console.ReadLine(); // Lee nuevamente
                } 

                numeros[i] = numero; // Guarda el número en el arreglo original
            } 

            int[] repetidosFinal = ObtenerRepetidos(numeros); // Llama la función y obtiene el arreglo con repetidos

            Console.Clear(); // Limpia antes de mostrar resultados
            Console.WriteLine("========================================");
            Console.WriteLine("            NUMERO REPETIDO");
            Console.WriteLine("========================================");

            if (repetidosFinal.Length == 0) // Si no hay repetidos
            { 
                Console.WriteLine("No hay números repetidos."); // Muestra mensaje
            } 
            else // Si sí hay repetidos
            { 
                for (int i = 0; i < repetidosFinal.Length; i++) // Recorre el arreglo de repetidos
                { 
                    Console.WriteLine(repetidosFinal[i]); // Muestra cada número repetido
                } 
            } 
        } 
    } 
} 