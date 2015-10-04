using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Enums;

namespace SmartHouse.Interfaces
{
    interface IBlowable
    {
        Mode Blowout { get; }
        void BlowoutUp();
        void BlowoutDown();
        void BlowoutSet(Mode blowout);
    }
}
