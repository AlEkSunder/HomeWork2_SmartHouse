using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Childs;
using SmartHouse.Enums;
using SmartHouse.Interfaces;
using SmartHouse.Abstract;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SmartHouse.ConsoleMenu
{
    [Serializable]
    class Menu
    {
        private Dictionary<string, Device> listDevices;

        public void Show()
        {
            listDevices = new Dictionary<string, Device>();
            while (true)
            {
                Console.Clear();
                foreach (var dev in listDevices)
                {
                    Console.WriteLine("Название: " + dev.Key + ", " + dev.Value.ToString());
                }
                Console.WriteLine("Введите команду:");
                string[] command = Console.ReadLine().Split(' ');
                if (command[0].ToLower() == "exit")
                {
                    return;
                }
                if (command.Length < 2)
                {
                    Help();
                    continue;
                }
                if (command[0] == "add" && command.Length == 3)
                {
                    if (command[0].ToLower() == "add" && !listDevices.ContainsKey(command[2]))
                    {
                        switch (command[1].ToLower())
                        {
                            case "blender":
                                listDevices.Add(command[2], new Blender(command[2], 200));
                                break;
                            case "boiler":
                                listDevices.Add(command[2], new Boiler(command[2], 5000));
                                break;
                            case "conditioner":
                                listDevices.Add(command[2], new Conditioner(command[2], 2000));
                                break;
                            case "fan":
                                listDevices.Add(command[2], new Fan(command[2], 1000));
                                break;
                            case "fridge":
                                listDevices.Add(command[2], new Fridge(command[2], 1000, new Lamp("", 5)));
                                break;
                            case "lamp":
                                listDevices.Add(command[2], new Lamp(command[2], 10));
                                break;
                            case "microwave":
                                listDevices.Add(command[2], new MicrowaveOven(command[2], 2000));
                                break;
                            case "music":
                                listDevices.Add(command[2], new MusicCenter(command[2], 100));
                                break;
                            case "stove":
                                listDevices.Add(command[2], new Stove(command[2], 1000, new Oven(new Lamp("", 5))));
                                break;
                            case "tv":
                                listDevices.Add(command[2], new Televisor(command[2], 100, new List<string>()));
                                break;
                            default:
                                Console.WriteLine("Такого типа устройства не существует");
                                HelpDevices();
                                break;
                        }
                        continue;
                    }
                    else if (command[0].ToLower() == "add" && listDevices.ContainsKey(command[2]))
                    {
                        Console.WriteLine("Устройство с таким именем существует.");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadLine();
                        continue;
                    }
                }
                if (command.Length == 1)//проверка команды из 1 слова
                {
                    switch (command[0].ToLower())
                    {
                        case "on all":
                            foreach (var dev in listDevices)
                            {
                                dev.Value.State = Status.on;
                            }
                            break;
                        case "off all":
                            foreach (var dev in listDevices)
                            {
                                dev.Value.State = Status.off;
                            }
                            break;
                    }
                }
                else if (command.Length == 2 && listDevices.ContainsKey(command[1]))//проверка команды из 2 слов
                {
                    switch (command[0].ToLower())
                    {
                        case "on":
                            listDevices[command[1]].Turn();
                            break;
                        case "off":
                            listDevices[command[1]].Turn();
                            break;
                        case "del":
                            listDevices.Remove(command[1]);
                            break;
                        case "lightup":
                            if (listDevices[command[1]] is ILightable)
                            {
                                ((ILightable)listDevices[command[1]]).LightUp();
                            }
                            break;
                        case "lightdown":
                            if (listDevices[command[1]] is ILightable)
                            {
                                ((ILightable)listDevices[command[1]]).LightDown();
                            }
                            break;
                        case "volumeup":
                            if (listDevices[command[1]] is IVolumable)
                            {
                                ((IVolumable)listDevices[command[1]]).VolumeUp();
                            }
                            break;
                        case "volumedown":
                            if (listDevices[command[1]] is IVolumable)
                            {
                                ((IVolumable)listDevices[command[1]]).VolumeDown();
                            }
                            break;
                        case "powerup":
                            if (listDevices[command[1]] is IPowerable)
                            {
                                ((IPowerable)listDevices[command[1]]).PowerUp();
                            }
                            break;
                        case "powerdown":
                            if (listDevices[command[1]] is IPowerable)
                            {
                                ((IPowerable)listDevices[command[1]]).PowerDown();
                            }
                            break;
                        case "tempup":
                            if (listDevices[command[1]] is ITemperable)
                            {
                                ((ITemperable)listDevices[command[1]]).TempUp();
                            }
                            break;
                        case "tempdown":
                            if (listDevices[command[1]] is ITemperable)
                            {
                                ((ITemperable)listDevices[command[1]]).TempDown();
                            }
                            break;
                        case "blowoutup":
                            if (listDevices[command[1]] is IBlowable)
                            {
                                ((IBlowable)listDevices[command[1]]).BlowoutUp();
                            }
                            break;
                        case "blowoutdown":
                            if (listDevices[command[1]] is IBlowable)
                            {
                                ((IBlowable)listDevices[command[1]]).BlowoutDown();
                            }
                            break;
                        case "nextchannel":
                            if (listDevices[command[1]] is Televisor)
                            {
                                ((Televisor)listDevices[command[1]]).NextChannel();
                            }
                            break;
                        case "prevchannel":
                            if (listDevices[command[1]] is Televisor)
                            {
                                ((Televisor)listDevices[command[1]]).PrevousChannel();
                            }
                            break;
                        case "showchannels":
                            if (listDevices[command[1]] is Televisor)
                            {
                                Console.WriteLine("Список каналов:");
                                foreach (string channel in ((Televisor)listDevices[command[1]]).ReturnChannelList())
                                {
                                    Console.WriteLine(channel);
                                }
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadLine();
                            }
                            continue;
                        case "onoven":
                        case "offoven":
                            if (listDevices[command[1]] is Stove)
                            {
                                ((Stove)listDevices[command[1]]).TurnOven();
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (command.Length == 3 && listDevices.ContainsKey(command[2]))//проверка команды из 3 слов
                {
                    switch (command[0].ToLower())
                    {
                        case "newchannel":
                            if (listDevices[command[2]] is Televisor)
                            {
                                ((Televisor)listDevices[command[2]]).AddChannel(command[1]);
                            }
                            break;
                        case "delchannel":
                            if (listDevices[command[2]] is Televisor)
                            {
                                ((Televisor)listDevices[command[2]]).DelChannel(command[1]);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (command.Length == 4 && listDevices.ContainsKey(command[3]))//проверка команды из 4 слов
                {
                    int flag;
                    Int32.TryParse(command[2], out flag);
                    if (flag != 0)
                    {
                        if (command[1].ToLower() == "channel" && listDevices[command[3]] is Televisor)
                        {
                            ((Televisor)listDevices[command[3]]).SetChannel(Convert.ToInt32(command[2]));
                        }
                        if (command[1].ToLower() == "temperature" && listDevices[command[3]] is ITemperable)
                        {
                            ((ITemperable)listDevices[command[3]]).TempSet(Convert.ToInt32(command[2]));
                        }
                        if (command[1].ToLower() == "volume" && listDevices[command[3]] is IVolumable)
                        {
                            ((IVolumable)listDevices[command[3]]).VolumeSet(Convert.ToInt32(command[2]));
                        }
                    }
                    else if (command[1].ToLower() == "light" && listDevices[command[3]] is ILightable)
                    {
                        switch (command[2])
                        {
                            case "low":
                                ((ILightable)listDevices[command[3]]).LightSet(Mode.low);
                                break;
                            case "medium":
                            case "middle":
                                ((ILightable)listDevices[command[3]]).LightSet(Mode.middle);
                                break;
                            case "high":
                                ((ILightable)listDevices[command[3]]).LightSet(Mode.high);
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректный уровень освещения");
                                HelpModes();
                                break;
                        }
                    }
                    else if (command[1].ToLower() == "blowout" && listDevices[command[3]] is IBlowable)
                    {
                        switch (command[2].ToLower())
                        {
                            case "low":
                                ((IBlowable)listDevices[command[3]]).BlowoutSet(Mode.low);
                                break;
                            case "medium":
                            case "middle":
                                ((IBlowable)listDevices[command[3]]).BlowoutSet(Mode.middle);
                                break;
                            case "high":
                                ((IBlowable)listDevices[command[3]]).BlowoutSet(Mode.high);
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректный уровень обдува");
                                HelpModes();
                                break;
                        }
                    }
                    else if (command[1].ToLower() == "power" && listDevices[command[3]] is IPowerable)
                    {
                        switch (command[2].ToLower())
                        {
                            case "low":
                                ((IPowerable)listDevices[command[3]]).PowerSet(Mode.low);
                                break;
                            case "medium":
                            case "middle":
                                ((IPowerable)listDevices[command[3]]).PowerSet(Mode.middle);
                                break;
                            case "high":
                                ((IPowerable)listDevices[command[3]]).PowerSet(Mode.high);
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректный уровень обдува");
                                HelpModes();
                                break;
                        }
                    }
                    else if (command[1].ToLower() == "channel" && listDevices[command[3]] is Televisor)
                    {
                        ((Televisor)listDevices[command[3]]).SetChannel(Convert.ToInt32(command[2]));
                    }
                }
                else
                {
                    Console.WriteLine("Некорректная команда");
                }

            }
        }

        public void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tadd device name");
            Console.WriteLine("\tdel devicename");
            Console.WriteLine("\ton devicenamee");
            Console.WriteLine("\ton all");
            Console.WriteLine("\toff devicename");
            Console.WriteLine("\toff all");
            Console.WriteLine("\tlightup devicename");
            Console.WriteLine("\tlightdown devicename");
            Console.WriteLine("\tset light Level devicename");
            Console.WriteLine("\tvolumeup devicename");
            Console.WriteLine("\tvolumedown devicename");
            Console.WriteLine("\tset volume value devicename");
            Console.WriteLine("\tpowerup nadevicenameme");
            Console.WriteLine("\tpowerdown devicename");
            Console.WriteLine("\tset power Level devicename");
            Console.WriteLine("\ttempup devicename");
            Console.WriteLine("\ttempdown devicename");
            Console.WriteLine("\tset temperature value devicename");
            Console.WriteLine("\tlowoutup devicename");
            Console.WriteLine("\tblowoutdown devicename");
            Console.WriteLine("\tset blowout Level devicename");
            Console.WriteLine("\tset channel channelnumber devicename");
            Console.WriteLine("\tnextchannel devicename");
            Console.WriteLine("\tprevchannel devicename");
            Console.WriteLine("\tnewchannel name devicename");
            Console.WriteLine("\tdelchannel channelname devicename");
            Console.WriteLine("\tshowchannellist devicename");
            Console.WriteLine("\tonoven stovename");
            Console.WriteLine("\tonoven stovename");
            Console.WriteLine("\texit");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }

        public void HelpDevices()
        {
            Console.WriteLine("Доступные устройства:");
            Console.WriteLine("\tblender");
            Console.WriteLine("\tboiler");
            Console.WriteLine("\tconditioner");
            Console.WriteLine("\tfan");
            Console.WriteLine("\tfridge");
            Console.WriteLine("\tlamp");
            Console.WriteLine("\tmicrowave");
            Console.WriteLine("\tmusic");
            Console.WriteLine("\tstove");
            Console.WriteLine("\ttv");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }

        public void HelpModes()
        {
            Console.WriteLine("Доступные уровни:");
            Console.WriteLine("\tlow");
            Console.WriteLine("\tmiddle");
            Console.WriteLine("\thigh");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
