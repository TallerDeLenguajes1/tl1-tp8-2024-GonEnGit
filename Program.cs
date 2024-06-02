// using lleva el namespace no el nombre del archivo
using EspacioCalculadora;

char continuar = 'S';
char operacion;
double numero;
string ingreso;
bool confirmacion;
Calculadora NuevaCalculadora = new Calculadora();

do
{
    Console.WriteLine("Elija una operacion: ");
    Console.WriteLine("Suma (+)");
    Console.WriteLine("Resta (-)");
    Console.WriteLine("Producto (*)");
    Console.WriteLine("Cociente (/)");
    Console.WriteLine("Mostrar valor Actual (M)");
    Console.WriteLine("Limpiar Valores (L)");

    do
    {
        ingreso = Console.ReadLine();
        confirmacion = char.TryParse(ingreso, out operacion);
        if (operacion != '+' && operacion != '-' && operacion != '*' && operacion != '/' && operacion != 'L' && operacion != 'M')
        {
            Console.WriteLine("Solo se pueden usar estas 4 operaciones.");
            confirmacion = false;
        }
    } while (!confirmacion);

    Console.WriteLine("Ingrese un valor a usar: ");
    do
    {
        ingreso = Console.ReadLine();
        confirmacion = double.TryParse(ingreso, out numero);
        if (!confirmacion)
        {
            Console.WriteLine("Ingrese unicamente numeros.");
        }
    } while (!confirmacion);


    switch (operacion)
    {
        case '+':
            NuevaCalculadora.Sumar(numero);
            break;

        case '-':
            NuevaCalculadora.Restar(numero);
            break;
        
        case '*':
            NuevaCalculadora.Multiplicar(numero);
            break;

        case '/':
            NuevaCalculadora.Dividir(numero);
            break;

        case 'M':
            Console.WriteLine($"El resultado actual es {NuevaCalculadora.Resultado}");
            break;

        case 'L':
            NuevaCalculadora.Limpiar();
            break;
    }

    do
    {
        Console.WriteLine("Realizar otra operacion? (S/N)");
        ingreso = Console.ReadLine();
        confirmacion = char.TryParse(ingreso, out continuar);
        if (continuar != 'N' && continuar != 'S')
        {
            Console.WriteLine("Ingrese S para continuar o N para terminar.");
            confirmacion = false;
        }
    } while (continuar != 'N' && continuar != 'S');
} while (continuar != 'N');