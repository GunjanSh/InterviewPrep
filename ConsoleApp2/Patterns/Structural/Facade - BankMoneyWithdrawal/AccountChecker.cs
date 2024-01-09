using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Facade___BankMoneyWithdrawal
{
    internal class AccountChecker
    {
        int accountNumber = 12345678;

        public bool IsValidAccount(int accountNumber)
        {
            if (this.accountNumber == accountNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
