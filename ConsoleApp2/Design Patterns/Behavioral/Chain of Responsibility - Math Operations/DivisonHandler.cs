using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Chain_of_Responsibility___Math_Operations
{
    internal class DivisonHandler : IHandler
    {
        IHandler Next { get; set; }

        public void Execute(MathRequest request)
        {
            if (request.Operation == "DIVIDE")
            {
                Console.WriteLine("Dividing {0} / {1}  = {2} ", request.Operand1, request.Operand2, request.Operand1 / request.Operand2);
            }
            else
            {
                if (this.Next != null)
                {
                    this.Next.Execute(request);
                }
                else
                {
                    this.Next = null;
                }
            }
        }

        public void SetNext(IHandler handler)
        {
            this.Next = handler;
        }
    }
}
