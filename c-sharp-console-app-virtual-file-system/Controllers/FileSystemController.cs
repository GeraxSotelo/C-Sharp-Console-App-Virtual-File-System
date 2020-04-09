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
            _fss.AddTestMessages();
            while (_running)
            {
                Console.WriteLine("Running...");
                _running = false;
                Print();
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
