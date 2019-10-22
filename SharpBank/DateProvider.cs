using System;

namespace SharpBank
{
   /// <summary>
   /// Clase que implmenta la interfaz <see cref="IDateProvider"/>.
   /// </summary>
   // Se aplica Patrón Singleton
   public class DateProvider : IDateProvider
   {
      /// <summary>
      /// Instancia de la clase <see cref="DateProvider"/>.
      /// </summary>
      private static DateProvider _instance = null;

      /// <summary>
      /// Inicializa la instancia de la clase <see cref="DateProvider"/>.
      /// </summary>
      private DateProvider() { }

      /// <summary>
      /// Retorna la instancia de la clase <see cref="DateProvider"/>
      /// </summary>
      public static DateProvider GetInstance()
      {
         if (_instance == null)
            _instance = new DateProvider();
         return _instance;
      }

      /// <summary>
      /// Devuelve la fecha actual.
      /// </summary>
      public DateTime Now()
      {
         return DateTime.Now;
      }
   }
}
