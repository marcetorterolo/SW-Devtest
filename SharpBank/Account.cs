using SharpBank.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpBank
{
   /// <summary>
   /// Clase que representa una cuenta en el sistema.
   /// </summary>
   public class Account
   {
      #region Propiedades
      /// <summary>
      /// Numerador para las cuentas de tipo <see cref="AccountType.Checking"> de un mismo cliente.
      /// </summary>
      private static int _idAccCheking = 1000;

      /// <summary>
      /// Numerador para las cuentas de tipo <see cref="AccountType.Savings"/> de un mismo cliente.
      /// </summary>
      private static int _idAccSaving = 2000;

      /// <summary>
      /// Numerador para las cuentas de tipo <see cref="AccountType.MaxiSavings"/> de un mismo cliente.
      /// </summary>
      private static int _idAccMaxiSaving = 3000;

      /// <summary>
      /// Calculadora de interés
      /// </summary>
      private IInterestCalculator _interestCalculator;

      /// <summary>
      /// Historial de transacciones de la cuenta.
      /// </summary>
      private readonly List<Transaction> _transactionsList;

      /// <summary>
      /// Devuelve el tipo de cuenta <see cref="AccountType"/>.
      /// </summary>
      /// <value>
      /// Tipo de cuenta.
      /// </value>
      public AccountType Type { get; private set; }

      /// <summary>
      /// Devuelve el número de cuenta.
      /// </summary>
      /// <value>
      /// Número de cuenta.
      /// </value>
      public int Number { get; private set; }

      /// <summary>
      /// Devuelve el historial de transacciones de la cuenta.
      /// </summary>
      /// <value>
      /// Las transacciones.
      /// </value>
      public IEnumerable<Transaction> Transactions
      {
         get
         {
            return _transactionsList.ToArray();
         }
      }

      /// <summary>
      /// Devuelve el total de dinero en la cuenta.
      /// </summary>
      /// <value>
      /// El Balance.
      /// </value>
      public double Balance { get; private set; }

      /// <summary>
      /// Devuelve la fecha del último retiro.
      /// </summary>
      public DateTime? LastWithdraw { get; private set; }

      /// <summary>
      /// Devuelve la fecha en que fue creada la cuenta.
      /// </summary>
      public DateTime DateCreate { get; }
      #endregion

      /// <summary>
      /// Inicializa una nueva instancia de la clase <see cref="Account"/> sin transacciones.
      /// </summary>
      /// <param name="pAccountType">Tipo de cuenta.</param>
      public Account(AccountType pAccountType)
      {
         switch (pAccountType)
         {
            case AccountType.Checking:
               Number = ++_idAccCheking;
               break;

            case AccountType.Savings:
               Number = ++_idAccSaving;
               break;

            case AccountType.MaxiSavings:
               Number = ++_idAccMaxiSaving;
               break;
         }

         Type = pAccountType;
         Balance = 0;
         DateCreate = DateProvider.GetInstance().Now();
         _transactionsList = new List<Transaction>();
         LastWithdraw = null;
      }

      /// <summary>
      /// Retorna el nombre (string) de la cuenta.
      /// </summary>
      public string GetAccName()
      {
         StringBuilder s = new StringBuilder();
         switch (this.Type)
         {
            case AccountType.Checking:
               s.Append("Checking Account");
               break;

            case AccountType.Savings:
               s.Append("Savings Account");
               break;

            case AccountType.MaxiSavings:
               s.Append("Maxi-Savings Account");
               break;
         }
         return s.ToString();
      }

      /// <summary>
      /// Operación que permite realizar un depósito en la cuenta.
      /// </summary>
      /// <param name="pAmount">Monto del depósito.</param>
      /// <returns>Monto depositado.</returns>
      /// <exception cref="System.ArgumentException">amount must be greater than zero</exception>
      public double Deposit(double pAmount)
      {
         if (pAmount <= 0)
            throw new ArgumentException("amount must be greater than zero");
         else
         {
            _transactionsList.Add(new Transaction(pAmount));
            Balance += pAmount;
            return pAmount;
         }
      }

      /// <summary>
      /// Operación que permite realizar un retiro en la cuenta.
      /// </summary>
      /// <param name="pAmount">Monto del retiro.</param>
      /// <returns>Monto retirado.</returns>
      /// <exception cref="System.ArgumentException">amount must be greater than zero</exception>
      /// <exception cref="System.ArgumentException">insufficient funds</exception>
      public double Withdraw(double pAmount)
      {
         if (pAmount <= 0)
            throw new ArgumentException("amount must be greater than zero");
         else if (pAmount > Balance)
            throw new ArgumentException("insufficient funds");
         else
         {
            _transactionsList.Add(new Transaction(-pAmount));
            Balance -= pAmount;
            LastWithdraw = DateProvider.GetInstance().Now();
            return pAmount;
         }
      }

      /// <summary>
      /// Operación que permite realizar transferencia desde la cuenta actual
      /// a la cuenta destino <paramref name="pDestination"/>.
      /// </summary>
      /// <param name="pAmount">Monto de la transferencia.</param>
      /// <param name="pDestination">Cuenta destino.</param>
      /// <returns>Monto transferido.</returns>
      public double Transfer(double pAmount, Account pDestination)
      {
         if (pDestination != null)
         {
            if (this.Number == pDestination.Number)
               throw new ArgumentException("the accounts must be different");
            else
            {
               try
               {
                  return pDestination.Deposit(this.Withdraw(pAmount));
               }
               catch (ArgumentException e)
               {
                  Console.WriteLine(e.Message);
                  return -1;
               }
            }
         }
         else
            return 0;
      }

      /// <summary>
      /// Calcula el total de interés ganado en la cuenta.
      /// </summary>
      /// <returns>
      /// Interés ganado.
      /// </returns>
      public double GetInterestEarned()
      {
         double interestEarned;
         switch (this.Type)
         {
            case AccountType.Checking:
               _interestCalculator = new InterestCalculatorChecking();
               break;

            case AccountType.Savings:
               _interestCalculator = new InterestCalculatorSaving();
               break;

            case AccountType.MaxiSavings:
               _interestCalculator = new InterestCalculatorMaxiSaving();
               break;

            case AccountType.NewMaxiSavings:
               _interestCalculator = new InterestCalculatorNewMaxiSaving(this.LastWithdraw);
               break;
         }

         interestEarned = _interestCalculator.Calculate(Balance, this.DateCreate);
         return interestEarned;
      }

      /// <summary>
      /// Retorna string con el tipo(nombre) de cuenta y el balance
      /// de la misma, asi como también cada una de las transacciones
      /// junto con el importe.
      /// </summary>
      /// <example>
      /// Savings Account
      ///   deposit $4.000,00
      ///   withdrawal $200,00
      /// Total $3.800,00
      /// </example>
      public string GetStatement()
      {
         StringBuilder s = new StringBuilder();
         s.Append(GetAccName() + "\n");

         //Now total up all the transactions
         foreach (Transaction t in Transactions)
         {
            s.Append("  " + (t.Amount < 0 ? "withdrawal" : "deposit") + " " + Utils.ToDollars(t.Amount) + "\n");
         }
         s.Append("Total " + Utils.ToDollars(Balance));
         return s.ToString();
      }
   }
}
