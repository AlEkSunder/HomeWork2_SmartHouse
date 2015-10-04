using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouse.Childs;
using SmartHouse.Abstract;
using SmartHouse.Enums;
using SmartHouse.Interfaces;
using SmartHouse.ConsoleMenu;

namespace SmartHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            new Menu().Show();
        }
    }
}
