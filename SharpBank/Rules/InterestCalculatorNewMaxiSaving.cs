using System;

namespace SharpBank.Rules
{
   /// <summary>
   /// Clase que implmenta la interfaz <see cref="IInterestCalculator"/>
   /// para las cuentas del tipo <see cref="AccountType.NewMaxiSavings"/>.
   /// </summary>
   public class InterestCalculatorNewMaxiSaving : IInterestCalculator
   {
      public readonly DateTime? lastWithdraw;

      private const double PERCENTAGELESS10DAYSWITHDRAW = 0.1;
      private const double PERCENTAGEMORE10DAYSWITHDRAW = 5;

      public InterestCalculatorNewMaxiSaving(DateTime? lastWithdraw)
      {
         this.lastWithdraw = lastWithdraw;
      }

      /// <summary>
      /// Calcula el interés generado del monto <paramref name="pAmount"/>
      /// desde la fecha <paramref name="pDate"/>.
      /// </summary>
      /// <param name="pAmount">Monto sobre el cuál se calcula el interés.</param>
      /// <param name="pDate">Fecha desde cuando se calcula el interés.</param>
      public double Calculate(double pAmount, DateTime pDate)
      {
         var shouldApplyMaxiSavingInterest = lastWithdraw == null || (int)(DateTime.Now - lastWithdraw.Value).TotalDays > 10;

         //var interestPerYear = (shouldApplyMaxiSavingInterest ? (pAmount * (PERCENTAGEMORE10DAYSWITHDRAW / 100)) : (pAmount * (PERCENTAGELESS10DAYSWITHDRAW / 100)));
         //var countDayLast = (int)(System.DateTime.Now - pDate).TotalDays;
         //pAmount += interestPerYear / 365 * countDayLast;

         if (shouldApplyMaxiSavingInterest)
         {
            pAmount += pAmount.DailyInterest(PERCENTAGEMORE10DAYSWITHDRAW, (int)(DateTime.Now - pDate).TotalDays);
            return pAmount * 0.05;
         }
         else
         {
            pAmount += pAmount.DailyInterest(PERCENTAGELESS10DAYSWITHDRAW, (int)(DateTime.Now - pDate).TotalDays);
            return pAmount * 0.001;
         }
      }
   }
}
