using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Services
{
    class FileSystemService
    {
        public List<string> Messages {get; set;}

        public FileSystemService()
        {
            Messages = new List<string>();
        }

        public void Help()
        {
            Messages.Add("mkdir     Creates a directory.");
            Messages.Add("ls        Lists files in current working directory");
            Messages.Add("rm        Remove a file");
        }

    }
}
