using System;
using System.Collections.Generic;

namespace Investor.Api.Entities
{
    public class Investment
    {
        public Guid InvestmentId { get; set; }

        public Guid AccountNumber { get; set; }

        public Constants.Institution Institution { get; set; }

        public Constants.Currency Currency { get; set; }

        public decimal InvestmentAmount { get; set; }
    }
}