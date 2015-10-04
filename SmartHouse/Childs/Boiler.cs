using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Parent;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Boiler : HeaterCooler
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
                if (value > 25 && value < 60)
                {
                    _temperature = value;
                }
            }
        }

        public Boiler(string name, int consumption, int temperature = 25)
            : base(name, consumption)
        {
            Temperature = temperature;
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
                return "устройство " + type[2] + " " + State.ToName() + ", температура " + Temperature;
            }
        }

    }
}
