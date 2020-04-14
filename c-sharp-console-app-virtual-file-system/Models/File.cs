using c_sharp_console_app_virtual_file_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    public class File : IFile
    {
        public string Name { get; set; }
        public int ParentDirectoryId { get; set; }

        public File(string name)
        {
            Name = name;
        }
    }
}
