using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Adapter___GamePlayerAndRobot
{
    /*
     * EnemyTank implements EnemyAttacker perfectly
     * Our job is to make classes with different methods
     * from EnemyAttacker to work with the EnemyAttacker interface
     */

    internal class EnemyTank : IEnemyAttacker
    {
        Random randomizer = new Random(1);

        public void AssignDriver(string driverName)
        {
            Console.WriteLine("Enemy Tank is driven by {0}", driverName);
        }

        public void DriveForward()
        {
            int random = randomizer.Next(5)+1;
            Console.WriteLine("Enemy Tank can drive {0} movement", random);
        }

        public void FireWeapon()
        {
            int random = randomizer.Next(10)+1;
            Console.WriteLine("Firing weapon can cause {0} damages", random);
        }
    }
}
