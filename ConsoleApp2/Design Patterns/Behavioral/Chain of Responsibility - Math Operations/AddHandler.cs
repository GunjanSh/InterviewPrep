using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Chain_of_Responsibility___Math_Operations
{
    internal class AddHandler : IHandler
    {
        IHandler Next {  get; set; }

        public void Execute(MathRequest request)
        {
            if (request.Operation == "ADD")
            {
                Console.WriteLine("Adding {0} + {1}  = {2} ", request.Operand1, request.Operand2, request.Operand1 + request.Operand2);
            }
            else
            {
                this.Next.Execute(request);
            }
        }

        public void SetNext(IHandler handler)
        {
            this.Next = handler;
        }
    }
}
