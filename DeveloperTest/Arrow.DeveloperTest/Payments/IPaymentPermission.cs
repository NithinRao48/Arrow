using System;

namespace Arrow.DeveloperTest.Types
{
    public  interface  IPaymentPermission
    {
        public bool  PaymentStatus(IAccount account, MakePaymentRequest request);
    }
}
