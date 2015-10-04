using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Enums;
namespace SmartHouse.Abstract
{
    class Device
    {
        public string Name { get; set; }
        public Status State { get; set; }
        private int _consumption;
        public int Consumption
        {
            get
            {
                return _consumption;
            }
            set
            {
                if (value > 0 && value < 10000)
                {
                    _consumption = value;
                }
            }
        }

        public Device(string name, int consumption, Status state = Status.off)
        {
            Name = name;
            Consumption = consumption;
            State = state;
        }

        public virtual void Turn()
        {
            if (State == Status.on)
            {
                State = Status.off;
            }
            else
            {
                State = Status.on;
            }
        }
    }
}
