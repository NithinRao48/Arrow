using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Types
{
    public class Bacs : IPaymentPermission
    {

        public bool PaymentStatus(IAccount account, MakePaymentRequest request)
        {
            if (account == null)
            {
                return false;
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                return false;
            }
            return true;
        }
    }
}
