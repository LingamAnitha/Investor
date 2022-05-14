using Investor.Api.Entities;
using Investor.Api.Dtos;

namespace Investor.Api
{
    public static class Extensions
    {
        public static AccountDto AsAccountDto(this Account account)
        {
            return new AccountDto(account.AccountNumber, account.AccountName, account.Deposit, account.Balance);
        }
        public static InvestmentDto AsInvestmentDto(this Investment investment)
        {
            return new InvestmentDto(investment.InvestmentId, investment.AccountNumber, investment.Institution, investment.Currency, investment.InvestmentAmount);
        }
    }
}
