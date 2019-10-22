using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Rules
{
   /// <summary>
   /// Proporciona una interfaz de calculadora de interés.
   /// </summary>
   public interface IInterestCalculator
   {
      /// <summary>
      /// Calcula el interés generado del monto <paramref name="pAmount"/>
      /// desde la fecha <paramref name="pDate"/>.
      /// </summary>
      /// <param name="pAmount">Monto sobre el cuál se calcula el interés.</param>
      /// <param name="pDate">Fecha desde cuando se calcula el interés.</param>
      double Calculate(double pAmount, DateTime pDate);
   }
}
