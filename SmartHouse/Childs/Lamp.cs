using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Lamp : Device, ILightable
    {
        private Mode _light;
        public Mode Light
        {
            get
            {
                return _light;
            }
        }

        public Lamp(string name, int consumption, Mode light = Mode.low)
            : base(name, consumption)
        {
            _light = light;
        }

        public void LightUp()
        {
            if (_light != Mode.high)
            {
                _light++;
            }
        }

        public void LightDown()
        {
            if (_light != Mode.low)
            {
                _light--;
            }
        }

        public void LightSet(Mode light)
        {
            _light = light;
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
                return "устройство " + type[2] + " " + State.ToName() + ", уровень освещения " + Light.ToName();
            }
        }
    }
}
