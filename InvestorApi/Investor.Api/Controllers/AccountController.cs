using Microsoft.AspNetCore.Mvc;
using Investor.Api.Repository;
using System.Collections.Generic;
using Investor.Api.Entities;
using System;
using Investor.Api.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace Investor.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IInMemRepository repository;

        public AccountController(IInMemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
        {
            var items = (await repository.GetAccountsAsync())
                        .Select(item => item.AsAccountDto());

            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(Guid id)
        {
            var item = await repository.GetAccountAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsAccountDto();
        }


        [HttpPost()]
        public async Task<ActionResult<AccountDto>> CreateAccountAsync(CreateAccountDto accountDto)
        {
            Account account = new()
            {
                AccountNumber = Guid.NewGuid(),
                AccountName = accountDto.AccountName,
                Deposit = accountDto.Deposit
            };

            await repository.CreateAccountAsync(account);

            return CreatedAtAction(nameof(GetAccountAsync), new { id = account.AccountNumber }, account.AsAccountDto());
        }

        [HttpGet]
        [Route("GetInvestments")]
        public async Task<IEnumerable<InvestmentDto>> GetInvestmentsAsync()
        {
            var investments = (await repository.GetInvestmentsAsync())
                        .Select(item => item.AsInvestmentDto());

            return investments;
        }

        [HttpGet]
        [Route("GetInvestment{id}")]
        public async Task<ActionResult<InvestmentDto>> GetInvestmentAsync(Guid id)
        {
            var investment = await repository.GetInvestmentAsync(id);

            if (investment is null)
            {
                return NotFound();
            }

            return investment.AsInvestmentDto();
        }


        [HttpPost()]
        [Route("Invest")]
        public async Task<ActionResult<InvestmentDto>> InvestAsync(CreateInvestmentDto investmentDto)
        {
            Investment investment = new()
            {
                InvestmentId = Guid.NewGuid(),
                AccountNumber = investmentDto.AccountNumber,
                Institution = investmentDto.Institution,
                Currency = investmentDto.Currency,
                InvestmentAmount = investmentDto.InvestmentAmount
            };

            await repository.InvestAsync(investment);

            return CreatedAtAction(nameof(GetInvestmentAsync), new { id = investment.InvestmentId }, investment.AsInvestmentDto());
        }

        [HttpGet]
        [Route("GetCurrentBalance{accountNumber}")]
        public async Task<ActionResult<Decimal>> GetCurrentBalanceAsync(Guid accountNumber)
        {
            var balance = await repository.GetCurrentBalanceAsync(accountNumber);
            return balance;
        }


        [HttpGet]
        [Route("GetCurrentInvestsentsByInstitution{institutionName}")]
        public async Task<IEnumerable<InvestmentDto>> GetCurrInvesByInstAsync(Constants.Institution institutionName)
        {
            var investments = (await repository.GetCurrInvesByInstAsync(institutionName))
                    .Select(item => item.AsInvestmentDto());

            return investments;
        }


        [HttpGet]
        [Route("GetCurrentInvestsentsByCurrency{currency}")]
        public async Task<IEnumerable<InvestmentDto>> GetCurrInvesByCurencyAsync(Constants.Currency currency)
        {
            var investments = (await repository.GetCurrInvesByCurencyAsync(currency))
                    .Select(item => item.AsInvestmentDto());

            return investments;
        }


        [HttpGet]
        [Route("GetCurrentInvestsentsByAmount{amount}")]
        public async Task<IEnumerable<InvestmentDto>> GetCurrInvesByAmtAsync(decimal amount)
        {
            var investments = (await repository.GetCurrInvesByAmtAsync(amount))
                    .Select(item => item.AsInvestmentDto());

            return investments;
        }
    }
}