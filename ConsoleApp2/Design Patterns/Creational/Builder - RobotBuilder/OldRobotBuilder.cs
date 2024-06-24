using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___RobotBuilder
{
    internal class OldRobotBuilder : IRobotBuilder
    {
        Robot robot;

        public OldRobotBuilder(Robot robot)
        {
            this.robot = robot;
        }

        public void BuildArms()
        {
            Console.WriteLine("Building ARMS for old robot");
            this.robot.BuildArms("Steel arms");
        }

        public void BuildHead()
        {
            Console.WriteLine("Building HEAD for old robot");
            this.robot.BuildHead("Steel head");
        }

        public void BuildLegs()
        {
            Console.WriteLine("Building LEGS for old robot");
            this.robot.BuildLegs("Steel legs");
        }

        public void BuildRobot()
        {
            this.BuildHead();
            this.BuildArms();
            this.BuildTorso();
            this.BuildLegs();
        }

        public void BuildTorso()
        {
            Console.WriteLine("Building TORSO for old robot");
            this.robot.BuildTorso("Steel torso");
        }

        public Robot GetRobot()
        {
            return this.robot;
        }
    }
}
