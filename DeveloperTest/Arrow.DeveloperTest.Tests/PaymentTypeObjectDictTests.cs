using Arrow.DeveloperTest.Types;
using NUnit.Framework;

namespace Arrow.DeveloperTest.Tests
{
    [TestFixture]
    public class PaymentTypeObjectDictTests
    {
        [Test]
        public void getPaymentShemeObj_PaymentSchemeIsChap_ReturnsChap()
        {
            //Arrange
            var paymentType = new PaymentTypeObjectDict();

            //Act
            var scheme = paymentType.getPaymentShemeObj(PaymentScheme.Chaps);

            //Assert
            Assert.IsTrue(scheme.GetType() == typeof(Chaps));
        }

        [Test]
        public void getPaymentShemeObj_PaymentSchemeIsBacs_ReturnsBacs()
        {
            //Arramge
            var paymentType = new PaymentTypeObjectDict();

            //Act
            var scheme = paymentType.getPaymentShemeObj(PaymentScheme.Bacs);

            //Assert
            Assert.IsTrue(scheme.GetType() == typeof(Bacs));
        }

        [Test]
        public void getPaymentShemeObj_PaymentSchemeIsFasterPayment_ReturnsFasterPayment()
        {
            var paymentType = new PaymentTypeObjectDict();

            //Act
            var scheme = paymentType.getPaymentShemeObj(PaymentScheme.FasterPayments);

            //Assert
            Assert.IsTrue(scheme.GetType() == typeof(FasterPayments));
        }
    }
}
