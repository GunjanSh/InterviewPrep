using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Facade___BankMoneyWithdrawal
{
    /* 
     * Provides a simplified interface to a library, a framework, or any other complex set of classes.
     * 
     * * Real World Analogy
     *   Placing orders on phone
     *   When you call a shop to place a phone order, an operator is your facade to all services and departments of the shop. 
     *   The operator provides you with a simple voice interface to the ordering system, payment gateways, and various delivery services.
     *   
     * * APPLICABILITY
     * * Use the Facade pattern when you need to have a limited but straightforward interface to a complex subsystem.
     * * Use the Facade when you want to structure a subsystem into layers.
     * 
     */

    internal class BankFacade
    {
        AccountChecker AccountChecker { get; set; }
        SecurityChecker SecurityChecker { get; set; }
        BankManager BankManager { get; set; }

        int AccountNumber { get; set; }

        int SecurityCode { get; set; }

        public BankFacade(int accountNumber, int securityCode)
        {
            this.AccountChecker = new AccountChecker();
            this.SecurityChecker = new SecurityChecker();
            this.BankManager = new BankManager();

            this.AccountNumber = accountNumber;
            this.SecurityCode = securityCode;
        }

        public void WithdrawMoney(double amount)
        {
            if (this.AccountChecker.IsValidAccount(this.AccountNumber)
                && this.SecurityChecker.IsValidCode(this.SecurityCode)
                && this.BankManager.CheckBalance(amount))
            {
                this.BankManager.WithdrawMoney(amount);
            }
            else
            {
                Console.WriteLine("Could not withdraw the money");
            }
        }

        public void DepositMoney(double amount)
        {
            if (this.AccountChecker.IsValidAccount(this.AccountNumber)
                && this.SecurityChecker.IsValidCode(this.SecurityCode))
            {
                this.BankManager.DepositMoney(amount);
            }
            else
            { 
                Console.WriteLine("Could not deposit the money"); 
            }
        }
    }
}
