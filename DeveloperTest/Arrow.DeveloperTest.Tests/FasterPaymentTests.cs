using Arrow.DeveloperTest.Types;
using Moq;
using NUnit.Framework;


namespace Arrow.DeveloperTest.Tests
{
    [TestFixture]
    class FasterPaymentTests
    {
        [Test]
        public void PaymentStatus_AccountIsNull_ReturnsFalse()
        {
            //Arrange
            var fasterPayments = new FasterPayments();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.FasterPayments
            };

            //Act
            var paymentStatus = fasterPayments.PaymentStatus(null, paymentRequest);

            //Assert
            Assert.IsFalse(paymentStatus);
        }

        [Test]
        public void PaymentStatus_AccountAllowedSchemeContatinsFasterPayments_ReturnsTrue()
        {
            //Arrange
            var account = new Mock<IAccount>();
            account.Setup(a => a.AllowedPaymentSchemes).Returns(AllowedPaymentSchemes.FasterPayments);

            var fasterPayments = new FasterPayments();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.FasterPayments
            };

            //Act
            var paymentStatus = fasterPayments.PaymentStatus(account.Object, paymentRequest);

            //Assert
            Assert.IsTrue(paymentStatus);
        }

        [Test]
        public void PaymentStatus_AccountAllowedSchemeDoesNotContatinsFasterPayments_ReturnsFalse()
        {
            //Arrange
            var account = new Mock<IAccount>();
            account.Setup(a => a.AllowedPaymentSchemes).Returns(AllowedPaymentSchemes.Bacs);

            var fasterPayments = new FasterPayments();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.FasterPayments
            };

            //Act
            var paymentStatus = fasterPayments.PaymentStatus(account.Object, paymentRequest);

            //Assert
            Assert.IsFalse(paymentStatus);
        }
    }
}

