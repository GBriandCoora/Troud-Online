using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Troud_Online
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 120;

            Connection();

            Globals.display.ShowTitle();
            Thread.Sleep(3000);
            Console.Clear();

            Globals.display.Connection();
            Globals.db.AddPlayerToGame();


            Console.ReadLine();
            Globals.connected = false;
        }

        private static void Connection()
        {
            new Thread(Globals.db.Start).Start();
            while(Globals.connected != true) { }
        }
    }
}
