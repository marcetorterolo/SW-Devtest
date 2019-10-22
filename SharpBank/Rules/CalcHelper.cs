using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Rules
{
   /// <summary>
   /// Calculadora Helper.
   /// </summary>
   public static class CalcHelper
   {
      /// <summary>
      /// Calcula el interés diario adquirido
      /// </summary>
      /// <param name="pAmount">El monto.</param>
      /// <param name="pYearRate">Tasa de interés anual.</param>
      /// <param name="pDays">Los días para calcular.</param>
      /// <param name="pDaysInYear">Los días en un año.</param>
      /// <returns>Interés calculado</returns>
      public static double DailyInterest(this double pAmount, double pYearRate, int pDays, int pDaysInYear = 365)
      {
         double rate = pYearRate / 100.0;
         return pAmount * (rate / pDaysInYear) * pDays;
      }
   }
}
