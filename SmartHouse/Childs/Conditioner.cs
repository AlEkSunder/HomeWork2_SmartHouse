using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using SmartHouse.Parent;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Conditioner : HeaterCooler, IBlowable
    {
        private int _temperature;
        public override int Temperature
        {
            get 
            {
                return _temperature;
            }
            set
            {
                if (value >= 18 && value <= 25)
                {
                    _temperature = value;
                }
            }
        }
        private Mode _blowout;
        public Mode Blowout
        {
            get
            {
                return _blowout;
            }

        }

        public Conditioner(string name, int consumption, int temperature = 23, Mode blowout = Mode.low)
            : base(name, consumption)
        {
            Temperature = temperature;
            _blowout = blowout;
        }

        public void BlowoutUp()
        {
            if (_blowout != Mode.high)
            {
                _blowout++;
            }
        }

        public void BlowoutDown()
        {
            if (_blowout != Mode.low)
            {
                _blowout--;
            }
        }

        public void BlowoutSet(Mode blowout)
        {
            _blowout = blowout;
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
                return "устройство " + type[2] + " " + State.ToName() + ", уровень обдува " + Blowout.ToName() + ", температура " + Temperature;
            }
        }
    }
}
