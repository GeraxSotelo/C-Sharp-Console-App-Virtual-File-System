using c_sharp_console_app_virtual_file_system.Interfaces;using c_sharp_console_app_virtual_file_system.Models;
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
        public List<string> Messages { get; set; }
        public DirectoryService()
        {
            _repo = new DirectoryRepository();
            Messages = new List<string>();
        }

        public RootDirectory GetRootDirectory()
        {
            var found = _repo.GetRootDirectory();
            if (found == null)
            {
                RootDirectory root = new RootDirectory("root");
                int id = _repo.CreateRootDirectory(root);
                root.Id = id;
                return root;
            } 
            else
            {
                return found;
            }
        }

        public void Mkdir(Directory data)
        {
            _repo.Mkdir(data);
        }

        public void Print()
        {
            foreach (string msg in Messages)
            {
                Console.WriteLine(msg);
            }
            Messages.Clear();
        }

    }
}
