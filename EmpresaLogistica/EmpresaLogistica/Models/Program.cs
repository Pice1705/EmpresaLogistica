using EmpresaLogistica.Models;

public class Program
{
    public static void Main(string[] args)
    {
        // Ejemplo 1: Calculo por peso y destino (nacional)

        Paquetes paquete1 = new Paquetes
        {
            peso = 10.0, // kg
            destino = "Nacional",
            MetodoEnvio = MetodoEnvio.Estandar
        };

        Console.WriteLine("Costo por Peso y Destino: " + paquete1.CalcularPorPesoYDestino());

        // Ejemplo 2: Cálculo por tamaño
        Paquetes paquete2 = new Paquetes
        {
            largo = 0.5, // metros
            ancho = 0.4, // metros
            alto = 0.3, // metros
            MetodoEnvio = MetodoEnvio.Estandar
        };
        Console.WriteLine("Costo por Tamaño: " + paquete2.CalcularPorTamaño());

        // Ejemplo 3: Cálculo completo por peso, tamaño y método de envío (exprés)
        Paquetes paquete3 = new Paquetes
        {
            peso = 5.0, // kg
            largo = 0.5, // metros
            ancho = 0.4, // metros
            alto = 0.3, // metros
            MetodoEnvio = MetodoEnvio.Expres
        };
        Console.WriteLine("Costo Total (Peso, Tamaño, Exprés): " + paquete3.CalcularCostoEnvio());

        // Ejemplo 4: Cálculo completo por peso, tamaño y método de envío (internacional)
        Paquetes paquete4 = new Paquetes
        {
            peso = 7.0, // kg
            largo = 0.6, // metros
            ancho = 0.5, // metros
            alto = 0.4, // metros
            MetodoEnvio = MetodoEnvio.Internacional
        };
        Console.WriteLine("Costo Total (Peso, Tamaño, Internacional): " + paquete4.CalcularCostoEnvio());
    }
}