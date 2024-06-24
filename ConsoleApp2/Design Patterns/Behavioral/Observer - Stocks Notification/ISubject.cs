using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Observer___Stocks_Notification
{
    /*
     * * lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.
     * 
     * * Real World Analogy
     * * Magazine and Newspaper subscriptions.
     * 
     * * APPLICABILITY
     * * Use the Observer pattern when changes to the state of one object may require changing other objects, 
     *   and the actual set of objects is unknown beforehand or changes dynamically.
     * * Use the pattern when some objects in your app must observe others, but only for a limited time or in specific cases.
     * 
     */

    internal interface ISubject
    {
        void Register(IObserver observer);

        void Unregister(IObserver observer);

        void Notify();
    }
}
