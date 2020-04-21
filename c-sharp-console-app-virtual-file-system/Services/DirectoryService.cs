using c_sharp_console_app_virtual_file_system.Interfaces;using c_sharp_console_app_virtual_file_system.Models;
using c_sharp_console_app_virtual_file_system.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
            string pattern = @"^[A-Za-z0-9 _]*$";
            if (data.Name == "")
            {
                data.Name = "New Folder";
            }
            else if (!Regex.IsMatch(data.Name, pattern))
            {
                throw new Exception("Invalid directory name.");
            }
            try
            {
                int id = _repo.Mkdir(data);
                data.Id = id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if(data.Id > 0)
            {
                MkdirRelationship(data);
            }
        }

        public void MkdirRelationship(Directory data)
        {
            _repo.MkdirRelationship(data);
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
