using c_sharp_console_app_virtual_file_system.Models;
using c_sharp_console_app_virtual_file_system.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            string pattern = @"^[A-Za-z0-9 _]*$";
            if (data.Name == "")
            {
                data.Name = "New File.txt";
            }
            else if(!Regex.IsMatch(data.Name, pattern))
            {
                throw new Exception("Invalid file name.");
            }
            _repo.Touch(data);
        }
    }
}
