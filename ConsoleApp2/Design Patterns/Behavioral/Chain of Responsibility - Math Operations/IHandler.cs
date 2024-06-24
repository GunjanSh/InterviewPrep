using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Chain_of_Responsibility___Math_Operations
{
    /*
     * * Lets you pass requests along a chain of handlers. 
     *   Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
     *   
     * * Real World Analogy
     * A call to tech support can go through multiple operators.
     * 
     * * APPLICABILITY
     * * Use the Chain of Responsibility pattern when your program is expected to process different kinds of requests in various ways, 
     *    but the exact types of requests and their sequences are unknown beforehand.
     * * Use the pattern when it’s essential to execute several handlers in a particular order.
     * * Use the CoR pattern when the set of handlers and their order are supposed to change at runtime.
     * 
     */

    internal interface IHandler
    {
        void SetNext(IHandler handler);

        void Execute(MathRequest request);
    }
}
