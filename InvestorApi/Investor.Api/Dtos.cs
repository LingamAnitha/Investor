using System;
using System.ComponentModel.DataAnnotations;
using Investor.Api.Entities;

namespace Investor.Api.Dtos
{
    public record AccountDto(Guid AccountNumber, string AccountName, decimal Deposit, decimal Balance);
    public record CreateAccountDto([Required] string AccountName, decimal Deposit);
    public record InvestmentDto(Guid InvestmentId, Guid AccountNumber, Constants.Institution Institution, Constants.Currency Currency, decimal InvestmentAmount);
    public record CreateInvestmentDto(Guid AccountNumber, Constants.Institution Institution, Constants.Currency Currency, decimal InvestmentAmount);
}
