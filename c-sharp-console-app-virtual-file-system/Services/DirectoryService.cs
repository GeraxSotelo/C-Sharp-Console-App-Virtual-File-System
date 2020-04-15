using c_sharp_console_app_virtual_file_system.Models;
using c_sharp_console_app_virtual_file_system.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_console_app_virtual_file_system.Services
{
    class DirectoryService
    {
        private readonly DirectoryRepository _repo;

        public DirectoryService()
        {
            _repo = new DirectoryRepository();
        }

        public void Mkdir(Directory data)
        {
            _repo.Mkdir(data);
        }
    }
}
