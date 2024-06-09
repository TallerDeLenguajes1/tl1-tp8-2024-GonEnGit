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
// primero mostras el menu
    Console.WriteLine("\nElija una operacion: ");
    Console.WriteLine("Suma (+)");
    Console.WriteLine("Resta (-)");
    Console.WriteLine("Producto (*)");
    Console.WriteLine("Cociente (/)");
    Console.WriteLine("Mostrar valor Actual (M)");
    Console.WriteLine("Buscar en el historial (B)");
    Console.WriteLine("Limpiar Valores (L)\n");

// un control para ver que se ingresen las opciones correctas
    do
    {
        ingreso = Console.ReadLine();
        confirmacion = char.TryParse(ingreso, out operacion);
        if (operacion != '+' && operacion != '-' && operacion != '*' && operacion != '/' && operacion != 'L' && operacion != 'M' && operacion != 'B')
        {
            Console.WriteLine("\nSolo se pueden usar estas 6 operaciones.");
            confirmacion = false;
        }
    } while (!confirmacion);

    if (operacion == 'M' || operacion == 'L' || operacion == 'B')
    {
        if (operacion == 'M')
        {
            Console.WriteLine($"\nEl resultado actual es {NuevaCalculadora.Resultado}\n");
        }
        else if (operacion == 'L')
        {
            NuevaCalculadora.Limpiar();
        }
        else
        {
        // te dijeron que no uses codigo edl lenguaje en las clases
        // osea que la mejor opcion es hacer una lista de strings
        // usando los datos del historial y manipular esa lista
            List<string> HistorialTemp = new List<string>();
            HistorialTemp = NuevaCalculadora.EnviarHistorial();

            Console.WriteLine("\nIngrese 'Todo' para ver todo el historial.");
            Console.WriteLine("O ingrese una operacion a buscar(Suma, Resta, Multiplicacion, Division, Limpiar): ");
            ingreso = Console.ReadLine();

            if (ingreso.Equals("Todo"))
            {
                foreach (var item in HistorialTemp)
                {
                    Console.WriteLine($"\n{item}");
                }
            }
            else if (ingreso.Equals("Suma") || ingreso.Equals("Resta") 
            || ingreso.Equals("Multiplicacion") || ingreso.Equals("Division") || ingreso.Equals("Limpiar"))
            {
                foreach (var item in HistorialTemp)
                {
                    if (item.Contains(ingreso))
                    {
                        Console.WriteLine($"\n{item}");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nLa opcion ingresada no es valida.");
            }
        // aparentemente en C# liberar listas es un solo metodo
        // la documentacion que encontraste en internet dice que
        // si bien se podria, no hace falta liberar nodo por nodo
            HistorialTemp.Clear();
        }
    }
    else
    {
    // esta parte lleva a los metodos de Calculadora.cs
        Console.WriteLine("\nIngrese un valor a usar: ");
        do
        {
            ingreso = Console.ReadLine();
            confirmacion = double.TryParse(ingreso, out numero);
            if (!confirmacion)
            {
                Console.WriteLine("\nIngrese unicamente numeros.");
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
        }
    }

    do
    {
        Console.WriteLine("\nRealizar otra operacion? (S/N)");
        ingreso = Console.ReadLine();
        confirmacion = char.TryParse(ingreso, out continuar);
        if (continuar != 'N' && continuar != 'S')
        {
            Console.WriteLine("\nIngrese S para continuar o N para terminar.");
            confirmacion = false;
        }
    } while (continuar != 'N' && continuar != 'S');
} while (continuar != 'N');

NuevaCalculadora.LiberarHistorial();

Console.WriteLine("\nHasta la proxima!\n");