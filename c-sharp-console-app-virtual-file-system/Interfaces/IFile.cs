using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Interfaces
{
    public interface IFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentDirectoryId { get; set; }
    }
}
