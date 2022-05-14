using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investor.Api.Entities;

namespace Investor.Api.Repository
{
    public class InMemRepository : IInMemRepository
    {
        private readonly List<Account> accounts = new()
        {
            new Account { AccountNumber = Guid.NewGuid(), AccountName = "John", Deposit = 1000},
            new Account { AccountNumber = Guid.NewGuid(), AccountName = "Collins", Deposit = 2000},
            new Account { AccountNumber = Guid.NewGuid(), AccountName = "Sheen", Deposit = 1500}
        };

        private readonly List<Investment> investments = new List<Investment>();

        public async Task CreateAccountAsync(Account account)
        {

            //List<Investment> investments = new List<Investment>();
            //foreach (Investment ins in account.Investments)
            //{
            //    Investment investment = new()
            //    {
            //        InvestmentId = Guid.NewGuid(),
            //        Institution = ins.Institution,
            //        Currency = ins.Currency,
            //        InvestmentAmount = ins.InvestmentAmount
            //    };
            //    investments.Add(investment);
            //}

            //Account newAccount = new()
            //{
            //    AccountNumber = Guid.NewGuid(),
            //    Deposit = account.Deposit,
            //    Investments = account.Investments,
            //};
            //accounts.Add(newAccount);
            accounts.Add(account);
            await Task.CompletedTask;

        }

        public async Task InvestAsync(Investment investment)
        {

            //List<Investment> investments = new List<Investment>();
            //foreach (Investment ins in account.Investments)
            //{
            //    Investment investment = new()
            //    {
            //        InvestmentId = Guid.NewGuid(),
            //        Institution = ins.Institution,
            //        Currency = ins.Currency,
            //        InvestmentAmount = ins.InvestmentAmount
            //    };
            //    investments.Add(investment);
            //}

            //Account newAccount = new()
            //{
            //    AccountNumber = Guid.NewGuid(),
            //    Deposit = account.Deposit,
            //    Investments = account.Investments,
            //};
            //accounts.Add(newAccount);
            investments.Add(investment);
            await Task.CompletedTask;

        }

        public async Task<decimal> GetCurrentBalanceAsync(Guid accountNumber)
        {
            var invests = investments.Where(item => item.AccountNumber == accountNumber).ToList();
            decimal investedAmount = 0;

            foreach (Investment ins in invests)
            {
                investedAmount = investedAmount + ins.InvestmentAmount;
            }
            Account acct = accounts.Where(item => item.AccountNumber == accountNumber).FirstOrDefault();
            return await Task.FromResult(acct.Deposit - investedAmount);
        }

        public async Task<IEnumerable<Investment>> GetCurrInvesByInstAsync(Constants.Institution institutionName)
        {
            var invests = investments.Where(x => x.Institution == institutionName).ToList();
            return await Task.FromResult(invests);
        }

        public async Task<IEnumerable<Investment>> GetCurrInvesByCurencyAsync(Constants.Currency currency)
        {
            var invests = investments.Where(x => x.Currency == currency).ToList();
            return await Task.FromResult(invests);
        }

        public async Task<IEnumerable<Investment>> GetCurrInvesByAmtAsync(decimal amount)
        {
            var invests = investments.Where(x => x.InvestmentAmount == amount).ToList();
            return await Task.FromResult(invests);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await Task.FromResult(accounts);
        }
        public async Task<Account> GetAccountAsync(Guid accountNumber)
        {
            var account = accounts.Where(item => item.AccountNumber == accountNumber).SingleOrDefault();
            return await Task.FromResult(account);
        }
        public async Task<IEnumerable<Investment>> GetInvestmentsAsync()
        {
            return await Task.FromResult(investments);
        }
        public async Task<Investment> GetInvestmentAsync(Guid investmentId)
        {
            var investment = investments.Where(item => item.InvestmentId == investmentId).SingleOrDefault();
            return await Task.FromResult(investment);
        }
    }
}