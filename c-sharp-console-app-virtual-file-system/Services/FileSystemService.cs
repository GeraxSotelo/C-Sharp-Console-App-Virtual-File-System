using c_sharp_console_app_virtual_file_system.Interfaces;
using c_sharp_console_app_virtual_file_system.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Services
{
    class FileSystemService
    {
        public IFileSystem fileSystem { get; set; }
        public List<string> Messages {get; set;}

        //CONSTRUCTOR
        public FileSystemService()
        {
            fileSystem = new FileSystem();
            Messages = new List<string>();
        }

        public void Help()
        {
            Messages.Add("\nmkdir     Creates a directory.");
            Messages.Add("ls        Lists files in current working directory");
            Messages.Add("rm        Remove a file");
        }

        public void Ls()
        {
            foreach (Directory d in fileSystem.CurrentDirectory.Directories)
            {
                Messages.Add($"\n{d.Name}");
            }
            foreach (var f in fileSystem.CurrentDirectory.Files)
            {
                Messages.Add(f.Name);
            }
        }

    }
}
