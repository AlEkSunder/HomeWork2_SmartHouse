using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Parent;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Fridge : HeaterCooler, ILightable
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
                if (value <= 5 && value >= -25)
                {
                    _temperature = value;
                }
            }
        }
        public Mode Light
        {
            get
            {
                return _lightLevel.Light;
            }
            set
            {
                _lightLevel.LightSet(value);
            }
        }

        private Lamp _lightLevel;

        public Fridge(string name, int consumption, Lamp lightLevel, int temperature = 0)
            : base(name, consumption)
        {
            Temperature = temperature;
            _lightLevel = lightLevel;
        }

        public void LightUp()
        {
            _lightLevel.LightUp();
        }

        public void LightDown()
        {
            _lightLevel.LightDown();
        }

        public void LightSet(Mode light)
        {
            _lightLevel.LightSet(light);
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
                return "устройство " + type[2] + " " + State.ToName() + ", температура " + Temperature + ", уровень освещения в холодильнике " + _lightLevel.Light.ToName();
            }
        }
    }
}
