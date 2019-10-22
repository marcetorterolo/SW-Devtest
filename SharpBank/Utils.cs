using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank
{
   public static class Utils
   {
      /// <summary>
      /// Dado un número (double) devuelve un string con el símbolo de moneda $.
      /// </summary>
      /// <param name="pVal">El valor.</param>
      /// <returns>
      /// String con el siguiente formato $0,00 
      /// </returns>
      public static string ToDollars(double pVal)
      {
         return string.Format(CultureInfo.CurrentCulture, "${0:N2}", Math.Abs(pVal));
      }

      /// <summary>
      /// Se crea el plural correcto de la palabra <paramref name="pWord"/>
      /// en función del número pasado <paramref name="pNumber"/>.
      /// </summary>
      /// <param name="pNumber">Número.</param>    
      /// <param name="pWord">Palabara.</param>
      /// <returns>
      /// Si <paramref name="pNumber"/> es 1 retorna <paramref name="pWord"/>,
      /// de lo contrario se agrega una 's' al final.
      /// </returns>
      public static string ToPlural(int pNumber, string pWord)
      {
         return pNumber + " " + (pNumber == 1 ? pWord : pWord + "s");
      }
   }
}
