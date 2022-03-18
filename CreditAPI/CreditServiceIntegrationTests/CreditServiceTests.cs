using CreditAPI.Dtos;
using CreditAPI.Services;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CreditServiceIntegrationTests
{
    public class CreditServiceTests
    {

        private readonly CreditService _creditService;

        //private readonly Fixture _fixture = new Fixture();

        public CreditServiceTests()
        {
            _creditService = new CreditService();
        }
        [Fact]
        public async Task Test()
        {
            Credit exampleCredit = new Credit
            {
                CreditAmount = 1999,
                PreexistingCreditAmount = 10000
            };

            var credit =  _creditService.GetDecision(exampleCredit);
            
            credit.CreditAmount.Should().Be(1999);
            credit.PreexistingCreditAmount.Should().Be(10000);
        }
    }
}