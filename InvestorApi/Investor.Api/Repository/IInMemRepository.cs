using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Investor.Api.Entities;

namespace Investor.Api.Repository
{
    public interface IInMemRepository
    {
        Task<decimal> GetCurrentBalanceAsync(Guid accountNumber);
        Task<IEnumerable<Investment>> GetCurrInvesByInstAsync(Constants.Institution institutionName);
        Task<IEnumerable<Investment>> GetCurrInvesByCurencyAsync(Constants.Currency currency);
        Task<IEnumerable<Investment>> GetCurrInvesByAmtAsync(decimal amount);
        Task CreateAccountAsync(Account account);
        Task InvestAsync(Investment investment);
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(Guid accountNumber);
        Task<IEnumerable<Investment>> GetInvestmentsAsync();
        Task<Investment> GetInvestmentAsync(Guid investmentId);
    }
}
