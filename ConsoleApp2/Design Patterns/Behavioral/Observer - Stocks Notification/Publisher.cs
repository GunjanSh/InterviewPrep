using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Observer___Stocks_Notification
{
    internal class Publisher : ISubject
    {
        private double ibmPrice;
        private double applePrice;
        private double googlePrice;

        List<IObserver> Observers = new List<IObserver>();

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.update(ibmPrice, applePrice, googlePrice);
            }
        }

        public void Register(IObserver observer)
        {
            this.Observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            var index = Observers.IndexOf(observer);
            Console.WriteLine("Unregistering observer {0}", index+1);

            this.Observers.Remove(observer);
        }

        public void SetIbmPrice(double ibmPrice)
        {
            this.ibmPrice = ibmPrice;
            this.Notify();
        }

        public void SetApplePrice(double applePrice)
        {
            this.applePrice = applePrice;
            this.Notify();
        }

        public void SetGooglePrice(double googlePrice)
        {
            this.googlePrice = googlePrice;
            this.Notify();
        }
    }
}
