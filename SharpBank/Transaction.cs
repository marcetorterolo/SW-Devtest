using System;

namespace SharpBank
{
   /// <summary>
   /// Clase que representa una transacción en el sistema.
   /// </summary>
   public class Transaction
   {
      #region Propiedades
      /// <summary>
      /// Numerador para las transacciones de una misma cuenta.
      /// </summary>
      private static int _idTransaction = 0;

      /// <summary>
      /// Devuelve el monto de la transacción.
      /// </summary>
      /// <value>
      /// Monto de la transacción.
      /// </value>
      public double Amount { get; private set; }

      /// <summary>
      /// Devuelve la fecha/hora de la transacción.
      /// </summary>
      /// <value>
      /// Fecha de la transacción.
      /// </value>
      public DateTime Date { get; private set; }

      /// <summary>
      /// Devuelve el número de la transacción.
      /// </summary>
      /// <value>
      /// Número de transacción.
      /// </value>
      public int Number { get; private set; }
      #endregion

      /// <summary>
      /// Inicializa una nueva instancia de la clase <see cref="Transaction"/>.
      /// </summary>
      /// <param name="pAmount">Monto de la transacción.</param>
      public Transaction(double pAmount)
      {
         Amount = pAmount;
         Number = ++_idTransaction;
         Date = DateProvider.GetInstance().Now();
      }
   }
}
