using System;
using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Parent;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Stove : HeaterCooler
    {
        private Oven _oven { get; set; }
        public override int Temperature
        {
            get
            {
                return _oven.Temperature;
            }
            set
            {
                _oven.Temperature = value;
            }
        }

        public Stove(string name, int consumption, Oven oven)
            : base(name, consumption)
        {
            _oven = oven;
        }

        public void TurnOven()
        {
            _oven.Turn();
        }

        public override void TempUp()
        {
            _oven.TempUp();
        }

        public override void TempDown()
        {
            _oven.TempDown();
        }

        public override void TempSet(int temperature)
        {
            _oven.TempSet(temperature);
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
                if (_oven.State == Status.off)
                {
                    return "устройство " + type[2] + " " + State.ToName() + ", подустройство духовка " + _oven.State.ToName();
                }
                else
                {
                    return "устройство " + type[2] + " " + State.ToName() + ", духовка включена, температура " + _oven.Temperature + ", уровень освещения в духовке " + _oven.LightLevel.Light.ToName(); 
                }
            }
        }
    }
    class Oven : ITemperable
    {
        public Lamp LightLevel { get; set; }
        public Status State { get; set; }
        private int _temperature;
        public int Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                if (value > 50 && value < 250)
                {
                    _temperature = value;
                }
            }
        }

        public Oven(Lamp lightLevel, Status state = Status.off, int temperature = 0)
        {
            State = state;
            Temperature = temperature;
            LightLevel = lightLevel;
        }

        public void Turn ()
        {
            if (State == Status.off)
            {
                State = Status.on;
            }
            else
            {
                State = Status.off;
            }
        }

        public void TempUp()
        {
            Temperature++;
        }

        public void TempDown()
        {
            Temperature--;
        }

        public void TempSet(int temperature)
        {
            Temperature = temperature;
        }

        public void LightLevelUp()
        {
            LightLevel.LightUp();
        }

        public void LightLevelDown()
        {
            LightLevel.LightDown();
        }

        public void LightLevelSet (Mode level)
        {
            LightLevel.LightSet(level);
        }
    }
}
