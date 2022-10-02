

namespace Arrow.DeveloperTest.Types
{
    public class FasterPayments : IPaymentPermission
    {
        public bool PaymentStatus(IAccount account, MakePaymentRequest request)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                return false;
            }
            else if (account.Balance < request.Amount)
            {
                return false;
            }
            return true;
        }
    }

}
