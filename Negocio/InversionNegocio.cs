using Dominio;
using System;

namespace Negocio // lo que hace negocio : Negocio realiza los cálculos con esos datos
{
    public class InversionNegocio
    {
        public decimal CalcularPromedio(Banco banco)
        { 
           if(banco.TasasHistoricas.Count!=3)
            {
                throw new Exception("El banco debe tener exactamente 3 tasas");


            }
            
            decimal suma = 0;
            foreach(decimal tasa in banco.TasasHistoricas)
            {
                suma = suma + tasa;

            }   
            return suma / banco.TasasHistoricas.Count;

        }


        public decimal CalcularCapitalFinal (
            decimal capitalInicial,
            decimal tasaAnualPromedio,
            int cantidadPeriodos
            )
        {
            decimal capitalActual = capitalInicial;

            // aca : tasa que corresponde a cada período
            decimal tasaPorPeriodo = tasaAnualPromedio / 100 / cantidadPeriodos;

            //ciclo que suma los intereses en cada período

            for (int periodo = 1; periodo <= cantidadPeriodos; periodo++)
            {
                decimal intereses = capitalActual * tasaPorPeriodo;
                capitalActual = capitalActual + intereses;


                return capitalActual;

        }


    }
}
