using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Prototype___PersonDetailsClone
{
    /*
     * * Lets you copy existing objects without making your code dependent on their classes.
     * * Creating new objects by cloning other objects.
     * * Allows for adding of any subclass instance of a known super class at run time.
     * * When there are numerous potential classes that you want to only use if needed at runtime.
     * * Reduce the need for subclass.
     * 
     * * Real World Analogy
     * * process of mitotic cell division.After mitotic division, a pair of identical cells is formed. 
     * * The original cell acts as a prototype and takes an active role in creating the copy.
     * 
     * APPLICABILITY:
     * Use the Prototype pattern when your code shouldn’t depend on the concrete classes of objects that you need to copy.
     * Use the pattern when you want to reduce the number of subclasses that only differ in the way they initialize their respective objects.
     * 
     */

    internal class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public IdInfo IdDetails { get; set; }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            var clone = (Person)this.MemberwiseClone();
            clone.IdDetails = new IdInfo(IdDetails.Id);
            clone.Name = this.Name;

            return clone;
        }

        internal static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdDetails.Id);
        }
    }
}
