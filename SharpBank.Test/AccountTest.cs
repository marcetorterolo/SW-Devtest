using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBank.Test
{
   [TestFixture]
   public class AccountTest
   {
      [Test]
      public void TestInterestEarned1()
      {
         Account ac = new Account(AccountType.Savings);
         ac.Deposit(3000.0);
         Assert.AreEqual(5.0, ac.GetInterestEarned());
      }

      [Test]
      public void TestInterestEarned2()
      {
         // create accounts 
         Account accChecking = new Account(AccountType.Checking);
         Account accSavings = new Account(AccountType.Savings);
         Account accNMaxiSavings = new Account(AccountType.NewMaxiSavings);

         // deposit
         accChecking.Deposit(10000.0);
         accSavings.Deposit(1000.0);
         accNMaxiSavings.Deposit(1000.0);

         double total = accChecking.GetInterestEarned();
         Assert.AreEqual(total, accChecking.Balance * 0.001);

         total = accNMaxiSavings.GetInterestEarned();
         Assert.AreEqual(total, accNMaxiSavings.Balance * 0.05);

         accNMaxiSavings.Withdraw(100.0);
         total = accNMaxiSavings.GetInterestEarned();
         Assert.AreEqual(total, accNMaxiSavings.Balance * 0.001);
      }

      [Test]
      public void TestDeposit()
      {
         Account ac = new Account(AccountType.Savings);
         Assert.AreEqual(5000.0, ac.Deposit(5000.0));
      }

      [Test]
      public void TestWithdraw()
      {
         Account ac = new Account(AccountType.Savings);
         ac.Deposit(5000.0);
         Assert.AreEqual(4000.0, ac.Withdraw(4000.0));
      }

      [Test]
      public void TestTransferSameAccount()
      {
         Account ac = new Account(AccountType.Savings);
         ac.Deposit(5000.0);

         var ex = Assert.Throws<ArgumentException>(() => ac.Transfer(2500.0, ac));
         Assert.That(ex.Message, Is.EqualTo("the accounts must be different"));
      }

      [Test]
      public void TestTransferDifferentAccount()
      {
         Account ac1 = new Account(AccountType.Savings);
         Account ac2 = new Account(AccountType.Checking);
         ac1.Deposit(5000.0);
         
         Assert.AreEqual(3000.0, ac1.Transfer(3000.0, ac2));
         Assert.AreEqual(2000.0, ac1.Balance);
         Assert.AreEqual(3000.0, ac2.Balance);
      }
   }
}
