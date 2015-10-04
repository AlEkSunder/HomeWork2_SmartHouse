using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Fan : Device, IBlowable
    {
        private Mode _blowout;
        public Mode Blowout
        {
            get
            {
                return _blowout;
            }
        }

        public Fan(string name, int consumption)
            : base(name, consumption)
        {

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
                return "устройство " + type[2] + " " + State.ToName() + ", уровень обдува " + Blowout.ToName();
            }
        }
    }
}
