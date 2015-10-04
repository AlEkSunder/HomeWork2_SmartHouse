using System;
using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Blender : Device, IPowerable
    {
        private Mode _power;
        public Mode Power
        {
            get
            {
                return _power;
            }
        }

        public Blender(string name, int consumption, Mode power = Mode.low)
            : base(name, consumption)
        {
            _power = power;
        }

        public void PowerUp()
        {
            if (_power != Mode.high)
            {
                _power++;
            }
        }

        public void PowerDown()
        {
            if (_power != Mode.low)
            {
                _power--;
            }
        }

        public void PowerSet(Mode power)
        {
            _power = power;
        }

        public override string ToString()
        {
            string[] type = this.GetType().ToString().Split('.');
            if (State == Status.off)
            {
                return "устройство " + type[2] + " " + State.ToName();
            }
            else
            {
                return "устройство " + type[2] + " " + State.ToName() + ", уровень мощности " + Power.ToName();
            }
        }

    }
}
