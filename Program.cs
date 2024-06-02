using Microsoft.VisualBasic.FileIO;
using utilidadesTarea;

Random random = new Random();       // esta es la forma de implementar un nuevo objeto random
int randNum = random.Next(10) + 5;  // y usas .Next para generar un numero hasta valor - 1

// el +5 que pusiste es solo para evitar que 
// te caiga en 0 tareas, hay alguna manera mejor?

int maxId;
int idABuscar;
int opcion;
int indiceDesc;
int tareasEncontradas = 0;
char continuar = 'S';
string ingreso;
string[] arregloDescripciones = {"Una descripcion", "Otra descripcion", "mas descripciones", "una mas", "otra for good measure"};
bool prueba;
bool palabraEncontrada;

// en C# las listas ya son una 'variable'... gracias a Dios...
// solo declaras una instancia de lista y la usas... no te comas estos ()
List<Tarea> listaPendientes = new List<Tarea>();
List<Tarea> listaCompletadas = new List<Tarea>();

// Nodo por lo general implica que tiene un siguiente
// podes usar cualquier otro nombre, probablemente sea mejor
for (int i = 0; i < randNum; i++)
{
    maxId = 0;
    Tarea entrada = new Tarea();
    // acá tenes una forma de hacer que se recorra toda la lista
    // y siempre hubicar cual es el id mas alto, de esa forma
    // podes acegurar que los id no se repitan aunque la lista
    // esté desordenada
    foreach(var tareaPendiente in listaPendientes)
    { 
        if(tareaPendiente.Tareaid > maxId)
        {
            maxId = tareaPendiente.Tareaid;
        }
    }
    entrada.Tareaid = maxId + 1;
    entrada.Duracion = random.Next(10) + 1;
    indiceDesc = random.Next(5);
    entrada.Descripcion = arregloDescripciones[indiceDesc];

    // si no agregas la tarea a la lista como que no sirve
    listaPendientes.Add(entrada);
}

Console.WriteLine("\n");
foreach(var tareaPendiente in listaPendientes)
{
    Console.WriteLine(tareaPendiente.MostrarDatos());
}
Console.WriteLine("\n");

while (continuar == 'S')
{
    Console.WriteLine("\nIngrese una Opcion: ");
    Console.WriteLine("1. Completar una tarea.");
    Console.WriteLine("2. Buscar una tarea por palabra.");
    Console.WriteLine("3. Mostrar todas las tareas.");
    do
    {
        ingreso = Console.ReadLine();
        prueba = int.TryParse(ingreso, out opcion);
        if (prueba == false || opcion <= 0 || opcion >= 4)
        {
            Console.WriteLine("No es una opcion valida.");
        }
    } while (prueba == false || opcion <= 0 || opcion >= 4);

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese el id de la tarea.");
            do
            {
                ingreso = Console.ReadLine();
                prueba = int.TryParse(ingreso, out idABuscar);
                if (prueba == false)
                {
                    Console.WriteLine("Los IDs deben ser numeros.");
                }
            } while (prueba == false);

            foreach (var tarea in listaPendientes)
            {
                if (tarea != null && tarea.Tareaid == idABuscar)
                {
                    // si tenes que usar un auxiliar copiar y borrar
                    // o eso te dijeron los profes y el ayudante
                    // pero lo que encontras en internet y lo que indica vscode
                    // apunta que no hace falta, vos hacelo así por las dudas
                    // pero una vez que borras usa un break para no romper todo
                    Tarea entradaCompletada = new Tarea();
                    entradaCompletada = tarea;
                    listaCompletadas.Add(entradaCompletada);
                    listaPendientes.Remove(tarea);
                    break;
                }
            }

            break;
        case 2:
            Console.WriteLine("Ingrese una palabra a buscar entre las descripciones: ");
            ingreso = Console.ReadLine();

            Console.WriteLine("\n/------ Tareas Pendientes ------/\n");
            foreach (var tarea in listaPendientes)
            {
                palabraEncontrada = tarea.Descripcion.Contains(ingreso);
                if (palabraEncontrada)
                {
                    tareasEncontradas++;
                    Console.WriteLine(tarea.MostrarDatos());
                }
            }
            if (tareasEncontradas == 0)
            {
                Console.WriteLine($"No hay tareas que contendgan {ingreso} en la lista de Pendientes.");
            }
            tareasEncontradas = 0;

            Console.WriteLine("\n/------ Tareas Completadas ------/\n");
            foreach (var tarea in listaCompletadas)
            {
                palabraEncontrada = tarea.Descripcion.Contains(ingreso);
                if (palabraEncontrada)
                {
                    tareasEncontradas++;
                    Console.WriteLine(tarea.MostrarDatos());
                }
            }
            if (tareasEncontradas == 0)
            {
                Console.WriteLine($"No hay tareas que contendgan {ingreso} en la lista de Completadas.");
            }
            tareasEncontradas = 0;

            break;

        case 3:
            Console.WriteLine("\n/------ Tareas Pendientes ------/\n");
            foreach (var tarea in listaPendientes)
            {
                Console.WriteLine(tarea.MostrarDatos());
            }
            Console.WriteLine("\n/------ Tareas Completadas ------/\n");
            foreach (var tarea in listaCompletadas)
            {
                Console.WriteLine(tarea.MostrarDatos());
            }
            break;
    }


    Console.WriteLine("Continuar con otra operacion? (S/N)");
    do
    {
        ingreso = Console.ReadLine();
        prueba = char.TryParse(ingreso, out continuar);
        continuar = Char.ToUpper(continuar);
        if (prueba == false || (continuar.Equals('S') == false && continuar.Equals('N') == false) )
        {
            Console.WriteLine("No es una opcion valida.");
        }
    } while (prueba == false || (continuar.Equals('S') == false && continuar.Equals('N') == false) );
}

Console.Write("Hasta la proxima!");