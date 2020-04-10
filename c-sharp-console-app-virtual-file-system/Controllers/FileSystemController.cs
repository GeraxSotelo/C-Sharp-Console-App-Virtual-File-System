using c_sharp_console_app_virtual_file_system.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system
{
    class FileSystemController
    {
        private bool _running = true;
        private FileSystemService _fss = new FileSystemService();

        public void Run()
        {
            while (_running)
            {
                Print();
                GetUserInput();
            }
        }

        private void GetUserInput()
        {
            Console.WriteLine("\nType a command. Type 'help' for information. Type 'q' or 'e' to exit.\n");
            string input = Console.ReadLine().ToLower();

            switch(input)
            {
                case "q":
                case "e":
                    _running = false;
                    break;
                case "help":
                    _fss.Help();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }

        public void Print()
        {
            foreach (string msg in _fss.Messages)
            {
                Console.WriteLine(msg);
            }
            _fss.Messages.Clear();
        }
    }
}
