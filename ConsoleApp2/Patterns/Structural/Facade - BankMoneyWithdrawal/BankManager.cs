using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Facade___BankMoneyWithdrawal
{
    internal class BankManager
    {
        double accountBalance = 1000.00;

        public bool CheckBalance(double amount)
        {
            if (accountBalance > amount)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Current balance is {0}, cannot withdraw the amount {1}", accountBalance, amount);
                return false;
            }
        }

        public void WithdrawMoney(double amount)
        {
            accountBalance -= amount;
            Console.WriteLine("Withdrew {0} amount. Current balance is {1}", amount, accountBalance);
        }

        public void DepositMoney(double amount)
        {
            accountBalance += amount;
            Console.WriteLine("Deposited {0} amount. Current balance is {1}", amount, accountBalance);
        }

    }
}
