using Arrow.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace Arrow.DeveloperTest.Tests
{
    [TestFixture]
    public class BacsTests
    {
        [Test]
        public void PaymentStatus_AccountIsNull_ReturnsFalse()
        {
            //Arrange
            var bacs = new Bacs();
            var paymentRequest = new MakePaymentRequest() 
            { 
                PaymentScheme = PaymentScheme.Bacs 
            };

            //Act
            var paymentStatus = bacs.PaymentStatus(null, paymentRequest);

            //Assert
            Assert.IsFalse(paymentStatus);
        }

        [Test]
        public void PaymentStatus_AccountAllowedSchemeContatinsBacs_ReturnsTrue()
        {
            //Arrange
            var account = new Mock<IAccount>();
            account.Setup(a => a.AllowedPaymentSchemes).Returns(AllowedPaymentSchemes.Bacs);

            var bacs = new Bacs();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.Bacs
            };

            //Act
            var paymentStatus = bacs.PaymentStatus(account.Object, paymentRequest);

            //Assert
            Assert.IsTrue(paymentStatus);
        }

        [Test]
        public void PaymentStatus_AccountAllowedSchemeDoesNotContatinsBacs_ReturnsFalse()
        {
            //Arrange
            var account = new Mock<IAccount>();
            account.Setup(a => a.AllowedPaymentSchemes).Returns(AllowedPaymentSchemes.FasterPayments);

            var bacs = new Bacs();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.Bacs
            };

            //Act
            var paymentStatus = bacs.PaymentStatus(account.Object, paymentRequest);

            //Assert
            Assert.IsFalse(paymentStatus);
        }
    }
}
