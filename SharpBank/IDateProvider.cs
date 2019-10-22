using System;

namespace SharpBank
{
   /// <summary>
   /// Proporciona una interfaz de fecha "Now".
   /// </summary>
   public interface IDateProvider
   {
      /// <summary>
      /// Devuelve la fecha actual.
      /// </summary>
      DateTime Now();
   }
}
