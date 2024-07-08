using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Behavioral.Visitor
{
    /*
     * * LETS YOU SEPARATE ALGORITHMS FROM THE OBJECTS ON WHICH THEY OPERATE.
     * * Visitor pattern allows you to add methods to classes without much altering to those classes.
     * * Allows you to define external classes that can extend other classes without majorly editing them.
     * * Lets you separate algorithms from the objects on which they operate.
     * 
     * * Real World Analogy
     *   A good insurance agent is always ready to offer different policies to various types of organizations.
     *   If it’s a residential building, he sells medical insurance.
     *   If it’s a bank, he sells theft insurance.
     *   If it’s a coffee shop, he sells fire and flood insurance.
     * 
     * * APPLICABILITY
     * * Use the Visitor when you need to perform an operation on all elements of a complex object structure (for example, an object tree).
     * * Use the Visitor to clean up the business logic of auxiliary behaviors.
     *   The pattern lets you make the primary classes of your app more focused on their main jobs by extracting all other behaviors into a set of visitor classes.
     * * Use the pattern when a behavior makes sense only in some classes of a class hierarchy, but not in others.
     *   You can extract this behavior into a separate visitor class and implement only those visiting methods that accept objects of relevant classes, leaving the rest empty.  
     * 
     */

    public class TaxVisitor : IVisitor
    {
        public double Visit(Necessity obj)
        {
            Console.WriteLine("From Necessity tax visitor");
            return obj.GetPrice() * .18;
        }

        public double Visit(Tobacco obj)
        {
            Console.WriteLine("From Tobacco tax visitor");
            return obj.GetPrice() * .32;
        }
    }
}
