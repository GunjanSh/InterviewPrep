using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Patterns.Structural.Bridge
{
    internal interface IDevice
    {
        bool IsEnabled();

        void Enable();

        void Disable();

        int GetVolume();

        void SetVolume(int percent);

        int GetChannel();

        void SetChannel(int channel);

        void DisplayStatus();
    }
}
