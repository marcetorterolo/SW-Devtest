using NUnit.Framework;
using System;
using System.Globalization;

namespace SharpBank.Test
{
   [TestFixture]
   public class CustomerTest
   {

      [Test]
      public void TestCustomerStatementGeneration()
      {
         string expectedResult = String.Format(CultureInfo.CurrentCulture, "Statement for Henry\n");
         expectedResult += String.Format(CultureInfo.CurrentCulture, "\n");

         expectedResult += String.Format(CultureInfo.CurrentCulture, "Checking Account\n");
         expectedResult += String.Format(CultureInfo.CurrentCulture, "  deposit ${0:N2}\n", 100);
         expectedResult += String.Format(CultureInfo.CurrentCulture, "Total ${0:N2}\n", 100);
         expectedResult += String.Format(CultureInfo.CurrentCulture, "\n");

         expectedResult += String.Format(CultureInfo.CurrentCulture, "Savings Account\n");
         expectedResult += String.Format(CultureInfo.CurrentCulture, "  deposit ${0:N2}\n", 4000);
         expectedResult += String.Format(CultureInfo.CurrentCulture, "  withdrawal ${0:N2}\n", 200);
         expectedResult += String.Format(CultureInfo.CurrentCulture, "Total ${0:N2}\n", 3800);
         expectedResult += String.Format(CultureInfo.CurrentCulture, "\n");

         expectedResult += String.Format(CultureInfo.CurrentCulture, "Total In All Accounts ${0:N2}", 3900);

         Customer c1 = new Customer("Henry");

         Account a1c1 = c1.OpenAccount(AccountType.Checking);
         Account a2c1 = c1.OpenAccount(AccountType.Savings);

         a1c1.Deposit(100.0);
         a2c1.Deposit(4000.0);
         a2c1.Withdraw(200.0);

         Assert.AreEqual(expectedResult, c1.GetStatement());
      }

      [Test]
      public void TestOneAccount()
      {
         Customer c1 = new Customer("Oscar");
         c1.OpenAccount(AccountType.Savings);

         Assert.AreEqual(1, c1.GetNumberOfAccounts());
      }

      [Test]
      public void TestTwoAccount()
      {
         Customer c1 = new Customer("Oscar");
         c1.OpenAccount(AccountType.Savings);
         c1.OpenAccount(AccountType.Checking);

         Assert.AreEqual(2, c1.GetNumberOfAccounts());
      }

      [Test]
      public void TestThreeAcounts()
      {
         Customer c1 = new Customer("Oscar");
         c1.OpenAccount(AccountType.Savings);
         c1.OpenAccount(AccountType.Checking);
         c1.OpenAccount(AccountType.MaxiSavings);

         Assert.AreEqual(3, c1.GetNumberOfAccounts());
      }
   }
}
