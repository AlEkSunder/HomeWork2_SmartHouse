using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SmartHouse.Enums
{
    public enum Mode
    {
        [Description("низкий")]
        low,
        [Description("средний")]
        middle,
        [Description("высокий")]
        high
    }
}
