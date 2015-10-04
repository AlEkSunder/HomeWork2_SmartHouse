using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SmartHouse.Enums
{
    public enum Status
    {
        [Description("включено")]
        on,
        [Description("выключено")]
        off
    }
}
