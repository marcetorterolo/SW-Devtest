namespace SharpBank
{
   /// <summary>
   /// Enumerado que representa los distintos tipos de cuenta.
   /// </summary>
   public enum AccountType
   {
      /// <summary>
      /// Cuenta orientada a un usuario que quiera acceder a su dinero diariamente,
      /// normalmente en pequeñas cantidades y que no espera rendimiento de su cuenta.
      /// </summary>
      Checking = 0,

      /// <summary>
      /// Cuenta orientada al usuario que no acceda tanto a su dinero y que quiera
      /// sacar un rendimiento de sus ahorros. Genera un pequeño interés superior
      /// a las cuentas <see cref="Checking"/>.
      /// </summary>
      Savings = 1,

      /// <summary>
      /// Con esta cuenta se obtienen mayores rendimientos que la cuenta tipo
      /// <see cref="Savings"/>, manteniendo la posibilidad de acceder al dinero,
      /// aunque no diariamente.
      /// </summary>
      MaxiSavings = 2,

      /// <summary>
      /// Con esta cuenta se obtienen mayores rendimientos que <see cref="MaxiSavings"/>,
      /// si no existen retiros en los últimos
      /// 10 días.
      /// </summary>
      NewMaxiSavings = 3,
   }
}
