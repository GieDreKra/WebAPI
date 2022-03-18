using CreditAPI.Dtos;

namespace CreditAPI.Services
{
    public class CreditService
    {
        public  Credit GetDecision(Credit credit)
        {
            if ((credit.CreditAmount < 2000) || (credit.CreditAmount >= 70000))
            {
                credit.Decision = false;
                return  credit;
            }
            switch (credit.PreexistingCreditAmount)
            {
                case < 20000:
                    credit.Decision = true;
                    credit.InterestRate = 3;
                    return credit;

                case (>= 20000 and < 40000):
                    credit.Decision = true;
                    credit.InterestRate = 4;
                    return credit;

                case (>= 40000 and <= 60000):
                    credit.Decision = true;
                    credit.InterestRate = 5;
                    return credit;
                case > 60000:
                    credit.Decision = true;
                    credit.InterestRate = 6;
                    return credit;
            }
        }
    }
}
