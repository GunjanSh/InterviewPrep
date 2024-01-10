using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Bridge
{
    /*
     * * lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction 
     * and implementation—which can be developed independently of each other.
     * 
     * * APPLICABILITY
     * * Use the Bridge pattern when you want to divide and organize a monolithic class that has several variants of some functionality
     *   (for example, if the class can work with various database servers).
     * * Use the pattern when you need to extend a class in several orthogonal (independent) dimensions.
     * * 
     */

    internal class BasicRemoteControl : IRemoteControl
    {
        protected IDevice Device;

        public BasicRemoteControl(IDevice device)
        {
            this.Device = device;
        }

        public void TogglePower()
        {
            if (this.Device.IsEnabled())
            {
                this.Device.Disable();
            }
            else
            {
                this.Device.Enable();
            }
        }

        public void VolumeUp()
        {
            this.Device.SetVolume(this.Device.GetVolume() + 10);
        }

        public void VolumeDown()
        {
            this.Device.SetVolume(this.Device.GetVolume() - 10);
        }

        public void ChannelUp()
        {
            this.Device.SetChannel(this.Device.GetChannel() + 1);
        }

        public void ChannelDown()
        {
            this.Device.SetChannel(this.Device.GetChannel() - 1);
        }
    }
}
