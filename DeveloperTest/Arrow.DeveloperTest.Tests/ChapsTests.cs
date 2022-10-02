using Arrow.DeveloperTest.Types;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Tests
{
    [TestFixture]
    class ChapsTests
    {
        [Test]
        public void PaymentStatus_AccountIsNull_ReturnsFalse()
        {
            //Arrange
            var chaps = new Chaps();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.Bacs
            };

            //Act
            var paymentStatus = chaps.PaymentStatus(null, paymentRequest);

            //Assert
            Assert.IsFalse(paymentStatus);
        }

        [Test]
        public void PaymentStatus_AccountAllowedSchemeContatinsChaps_ReturnsTrue()
        {
            //Arrange
            var account = new Mock<IAccount>();
            account.Setup(a => a.AllowedPaymentSchemes).Returns(AllowedPaymentSchemes.Chaps);

            var chaps = new Chaps();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.Chaps
            };

            //Act
            var paymentStatus = chaps.PaymentStatus(account.Object, paymentRequest);

            //Assert
            Assert.IsTrue(paymentStatus);
        }

        [Test]
        public void PaymentStatus_AccountAllowedSchemeDoesNotContatinsChaps_ReturnsFalse()
        {
            //Arrange
            var account = new Mock<IAccount>();
            account.Setup(a => a.AllowedPaymentSchemes).Returns(AllowedPaymentSchemes.FasterPayments);

            var chaps = new Chaps();
            var paymentRequest = new MakePaymentRequest()
            {
                PaymentScheme = PaymentScheme.Chaps
            };

            //Act
            var paymentStatus = chaps.PaymentStatus(account.Object, paymentRequest);

            //Assert
            Assert.IsFalse(paymentStatus);
        }
    }
}

