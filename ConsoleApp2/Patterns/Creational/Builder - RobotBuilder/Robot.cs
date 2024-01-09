using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Creational.Builder___RobotBuilder
{
    internal class Robot : IRobotPlan
    {
        public string Head { get; set; }
        public string Arms { get; set; }
        public string Legs { get; set; }
        public string Torso { get; set; }

        public void BuildArms(string arms)
        {
            this.Arms = arms;
        }

        public void BuildHead(string head)
        {
            this.Head = head;
        }

        public void BuildLegs(string legs)
        {
            this.Legs = legs;
        }

        public void BuildTorso(string torso)
        {
            this.Torso = torso;
        }
    }
}
