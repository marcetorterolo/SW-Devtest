using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBank
{
   /// <summary>
   /// Clase que representa un cliente en el sistema.
   /// </summary>
   public class Customer
   {
      #region Propiedades
      /// <summary>
      /// Nombre del cliente.
      /// </summary>
      private readonly string _name;

      /// <summary>
      /// Lista de cuentas que posee el cliente.
      /// </summary>
      private List<Account> _accounts;

      /// <summary>
      /// Devuelve la lista de cuentas del cliente.
      /// </summary>
      /// <value>
      /// Las cuentas.
      /// </value>
      public IEnumerable<Account> Accounts
      {
         get { return _accounts.ToArray(); }
      }
      #endregion

      /// <summary>
      /// Crea una entidad Customer sin cuentas.
      /// </summary>
      /// <param name="pName">Nombre del cliente.</param>      
      public Customer(string pName)
      {
         _name = pName;
         _accounts = new List<Account>();
      }

      /// <summary>
      /// Devuelve el nombre del cliente.
      /// </summary>
      public string GetName() => _name;

      /// <summary>
      /// Realiza apertura de cuenta.
      /// </summary>
      /// <param name="pAccountType">Tipo de cuenta.</param>   
      public Account OpenAccount(AccountType pAccountType)
      {
         Account account = new Account(pAccountType);
         _accounts.Add(account);
         return account;
      }

      /// <summary>
      /// Retorna el total de cuentas que posee el cliente.
      /// </summary>
      public int GetNumberOfAccounts() => _accounts.Count;

      /// <summary>
      /// Devuelve el total de interés pagado al cliente.
      /// </summary>
      public double GetTotalInterestEarned()
      {
         return _accounts.Sum(sum => sum.GetInterestEarned());
      }

      public string GetStatement()
      {
         StringBuilder statement = new StringBuilder();
         statement.Append("Statement for " + _name + "\n");

         double total = 0.0;
         foreach (Account a in _accounts)
         {
            statement.Append("\n" + a.GetStatement() + "\n");
            total += a.Balance;
         }

         statement.Append("\nTotal In All Accounts " + Utils.ToDollars(total));
         return statement.ToString();
      }
   }
}
