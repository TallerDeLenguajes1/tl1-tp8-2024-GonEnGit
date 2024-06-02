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

    public double ResultadoAnterior { get => resultadoAnterior;}
    public double NuevoValor { get => nuevoValor;}

    public enum tipoOperacion{ Suma, Resta, Multiplicacion, Division, }
}
public class Calculadora  // a veces se lo llama atributo
{
    private double dato;

    public global::System.Double Resultado { get => dato; }

    public void Sumar(double termino)
    {
        dato += termino;
    }
    public void Restar(double termino)
    {
        dato -= termino;
    }
    public void Multiplicar(double termino)
    {
        dato *= termino;
    }
    public void Dividir(double termino)
    {
        dato /= termino;
    }
    public void Limpiar()
    {
        dato = 0;
    }
}