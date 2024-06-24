using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___RobotBuilder
{
    internal interface IRobotBuilder
    {
        void BuildHead();

        void BuildTorso();

        void BuildArms();

        void BuildLegs();

        void BuildRobot();

        Robot GetRobot();
    }
}
