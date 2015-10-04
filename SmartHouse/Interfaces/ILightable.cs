using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Enums;

namespace SmartHouse.Interfaces
{
    interface ILightable
    {
        Mode Light { get; }
        void LightUp();
        void LightDown();
        void LightSet(Mode light);
    }
}
