using System;

namespace SharpBank.Rules
{
   /// <summary>
   /// Clase que implmenta la interfaz <see cref="IInterestCalculator"/>
   /// para las cuentas del tipo <see cref="AccountType.Checking"/>.
   /// </summary>
   public class InterestCalculatorChecking : IInterestCalculator
   {
      private const double PERCENTAGE_YEAR = 5;

      /// <summary>
      /// Calcula el interés generado del monto <paramref name="pAmount"/>
      /// desde la fecha <paramref name="pDate"/>.
      /// </summary>
      /// <param name="pAmount">Monto sobre el cuál se calcula el interés.</param>
      /// <param name="pDate">Fecha desde cuando se calcula el interés.</param>
      public double Calculate(double pAmount, DateTime pDate)
      {
         //var interestDay = Math.Round(PERCENTAGE_YEAR /365, 3);
         //var countDayLast = (int)(DateTime.Now - pDate).TotalDays;
         //pAmount += (pAmount * (countDayLast * interestDay));

         pAmount += pAmount.DailyInterest(PERCENTAGE_YEAR, (int)(DateTime.Now - pDate).TotalDays);
         return pAmount * 0.001;
      }
   }
}
