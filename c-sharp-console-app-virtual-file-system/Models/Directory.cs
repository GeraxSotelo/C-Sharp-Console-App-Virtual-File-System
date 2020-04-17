using c_sharp_console_app_virtual_file_system.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Models
{
    public class Directory : IDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; } = "New Folder";
        public int ParentId { get; set; }

        public Directory(string name)
        {
            Name = name;
        }
    }
}
