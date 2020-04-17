using c_sharp_console_app_virtual_file_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    public class RootDirectory : IDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RootDirectory(string name)
        {
            Name = name;
        }

        public RootDirectory()
        {

        }
    }
}
