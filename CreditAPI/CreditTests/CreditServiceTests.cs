using AutoFixture;
using CreditAPI.Dtos;
using CreditAPI.Services;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CreditServiceTests
{

    public class CreditServiceTests
    {
        private readonly CreditService _creditService;

        private readonly Fixture _fixture = new Fixture();

        public CreditServiceTests()
        {
            _creditService = new CreditService();
        }

        [Fact]
        public async Task TestDecision()
        {
            List<Credit> exampleCreditFalse = new List<Credit>{
                new Credit {
                CreditAmount = 1999,
                PreexistingCreditAmount = 0
                },
                new Credit {
                CreditAmount = 70000,
                PreexistingCreditAmount = 0
                }
            };

            List<Credit> exampleCreditTrue = new List<Credit>{
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 19999,
                InterestRate = 3
                },
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 20000,
                InterestRate = 4
                },
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 39999,
                InterestRate = 4
                },
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 40000,
                InterestRate = 5
                },
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 59999,
                InterestRate = 5
                },
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 60000,
                InterestRate = 5
                },
                new Credit {
                CreditAmount = 2000,
                PreexistingCreditAmount = 69999,
                InterestRate = 6
                }
            };

            foreach (Credit credit in exampleCreditFalse)
            {
                var c =  _creditService.GetDecision(credit);
                c.Decision.Should().Be(false);
            }
            foreach (Credit credit in exampleCreditTrue)
            {
                var rate = credit.InterestRate;
                var c =  _creditService.GetDecision(credit);
                c.Decision.Should().Be(true);
                c.InterestRate.Should().Be(rate);
            }

        }

    }
}
