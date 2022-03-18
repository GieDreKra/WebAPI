
namespace CreditAPI.Dtos
{
    public class Credit
    {
        public int CreditAmount { get; set; }
        public int Term { get; set; } //repayment in months
        public int PreexistingCreditAmount { get; set; }
        public bool Decision { get; set; }
        public double InterestRate { get; set; }

    }
}
