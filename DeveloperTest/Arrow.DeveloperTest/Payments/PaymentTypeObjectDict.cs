using Arrow.DeveloperTest.Payments;
using System;
using System.Collections.Generic;   

namespace Arrow.DeveloperTest.Types
{
    public class PaymentTypeObjectDict : IPaymentTypeObjectDict
    {
        private Dictionary<PaymentScheme, Func<IPaymentPermission>> PaymentSchemeObj;

        public PaymentTypeObjectDict()
        {
            PaymentSchemeObj = new Dictionary<PaymentScheme, Func<IPaymentPermission>>();
            PaymentSchemeObj.Add(PaymentScheme.FasterPayments, () => { return new FasterPayments(); });
            PaymentSchemeObj.Add(PaymentScheme.Chaps, () => { return new Chaps(); });
            PaymentSchemeObj.Add(PaymentScheme.Bacs, () => { return new Bacs(); });
        }

        public IPaymentPermission getPaymentShemeObj(PaymentScheme payType)
        {
            return PaymentSchemeObj[payType]();
        }
    }
}
