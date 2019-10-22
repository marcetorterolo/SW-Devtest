using NUnit.Framework;

namespace SharpBank.Test
{
   [TestFixture]
   public class BankTest
   {
      private const double DOUBLE_DELTA = 1e-15;

      [Test]
      public void CustomerSummary()
      {
         string expectedResult = "Customer Summary\n - John (1 account)";

         Customer c1 = new Customer("John");
         c1.OpenAccount(AccountType.Checking);

         Bank bank = new Bank();
         bank.AddCustomer(c1);

         Assert.AreEqual(expectedResult, bank.CustomerSummary());
      }

      [Test]
      public void CheckingAccount()
      {
         Customer c1 = new Customer("Bill");
         Account a1c1 = c1.OpenAccount(AccountType.Checking);
         a1c1.Deposit(100.0);

         Bank bank = new Bank();
         bank.AddCustomer(c1);

         Assert.AreEqual(0.1, bank.TotalInterestPaid(), DOUBLE_DELTA);
      }

      [Test]
      public void SavingsAccount()
      {
         Customer c1 = new Customer("Bill");
         Account a1c1 = c1.OpenAccount(AccountType.Savings);
         a1c1.Deposit(1500.0);

         Bank bank = new Bank();
         bank.AddCustomer(c1);

         Assert.AreEqual(2.0, bank.TotalInterestPaid(), DOUBLE_DELTA);
      }

      [Test]
      public void MaxiSavingsAccount()
      {
         Customer c1 = new Customer("Bill");
         Account a1c1 = c1.OpenAccount(AccountType.MaxiSavings);
         a1c1.Deposit(3000.0);

         Bank bank = new Bank();
         bank.AddCustomer(c1);

         Assert.AreEqual(170.0, bank.TotalInterestPaid(), DOUBLE_DELTA);
      }

   }
}
