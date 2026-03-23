using System.Collections.Generic;

// Representa un alumno del curso (código único + nombre).
class Estudiante
{
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";

    // Guarda los datos al crear el objeto.
    public Estudiante(string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
    }

    // Dos estudiantes son "iguales" si tienen el mismo código (así el HashSet detecta duplicados).
    public override bool Equals(object? obj)
    {
        if (obj is Estudiante otro)
            return Codigo == otro.Codigo;
        return false;
    }

    // Debe ir junto con Equals: el HashSet usa esto para ubicar elementos rápido.
    public override int GetHashCode()
    {
        return Codigo != null ? Codigo.GetHashCode() : 0;
    }
}

internal class Program
{
    // Imprime todos los estudiantes guardados en el conjunto.
    static void MostrarListaEstudiantes(HashSet<Estudiante> estudiantes)
    {
        Console.WriteLine("Estudiantes registrados:");
        foreach (Estudiante e in estudiantes)
        {
            Console.WriteLine("- Código: " + e.Codigo + " | Nombre: " + e.Nombre);
        }
    }

    static void Main()
    {
        // HashSet: no permite repetir elementos según Equals/GetHashCode de Estudiante.
        HashSet<Estudiante> estudiantes = new HashSet<Estudiante>();
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("--- Menú ---");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Mostrar estudiantes");
            Console.WriteLine("3. Buscar por código");
            Console.WriteLine("4. Salir");
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción: ");
            string opcion = (Console.ReadLine() ?? "").Trim();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Ingrese código: ");
                    string codigo = (Console.ReadLine() ?? "").Trim();
                    Console.WriteLine("Ingrese nombre: ");
                    string nombre = (Console.ReadLine() ?? "").Trim();

                    Estudiante nuevo = new Estudiante(codigo, nombre);
                    // Add devuelve true si lo agregó, false si ya existía ese código.
                    if (estudiantes.Add(nuevo))
                    {
                        Console.WriteLine("Estudiante agregado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El estudiante ya está registrado.");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Pulse Enter para volver al menú...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Clear();
                    MostrarListaEstudiantes(estudiantes);
                    Console.WriteLine();
                    Console.WriteLine("Pulse Enter para volver al menú...");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Ingrese código a buscar: ");
                    string codigoBuscar = (Console.ReadLine() ?? "").Trim();
                    bool encontrado = false;
                    // Recorremos el conjunto hasta encontrar el código.
                    foreach (Estudiante e in estudiantes)
                    {
                        if (e.Codigo == codigoBuscar)
                        {
                            Console.WriteLine("- Código: " + e.Codigo + " | Nombre: " + e.Nombre);
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("No hay ningún estudiante con ese código.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Pulse Enter para volver al menú...");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Clear();
                    // Al salir se muestra la lista final (lo pide el enunciado).
                    MostrarListaEstudiantes(estudiantes);
                    Console.WriteLine();
                    Console.WriteLine("Pulse Enter para cerrar...");
                    Console.ReadLine();
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Pulse Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
