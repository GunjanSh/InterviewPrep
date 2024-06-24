using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___RobotBuilder
{
    //Engineer is also called as DIRECTOR.
    internal class RobotEngineer
    {
        IRobotBuilder builder;

        public RobotEngineer(IRobotBuilder builder)
        {
            this.builder = builder;
        }

        public void MakeRobot()
        {
            this.builder.BuildRobot();
        }

        public void PrintRobotDetails()
        {
            Robot robot = this.builder.GetRobot();

            Console.WriteLine("HEAD for old robot", robot.Torso);
            Console.WriteLine("ARMS for old robot", robot.Arms);
            Console.WriteLine("TORSO for old robot", robot.Torso);
            Console.WriteLine("LEGS for old robot", robot.Legs);

        }

    }
}
