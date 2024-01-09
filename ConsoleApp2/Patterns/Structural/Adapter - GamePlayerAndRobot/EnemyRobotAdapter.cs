using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Adapter___GamePlayerAndRobot
{
    /*
     * The Adapter must provide an alternative action for
     * the the methods that need to be used because
     * EnemyAttacker was implemented.
     * 
     * This adapter does this by containing an object
     * of the same type as the Adaptee (EnemyRobot)
     * All calls to EnemyAttacker methods are sent
     * instead to methods used by EnemyRobot
     * 
     */

    /*
     * * Allows 2 incompatible interfaces to work together.
     * * Used when a client expects a target interface.
     * * Adapter class allows the use of available interface and target interface.
     * 
     * * Real World Analogy
     * * Power plug adapter that has the American-style socket and the European-style plug.
     * 
     * * APPLICABILITY
     * * Use the Adapter class when you want to use some existing class, 
     *   but its interface isn’t compatible with the rest of your code.
     * * Use the pattern when you want to reuse several existing subclasses that lack some 
     *   common functionality that can’t be added to the superclass.  
     */

    internal class EnemyRobotAdapter : IEnemyAttacker
    {
        EnemyRobot robot;

        public EnemyRobotAdapter(EnemyRobot robot)
        {
            this.robot = robot;
        }

        public void AssignDriver(string driverName)
        {
            this.robot.ReactToHuman(driverName);
        }

        public void DriveForward()
        {
            this.robot.WalkForward();
        }

        public void FireWeapon()
        {
            this.robot.SmashWithHands();
        }
    }
}
