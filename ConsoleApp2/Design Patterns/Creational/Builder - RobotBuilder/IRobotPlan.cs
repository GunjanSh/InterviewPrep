using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___RobotBuilder
{
    internal interface IRobotPlan
    {
        void BuildHead(string head);
        void BuildTorso(string torso);
        void BuildArms(string arms);
        void BuildLegs(string legs);
    }
}
