using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaLogistica.Models
{
    internal class Paquetes
    {
        //Ponemos signo de pregunta en las varibles para determinar que su valor es "nullable" si no hay nada asignado
        //con esto evitamos que su valor sea cero hasta que el cliente no le ponga un valor a cualquiera de las variables
        public double? peso { get; set; }
        public double? largo { get; set; }
        public double? ancho { get; set; }
        public double? alto { get; set; }
        public string destino { get; set; }
  
        public MetodoEnvio MetodoEnvio { get; set; }


        //Metodo para calcular el costo basado en el peso
        public double CalcularPorPeso()
        { 
          if (peso.HasValue) //con Has.Value Verifico si la variable peso tiene un valor asignado
            {
                return peso.Value * 5;
            }
          else
            {
                return 0;
            }
        }

        //Metodo para calcular por tamaño
        public double CalcularPorTamaño()
        {
            if (largo.HasValue && ancho.HasValue && alto.HasValue)
            {
                double volumen = ancho.Value * largo.Value * alto.Value;
                return volumen * 2;
            }
            else
            {
                return 0;
            }
        }

        //Metodo para calcular por peso y destino
        public double CalcularPorPesoYDestino()
        {
            if (peso.HasValue && !string.IsNullOrEmpty(destino))
            {
                double tarifaBase = 10.0;
                if (destino.Equals("Nacional")) //Con equals verificamos que destino tenga asignado Nacional
                {
                    return tarifaBase + (peso.Value * 4.0);
                }
                else if (destino.Equals("Internacional"))
                {
                    return 2 * tarifaBase + (peso.Value * 4.0 * 1.5);
                }
            }
            return 0.0;
        }


        //Metodo para calcular Por Peso, Tamaño, y Método de Envío:
        public double CalcularCostoEnvio()
        {
            double CostoPeso = CalcularPorPeso();
            double CostoTamaño = CalcularPorTamaño();
            double CostoBase = CostoPeso * CostoTamaño;

            switch (MetodoEnvio)
            {
                case MetodoEnvio.Expres:
                    return CostoBase * 1.25; //Sumamos el 25% del costo base

                case MetodoEnvio.Internacional:
                    return CostoBase * 1.50; //Sumamos el 50% del costo base

                default:
                    return CostoBase; //Envio Estandar
            }
        }

    }
}
