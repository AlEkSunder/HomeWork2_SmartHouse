using System;
using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class MusicCenter : Device, IVolumable
    {
        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _volume = value;
                }
            }
        }

        public MusicCenter(string name, int consumption, int volume = 10)
            : base(name, consumption)
        {
            Volume = volume;
        }

        public void VolumeUp()
        {
            Volume++;
        }

        public void VolumeDown()
        {
            Volume--;
        }

        public void VolumeSet(int volume)
        {
            Volume = volume;
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
                return "устройство " + type[2] + " " + State.ToName() + ", громкость " + Volume;
            }
        }

    }
}
