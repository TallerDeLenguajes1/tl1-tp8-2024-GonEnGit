using utilidadesTarea;

Random random = new Random();       // esta es la forma de implementa un nuevo objeto random
int randNum = random.Next(10);      // y usas .Next para generar un numero hasta valor - 1

int maxId;
string[] arregloDescripciones = {"Una descripcion", "Otra descripcion", "mas descripciones", "una mas"};

// en C# las listas ya son una 'variable'... gracias a Dios...
// solo declaras una instancia de lista y la usas... no te comas estos ()
List<Tarea> listaPendientes = new List<Tarea>();
List<Tarea> listaCompletadas = new List<Tarea>();

// Nodo por lo general implica que tiene un siguiente
// podes usar cualquier otro nombre, probablemente sea mejor
for (int i = 0; i < randNum; i++)
{
    maxId=0;
    Tarea entrada = new Tarea();
    // acá tenes una forma de hacer que se recorra toda la lista
    // y siempre hubicar cual es el id mas alto, de esa forma
    // podes acegurar que los id no se repitan aunque la lista
    // esté desordenada
    foreach(var tareaPendiente in listaPendientes)
    { 
        if(tareaPendiente.Tareaid>maxId)
        {
            maxId=tareaPendiente.Tareaid;
        }
    }
    entrada.Tareaid = maxId + 1;
    entrada.Duracion = random.Next(10);

}