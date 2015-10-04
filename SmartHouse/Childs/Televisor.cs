using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using System.ComponentModel;

namespace SmartHouse.Childs
{
    class Televisor : Device, IVolumable
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
        private int _currentChannel;
        public int CurrentChannel
        {
            get
            {
                return _currentChannel;
            }

            set
            {
                if (value < _listChannels.Count && value >= 0)
                {
                    _currentChannel = value;
                }
                else _currentChannel = 0;
            }
        }
        private List<string> _listChannels;
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < _listChannels.Count)
                {
                    return _listChannels[index];
                }
                else return _listChannels[_currentChannel]; 
            }
            set
            {
                if (index >= 0 && index < _listChannels.Count)
                {
                    _listChannels[index] = value;
                }
                else throw new Exception("Не удается установить значение на несуществующий индекс листа");
            }
        }

        public Televisor(string name, int consumption, List<string> listChannel, int channel = 0, int volume = 15)
            : base(name, consumption)
        {
            _listChannels = listChannel;
            _listChannels.Add("Первый");
            CurrentChannel = channel;
            Volume = volume;
        }

        public void AddChannel (string channel)
        {
            _listChannels.Add(channel);
        }

        public void DelChannel(string channel)
        {
            _listChannels.Remove(channel);
        }

        public void NextChannel()
        {
            CurrentChannel++;
        }
        
        public void PrevousChannel()
        {
            CurrentChannel--;
        }

        public void SetChannel(int channel)
        {
            CurrentChannel = channel;
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

        public IEnumerable<string> ReturnChannelList()
        {
            return _listChannels;
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
                if (_listChannels.Count == 0)
                {
                    return "устройство " + type[2] + " " + State.ToName() + ", громкость " + Volume + ", каналов в памяти " + _listChannels.Count;
                }
                else
                {
                    return "устройство " + type[2] + " " + State.ToName() + ", громкость " + Volume + ", текущий канал " + _listChannels[CurrentChannel] + ", каналов в памяти " + _listChannels.Count;
                }
            }
        }
    }
}
