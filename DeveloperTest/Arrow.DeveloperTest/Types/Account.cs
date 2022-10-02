namespace Arrow.DeveloperTest.Types
{
    public class Account : IAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        public void DeductAmount(decimal amount)
        {
            Balance -= amount;
        }
    }
}
