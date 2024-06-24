using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Observer___Stocks_Notification
{
    internal interface IObserver
    {
        void update(double ibmPrice, double applePrice, double googlePrice);
    }
}
