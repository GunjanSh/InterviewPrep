using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Adapter___GamePlayerAndRobot
{
    /*
     * This is the Target Interface : This is what the client
     * expects to work with. It is the adapters job to make new
     * classes compatible with this one.
     *
     */

    internal interface IEnemyAttacker
    {
        void FireWeapon();

        void DriveForward();

        void AssignDriver(string driverName);
    }
}
