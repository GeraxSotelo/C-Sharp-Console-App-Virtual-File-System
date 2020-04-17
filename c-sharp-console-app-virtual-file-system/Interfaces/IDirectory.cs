using c_sharp_console_app_virtual_file_system.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Interfaces
{
    public interface IDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
