using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Abstract;
using SmartHouse.Interfaces;

namespace SmartHouse.Parent
{
    class HeaterCooler: Device, ITemperable
    {
        private int _temperature;
        public virtual int Temperature
        {
            get 
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
            }
        }

        public HeaterCooler(string name, int consumption)
            : base(name, consumption)
        {
        }

        public virtual void TempUp()
        {
            Temperature++;
        }

        public virtual void TempDown()
        {
            Temperature--;
        }

        public virtual void TempSet(int temperature)
        {
            Temperature = temperature;
        }
    }
}
