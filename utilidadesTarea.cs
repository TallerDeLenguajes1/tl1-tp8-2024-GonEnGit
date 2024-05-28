namespace utilidadesTarea;

class Tarea
{
// esta bien declarar así los campos
    int tareaid;
    int duracion;
    string descripcion;

// pero las propiedades, que son el getter + setter ya que estamos
// son las que usas para guardar valores en los campos, no usas
// metodos para hacer eso
    // esto esta bien:
    public int Tareaid { get => tareaid; set => tareaid = value; }
    public int Duracion { get => duracion; set => duracion = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }

/* esto está mal:
    public void obtenerID(int valor)
    {
        tareaid = valor;
    }
    public void obtenerDuracion(int valor)
    {
        duracion = valor;
    }
    public void obtenerDescripcion(string desc)
    {
        descripcion = desc;
    }
*/

/* nunca uses codigo del lenguaje dentro de la clase
la idea es que tus clases se puedan llevar a otros lenguajes
osea, no hagas esto:

    public void MostrarDatos()
    {
        Console.WriteLine($"ID: {Tareaid}");
        Console.WriteLine($"Duracion: {duracion} Dias.");
        Console.WriteLine($"Descrpcion: '{descripcion}'");
    }
*/

// la forma ideal seria usar un return bastante simple
    public string MostrarDatos()
    {
        string linea = $"ID: {tareaid} Duracion: {duracion} Dias. Descrpcion: '{descripcion}'";
        return linea;
    }
// meotodos como este los dejar para alterar los datos
}