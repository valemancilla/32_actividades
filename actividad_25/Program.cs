using System.Collections;

class Program
{
    static void Main()
    {
        string nombre;
        int edad;
        double estatura;
        bool estado;

        // --- Entrada: pantalla limpia en cada paso ---
        Console.Clear();
        Console.WriteLine("--- DATOS PERSONALES (1/4) ---");
        Console.WriteLine();
        Console.Write("Ingrese su nombre:");
        nombre = Console.ReadLine() ?? "";

        Console.Clear();
        Console.WriteLine("--- DATOS PERSONALES (2/4) ---");
        Console.WriteLine();
        Console.Write("Ingrese su edad:");
        edad = int.Parse(Console.ReadLine()!);

        Console.Clear();
        Console.WriteLine("--- DATOS PERSONALES (3/4) ---");
        Console.WriteLine();
        Console.Write("Ingrese su estatura (por ejemplo 1,75):");
        estatura = double.Parse(Console.ReadLine()!);

        Console.Clear();
        Console.WriteLine("--- DATOS PERSONALES (4/4) ---");
        Console.WriteLine();
        Console.Write("Ingrese un estado booleano (True o False):");
        estado = bool.Parse(Console.ReadLine()!);

        // Guardar en ArrayList
        ArrayList datos = new ArrayList();
        datos.Add(nombre);
        datos.Add(edad);
        datos.Add(estatura);
        datos.Add(estado);

        // Salida ordenada
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  ==============================================");
        Console.WriteLine("     CONTENIDO DEL ARRAYLIST (valor y tipo)");
        Console.WriteLine("  ==============================================");
        Console.WriteLine();

        int numero = 1;
        foreach (object elemento in datos)
        {
            Console.WriteLine("  +------------------------------------------+");
            Console.WriteLine("  |  Elemento " + numero);
            Console.WriteLine("  +------------------------------------------+");
            Console.WriteLine("      Valor :  " + elemento);
            Console.WriteLine("      Tipo  :  " + elemento.GetType());
            Console.WriteLine();
            numero++;
        }

        Console.WriteLine("  ==============================================");
    }
}
