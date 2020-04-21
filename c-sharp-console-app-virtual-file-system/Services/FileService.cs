using c_sharp_console_app_virtual_file_system.Models;
using c_sharp_console_app_virtual_file_system.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Services
{
    class FileService
    {
        private readonly FileRepository _repo;
        private List<string> Messages;
        public FileService()
        {
            _repo = new FileRepository();
            Messages = new List<string>();
        }

        internal void Touch(File data)
        {
            if(data.Name == "")
            {
                data.Name = "New File.txt";
            }
            _repo.Touch(data);
        }
    }
}
