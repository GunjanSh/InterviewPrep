using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Facade___BankMoneyWithdrawal
{
    internal class SecurityChecker
    {
        int securityCode = 1234;

        public bool IsValidCode(int securityCode)
        {
            if (this.securityCode == securityCode)
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
