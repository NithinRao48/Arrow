using Arrow.DeveloperTest.Types;
using NUnit.Framework;

namespace Arrow.DeveloperTest.Tests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        public void DeductAmount_BalanceIsDeducted()
        {
            //arrange
            var account = new Account() { Balance = 100 };

            //Act
            account.DeductAmount(50);

            //Assert
            Assert.IsTrue(account.Balance == 50);
        }
    }
}
