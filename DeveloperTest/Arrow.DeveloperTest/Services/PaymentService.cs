using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Payments;
using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private IAccountDataStore myAccountDataStore;
        private IPaymentTypeObjectDict myPaymentTypeObjectDict;

        public PaymentService(IAccountDataStore accountDataStore, IPaymentTypeObjectDict paymentTypeObjectDict)
        {
            myAccountDataStore = accountDataStore;
            myPaymentTypeObjectDict = paymentTypeObjectDict;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = myAccountDataStore.GetAccount(request.DebtorAccountNumber);
            var permission = myPaymentTypeObjectDict.getPaymentShemeObj(request.PaymentScheme);

            MakePaymentResult result = new MakePaymentResult()
            {
                Success = permission.PaymentStatus(account, request)
            };

            if (result.Success)
            {
                account.DeductAmount(request.Amount);
                myAccountDataStore.UpdateAccount(account);
            }

            return result;
        }
    }
}
