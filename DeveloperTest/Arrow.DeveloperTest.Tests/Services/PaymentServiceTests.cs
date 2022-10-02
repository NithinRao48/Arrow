using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Payments;
using Arrow.DeveloperTest.Services;
using Arrow.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace Arrow.DeveloperTest.Tests.Services
{
    [TestFixture]
    public class PaymentServiceTests
    {
        [Test]
        public void MakePayment_PaymentRequestIsValid_ReturnsSuccessStateTrue()
        {
            //Arrage
            var account = MockAccount();
            var makePaymentRequest = new MakePaymentRequest()
            {
                Amount = 100
            };
            var paymentPermission = MockPermission(account.Object, makePaymentRequest, true);
            var paymentTypeDictionary = MockPaymentTypeDictionary(paymentPermission.Object);
            var accountDataStore = MockAccountDataStore(account.Object);
            var paymentService = new PaymentService(accountDataStore.Object, paymentTypeDictionary.Object);

            //Act
            var paymentResult = paymentService.MakePayment(makePaymentRequest);

            //Assert
            paymentTypeDictionary.Verify(p => p.getPaymentShemeObj(makePaymentRequest.PaymentScheme), Times.Once);
            paymentPermission.Verify(p => p.PaymentStatus(account.Object, makePaymentRequest), Times.Once);
            account.Verify(v => v.DeductAmount(100), Times.Once);
            accountDataStore.Verify(a => a.UpdateAccount(account.Object), Times.Once);
            Assert.IsTrue(paymentResult.Success);
        }

        [Test]
        public void MakePayment_PaymentRequestIsInValid_ReturnsSuccessStateFalse()
        {
            //Arrage
            var account = MockAccount();
            var makePaymentRequest = new MakePaymentRequest();
            var paymentPermission = MockPermission(account.Object, makePaymentRequest, false);
            var paymentTypeDictionary = MockPaymentTypeDictionary(paymentPermission.Object);
            var accountDataStore = MockAccountDataStore(account.Object);
            var paymentService = new PaymentService(accountDataStore.Object, paymentTypeDictionary.Object);

            //Act
            var paymentResult = paymentService.MakePayment(makePaymentRequest);

            //Assert
            paymentTypeDictionary.Verify(p => p.getPaymentShemeObj(makePaymentRequest.PaymentScheme), Times.Once);
            paymentPermission.Verify(p => p.PaymentStatus(account.Object, makePaymentRequest), Times.Once);
            account.Verify(v => v.DeductAmount(100), Times.Never);
            accountDataStore.Verify(a => a.UpdateAccount(account.Object), Times.Never);
            Assert.IsFalse(paymentResult.Success);
        }

        private Mock<IAccount> MockAccount()
        {
            var account = new Mock<IAccount>();
            return account;
        }

        private Mock<IPaymentPermission> MockPermission(IAccount account , MakePaymentRequest request, bool paymentStatus)
        {
            var paymentPermission = new Mock<IPaymentPermission>();
            paymentPermission.Setup(p => p.PaymentStatus(account, request)).Returns(paymentStatus);
            return paymentPermission;
        }

        private Mock<IPaymentTypeObjectDict> MockPaymentTypeDictionary(IPaymentPermission paymentPermission)
        {
            var paymentTypeObjectDict = new Mock<IPaymentTypeObjectDict>();
            paymentTypeObjectDict.Setup(p => p.getPaymentShemeObj(It.IsAny<PaymentScheme>())).Returns(paymentPermission);
            return paymentTypeObjectDict;
        }

        private Mock<IAccountDataStore> MockAccountDataStore(IAccount account)
        {
            var accountDataStore = new Mock<IAccountDataStore>();
            accountDataStore.Setup(s => s.GetAccount(It.IsAny<string>())).Returns(account);
            return accountDataStore;
        }
    }
}
