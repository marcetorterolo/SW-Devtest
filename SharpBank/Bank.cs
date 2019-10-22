using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpBank
{
   /// <summary>
   /// Clase que representa un banco en el sistema.
   /// </summary>
   public class Bank
   {
      #region Propiedades
      /// <summary>
      /// Lista de clientes que posee el banco.
      /// </summary>
      private List<Customer> _customers;
      #endregion

      /// <summary>
      /// Inicializa una entidad <see cref="Bank"/> sin clientes.
      /// </summary>
      public Bank()
      {
         _customers = new List<Customer>();
      }

      /// <summary>
      /// Se agrega el cliente indicado por <paramref name="pCustomer"/> al banco.
      /// </summary>
      /// <param name="pCustomer">Entidad Cliente.</param>   
      public void AddCustomer(Customer pCustomer)
      {
         _customers.Add(pCustomer);
      }

      public string CustomerSummary()
      {
         StringBuilder s = new StringBuilder();
         s.Append("Customer Summary");

         foreach (Customer c in _customers)
            s.Append("\n - " + c.GetName() + " (" + Utils.ToPlural(c.GetNumberOfAccounts(), "account") + ")");
         return s.ToString();
      }

      /// <summary>
      /// Retorna el interés total pagado por el banco en todas las cuentas.
      /// </summary>
      public double TotalInterestPaid()
      {
         return _customers.Sum(sum => sum.GetTotalInterestEarned());
      }

      /// <summary>
      /// Retorna el nombre del primer cliente.
      /// </summary>
      public string GetFirstCustomer()
      {
         if (!_customers.Any())
         {
            Console.WriteLine("Error: there are not customers to get.");
            return "Error";
         }
         return _customers.FirstOrDefault().GetName();
      }
   }
}
