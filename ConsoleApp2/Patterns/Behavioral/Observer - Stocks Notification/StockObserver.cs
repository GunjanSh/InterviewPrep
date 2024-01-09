using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Observer___Stocks_Notification
{
    internal class StockObserver : IObserver
    {
        public static int ObserverId = 0;

        ISubject Subject { get; set; }

        public StockObserver(ISubject subject)
        {
            this.Subject = subject;
            
            ++ObserverId;

            this.Subject.Register(this);
        }

        public void update(double ibmPrice, double applePrice, double googlePrice)
        {
            Console.WriteLine("Stock prices from observer {0} is Ibm: {1}, Apple: {2}, Google: {3}", ObserverId, ibmPrice, applePrice, googlePrice);
        }
    }
}
