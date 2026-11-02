using Dominio;
using System;
using System.Collections.Generic;


namespace Negocio
{
    public class InversionNegocio
    {
        // Recibe un banco y devuelve el promedio de sus tres tasas.
        public decimal CalcularPromedio(Banco banco)
        {
            if (banco.TasasHistoricas.Count != 3)
            {
                throw new ArgumentException(
                    "El banco debe tener exactamente 3 tasas.");
            }

            decimal suma = 0;

            foreach (decimal tasa in banco.TasasHistoricas)
            {
                suma = suma + tasa;
            }

            return suma / banco.TasasHistoricas.Count;
        }

        // Calcula el capital final reinvirtiendo en cada período.
        public decimal CalcularCapitalFinal(
            decimal capitalInicial,
            decimal tasaAnualPromedio,
            int cantidadPeriodos)
        {
            if (cantidadPeriodos <= 0)
            {
                throw new ArgumentException(
                    "La cantidad de períodos debe ser mayor que cero.");
            }

            decimal capitalActual = capitalInicial;
            decimal tasaPorPeriodo =
                tasaAnualPromedio / 100 / cantidadPeriodos;

            for (int periodo = 1; periodo <= cantidadPeriodos; periodo++)
            {
                decimal intereses = capitalActual * tasaPorPeriodo;
                capitalActual = capitalActual + intereses;
            }

            return capitalActual;
        }

        // Reúne los datos y cálculos de una inversión.
        public ResultadoInversion CalcularResultado(  
            Banco banco,
            decimal capitalInicial,
            ModalidadInversion modalidad)
        {
            ResultadoInversion resultado = new ResultadoInversion();

            resultado.Banco = banco;
            resultado.CapitalInicial = capitalInicial;
            resultado.Modalidad = modalidad;
            resultado.TasaAnualPromedio = CalcularPromedio(banco);

            int cantidadPeriodos;

            switch (modalidad)
            {
                case ModalidadInversion.Anual:
                    cantidadPeriodos = 1;
                    break;

                case ModalidadInversion.Trimestral:
                    cantidadPeriodos = 4;
                    break;

                case ModalidadInversion.Mensual:
                    cantidadPeriodos = 12;
                    break;

                default:
                    throw new ArgumentException(
                        "La modalidad no es válida.");
            }

            resultado.CapitalFinal = CalcularCapitalFinal(
                capitalInicial,
                resultado.TasaAnualPromedio,
                cantidadPeriodos);



            return resultado;
        }

        public List<ResultadoInversion> CalcularResultados(
            Banco banco,
            decimal capitalInicial)
        {
            List<ResultadoInversion> resultados = new List<ResultadoInversion>();

            List<ModalidadInversion> modalidades = new List<ModalidadInversion>
        {
            ModalidadInversion.Anual,
            ModalidadInversion.Trimestral,
            ModalidadInversion.Mensual
        };
 foreach (ModalidadInversion modalidad in modalidades )
            {
                ResultadoInversion resultado = CalcularResultado(
                    banco,
                    capitalInicial,
                    modalidad);
                resultados.Add(resultado);
            }



            return resultados;


        }




    }
}