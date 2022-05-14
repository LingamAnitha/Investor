using System;
using System.Collections.Generic;

namespace Investor.Api.Entities
{
    public class Account
    {
        public Guid AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Deposit { get; set; }
        public decimal Balance
        {
            get { return Deposit; }
        }
    }

}