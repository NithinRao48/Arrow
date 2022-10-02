using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Types
{
    public class Chaps : IPaymentPermission
    {
        public bool  PaymentStatus(IAccount account, MakePaymentRequest request)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                return false;
            }
            else if (account.Status != AccountStatus.Live)
            {
                return false;
            }
            return true;
        }
    }
}
