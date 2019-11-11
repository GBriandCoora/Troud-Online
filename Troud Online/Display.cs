using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Troud_Online
{
    public class Display
    {
        public void ShowTitle()
        {
            string[] titleTroud = new string[] {".----------------.  .----------------.  .----------------.  .----------------.  .----------------.",
                                                "| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |",
                                                "| |  _________   | || |  _______     | || |     ____     | || | _____  _____ | || |  ________    | |",
                                                "| | |  _   _  |  | || | |_   __ \\    | || |   .'    `.   | || ||_   _||_   _|| || | |_   ___ `.  | |",
                                                "| | |_/ | | \\_|  | || |   | |__) |   | || |  /  .--.  \\  | || |  | |    | |  | || |   | |   `. \\ | |",
                                                "| |     | |      | || |   |  __ /    | || |  | |    | |  | || |  | '    ' |  | || |   | |    | | | |",
                                                "| |    _| |_     | || |  _| |  \\ \\_  | || |  \\  `--'  /  | || |   \\ `--' /   | || |  _| |___.' / | |",
                                                "| |   |_____|    | || | |____| |___| | || |   `.____.'   | || |    `.__.'    | || | |________.'  | |",
                                                "| |              | || |              | || |              | || |              | || |              | |",
                                                "| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |",
                                                "'----------------'  '----------------'  '----------------'  '----------------'  '----------------'"};

            string[] titleOnline = new string[] {   ".------..------..------..------..------..------.",
                                                    "|O.--. ||N.--. ||L.--. ||I.--. ||N.--. ||E.--. |",
                                                    "| :/\\: || :(): || :/\\: || (\\/) || :(): || (\\/) |",
                                                    "| :\\/: || ()() || (__) || :\\/: || ()() || :\\/: |",
                                                    "| '--'O|| '--'N|| '--'L|| '--'I|| '--'N|| '--'E|",
                                                    "`------'`------'`------'`------'`------'`------'" };

            for (int i = 3; i < 14; ++i)
            {
                Console.SetCursorPosition(10, i);
                Console.Write(titleTroud[i - 3]);
            }
            for (int i = 16; i < 22; ++i)
            {
                Console.SetCursorPosition(36, i);
                Console.Write(titleOnline[i - 16]);
            }
        }

        public void Connection()
        {
            bool connected = false;
            while (!connected)
            {
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("Entrez votre nom");
                Console.SetCursorPosition(0, 29);
                string name = Console.ReadLine();
                ClearCmd();
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("Entrez votre mot de passe");
                Console.SetCursorPosition(0, 29);
                string password = Console.ReadLine();
                ClearCmd();
                connected = Globals.db.CheckPlayer(name, password);
                if (!connected)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 27);
                    Console.Write("Vos identifiants sont inexacts");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public void ClearChat()
        {
            for (int i = 0; i < 30; ++i)
            {
                Console.SetCursorPosition(90, i);
                for (int j = 0; j < 30; ++j)
                {
                    Console.Write(" ");
                }
            }
        }

        public void ClearCmd()
        {
            for(int i = 27; i < 30; ++i)
            {
                Console.SetCursorPosition(0, i);
                for(int j = 0; j < 90; ++j)
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
