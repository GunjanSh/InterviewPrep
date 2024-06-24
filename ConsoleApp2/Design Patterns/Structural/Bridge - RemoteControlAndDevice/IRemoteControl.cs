using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Bridge
{
    internal interface IRemoteControl
    {
        public void TogglePower();

        public void VolumeUp();

        public void VolumeDown();

        public void ChannelUp();

        public void ChannelDown();
    }
}
