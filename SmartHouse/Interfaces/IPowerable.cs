using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Enums;

namespace SmartHouse.Interfaces
{
    interface IPowerable
    {
        Mode Power { get; }
        void PowerUp();
        void PowerDown();
        void PowerSet(Mode power);
    }
}
