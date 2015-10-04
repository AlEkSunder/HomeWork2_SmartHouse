using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Interfaces
{
    interface IVolumable
    {
        int Volume { get; }
        void VolumeUp();
        void VolumeDown();
        void VolumeSet(int volume);
    }
}
