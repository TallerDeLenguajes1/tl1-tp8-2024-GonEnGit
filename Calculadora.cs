// la idea del ejercicio 2 es usar la misma calculadora del TP 7
// pero le agregas una lista de clases 'operaciones'

/* 
    public operacion{
        
        operacion = Operacion.Limpiar()
    }
*/

// el metodo resultado, la idea es que tome los 3 datos guardados
// y devuelve la operacion en si osea si esta guardado 5, 6 y + 
// resultado devuelve 11 (5+6)

// será por la version, ahora el namespace no lleva llaves
// el namespace sirve para relaciones funciones de distintos archivos
// cuando llames Espaciocalculadora, va a llamar TODOS los EspacioCalculadora que existan
namespace EspacioCalculadora;

public class Operacion
{
    private double resultadoAnterior;
    private double nuevoValor;
    private tipoOperacion operacion;

    public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
    public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
    public tipoOperacion TipoOperacion { get => operacion; set => operacion = value; }

    public enum tipoOperacion{ 
        Suma, 
        Resta, 
        Multiplicacion, 
        Division,
        Limpiar, }
}
public class Calculadora  // a veces se lo llama atributo
{
    List<Operacion> Historial = new List<Operacion>();
    private double dato;
    public double Resultado { get => dato; }

    public void Sumar(double termino)
    {
    // se supone que guardas el resultado anterior,
    // tendrais que guardar los datos que tenes primero
    // y recien podes hacer la nueva operacion
        AgregarAlHistorial(dato, termino, Operacion.tipoOperacion.Suma);
        dato += termino;
    }
    public void Restar(double termino)
    {
        AgregarAlHistorial(dato, termino, Operacion.tipoOperacion.Resta);
        dato -= termino;
    }
    public void Multiplicar(double termino)
    {
        AgregarAlHistorial(dato, termino, Operacion.tipoOperacion.Multiplicacion);
        dato *= termino;
    }
    public void Dividir(double termino)
    {
        AgregarAlHistorial(dato, termino, Operacion.tipoOperacion.Division);
        dato /= termino;
    }
    public void Limpiar()
    {
        AgregarAlHistorial(dato, 0, Operacion.tipoOperacion.Limpiar);
        dato = 0;
    }

// agregas los nodos al historial de la misma forma que se hacia en C
    public void AgregarAlHistorial(double resultado, double valor, Operacion.tipoOperacion operacion)
    {
        Operacion entrada = new Operacion();
        entrada.ResultadoAnterior = resultado;
        entrada.NuevoValor = valor;
        entrada.TipoOperacion = operacion;

        Historial.Add(entrada);
    }

// esta parte convierte el historial en una lista
// de strings y devuelve eso en lugar del historial en si
    public List<string> EnviarHistorial()
    {
        List<string> HistorialComoString = new List<string>();
        foreach (var item in Historial)
        {
            string frase = $"Resultado Anterior: {item.ResultadoAnterior}, Valor ingresado: {item.NuevoValor}, Operacion: {item.TipoOperacion}";
            HistorialComoString.Add(frase);
        }
        return HistorialComoString;
    }

    public void LiberarHistorial()
    {
        Historial.Clear();
    }

}