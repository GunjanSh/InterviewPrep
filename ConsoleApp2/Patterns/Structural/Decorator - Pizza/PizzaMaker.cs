using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Decorator___Pizza
{
    internal class PizzaMaker
    {
        /*
         * 
         * Decorator allows you to modify an object dynamically and you would use this pattern when you want the capabilities
         * of inheritance with subclasses but you need to add functionality at run time ,you want this thing to be dynamic 
         * It is more flexible than inheritance and it's going to simplify your code because you add functionality using many many simple
         * classes rather than trying to do all this through inheritance
         * It allows you to rather than rewrite old code you are now going to use the decorator design pattern extend with brand new code and
         * keep everything the way that it was.
         * 
         * Applicability:
         * Use the Decorator pattern when you need to be able to assign extra behaviors to objects at runtime without breaking the code that uses these objects.
         * Use the pattern when it’s awkward or not possible to extend an object’s behavior using inheritance.
         * 
         * Advantages:
         * You can extend an object’s behavior without making a new subclass.
         * You can add or remove responsibilities from an object at runtime.
         *  You can combine several behaviors by wrapping an object into multiple decorators.
         *  Single Responsibility Principle. You can divide a monolithic class that implements many possible variants of behavior into several smaller classes.
         *  
         *  Drawbacks:
         *  It’s hard to remove a specific wrapper from the wrappers stack.
         *  It’s hard to implement a decorator in such a way that its behavior doesn’t depend on the order in the decorators stack.
         *  The initial configuration code of layers might look pretty ugly.
         *  
         */

        public static void PreparePizza()
        {
            IPizza pizza = new BasePizza();

            Console.WriteLine("Pizza Name : {0}, Cost :{1}", pizza.GetDescription(), pizza.GetPrice());

            pizza = new TomatoSauce(pizza);

            Console.WriteLine("Pizza after adding Tomato sauce -  Name : {0}, Cost :{1}", pizza.GetDescription(), pizza.GetPrice());

            pizza = new Mozarella(pizza);
            pizza = new Mozarella(pizza);

            Console.WriteLine("Pizza after adding Mozarella double cheese -  Name : {0}, Cost :{1}", pizza.GetDescription(), pizza.GetPrice());

        }
    }
}
