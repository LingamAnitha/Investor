using System;

namespace Investor.Api.Entities
{
    public class Constants
    {
         public enum Currency : int
         {
              EURO = 1,
              Pound = 2,  
              USD = 3,
              Rupee = 4        
         }

         public enum Institution : int
         {
           Microsoft = 1,
           Amazon = 2,
           Google = 3,
           TCS = 4
         }
    }
}