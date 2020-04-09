using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Interfaces
{
    interface IDirectory
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
