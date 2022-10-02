using Arrow.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Payments
{
    public interface IPaymentTypeObjectDict
    {
        IPaymentPermission getPaymentShemeObj(PaymentScheme payType);
    }
}
