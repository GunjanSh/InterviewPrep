using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Bridge
{
    internal class Radio : IDevice
    {
        bool on = false;
        int volume = 30, channel = 1;

        public void Disable()
        {
            this.on = false;
        }

        public void Enable()
        {
            this.on = true;
        }

        public int GetChannel()
        {
            return this.channel;
        }

        public int GetVolume()
        {
            return this.volume;
        }

        public bool IsEnabled()
        {
            return this.on;
        }

        public void SetChannel(int channel)
        {
            if (this.channel > 200)
            {
                this.channel = 200;
            }
            else if (this.channel < 0)
            {
                this.channel = 0;
            }
            else
            {
                this.channel = channel;
            }
        }

        public void SetVolume(int percent)
        {
            if (this.volume > 100)
            {
                this.volume = 100;
            }
            else if (this.volume < 0)
            {
                this.volume = 0;
            }
            else
            {
                this.volume = percent;
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine("Im on Radio. I'm currently {0}. Currently on volume {1} and channel {2}",
                this.on ? "enabled" : "disabled", this.volume, this.channel);
        }
    }
}
