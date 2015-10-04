using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHouse.Interfaces
{
    interface ITemperable
    {
        int Temperature { get; }
        void TempUp();
        void TempDown();
        void TempSet(int temperature);
    }
}
