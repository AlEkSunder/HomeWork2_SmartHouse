using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SmartHouse.Interfaces
{
    interface ITimerable
    {
        Timer TimerInstance { set; }
        void SetTimer(int time);
    }
}
