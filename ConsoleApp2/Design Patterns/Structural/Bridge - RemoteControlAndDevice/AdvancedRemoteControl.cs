using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Bridge
{
    internal class AdvancedRemoteControl : BasicRemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            this.Device.SetVolume(0);
            Console.WriteLine("Remote is on MUTE");
        }
    }
}
