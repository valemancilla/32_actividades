// Crea el generador de números aleatorios.
Random random = new Random();

// Define todas las letras mayúsculas permitidas.
string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
// Define todas las letras minúsculas permitidas.
string minusculas = "abcdefghijklmnopqrstuvwxyz";
// Define todos los números permitidos.
string numeros = "0123456789";
// Define los caracteres especiales permitidos por la actividad.
string especiales = "!@#$%&*?+=-/";

// Une todos los grupos en un solo conjunto para completar la contraseña.
string todos = mayusculas + minusculas + numeros + especiales;

// Genera una longitud aleatoria entre 15 y 87.
int longitud = random.Next(15, 88);
// Crea un arreglo de caracteres con la longitud generada.
char[] password = new char[longitud];

// Asegura al menos un carácter de cada tipo
// Coloca una mayúscula en la primera posición.
password[0] = mayusculas[random.Next(0, mayusculas.Length)];
// Coloca una minúscula en la segunda posición.
password[1] = minusculas[random.Next(0, minusculas.Length)];
// Coloca un número en la tercera posición.
password[2] = numeros[random.Next(0, numeros.Length)];
// Coloca un carácter especial en la cuarta posición.
password[3] = especiales[random.Next(0, especiales.Length)];

// Completa el resto de la contraseña
// Recorre desde la posición 4 hasta el final del arreglo.
for (int i = 4; i < longitud; i++)
{
    // Asigna un carácter aleatorio del conjunto completo.
    password[i] = todos[random.Next(0, todos.Length)];
}

// Mezcla los caracteres para que no queden en orden fijo
// Recorre todas las posiciones del arreglo para mezclar.
for (int i = 0; i < password.Length; i++)
{
    // Elige una posición aleatoria dentro del arreglo.
    int indiceAleatorio = random.Next(0, password.Length);
    // Guarda temporalmente el carácter actual.
    char temporal = password[i];
    // Mueve el carácter aleatorio a la posición actual.
    password[i] = password[indiceAleatorio];
    // Coloca el carácter temporal en la posición aleatoria.
    password[indiceAleatorio] = temporal;
}

// Inicializa la variable donde se construirá la contraseña final.
string contrasena = "";
// Recorre cada carácter del arreglo mezclado.
for (int i = 0; i < password.Length; i++)
{
    // Concatena cada carácter para formar el texto final.
    contrasena = contrasena + password[i];
}

// Limpia la consola antes de mostrar el resultado.
Console.Clear();
Console.WriteLine("==============================");
// Muestra un título para identificar el resultado.
Console.WriteLine("Contrasena segura generada:"   );
Console.WriteLine("==============================");
// Imprime la contraseña generada.
Console.WriteLine(contrasena);
