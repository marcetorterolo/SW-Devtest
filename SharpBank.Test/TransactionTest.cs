using NUnit.Framework;

namespace SharpBank.Test
{
   [TestFixture]
   public class TransactionTest
   {
      [Test]
      public void Transaction()
      {
         Transaction t = new Transaction(5);
         Assert.AreEqual(true, t is Transaction);
      }
   }
}
