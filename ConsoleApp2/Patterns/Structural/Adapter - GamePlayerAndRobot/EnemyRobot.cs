using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Adapter___GamePlayerAndRobot
{
    /*
     * This is the Adaptee. The Adapter sends method calls
     * to objects that use the EnemyAttacker interface
     * to the right methods defined in EnemyRobot
     */

    internal class EnemyRobot
    {
        Random randomizer = new Random(1);

        public void SmashWithHands()
        {
            int random = randomizer.Next(10)+1;
            Console.WriteLine("Smashing with robot can cause {0} damages", random);
        }

        public void WalkForward()
        {
            int random = randomizer.Next(5)+1;
            Console.WriteLine("Robot can walk {0} steps forward", random);
        }

        public void ReactToHuman(string driverName)
        {
            Console.WriteLine("Enemy Robot tramps on {0}", driverName);
        }
    }
}
